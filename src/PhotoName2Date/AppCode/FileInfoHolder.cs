using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using ExifLib;

namespace PhotoName2Date.MiddleLayer
{
	public delegate void FileProcessedDelegate(FileInfoHolder fih, int current, int total);

	public class FileInfoHolder
	{
		public FileInfoHolder(string fullFilename, DataRow dr)
		{
			_dr = dr;
			this.NeedRename = true;

			this.FullFilename = fullFilename;
		}

		private int _index = 0;

		public void ResolveIndex()
		{
			while (File.Exists(this.NewFullFilename))
			{
				this._index++;
			}
		}

		private DataRow _dr;

		public DataRow Dr
		{
			get { return _dr; }
			set { _dr = value; }
		}

		//public void UpdateDataRow() {
		//  //_dr[DbColumns.fullFilename] = _fullFilename;
		//  //_dr[DbColumns.filepath] = _filePath;
		//  //_dr[DbColumns.filenameOnly] = _filenameOnly;
		//  //_dr[DbColumns.ext] = _ext;
		//  //_dr[DbColumns.newFilenameOnly] = _newFilenameOnly;
		//  //_dr[DbColumns.needRename] = _needRename;
		//}

		//public void UpdateFromDataRow() {
		//  //_fullFilename = _dr[DbColumns.fullFilename];
		//  //_filePath = _dr[DbColumns.filepath];
		//  //_filenameOnly = _dr[DbColumns.filenameOnly];
		//  //_ext_dr[DbColumns.ext];
		//  //_newFilenameOnly = _dr[DbColumns.newFilenameOnly];
		//  _needRename = Convert.ToBoolean(_dr[DbColumns.needRename]);
		//}

		private string _fullFilename;

		public string FullFilename
		{
			get { return _fullFilename; }
			set
			{
				_fullFilename = value;
				this.FilePath = Path.GetDirectoryName(_fullFilename);
				this.FilenameOnly = Path.GetFileNameWithoutExtension(_fullFilename);
				this.Ext = Path.GetExtension(_fullFilename);
				this.DetectedDateTime = FileInfoHolder.GetDateTime(_fullFilename);

				DateTime shifted = Utils.ShiftDateTime(_detectedDateTime,
				                                       (int) global::PhotoName2Date.Properties.Settings.Default.ShiftTimeByHours);

				this.NewFilenameOnly = shifted.ToString(global::PhotoName2Date.Properties.Settings.Default.RenamePattern);
				_index = 0;
				//this.UpdateDataRow();
			}
		}

		//private string _filePath;
		public string FilePath
		{
			get { return _dr[DbColumns.filepath].ToString(); }
			set { _dr[DbColumns.filepath] = value; }
		}

		//private string _filenameOnly;
		public string FilenameOnly
		{
			get { return _dr[DbColumns.filenameOnly].ToString(); }
			set { _dr[DbColumns.filenameOnly] = value; }
		}

		//private string _ext;
		public string Ext
		{
			get { return _dr[DbColumns.ext].ToString(); }
			set { _dr[DbColumns.ext] = value; }
		}

		private string _suffix
		{
			get { return this._index > 0 ? (MyFile.SUFFIX_SEPARATOR + this._index.ToString(MyFile.SUFFIX_FORMAT)) : string.Empty; }
		}

		private DateTime _detectedDateTime;

		public DateTime DetectedDateTime
		{
			get { return _detectedDateTime; }
			set { _detectedDateTime = value; }
		}

		//private string _newFilenameOnly;
		public string NewFilenameOnly
		{
			get { return _dr[DbColumns.newFilenameOnly].ToString(); }
			set
			{
				_dr[DbColumns.newFilenameOnly] = value;
				if (this.FilenameOnly.StartsWith(value))
				{
					this.NeedRename = false;
				}
			}
		}

		public string NewFullFilename
		{
			get { return this.FilePath + Path.DirectorySeparatorChar + this.NewFilenameOnly + this._suffix + this.Ext; }
		}

		//private bool _needRename = true;
		public bool NeedRename
		{
			get { return Convert.ToBoolean(_dr[DbColumns.needRename]); }
			set { _dr[DbColumns.needRename] = value; }
		}

		public string Status
		{
			get { return _dr[DbColumns.status].ToString(); }
			set { _dr[DbColumns.status] = value; }
		}


		/// <summary>
		/// renames the file
		/// </summary>
		/// <returns>info to write into log</returns>
		public void Rename(bool touch)
		{
			if (!this.NeedRename)
			{
				return;
			}

			if (touch)
			{
				this.Touch();
			}

			this.ResolveIndex();
			File.Move(this.FullFilename, this.NewFullFilename);
			this.NewFilenameOnly = this.NewFilenameOnly + this._suffix;
			this.Status = "done";
		}

		public void Touch()
		{
			File.SetLastWriteTime(this.FullFilename,
			                      Utils.ShiftDateTime(_detectedDateTime,
			                                          (int) global::PhotoName2Date.Properties.Settings.Default.ShiftTimeByHours));
		}

		#region static

		private static readonly Dictionary<string, DateTime> _filePathCached = new Dictionary<string, DateTime>();

		private static DateTime GetDateTime(string fileName)
		{
			if (_filePathCached.ContainsKey(fileName))
			{
				return _filePathCached[fileName];
			}

			DateTime newDateTime = GetExifDateTime(fileName);
			if (newDateTime == DateTime.MinValue)
			{
				//FireInfo("  getting filesystem info:");
				newDateTime = GetFileSystemDateTime(fileName);
			}
			_filePathCached[fileName] = newDateTime;
			return newDateTime;
		}

		private static DateTime GetExifDateTime(string fileName)
		{
			var fileExifDatetime = DateTime.MinValue;

			var messages = new List<string>
			               	{
			               		"Could not find Exif data block",
			               		"File is not a valid JPEG"
			               	};

			// Instantiate the reader
			ExifReader reader = null;
			try
			{
				using (reader = new ExifReader(fileName))
				{
					var tags = new[] {ExifTags.DateTimeOriginal, ExifTags.DateTime, ExifTags.DateTimeDigitized};
					foreach (var tag in tags)
					{
						try
						{
							if (reader.GetTagValue(tag, out fileExifDatetime) && fileExifDatetime > DateTime.MinValue)
								break;
						}
						catch (FormatException)
						{
						}
					}
				}
			}
			catch (Exception ex)
			{
				if (!messages.Contains(ex.Message))
					throw;
			}
			return fileExifDatetime;

			//var result = reader.GetTagValue<DateTime>(ExifTags.DateTimeDigitized, out fileExifDatetime);
			//if(!result)
			//{
			//    return fileExifDatetime;
			//} else if( reader.GetTagValue<DateTime>( ExifTags.DateTimeOriginal,
			//                                    out fileExifDatetime ) )
			//{
			//    return fileExifDatetime;
			//}
			//return fileExifDatetime;


			//Image image;
			//PropertyItem[] propItems;
			//try {
			//    image = new Bitmap(fileName);
			//} catch (ArgumentException) {
			//    return fileExifDatetime;
			//}

			//propItems = new PropertyItem[IDS_ALLOWED.Length];

			//for (int i = 0; i < propItems.Length; i++) {
			//    try {
			//        propItems[i] = image.GetPropertyItem(IDS_ALLOWED[i]);
			//    } catch {
			//        propItems[i] = null;
			//    }
			//}

			//image.Dispose();


			//foreach (PropertyItem propItem in propItems) {
			//    if (propItem == null)
			//        continue;

			//    string propVal = Utils.ByteArrToStr(propItem.Value);
			//    //FireInfo("  (" + propItem.Id + ") " + propVal);
			//    if (propVal.Length < 1)
			//        continue;

			//    if (propVal.Length >= 19) {
			//        //2006:07:24 09:16:18
			//        DateTime dt;
			//        try {
			//            dt = new DateTime(
			//                Convert.ToInt32(propVal.Substring(0, 4)),
			//                Convert.ToInt32(propVal.Substring(5, 2)),
			//                Convert.ToInt32(propVal.Substring(8, 2)),
			//                Convert.ToInt32(propVal.Substring(11, 2)),
			//                Convert.ToInt32(propVal.Substring(14, 2)),
			//                Convert.ToInt32(propVal.Substring(17, 2))
			//                );
			//            fileExifDatetime = dt;
			//            break;
			//        } catch (ArgumentOutOfRangeException) {
			//            continue;
			//        }
			//    }
			//}

			//return fileExifDatetime;
		}

		private static DateTime GetFileSystemDateTime(string fileName)
		{
			//FileInfo fi = new FileInfo(fileName);
			//return fi.CreationTime > fi.LastWriteTime ? fi.CreationTime : fi.LastWriteTime;

			return File.GetLastWriteTime(fileName);
		}

		//private static readonly int[] IDS_ALLOWED = new[] {36867, 306, 36868};

		#endregion static
	}
}
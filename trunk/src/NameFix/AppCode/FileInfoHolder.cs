using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using ExifLib;

namespace NameFix.AppCode
{
	public delegate void FileProcessedDelegate(FileInfoHolder fih, int current, int total);

	public class FileInfoHolder
	{
		private DateTime _detectedDateTime;
		private DataRow _dr;
		private string _fullFilename;
		private int _index;

		public FileInfoHolder(string fullFilename, DataRow dr)
		{
			_dr = dr;
			NeedRename = true;

			FullFilename = fullFilename;
		}

		public void ResolveIndex()
		{
			while(File.Exists(NewFullFilename))
			{
				_index++;
			}
		}

		/// <summary>
		/// renames the file
		/// </summary>
		/// <returns>info to write into log</returns>
		public void Rename(bool touch)
		{
			if(!NeedRename)
			{
				return;
			}

			if(touch)
			{
				Touch();
			}

			ResolveIndex();
			File.Move(FullFilename, NewFullFilename);
			NewFilenameOnly = NewFilenameOnly + _suffix;
			Status = "done";
		}

		public void Touch()
		{
			File.SetLastWriteTime(FullFilename,
				Utils.ShiftDateTime(_detectedDateTime,
					(int)NameFix.Properties.Settings.Default.ShiftTimeByHours));
		}

		#region static

		private static readonly Dictionary<string, DateTime> _filePathCached = new Dictionary<string, DateTime>();

		private static DateTime GetDateTime(string fileName)
		{
			if(_filePathCached.ContainsKey(fileName))
			{
				return _filePathCached[fileName];
			}

			DateTime newDateTime = GetExifDateTime(fileName);
			if(newDateTime == DateTime.MinValue)
			{
				//FireInfo("  getting filesystem info:");
				newDateTime = GetFileSystemDateTime(fileName);
			}
			_filePathCached[fileName] = newDateTime;
			return newDateTime;
		}

		private static DateTime GetExifDateTime(string fileName)
		{
			DateTime fileExifDatetime = DateTime.MinValue;

			var messages = new List<string>
			{
				"Could not find Exif data block",
				"File is not a valid JPEG",
				"Unable to locate Exif data",
			};

			// Instantiate the reader
			ExifReader reader = null;
			try
			{
				using(reader = new ExifReader(fileName))
				{
					var tags = new[] {ExifTags.DateTimeOriginal, ExifTags.DateTime, ExifTags.DateTimeDigitized};
					foreach(ExifTags tag in tags)
					{
						try
						{
							if(reader.GetTagValue(tag, out fileExifDatetime) && fileExifDatetime > DateTime.MinValue)
								break;
						}
						catch(FormatException) {}
					}
				}
			}
			catch(Exception ex)
			{
				if(!messages.Contains(ex.Message))
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

		public DataRow Dr
		{
			get {return _dr;}
			set {_dr = value;}
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

		public string FullFilename
		{
			get {return _fullFilename;}
			set
			{
				_fullFilename = value;
				FilePath = Path.GetDirectoryName(_fullFilename);
				FilenameOnly = Path.GetFileNameWithoutExtension(_fullFilename);
				Ext = Path.GetExtension(_fullFilename).ToLower();
				DetectedDateTime = GetDateTime(_fullFilename);

				DateTime shifted = Utils.ShiftDateTime(_detectedDateTime,
					(int)NameFix.Properties.Settings.Default.ShiftTimeByHours);

				NewFilenameOnly = shifted.ToString(NameFix.Properties.Settings.Default.RenamePattern);
				_index = 0;
				//this.UpdateDataRow();
			}
		}

		//private string _filePath;
		public string FilePath
		{
			get {return _dr[DbColumns.filepath].ToString();}
			set {_dr[DbColumns.filepath] = value;}
		}

		//private string _filenameOnly;
		public string FilenameOnly
		{
			get {return _dr[DbColumns.filenameOnly].ToString();}
			set {_dr[DbColumns.filenameOnly] = value;}
		}

		//private string _ext;
		public string Ext
		{
			get {return _dr[DbColumns.ext].ToString();}
			set {_dr[DbColumns.ext] = value;}
		}

		private string _suffix
		{
			get {return _index > 0 ? (MyFile.SUFFIX_SEPARATOR + _index.ToString(MyFile.SUFFIX_FORMAT)) : string.Empty;}
		}

		public DateTime DetectedDateTime
		{
			get {return _detectedDateTime;}
			set {_detectedDateTime = value;}
		}

		//private string _newFilenameOnly;
		public string NewFilenameOnly
		{
			get {return _dr[DbColumns.newFilenameOnly].ToString();}
			set
			{
				_dr[DbColumns.newFilenameOnly] = value;
				if(FilenameOnly.StartsWith(value))
				{
					NeedRename = false;
				}
			}
		}

		public string NewFullFilename
		{
			get {return FilePath + Path.DirectorySeparatorChar + NewFilenameOnly + _suffix + Ext;}
		}

		//private bool _needRename = true;
		public bool NeedRename
		{
			get {return Convert.ToBoolean(_dr[DbColumns.needRename]);}
			set {_dr[DbColumns.needRename] = value;}
		}

		public string Status
		{
			get {return _dr[DbColumns.status].ToString();}
			set {_dr[DbColumns.status] = value;}
		}
	}
}
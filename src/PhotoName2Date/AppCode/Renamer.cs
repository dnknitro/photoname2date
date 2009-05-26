using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.ComponentModel;

namespace PhotoName2Date.MiddleLayer {
	public delegate void InfoDelegate(string info);

	public class Renamer {
		public event InfoDelegate InfoEvent;

		private RenamerConfig _renamerConfig = null;
		private BackgroundWorker _worker = null;

		private int[] IDS_ALLOWED = new int[] { 36867, 306, 36868 };

		public Renamer(RenamerConfig renamerConfig) {
			_renamerConfig = renamerConfig;
		}

		public void ProcessDirectory(BackgroundWorker worker, DoWorkEventArgs e) {
			this._worker = worker;
			ProcessDirectory(this._renamerConfig.Path);
		}

		public void ProcessDirectory(string path) {
			FireInfo("Started at " + DateTime.Now.ToString());
			if (_renamerConfig.RecurseSubdirs) {
				string[] subdirectoryEntries = Directory.GetDirectories(path);
				foreach (string subdirectory in subdirectoryEntries) {
					ProcessDirectory(subdirectory);
				}
			}

			//process files with exif info
			List<string> filesList = new List<string>();
			string[] extentions = _renamerConfig.Extentions.Split(';');
			foreach (string ext in extentions) {
				string[] files = Directory.GetFiles(path, ext);
				filesList.AddRange(files);
			}

			foreach (string fileName in filesList) {
				if (this._worker != null && this._worker.CancellationPending) {
					FireInfo("Cancel at " + DateTime.Now.ToString());
					return;
				}
				FireInfo("");
				FireInfo(fileName);
				try {
					ProcessFile(fileName);
				} catch (Exception e) {
					FireInfo("EXCEPTION: " + e.ToString());
				}
			}

			FireInfo("Finished at " + DateTime.Now.ToString());
		}

		/// <summary>
		/// prcess file by filename
		/// </summary>
		/// <param name="filename">string PathOnly to file to process</param>
		private void ProcessFile(string fileName) {
			FireInfo("  getting exif info:");
			DateTime newDateTime = GetExifDateTime(fileName);
			if (newDateTime == DateTime.MinValue) {
				FireInfo("  getting filesystem info:");
				newDateTime = GetFileSystemDateTime(fileName);
			}

			//shift newDateTime
			newDateTime = Utils.ShiftDateTime(newDateTime, _renamerConfig.ShiftTimeByHours);

			RenameInfo ri = new RenameInfo(fileName);
			ri.Timestamp = newDateTime;

			//rename!
			FireInfo(ri.Rename());
			if (_renamerConfig.Touch) {
				Renamer.Touch(ri);
			}
		}

		private DateTime GetExifDateTime(string fileName) {
			DateTime fileExifDatetime = DateTime.MinValue;

			Image image;
			PropertyItem[] propItems;
			try {
				image = new Bitmap(fileName);
			} catch (ArgumentException) {
				return fileExifDatetime;
			}

			propItems = new PropertyItem[IDS_ALLOWED.Length];

			for (int i = 0; i < propItems.Length; i++) {
				try {
					propItems[i] = image.GetPropertyItem(IDS_ALLOWED[i]);
				} catch {
					propItems[i] = null;
				}
			}

			image.Dispose();


			foreach (PropertyItem propItem in propItems) {
				if (propItem == null)
					continue;

				string propVal = Utils.ByteArrToStr(propItem.Value);
				FireInfo("  (" + propItem.Id + ") " + propVal);
				if (propVal.Length < 1)
					continue;

				if (propVal.Length >= 19) {
					//2006:07:24 09:16:18
					DateTime dt;
					try {
						dt = new DateTime(
							Convert.ToInt32(propVal.Substring(0, 4)),
							Convert.ToInt32(propVal.Substring(5, 2)),
							Convert.ToInt32(propVal.Substring(8, 2)),
							Convert.ToInt32(propVal.Substring(11, 2)),
							Convert.ToInt32(propVal.Substring(14, 2)),
							Convert.ToInt32(propVal.Substring(17, 2))
							);
						fileExifDatetime = dt;
						break;
					} catch (ArgumentOutOfRangeException) {
						continue;
					}
				}
			}

			return fileExifDatetime;
		}

		private DateTime GetFileSystemDateTime(string fileName) {
			//FileInfo fi = new FileInfo(fileName);
			//return fi.CreationTime > fi.LastWriteTime ? fi.CreationTime : fi.LastWriteTime;

			return File.GetLastWriteTime(fileName);
		}

		public static void Touch(RenameInfo ri) {
			File.SetLastWriteTime(ri.ResultingName, ri.Timestamp);
		}

		private void FireInfo(string info) {
			if (this.InfoEvent != null) {
				this.InfoEvent(info);
			}
			if (this._worker != null) {
				this._worker.ReportProgress(0, info);
			}
		}
	}
}

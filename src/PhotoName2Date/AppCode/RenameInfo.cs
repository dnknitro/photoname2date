using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace PhotoName2Date.MiddleLayer {
	public class RenameInfo {
		public MyFile OriginalFilename = null;
		public MyFile ResultingName = null;

		private DateTime _timestamp = DateTime.MinValue;
		public DateTime Timestamp {
			get { return _timestamp; }
			set { 
				_timestamp = value;
				ResultingName = OriginalFilename.ToString();
				ResultingName.baseName = _timestamp.ToString("yyyy-MM-dd HH-mm-ss");
			}
		}

		public bool isSkipped {
			get { return OriginalFilename.ToString() == ResultingName.ToString(); }
		}

		public RenameInfo(string filename) {
			OriginalFilename = filename;
		}

		/// <summary>
		/// renames the file
		/// </summary>
		/// <returns>info to write into log</returns>
		public string Rename() {
			if (this.isSkipped) {
				return "  [skipped] " + OriginalFilename;
			}
			ResultingName.CheckIndex();
			File.Move(OriginalFilename.ToString(), ResultingName.ToString());
			return "  [renamed] " + OriginalFilename + "  =>  " + ResultingName;
		}
	}
}

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace PhotoName2Date.MiddleLayer {
	public class Log {
		private static StreamWriter _log = File.AppendText(Application.ProductName + ".log");

		~Log() {
			_log.Close();
		}

		public static void Append(string str) {
			_log.WriteLine(str);
		}
	}
}

using System;
using System.IO;
using System.Windows.Forms;

namespace NameFix.AppCode
{
	public class Log
	{
		private static readonly string _logFile = Application.ProductName + ".log";

		public static void Append(string str)
		{
			str = string.Format("[{0}] {1}", DateTime.Now.ToString("s"), str);
			File.AppendAllLines(_logFile, new[] {str});
			Console.WriteLine(str);
		}
	}
}
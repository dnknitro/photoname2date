using System;
using System.Collections.Generic;
using System.Windows.Forms;
using NameFix.AppCode;
using NameFix.Properties;

namespace NameFix
{
	internal static class NameFixProgram
	{
		public static FilesList FilesList;
		public static RenamerConfig RenamerConfig;

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		private static void Main(string[] args)
		{
			RenamerConfig = new RenamerConfig();
			FilesList = new FilesList();

			var folder = Environment.CurrentDirectory;
			var argsDic = new Dictionary<string, string>();

			var key = string.Empty;
			for(var i = 0; i < args.Length; i++)
			{
				var arg = args[i];
				if(!string.IsNullOrEmpty(key))
				{
					argsDic[key] = arg;
					key = string.Empty;
				}
				else if(arg[0] == '-')
				{
					key = arg.ToUpper();
					argsDic[key] = null;
				}
				else
				{
					folder = arg;
				}
			}

			foreach(var pair in argsDic)
			{
				if(pair.Key == "-E")
					Settings.Default.Extensions = pair.Value;
				if(pair.Key == "-P")
					Settings.Default.Extensions = pair.Value;
				if(pair.Key == "-T")
					Settings.Default.Touch = string.IsNullOrEmpty(pair.Value) || bool.Parse(pair.Value);
				if(pair.Key == "-R")
					Settings.Default.RecurseSubdirs = string.IsNullOrEmpty(pair.Value) || bool.Parse(pair.Value);
			}

			if(argsDic.ContainsKey("-UI"))
			{
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				Application.Run(new MainForm());
			}
			else
			{
				FilesList.Message += LogMessage;
				FilesList.PreviewFinished += FilesListOnPreviewFinished;
				FilesList.DoPreview(null, folder);
			}
		}

		private static void FilesListOnPreviewFinished(object sender, string message)
		{
			FilesList.DoRename(null);
		}

		private static void LogMessage(object sender, string message)
		{
			Log.Append(message);
		}
	}
}
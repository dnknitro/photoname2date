using System;
using System.IO;

namespace NameFix.AppCode
{
	public class MyFile
	{
		public const string SUFFIX_FORMAT = "000";
		public const string SUFFIX_SEPARATOR = "  ";
		private string _baseName;
		private string _ext;
		private int _index;

		public MyFile(string file)
		{
			PathOnly = Path.GetDirectoryName(file);
			baseName = Path.GetFileNameWithoutExtension(file);
			ext = Path.GetExtension(file);
		}

		public void CheckIndex()
		{
			while(File.Exists(ToString()))
			{
				_index++;
			}
		}

		public static implicit operator string(MyFile myFile)
		{
			return myFile.ToString();
		}

		public static implicit operator MyFile(string filename)
		{
			return new MyFile(filename);
		}

		public override string ToString()
		{
			return PathOnly + Path.DirectorySeparatorChar + baseName + suffix + ext;
		}

		public string suffix
		{
			get {return _index > 0 ? (SUFFIX_SEPARATOR + _index.ToString(SUFFIX_FORMAT)) : string.Empty;}
		}

		public string PathOnly {get; set;}

		public string baseName
		{
			get {return _baseName;}
			set
			{
				string[] parts = value.Split(new[] {SUFFIX_SEPARATOR}, StringSplitOptions.None);
				_baseName = parts[0];
				if(parts.Length > 1)
				{
					try
					{
						_index = Convert.ToInt32(parts[1]);
					}
					catch(FormatException)
					{
						_index = 0;
					}
				}
			}
		}

		public string ext
		{
			get {return _ext;}
			set {_ext = value.ToLower();}
		}
	}
}
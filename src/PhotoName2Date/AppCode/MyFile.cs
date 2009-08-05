using System;
using System.IO;

namespace PhotoName2Date.MiddleLayer
{
	public class MyFile
	{
		public const string SUFFIX_SEPARATOR = "  ";
		public const string SUFFIX_FORMAT = "000";
		private string _pathOnly;
		private string _baseName;
		private string _ext;
		private int _index = 0;

		public string suffix
		{
			get { return _index > 0 ? (SUFFIX_SEPARATOR + _index.ToString(SUFFIX_FORMAT)) : string.Empty; }
		}

		public string PathOnly
		{
			get { return _pathOnly; }
			set { _pathOnly = value; }
		}

		public string baseName
		{
			get { return _baseName; }
			set
			{
				string[] parts = value.Split(new string[] {SUFFIX_SEPARATOR}, StringSplitOptions.None);
				_baseName = parts[0];
				if (parts.Length > 1)
				{
					try
					{
						_index = Convert.ToInt32(parts[1]);
					}
					catch (FormatException)
					{
						_index = 0;
					}
				}
			}
		}

		public string ext
		{
			get { return _ext; }
			set { _ext = value.ToLower(); }
		}

		public MyFile(string file)
		{
			PathOnly = Path.GetDirectoryName(file);
			baseName = Path.GetFileNameWithoutExtension(file);
			ext = Path.GetExtension(file);
		}

		public void CheckIndex()
		{
			while (File.Exists(this.ToString()))
			{
				this._index++;
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
	}
}
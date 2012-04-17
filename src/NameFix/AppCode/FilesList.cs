using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using NameFix.Properties;

namespace NameFix.AppCode
{
	public class DbColumns
	{
		public const string ext = "ext";
		public const string filenameOnly = "filenameOnly";
		public const string filepath = "filepath";
		public const string id = "id";
		//public const string shiftedDateTime = "shiftedDateTime";
		public const string needRename = "needRename";
		public const string newFilenameOnly = "newFilenameOnly";
		public const string status = "status";
	}

	public delegate void SenderMessageDelegate(object sender, string message);

	public class FilesList
	{
		private readonly Dictionary<DataRow, FileInfoHolder> _drToHolder = new Dictionary<DataRow, FileInfoHolder>();

		//private DataGridView _dataGridView;
		private static readonly object _padLock = new object();
		private MainForm _form;
		private BackgroundWorker _currentWorker;

		public DataView DatFile {get; set;}

		public event SenderMessageDelegate Message;
		public event SenderMessageDelegate PreviewStarted;
		public event SenderMessageDelegate FileProcessedPreview;
		public event SenderMessageDelegate PreviewFinished;
		public event SenderMessageDelegate RenameStarted;
		public event SenderMessageDelegate FileRenamed;
		public event SenderMessageDelegate RenameFinished;

		public FilesList()
		{
			DatFile = DatFactory();
		}

		public void SetForm(MainForm form)
		{
			_form = form;
			_form.Disposed += (sender, args) => CancelAsyncOperation();
			DatFile = DatFactory();
		}

		private void FireSenderMessage(SenderMessageDelegate action, string message)
		{
			if(action != Message)
				FireSenderMessage(Message, message);
			if(action != null)
			{
				if(_form == null)
					action(this, message);
				else
					_form.Invoke(action, new object[] {this, message});
			}
		}

		public static DataView DatFactory()
		{
			var dat = new DataTable();

			var col = new DataColumn(DbColumns.id, typeof(int));
			col.AutoIncrement = true;
			dat.Columns.Add(col);

			dat.PrimaryKey = new[] {col};

			//dat.Columns.Add(new DataColumn(DbColumns.fullFilename, typeof(string)));
			dat.Columns.Add(new DataColumn(DbColumns.filepath, typeof(string)));
			dat.Columns.Add(new DataColumn(DbColumns.filenameOnly, typeof(string)));
			dat.Columns.Add(new DataColumn(DbColumns.ext, typeof(string)));
			dat.Columns.Add(new DataColumn(DbColumns.newFilenameOnly, typeof(string)));
			//dat.Columns.Add(new DataColumn(DbColumns.shiftedDateTime, typeof(DateTime)));
			dat.Columns.Add(new DataColumn(DbColumns.needRename, typeof(bool)));
			dat.Columns.Add(new DataColumn(DbColumns.status, typeof(string)));

			return new DataView(dat);
		}

		private DataRow DatRowFactory()
		{
			var dr = DatFile.Table.NewRow();
			dr[DbColumns.needRename] = true;
			return dr;
		}

		public void CancelAsyncOperation()
		{
			if(_currentWorker != null)
			{
				_currentWorker.CancelAsync();
			}
		}

		public bool IsBusy
		{
			get {return _currentWorker != null && _currentWorker.IsBusy;}
		}

		private string GetStatusMessage(FileInfoHolder fih, int current, int total)
		{
			return string.Format("({0}/{1}) {2} => {3} {4}", current, total, fih.FilenameOnly, fih.NewFilenameOnly, fih.NeedRename ? "Yes" : "No");
		}

		public void DoPreviewAsync(string path)
		{
			if(IsBusy) throw new InvalidOperationException("There is active BackgroundWorker already");
			var worker = new BackgroundWorker();
			worker.DoWork += (sender, args) => DoPreview(worker, path);
			worker.RunWorkerCompleted += delegate {_currentWorker = null;};
			worker.RunWorkerAsync();
		}

		public void DoPreview(BackgroundWorker worker, string path)
		{
			FireSenderMessage(PreviewStarted, "Preview Started");
			var filesList = new List<string>();
			var extentions = Settings.Default.Extensions.Split(new[] {';'}, StringSplitOptions.RemoveEmptyEntries);
			if(extentions.Length < 1)
				extentions = new[] {"*"};
			foreach(var ext in extentions)
			{
				var so = Settings.Default.RecurseSubdirs
					? SearchOption.AllDirectories
					: SearchOption.TopDirectoryOnly;
				var files = Directory.GetFiles(path, ext, so);
				filesList.AddRange(files);
			}

			lock(_form ?? _padLock)
			{
				DatFile.Table.Rows.Clear();
				_drToHolder.Clear();
			}

			var current = 0;
			var total = filesList.Count;

			foreach(var fullFilename in filesList)
			{
				if((worker != null && worker.CancellationPending) || (_form != null && _form.IsDisposed))
				{
					FireSenderMessage(PreviewFinished, "Preview canceled");
					return;
				}

				current++;
				var dr = DatRowFactory();
				DatFile.Table.Rows.Add(dr);

				var fih = new FileInfoHolder(fullFilename, dr);
				_drToHolder[dr] = fih;

				FireSenderMessage(FileProcessedPreview, GetStatusMessage(fih, current, total));
			}
			FireSenderMessage(PreviewFinished, "Preview finished");
		}

		public void DoRenameAsync()
		{
			if(IsBusy) throw new InvalidOperationException("There is active BackgroundWorker already");
			_currentWorker = new BackgroundWorker();
			_currentWorker.DoWork += (sender, args) => DoRename(_currentWorker);
			_currentWorker.RunWorkerCompleted += delegate {_currentWorker = null;};
			_currentWorker.RunWorkerAsync();
		}

		public void DoRename(BackgroundWorker worker)
		{
			FireSenderMessage(RenameStarted, "Rename Started");
			var current = 0;
			var total = _drToHolder.Count;
			foreach(var fih in _drToHolder.Values)
			{
				if((worker != null && worker.CancellationPending) || (_form != null && _form.IsDisposed))
				{
					FireSenderMessage(RenameFinished, "Rename canceled");
					return;
				}

				current++;

				fih.Rename(Settings.Default.Touch);
				if(fih.NeedRename)
					FireSenderMessage(FileRenamed, GetStatusMessage(fih, current, total));
			}
			FireSenderMessage(RenameFinished, "Rename finished");
		}
	}
}
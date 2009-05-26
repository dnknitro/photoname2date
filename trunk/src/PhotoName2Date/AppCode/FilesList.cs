using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;
using PhotoName2Date.Properties;

namespace PhotoName2Date.MiddleLayer
{
	public class DbColumns
	{
		public const string id = "id";
		//public const string fullFilename = "fullFilename";
		public const string filepath = "filepath";
		public const string filenameOnly = "filenameOnly";
		public const string ext = "ext";
		public const string newFilenameOnly = "newFilenameOnly";
		//public const string shiftedDateTime = "shiftedDateTime";
		public const string needRename = "needRename";
		public const string status = "status";
	}

	internal delegate void DoPreviewInternalDelegate(string path);

	internal delegate void DoRenameInternalDelegate();

	public delegate void WorkFinished(object sender, string message);

	public class FilesList
	{
		public event FileProcessedDelegate FileRenamed;
		public event FileProcessedDelegate FileProcessedPreview;
		public event WorkFinished RenameFinished;
		public event WorkFinished PreviewFinished;

		public DataView DatFile { get; set; }

		public static DataView DatFactory()
		{
			var dat = new DataTable();

			var col = new DataColumn(DbColumns.id, typeof (int));
			col.AutoIncrement = true;
			dat.Columns.Add(col);

			dat.PrimaryKey = new DataColumn[] {col};

			//dat.Columns.Add(new DataColumn(DbColumns.fullFilename, typeof(string)));
			dat.Columns.Add(new DataColumn(DbColumns.filepath, typeof (string)));
			dat.Columns.Add(new DataColumn(DbColumns.filenameOnly, typeof (string)));
			dat.Columns.Add(new DataColumn(DbColumns.ext, typeof (string)));
			dat.Columns.Add(new DataColumn(DbColumns.newFilenameOnly, typeof (string)));
			//dat.Columns.Add(new DataColumn(DbColumns.shiftedDateTime, typeof(DateTime)));
			dat.Columns.Add(new DataColumn(DbColumns.needRename, typeof (bool)));
			dat.Columns.Add(new DataColumn(DbColumns.status, typeof (string)));

			return new DataView(dat);
		}

		private DataRow DatRowFactory()
		{
			DataRow dr = this.DatFile.Table.NewRow();
			dr[DbColumns.needRename] = true;
			return dr;
		}

		private readonly Dictionary<DataRow, FileInfoHolder> _drToHolder = new Dictionary<DataRow, FileInfoHolder>();

		//private DataGridView _dataGridView;
		private readonly Form _form;


		public FilesList(Form form)
		{
			_form = form;
			_form.Disposed += _form_Disposed;
			this.DatFile = FilesList.DatFactory();
		}

		private void _form_Disposed(object sender, EventArgs e)
		{
			CancelAsyncOperation();
		}

		private bool _cancelAsyncOperation = false;

		public void CancelAsyncOperation()
		{
			_cancelAsyncOperation = true;
		}

		#region doPreview

		private DoPreviewInternalDelegate _previewDelegate = null;

		public void DoPreview(string path)
		{
			_previewDelegate = this.DoPreviewInternal;
			_cancelAsyncOperation = false;
			_previewDelegate.BeginInvoke(path, DoPreviewInternalCallback, null);
		}

		private void DoPreviewInternalCallback(IAsyncResult aResult)
		{
			if (this.PreviewFinished != null)
			{
				_form.Invoke(PreviewFinished,
				             new object[] {this, this._cancelAsyncOperation ? "Preview canceled" : "Preview finished"});
			}
			_previewDelegate = null;
		}

		private Settings _settings
		{
			get { return global::PhotoName2Date.Properties.Settings.Default; }
		}

		private void DoPreviewInternal(string path)
		{
			List<string> filesList = new List<string>();
			var extentions = _settings.Extensions.Split(new[] {';'}, StringSplitOptions.RemoveEmptyEntries);
			if (extentions.Length < 1)
				extentions = new[] {"*"};
			foreach (var ext in extentions)
			{
				SearchOption so = _settings.RecurseSubdirs
				                  	? SearchOption.AllDirectories
				                  	: SearchOption.TopDirectoryOnly;
				string[] files = Directory.GetFiles(path, ext, so);
				filesList.AddRange(files);
			}

			lock (_form)
			{
				this.DatFile.Table.Rows.Clear();
				_drToHolder.Clear();
			}

			int current = 0;
			int total = filesList.Count;

			foreach (string fullFilename in filesList)
			{
				if (this._cancelAsyncOperation || this._form.IsDisposed)
				{
					break;
				}

				current++;
				DataRow dr = this.DatRowFactory();
				this.DatFile.Table.Rows.Add(dr);

				FileInfoHolder fih = new FileInfoHolder(fullFilename, dr);
				_drToHolder[dr] = fih;

				if (FileProcessedPreview != null)
				{
					_form.Invoke(FileProcessedPreview, new object[] {fih, current, total});
				}
			}
		}

		#endregion doPreview

		#region doRename

		public void DoRename()
		{
			DoRenameInternalDelegate pid = this.DoRenameInternal;
			_cancelAsyncOperation = false;
			pid.BeginInvoke(DoRenameInternalCallback, null);
		}

		private void DoRenameInternalCallback(IAsyncResult aResult)
		{
			if (this.RenameFinished != null)
			{
				_form.Invoke(RenameFinished, new object[] {this, this._cancelAsyncOperation ? "Rename canceled" : "Rename finished"});
			}
		}

		private void DoRenameInternal()
		{
			int current = 0;
			int total = this._drToHolder.Count;
			foreach (FileInfoHolder fih in this._drToHolder.Values)
			{
				if (this._cancelAsyncOperation || this._form.IsDisposed)
				{
					break;
				}

				current++;

				fih.Rename(_settings.Touch);
				if (this.FileRenamed != null)
				{
					_form.Invoke(FileRenamed, new object[] {fih, current, total});
				}
			}
		}

		#endregion doRename
	}
}
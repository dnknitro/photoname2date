using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using PhotoName2Date.MiddleLayer;

namespace PhotoName2Date
{
	public partial class FormMain : Form
	{
		private readonly RenamerConfig _renamerConfig;
		//private BackgroundWorker _bw = null;

		private readonly FilesList _filesList;

		public FormMain()
		{
			InitializeComponent();

			if (!string.IsNullOrEmpty(global::PhotoName2Date.Properties.Settings.Default.PathHistory))
			{
				string[] pathHistory = global::PhotoName2Date.Properties.Settings.Default.PathHistory.Split(';');
				string textBak = comboBoxFolders.Text;
				comboBoxFolders.Items.AddRange(pathHistory);
				comboBoxFolders.Text = textBak;
			}

			ConfigureDataGridView();

			this.comboBoxFolders.TextChanged += comboBoxFolders_TextChanged;
			this.comboBoxMasks.TextChanged += comboBoxMasks_TextChanged;

			this._renamerConfig = new RenamerConfig();
			_filesList = new FilesList(this);
			_filesList.PreviewFinished += _filesList_PreviewFinished;
			_filesList.RenameFinished += _filesList_RenameFinished;
			_filesList.FileRenamed += _filesList_FileRenamed;
			_filesList.FileProcessedPreview += _filesList_FileProcessedPreview;


			//this.comboBoxMasks.DataBindings.Add("Text", this._renamerConfig, "Extentions");
			//this.comboBoxFolders.DataBindings.Add("Text", this._renamerConfig, "Path");
			//this.checkBoxNeedTouch.DataBindings.Add("Checked", this._renamerConfig, "Touch");
			//this.checkBoxRecurseSubfolders.DataBindings.Add("Checked", this._renamerConfig, "RecurseSubdirs");
			//this.numericUpDownHoursShift.DataBindings.Add("Value", this._renamerConfig, "ShiftTimeByHours");

			Application.ApplicationExit += Application_ApplicationExit;

			RefreshUI();
		}

		private void _filesList_FileRenamed(FileInfoHolder fih, int current, int total)
		{
		}

		private void Application_ApplicationExit(object sender, EventArgs e)
		{
			this.SaveSettings();
		}

		private void SaveSettings()
		{
			global::PhotoName2Date.Properties.Settings.Default.PathHistory = Utils.Implode(";", comboBoxFolders.Items);
			global::PhotoName2Date.Properties.Settings.Default.Save();
		}

		private void comboBoxMasks_TextChanged(object sender, EventArgs e)
		{
			this._renamerConfig.Extentions = this.comboBoxMasks.Text;
		}

		private void comboBoxFolders_TextChanged(object sender, EventArgs e)
		{
			this.toolStripButtonRename.Enabled = false;
			this._renamerConfig.Path = this.comboBoxFolders.Text;
		}

		private void buttonSelectFolder_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog fbd = new FolderBrowserDialog();
			if (fbd.ShowDialog() == DialogResult.OK)
			{
				this.comboBoxFolders.Text = fbd.SelectedPath;
			}
		}

		private void FormMain_Load(object sender, EventArgs e)
		{
		}

		private bool PreProcess()
		{
			this._renamerConfig.Extentions = this.comboBoxMasks.Text;
			this._renamerConfig.Path = this.comboBoxFolders.Text;
			this._renamerConfig.Touch = this.checkBoxNeedTouch.Checked;
			this._renamerConfig.RecurseSubdirs = this.checkBoxRecurseSubfolders.Checked;
			this._renamerConfig.ShiftTimeByHours = (int) this.numericUpDownHoursShift.Value;


			bool ret = true;
			string path = this._renamerConfig.Path;
			if (path == string.Empty)
			{
				ret = false;
				errorProviderPath.SetIconAlignment(this.comboBoxFolders, ErrorIconAlignment.MiddleRight);
				errorProviderPath.SetIconPadding(this.comboBoxFolders, this.buttonSelectFolder.Width + 4);
				errorProviderPath.SetError(this.comboBoxFolders, "Missing entry.");
			}

			if (!Directory.Exists(path))
			{
				ret = false;
				errorProviderPath.SetIconAlignment(this.comboBoxFolders, ErrorIconAlignment.MiddleRight);
				errorProviderPath.SetIconPadding(this.comboBoxFolders, this.buttonSelectFolder.Width + 4);
				errorProviderPath.SetError(this.comboBoxFolders, path + " directory does not exist.");
			}

			if (ret)
			{
				errorProviderPath.Clear();
			}
			return ret;
		}

		private void AddToHistory(string item)
		{
			comboBoxFolders.Items.Insert(0, item);
			this.RemoveDuplicateItemsFromHistory();
		}

		private void RemoveDuplicateItemsFromHistory()
		{
			List<string> items = new List<string>();
			foreach (object item in comboBoxFolders.Items)
			{
				if (!items.Contains(item.ToString()))
				{
					items.Add(item.ToString());
				}
			}
			comboBoxFolders.Items.Clear();
			comboBoxFolders.Items.AddRange(items.ToArray());
		}

		private void toolStripButtonPreview_Click(object sender, EventArgs e)
		{
			if (!this.PreProcess())
			{
				return;
			}

			ren_InfoEvent("Preview started");

			this.toolStripButtonRename.Enabled = false;

			this.AddToHistory(_renamerConfig.Path);

			DataSource = null;

			ChangeEnabled(false);
			_filesList.DoPreview(_renamerConfig.Path);
		}

		private void toolStripButtonRename_Click(object sender, EventArgs e)
		{
			ren_InfoEvent("Rename started");
			ChangeEnabled(false);
			dataGridViewFiles.CommitEdit(DataGridViewDataErrorContexts.Commit);
			DataSource.Table.AcceptChanges();
			_filesList.DoRename();
		}

		private DataView DataSource
		{
			get { return (DataView) dataGridViewFiles.DataSource; }
			set
			{
				dataGridViewFiles.DataSource = value;
				checkBoxShowAffectedOnly.Enabled = value != null;
				if (value == null)
					checkBoxShowAffectedOnly.Checked = false;
			}
		}

		private void _filesList_PreviewFinished(object sender, string message)
		{
			DataSource = _filesList.DatFile;
			ChangeEnabled(true);
			toolStripButtonRename.Enabled = true;
			dataGridViewFiles.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
			ren_InfoEvent(message);
			checkBoxShowAffectedOnly.Checked = true;
		}

		private void _filesList_FileProcessedPreview(FileInfoHolder fih, int current, int total)
		{
			ren_InfoEvent(string.Format("({0}/{1}) {2} => {3}", current, total, fih.FilenameOnly, fih.NewFilenameOnly));
		}

		private void _filesList_RenameFinished(object sender, string message)
		{
			ChangeEnabled(true);
			toolStripButtonRename.Enabled = dataGridViewFiles.SelectedRows.Count > 0;
			ren_InfoEvent(message);
			MessageBox.Show(message, "Message");
		}

		private void ConfigureDataGridView()
		{
			dataGridViewFiles.AutoGenerateColumns = false;

			DataGridViewTextBoxColumn dgvTbCol;

			dgvTbCol = new DataGridViewTextBoxColumn();
			dgvTbCol.Name = DbColumns.filepath;
			dgvTbCol.DataPropertyName = dgvTbCol.Name;
			dgvTbCol.HeaderText = "Path";
			dgvTbCol.ReadOnly = true;
			dataGridViewFiles.Columns.Add(dgvTbCol);

			dgvTbCol = new DataGridViewTextBoxColumn();
			dgvTbCol.Name = DbColumns.filenameOnly;
			dgvTbCol.DataPropertyName = dgvTbCol.Name;
			dgvTbCol.HeaderText = "Name";
			dgvTbCol.ReadOnly = true;
			dataGridViewFiles.Columns.Add(dgvTbCol);

			dgvTbCol = new DataGridViewTextBoxColumn();
			dgvTbCol.Name = DbColumns.ext;
			dgvTbCol.DataPropertyName = dgvTbCol.Name;
			dgvTbCol.HeaderText = "Ext.";
			dgvTbCol.ReadOnly = true;
			dataGridViewFiles.Columns.Add(dgvTbCol);

			dgvTbCol = new DataGridViewTextBoxColumn();
			dgvTbCol.Name = DbColumns.newFilenameOnly;
			dgvTbCol.DataPropertyName = dgvTbCol.Name;
			dgvTbCol.HeaderText = "New Name";
			dgvTbCol.ReadOnly = false;
			dataGridViewFiles.Columns.Add(dgvTbCol);

			DataGridViewCheckBoxColumn dgvChbxCol = new DataGridViewCheckBoxColumn();
			dgvTbCol.Name = DbColumns.needRename;
			dgvChbxCol.DataPropertyName = dgvTbCol.Name;
			dgvChbxCol.Name = DbColumns.needRename;
			dgvChbxCol.HeaderText = "Rename?";
			dgvChbxCol.ReadOnly = false;
			dataGridViewFiles.Columns.Add(dgvChbxCol);

			dgvTbCol = new DataGridViewTextBoxColumn();
			dgvTbCol.Name = DbColumns.status;
			dgvTbCol.DataPropertyName = dgvTbCol.Name;
			dgvTbCol.HeaderText = "";
			dgvTbCol.ReadOnly = true;
			dataGridViewFiles.Columns.Add(dgvTbCol);
			dgvTbCol.MinimumWidth = 50;

			//DataGridViewImageColumn dgvImgCol = new DataGridViewImageColumn();
			//dgvImgCol.HeaderText = "";
			//dgvImgCol.ReadOnly = true;
			//dataGridViewFiles.Columns.Add(dgvImgCol);
		}

		private void ChangeEnabled(bool isEnabled)
		{
			panelMain.Cursor = isEnabled ? Cursors.Default : Cursors.WaitCursor;
			dataGridViewFiles.Cursor = panelMain.Cursor;
			groupBoxOptions.Enabled = isEnabled;
			toolStripButtonPreview.Enabled = isEnabled;
			toolStripButtonCancel.Enabled = !isEnabled;
		}

		private void ren_InfoEvent(string info)
		{
			this.toolStripStatusLabel1.Text = info;
			//Log.Append(info + "\n");
			//this.listBoxLog.Items.Add(info);
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			AboutBox about = new AboutBox();
			about.Show();
		}

		private void toolStripButtonCancel_Click(object sender, EventArgs e)
		{
			_filesList.CancelAsyncOperation();
		}

		protected override bool ProcessDialogKey(System.Windows.Forms.Keys keyData)
		{
			System.Windows.Forms.Keys key = keyData;
			if (key == System.Windows.Forms.Keys.Escape)
			{
				toolStripButtonCancel_Click(null, null);
				return true;
			}
			return base.ProcessDialogKey(keyData);
		}

		private void ChangeSelection(bool invert, bool check)
		{
			foreach (DataGridViewRow row in dataGridViewFiles.SelectedRows)
			{
				row.Cells[DbColumns.needRename].Value = invert
				                                        	? !((bool) row.Cells[DbColumns.needRename].Value)
				                                        	: check;
			}
		}

		private void contextMenuGrid_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{
			switch (e.ClickedItem.Tag.ToString())
			{
				case "invert":
					ChangeSelection(true, false);
					break;
				case "check":
					ChangeSelection(false, true);
					break;
				case "uncheck":
					ChangeSelection(false, false);
					break;
			}
		}

		private void dataGridViewFiles_DoubleClick(object sender, EventArgs e)
		{
			foreach (DataGridViewRow row in dataGridViewFiles.SelectedRows)
			{
				var path = row.Cells[DbColumns.filepath].Value.ToString() + Path.DirectorySeparatorChar;
				var ext = row.Cells[DbColumns.ext].Value;
				var file = path + row.Cells[DbColumns.filenameOnly].Value + ext;
				if (!File.Exists(file))
					file = path + row.Cells[DbColumns.newFilenameOnly].Value + ext;

				var psi = new ProcessStartInfo(file);
				Process.Start(psi);
			}
		}

		private void checkBoxShowAffectedOnly_CheckedChanged(object sender, EventArgs e)
		{
			RefreshUI();
		}

		private void RefreshUI()
		{
			if (DataSource == null) return;
			DataSource.RowFilter = checkBoxShowAffectedOnly.Checked
			                       	? (DbColumns.needRename + "=1")
			                       	: "";
		}
	}
}
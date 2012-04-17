using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using NameFix.AppCode;
using NameFix.Properties;

namespace NameFix
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();

			NameFixProgram.FilesList.SetForm(this);


			if(!string.IsNullOrEmpty(Settings.Default.PathHistory))
			{
				var pathHistory = Settings.Default.PathHistory.Split(';');
				var textBak = comboBoxFolders.Text;
				comboBoxFolders.Items.AddRange(pathHistory.Select(x => (object)x).ToArray());
				comboBoxFolders.Text = textBak;
			}

			ConfigureDataGridView();

			NameFixProgram.FilesList.PreviewStarted += (sender, message) => ChangeEnabled(true);
			NameFixProgram.FilesList.RenameStarted += (sender, message) => ChangeEnabled(true);
			NameFixProgram.FilesList.PreviewFinished += _filesList_PreviewFinished;
			NameFixProgram.FilesList.RenameFinished += _filesList_RenameFinished;

			NameFixProgram.FilesList.Message += (sender, message) => toolStripStatusLabel1.Text = message;


			comboBoxFolders.TextChanged += comboBoxFolders_TextChanged;
			comboBoxMasks.TextChanged += comboBoxMasks_TextChanged;

			Application.ApplicationExit += Application_ApplicationExit;

			RefreshUI();
		}

		private void Application_ApplicationExit(object sender, EventArgs e)
		{
			SaveSettings();
		}

		private void SaveSettings()
		{
			if(this.WindowState == FormWindowState.Minimized)
			{
				Settings.Default.Location = new Point(this.RestoreBounds.Left, this.RestoreBounds.Top);
				Settings.Default.ClientSize = new Size(this.RestoreBounds.Width, this.RestoreBounds.Height);
				Settings.Default.FormWindowState = FormWindowState.Normal;
			}
			Settings.Default.PathHistory = Utils.Implode(";", comboBoxFolders.Items);
			Settings.Default.Save();
		}

		private void comboBoxMasks_TextChanged(object sender, EventArgs e)
		{
			NameFixProgram.RenamerConfig.Extentions = comboBoxMasks.Text;
		}

		private void comboBoxFolders_TextChanged(object sender, EventArgs e)
		{
			NameFixProgram.RenamerConfig.Path = comboBoxFolders.Text;
		}

		private void buttonSelectFolder_Click(object sender, EventArgs e)
		{
			var fbd = new FolderBrowserDialog();
			if(fbd.ShowDialog() == DialogResult.OK)
			{
				comboBoxFolders.Text = fbd.SelectedPath;
			}
		}

		private void FormMain_Load(object sender, EventArgs e)
		{
			ChangeEnabled(false);
		}

		private bool PreProcess()
		{
			NameFixProgram.RenamerConfig.Extentions = comboBoxMasks.Text;
			NameFixProgram.RenamerConfig.Path = comboBoxFolders.Text;
			NameFixProgram.RenamerConfig.Touch = checkBoxNeedTouch.Checked;
			NameFixProgram.RenamerConfig.RecurseSubdirs = checkBoxRecurseSubfolders.Checked;
			NameFixProgram.RenamerConfig.ShiftTimeByHours = (int)numericUpDownHoursShift.Value;


			var ret = true;
			var path = NameFixProgram.RenamerConfig.Path;
			if(path == string.Empty)
			{
				ret = false;
				errorProviderPath.SetIconAlignment(comboBoxFolders, ErrorIconAlignment.MiddleRight);
				errorProviderPath.SetIconPadding(comboBoxFolders, buttonSelectFolder.Width + 4);
				errorProviderPath.SetError(comboBoxFolders, "Missing entry.");
			}

			if(!Directory.Exists(path))
			{
				ret = false;
				errorProviderPath.SetIconAlignment(comboBoxFolders, ErrorIconAlignment.MiddleRight);
				errorProviderPath.SetIconPadding(comboBoxFolders, buttonSelectFolder.Width + 4);
				errorProviderPath.SetError(comboBoxFolders, path + " directory does not exist.");
			}

			if(ret)
			{
				errorProviderPath.Clear();
			}
			return ret;
		}

		private void AddToHistory(string item)
		{
			comboBoxFolders.Items.Insert(0, item);
			RemoveDuplicateItemsFromHistory();
		}

		private void RemoveDuplicateItemsFromHistory()
		{
			var items = new List<object>();
			foreach(var item in comboBoxFolders.Items)
			{
				if(!items.Contains(item.ToString()))
				{
					items.Add(item.ToString());
				}
			}
			comboBoxFolders.Items.Clear();
			comboBoxFolders.Items.AddRange(items.ToArray());
		}

		private void _filesList_PreviewFinished(object sender, string message)
		{
			DataSource = NameFixProgram.FilesList.DatFile;
			ChangeEnabled(false);
			dataGridViewFiles.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
		}

		private void toolStripButtonRename_Click(object sender, EventArgs e)
		{
			dataGridViewFiles.CommitEdit(DataGridViewDataErrorContexts.Commit);
			if(DataSource != null)
				DataSource.Table.AcceptChanges();
			NameFixProgram.FilesList.DoRenameAsync();
		}

		private void toolStripButtonPreview_Click(object sender, EventArgs e)
		{
			if(!PreProcess())
			{
				return;
			}

			AddToHistory(NameFixProgram.RenamerConfig.Path);

			DataSource = null;

			NameFixProgram.FilesList.DoPreviewAsync(NameFixProgram.RenamerConfig.Path);
		}

		private void _filesList_RenameFinished(object sender, string message)
		{
			ChangeEnabled(false);

			foreach(DataGridViewRow row in dataGridViewFiles.Rows)
			{
				row.Cells[DbColumns.needRename].Value = false;
			}
			RefreshUI();
		}

		private void ConfigureDataGridView()
		{
			dataGridViewFiles.AutoGenerateColumns = false;

			dataGridViewFiles.Columns.Add(
				new DataGridViewTextBoxColumn
				{
					Name = DbColumns.filepath,
					DataPropertyName = DbColumns.filepath,
					HeaderText = "Path",
					ReadOnly = true
				});

			dataGridViewFiles.Columns.Add(
				new DataGridViewTextBoxColumn
				{
					Name = DbColumns.filenameOnly,
					DataPropertyName = DbColumns.filenameOnly,
					HeaderText = "Name",
					ReadOnly = true
				});

			dataGridViewFiles.Columns.Add(
				new DataGridViewTextBoxColumn
				{
					Name = DbColumns.ext,
					DataPropertyName = DbColumns.ext,
					HeaderText = "Ext.",
					ReadOnly = true
				});

			dataGridViewFiles.Columns.Add(
				new DataGridViewTextBoxColumn
				{
					Name = DbColumns.newFilenameOnly,
					DataPropertyName = DbColumns.newFilenameOnly,
					HeaderText = "New Name",
					ReadOnly = false
				});

			dataGridViewFiles.Columns.Add(
				new DataGridViewCheckBoxColumn
				{
					DataPropertyName = DbColumns.needRename,
					Name = DbColumns.needRename,
					HeaderText = "Rename?",
					ReadOnly = false
				});
			//((DataGridViewCheckBoxColumn)dataGridViewFiles.Columns[DbColumns.needRename]).
			dataGridViewFiles.CurrentCellDirtyStateChanged += dataGridViewFiles_CurrentCellDirtyStateChanged;

			dataGridViewFiles.Columns.Add(new DataGridViewTextBoxColumn
			{
				Name = DbColumns.status,
				DataPropertyName = DbColumns.status,
				HeaderText = "",
				ReadOnly = true,
				MinimumWidth = 50
			});
		}

		private void dataGridViewFiles_CurrentCellDirtyStateChanged(object sender, EventArgs e)
		{
			var view = (DataGridView)sender;
			if(view.IsCurrentCellDirty)
			{
				view.CommitEdit(DataGridViewDataErrorContexts.Commit);
				RefreshUI();
			}
		}

		private void ChangeEnabled(bool started)
		{
			panelMain.Cursor = !started ? Cursors.Default : Cursors.WaitCursor;
			dataGridViewFiles.Cursor = panelMain.Cursor;
			groupBoxOptions.Enabled = !started;
			toolStripButtonPreview.Enabled = !started;
			toolStripButtonRename.Enabled = !started;
			toolStripButtonCancel.Enabled = started;
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			new AboutBox().ShowDialog(this);
		}

		private void toolStripButtonCancel_Click(object sender, EventArgs e)
		{
			NameFixProgram.FilesList.CancelAsyncOperation();
		}

		protected override bool ProcessDialogKey(Keys keyData)
		{
			var key = keyData;
			if(key == Keys.Escape)
			{
				toolStripButtonCancel_Click(null, null);
				return true;
			}
			return base.ProcessDialogKey(keyData);
		}

		private void ChangeSelection(bool invert, bool check)
		{
			foreach(DataGridViewRow row in dataGridViewFiles.SelectedRows)
			{
				row.Cells[DbColumns.needRename].Value = invert
					? !((bool)row.Cells[DbColumns.needRename].Value)
					: check;
			}
		}

		private void contextMenuGrid_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{
			switch(e.ClickedItem.Tag.ToString())
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

		private void dataGridViewFiles_Click(object sender, EventArgs e) {}

		private void dataGridViewFiles_DoubleClick(object sender, EventArgs e)
		{
			foreach(DataGridViewRow row in dataGridViewFiles.SelectedRows)
			{
				var path = row.Cells[DbColumns.filepath].Value.ToString() + Path.DirectorySeparatorChar;
				var ext = row.Cells[DbColumns.ext].Value;
				var file = path + row.Cells[DbColumns.filenameOnly].Value + ext;
				if(!File.Exists(file))
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
			if(DataSource == null) return;
			DataSource.RowFilter = checkBoxShowAffectedOnly.Checked
				? (DbColumns.needRename + "=1")
				: "";
		}

		private DataView DataSource
		{
			get {return (DataView)dataGridViewFiles.DataSource;}
			set
			{
				dataGridViewFiles.DataSource = value;
				checkBoxShowAffectedOnly.Enabled = value != null;
				if(value == null)
					checkBoxShowAffectedOnly.Checked = false;
			}
		}
	}
}
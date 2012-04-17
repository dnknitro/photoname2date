namespace NameFix {
	partial class MainForm {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.groupBoxOptions = new System.Windows.Forms.GroupBox();
			this.panelOptions4 = new System.Windows.Forms.Panel();
			this.checkBoxShowAffectedOnly = new System.Windows.Forms.CheckBox();
			this.panelOptions3 = new System.Windows.Forms.Panel();
			this.labelHours = new System.Windows.Forms.Label();
			this.numericUpDownHoursShift = new System.Windows.Forms.NumericUpDown();
			this.labelShiftTimeBy = new System.Windows.Forms.Label();
			this.checkBoxRecurseSubfolders = new System.Windows.Forms.CheckBox();
			this.panelOptions2 = new System.Windows.Forms.Panel();
			this.textBoxPattern = new System.Windows.Forms.TextBox();
			this.labelPattern = new System.Windows.Forms.Label();
			this.checkBoxNeedTouch = new System.Windows.Forms.CheckBox();
			this.panelOptions1 = new System.Windows.Forms.Panel();
			this.comboBoxFolders = new System.Windows.Forms.ComboBox();
			this.buttonSelectFolder = new System.Windows.Forms.Button();
			this.labelDir = new System.Windows.Forms.Label();
			this.comboBoxMasks = new System.Windows.Forms.ComboBox();
			this.labelMask = new System.Windows.Forms.Label();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.statusStrip = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.toolStripButtonRename = new System.Windows.Forms.ToolStripButton();
			this.toolStripButtonPreview = new System.Windows.Forms.ToolStripButton();
			this.toolStripButtonCancel = new System.Windows.Forms.ToolStripButton();
			this.errorProviderPath = new System.Windows.Forms.ErrorProvider(this.components);
			this.groupBoxLog = new System.Windows.Forms.GroupBox();
			this.listBoxLog = new System.Windows.Forms.ListBox();
			this.panelMain = new System.Windows.Forms.Panel();
			this.dataGridViewFiles = new System.Windows.Forms.DataGridView();
			this.contextMenuGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.toolStripMenuItemInvertSelected = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItemCheckSelected = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItemUncheckSelected = new System.Windows.Forms.ToolStripMenuItem();
			this.groupBoxOptions.SuspendLayout();
			this.panelOptions4.SuspendLayout();
			this.panelOptions3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownHoursShift)).BeginInit();
			this.panelOptions2.SuspendLayout();
			this.panelOptions1.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.statusStrip.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.errorProviderPath)).BeginInit();
			this.groupBoxLog.SuspendLayout();
			this.panelMain.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewFiles)).BeginInit();
			this.contextMenuGrid.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBoxOptions
			// 
			this.groupBoxOptions.Controls.Add(this.panelOptions4);
			this.groupBoxOptions.Controls.Add(this.panelOptions3);
			this.groupBoxOptions.Controls.Add(this.panelOptions2);
			this.groupBoxOptions.Controls.Add(this.panelOptions1);
			this.groupBoxOptions.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBoxOptions.Location = new System.Drawing.Point(0, 0);
			this.groupBoxOptions.Name = "groupBoxOptions";
			this.groupBoxOptions.Size = new System.Drawing.Size(625, 121);
			this.groupBoxOptions.TabIndex = 0;
			this.groupBoxOptions.TabStop = false;
			this.groupBoxOptions.Text = "Options";
			// 
			// panelOptions4
			// 
			this.panelOptions4.Controls.Add(this.checkBoxShowAffectedOnly);
			this.panelOptions4.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelOptions4.Location = new System.Drawing.Point(3, 91);
			this.panelOptions4.Name = "panelOptions4";
			this.panelOptions4.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
			this.panelOptions4.Size = new System.Drawing.Size(619, 25);
			this.panelOptions4.TabIndex = 9;
			// 
			// checkBoxShowAffectedOnly
			// 
			this.checkBoxShowAffectedOnly.AutoSize = true;
			this.checkBoxShowAffectedOnly.Dock = System.Windows.Forms.DockStyle.Left;
			this.checkBoxShowAffectedOnly.Enabled = false;
			this.checkBoxShowAffectedOnly.Location = new System.Drawing.Point(0, 2);
			this.checkBoxShowAffectedOnly.Name = "checkBoxShowAffectedOnly";
			this.checkBoxShowAffectedOnly.Padding = new System.Windows.Forms.Padding(38, 0, 0, 0);
			this.checkBoxShowAffectedOnly.Size = new System.Drawing.Size(177, 21);
			this.checkBoxShowAffectedOnly.TabIndex = 3;
			this.checkBoxShowAffectedOnly.Text = "show checked files only";
			this.checkBoxShowAffectedOnly.UseVisualStyleBackColor = true;
			this.checkBoxShowAffectedOnly.CheckedChanged += new System.EventHandler(this.checkBoxShowAffectedOnly_CheckedChanged);
			// 
			// panelOptions3
			// 
			this.panelOptions3.Controls.Add(this.labelHours);
			this.panelOptions3.Controls.Add(this.numericUpDownHoursShift);
			this.panelOptions3.Controls.Add(this.labelShiftTimeBy);
			this.panelOptions3.Controls.Add(this.checkBoxRecurseSubfolders);
			this.panelOptions3.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelOptions3.Location = new System.Drawing.Point(3, 66);
			this.panelOptions3.Name = "panelOptions3";
			this.panelOptions3.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
			this.panelOptions3.Size = new System.Drawing.Size(619, 25);
			this.panelOptions3.TabIndex = 5;
			// 
			// labelHours
			// 
			this.labelHours.Dock = System.Windows.Forms.DockStyle.Left;
			this.labelHours.Location = new System.Drawing.Point(321, 2);
			this.labelHours.Name = "labelHours";
			this.labelHours.Size = new System.Drawing.Size(38, 21);
			this.labelHours.TabIndex = 8;
			this.labelHours.Text = "hours";
			this.labelHours.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// numericUpDownHoursShift
			// 
			this.numericUpDownHoursShift.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::NameFix.Properties.Settings.Default, "ShiftTimeByHours", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.numericUpDownHoursShift.Dock = System.Windows.Forms.DockStyle.Left;
			this.numericUpDownHoursShift.Location = new System.Drawing.Point(256, 2);
			this.numericUpDownHoursShift.Maximum = new decimal(new int[] {
            32000,
            0,
            0,
            0});
			this.numericUpDownHoursShift.Minimum = new decimal(new int[] {
            32000,
            0,
            0,
            -2147483648});
			this.numericUpDownHoursShift.Name = "numericUpDownHoursShift";
			this.numericUpDownHoursShift.Size = new System.Drawing.Size(65, 20);
			this.numericUpDownHoursShift.TabIndex = 7;
			this.numericUpDownHoursShift.Value = global::NameFix.Properties.Settings.Default.ShiftTimeByHours;
			// 
			// labelShiftTimeBy
			// 
			this.labelShiftTimeBy.Dock = System.Windows.Forms.DockStyle.Left;
			this.labelShiftTimeBy.Location = new System.Drawing.Point(150, 2);
			this.labelShiftTimeBy.Name = "labelShiftTimeBy";
			this.labelShiftTimeBy.Size = new System.Drawing.Size(106, 21);
			this.labelShiftTimeBy.TabIndex = 5;
			this.labelShiftTimeBy.Text = "Shift time by:";
			this.labelShiftTimeBy.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// checkBoxRecurseSubfolders
			// 
			this.checkBoxRecurseSubfolders.AutoSize = true;
			this.checkBoxRecurseSubfolders.Checked = global::NameFix.Properties.Settings.Default.RecurseSubdirs;
			this.checkBoxRecurseSubfolders.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBoxRecurseSubfolders.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::NameFix.Properties.Settings.Default, "RecurseSubdirs", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.checkBoxRecurseSubfolders.Dock = System.Windows.Forms.DockStyle.Left;
			this.checkBoxRecurseSubfolders.Location = new System.Drawing.Point(0, 2);
			this.checkBoxRecurseSubfolders.Name = "checkBoxRecurseSubfolders";
			this.checkBoxRecurseSubfolders.Padding = new System.Windows.Forms.Padding(38, 0, 0, 0);
			this.checkBoxRecurseSubfolders.Size = new System.Drawing.Size(150, 21);
			this.checkBoxRecurseSubfolders.TabIndex = 3;
			this.checkBoxRecurseSubfolders.Text = "recurse subfolders";
			this.checkBoxRecurseSubfolders.UseVisualStyleBackColor = true;
			// 
			// panelOptions2
			// 
			this.panelOptions2.Controls.Add(this.textBoxPattern);
			this.panelOptions2.Controls.Add(this.labelPattern);
			this.panelOptions2.Controls.Add(this.checkBoxNeedTouch);
			this.panelOptions2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelOptions2.Location = new System.Drawing.Point(3, 41);
			this.panelOptions2.Name = "panelOptions2";
			this.panelOptions2.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
			this.panelOptions2.Size = new System.Drawing.Size(619, 25);
			this.panelOptions2.TabIndex = 4;
			// 
			// textBoxPattern
			// 
			this.textBoxPattern.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::NameFix.Properties.Settings.Default, "RenamePattern", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.textBoxPattern.Dock = System.Windows.Forms.DockStyle.Left;
			this.textBoxPattern.Location = new System.Drawing.Point(256, 2);
			this.textBoxPattern.Name = "textBoxPattern";
			this.textBoxPattern.Size = new System.Drawing.Size(198, 20);
			this.textBoxPattern.TabIndex = 5;
			this.textBoxPattern.Text = global::NameFix.Properties.Settings.Default.RenamePattern;
			// 
			// labelPattern
			// 
			this.labelPattern.Dock = System.Windows.Forms.DockStyle.Left;
			this.labelPattern.Location = new System.Drawing.Point(166, 2);
			this.labelPattern.Name = "labelPattern";
			this.labelPattern.Size = new System.Drawing.Size(90, 21);
			this.labelPattern.TabIndex = 9;
			this.labelPattern.Text = "Pattern";
			this.labelPattern.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// checkBoxNeedTouch
			// 
			this.checkBoxNeedTouch.AutoSize = true;
			this.checkBoxNeedTouch.Checked = global::NameFix.Properties.Settings.Default.Touch;
			this.checkBoxNeedTouch.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::NameFix.Properties.Settings.Default, "Touch", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.checkBoxNeedTouch.Dock = System.Windows.Forms.DockStyle.Left;
			this.checkBoxNeedTouch.Location = new System.Drawing.Point(0, 2);
			this.checkBoxNeedTouch.Name = "checkBoxNeedTouch";
			this.checkBoxNeedTouch.Padding = new System.Windows.Forms.Padding(38, 0, 0, 0);
			this.checkBoxNeedTouch.Size = new System.Drawing.Size(166, 21);
			this.checkBoxNeedTouch.TabIndex = 4;
			this.checkBoxNeedTouch.Text = "touch file system date";
			this.checkBoxNeedTouch.UseVisualStyleBackColor = true;
			// 
			// panelOptions1
			// 
			this.panelOptions1.Controls.Add(this.comboBoxFolders);
			this.panelOptions1.Controls.Add(this.buttonSelectFolder);
			this.panelOptions1.Controls.Add(this.labelDir);
			this.panelOptions1.Controls.Add(this.comboBoxMasks);
			this.panelOptions1.Controls.Add(this.labelMask);
			this.panelOptions1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelOptions1.Location = new System.Drawing.Point(3, 16);
			this.panelOptions1.Name = "panelOptions1";
			this.panelOptions1.Padding = new System.Windows.Forms.Padding(0, 2, 40, 2);
			this.panelOptions1.Size = new System.Drawing.Size(619, 25);
			this.panelOptions1.TabIndex = 0;
			// 
			// comboBoxFolders
			// 
			this.comboBoxFolders.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.comboBoxFolders.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories;
			this.comboBoxFolders.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::NameFix.Properties.Settings.Default, "Path", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.comboBoxFolders.Dock = System.Windows.Forms.DockStyle.Fill;
			this.comboBoxFolders.FormattingEnabled = true;
			this.comboBoxFolders.Location = new System.Drawing.Point(256, 2);
			this.comboBoxFolders.Name = "comboBoxFolders";
			this.comboBoxFolders.Size = new System.Drawing.Size(298, 21);
			this.comboBoxFolders.TabIndex = 3;
			this.comboBoxFolders.Text = global::NameFix.Properties.Settings.Default.Path;
			// 
			// buttonSelectFolder
			// 
			this.buttonSelectFolder.Dock = System.Windows.Forms.DockStyle.Right;
			this.buttonSelectFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonSelectFolder.Location = new System.Drawing.Point(554, 2);
			this.buttonSelectFolder.Margin = new System.Windows.Forms.Padding(0);
			this.buttonSelectFolder.Name = "buttonSelectFolder";
			this.buttonSelectFolder.Size = new System.Drawing.Size(25, 21);
			this.buttonSelectFolder.TabIndex = 4;
			this.buttonSelectFolder.Text = "...";
			this.buttonSelectFolder.UseVisualStyleBackColor = true;
			this.buttonSelectFolder.Click += new System.EventHandler(this.buttonSelectFolder_Click);
			// 
			// labelDir
			// 
			this.labelDir.Dock = System.Windows.Forms.DockStyle.Left;
			this.labelDir.Location = new System.Drawing.Point(190, 2);
			this.labelDir.Name = "labelDir";
			this.labelDir.Size = new System.Drawing.Size(66, 21);
			this.labelDir.TabIndex = 7;
			this.labelDir.Text = "Dir:";
			this.labelDir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// comboBoxMasks
			// 
			this.comboBoxMasks.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::NameFix.Properties.Settings.Default, "Extensions", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.comboBoxMasks.Dock = System.Windows.Forms.DockStyle.Left;
			this.comboBoxMasks.FormattingEnabled = true;
			this.comboBoxMasks.Items.AddRange(new object[] {
            "*.cr2;*.jpg;*.avi;*.mov;*.mpg;*.3gp",
            "*.jpg",
            "*.avi;*.mov;*.mpg",
            "*.*"});
			this.comboBoxMasks.Location = new System.Drawing.Point(37, 2);
			this.comboBoxMasks.Name = "comboBoxMasks";
			this.comboBoxMasks.Size = new System.Drawing.Size(153, 21);
			this.comboBoxMasks.TabIndex = 2;
			this.comboBoxMasks.Text = global::NameFix.Properties.Settings.Default.Extensions;
			// 
			// labelMask
			// 
			this.labelMask.Dock = System.Windows.Forms.DockStyle.Left;
			this.labelMask.Location = new System.Drawing.Point(0, 2);
			this.labelMask.Name = "labelMask";
			this.labelMask.Size = new System.Drawing.Size(37, 21);
			this.labelMask.TabIndex = 0;
			this.labelMask.Text = "Mask:";
			this.labelMask.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(625, 24);
			this.menuStrip1.TabIndex = 1;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
			this.exitToolStripMenuItem.Text = "Exit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
			this.helpToolStripMenuItem.Text = "Help";
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
			this.aboutToolStripMenuItem.Text = "About";
			this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
			// 
			// statusStrip
			// 
			this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
			this.statusStrip.Location = new System.Drawing.Point(0, 398);
			this.statusStrip.Name = "statusStrip";
			this.statusStrip.Size = new System.Drawing.Size(625, 22);
			this.statusStrip.TabIndex = 2;
			this.statusStrip.Text = "statusStrip1";
			// 
			// toolStripStatusLabel1
			// 
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonRename,
            this.toolStripButtonPreview,
            this.toolStripButtonCancel});
			this.toolStrip1.Location = new System.Drawing.Point(0, 24);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(625, 25);
			this.toolStrip1.TabIndex = 3;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// toolStripButtonRename
			// 
			this.toolStripButtonRename.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonRename.Image")));
			this.toolStripButtonRename.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButtonRename.Name = "toolStripButtonRename";
			this.toolStripButtonRename.Size = new System.Drawing.Size(66, 22);
			this.toolStripButtonRename.Text = "Rename";
			this.toolStripButtonRename.Click += new System.EventHandler(this.toolStripButtonRename_Click);
			// 
			// toolStripButtonPreview
			// 
			this.toolStripButtonPreview.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonPreview.Image")));
			this.toolStripButtonPreview.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButtonPreview.Name = "toolStripButtonPreview";
			this.toolStripButtonPreview.Size = new System.Drawing.Size(65, 22);
			this.toolStripButtonPreview.Text = "Preview";
			this.toolStripButtonPreview.Click += new System.EventHandler(this.toolStripButtonPreview_Click);
			// 
			// toolStripButtonCancel
			// 
			this.toolStripButtonCancel.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonCancel.Image")));
			this.toolStripButtonCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButtonCancel.Name = "toolStripButtonCancel";
			this.toolStripButtonCancel.Size = new System.Drawing.Size(59, 22);
			this.toolStripButtonCancel.Text = "Cancel";
			this.toolStripButtonCancel.Click += new System.EventHandler(this.toolStripButtonCancel_Click);
			// 
			// errorProviderPath
			// 
			this.errorProviderPath.ContainerControl = this;
			// 
			// groupBoxLog
			// 
			this.groupBoxLog.Controls.Add(this.listBoxLog);
			this.groupBoxLog.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBoxLog.Location = new System.Drawing.Point(0, 49);
			this.groupBoxLog.Name = "groupBoxLog";
			this.groupBoxLog.Size = new System.Drawing.Size(625, 349);
			this.groupBoxLog.TabIndex = 4;
			this.groupBoxLog.TabStop = false;
			this.groupBoxLog.Text = "Log";
			this.groupBoxLog.Visible = false;
			// 
			// listBoxLog
			// 
			this.listBoxLog.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listBoxLog.FormattingEnabled = true;
			this.listBoxLog.Location = new System.Drawing.Point(3, 16);
			this.listBoxLog.Name = "listBoxLog";
			this.listBoxLog.Size = new System.Drawing.Size(619, 330);
			this.listBoxLog.TabIndex = 0;
			// 
			// panelMain
			// 
			this.panelMain.Controls.Add(this.dataGridViewFiles);
			this.panelMain.Controls.Add(this.groupBoxOptions);
			this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelMain.Location = new System.Drawing.Point(0, 49);
			this.panelMain.Name = "panelMain";
			this.panelMain.Size = new System.Drawing.Size(625, 349);
			this.panelMain.TabIndex = 7;
			// 
			// dataGridViewFiles
			// 
			this.dataGridViewFiles.AllowUserToAddRows = false;
			this.dataGridViewFiles.AllowUserToDeleteRows = false;
			this.dataGridViewFiles.BackgroundColor = System.Drawing.SystemColors.Window;
			this.dataGridViewFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewFiles.ContextMenuStrip = this.contextMenuGrid;
			this.dataGridViewFiles.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridViewFiles.Location = new System.Drawing.Point(0, 121);
			this.dataGridViewFiles.Name = "dataGridViewFiles";
			this.dataGridViewFiles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridViewFiles.Size = new System.Drawing.Size(625, 228);
			this.dataGridViewFiles.TabIndex = 0;
			this.dataGridViewFiles.Click += new System.EventHandler(this.dataGridViewFiles_Click);
			this.dataGridViewFiles.DoubleClick += new System.EventHandler(this.dataGridViewFiles_DoubleClick);
			// 
			// contextMenuGrid
			// 
			this.contextMenuGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemInvertSelected,
            this.toolStripMenuItemCheckSelected,
            this.toolStripMenuItemUncheckSelected});
			this.contextMenuGrid.Name = "contextMenuGrid";
			this.contextMenuGrid.Size = new System.Drawing.Size(170, 70);
			this.contextMenuGrid.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuGrid_ItemClicked);
			// 
			// toolStripMenuItemInvertSelected
			// 
			this.toolStripMenuItemInvertSelected.Name = "toolStripMenuItemInvertSelected";
			this.toolStripMenuItemInvertSelected.Size = new System.Drawing.Size(169, 22);
			this.toolStripMenuItemInvertSelected.Tag = "invert";
			this.toolStripMenuItemInvertSelected.Text = "Invert Selected";
			// 
			// toolStripMenuItemCheckSelected
			// 
			this.toolStripMenuItemCheckSelected.Name = "toolStripMenuItemCheckSelected";
			this.toolStripMenuItemCheckSelected.Size = new System.Drawing.Size(169, 22);
			this.toolStripMenuItemCheckSelected.Tag = "check";
			this.toolStripMenuItemCheckSelected.Text = "Check Selected";
			// 
			// toolStripMenuItemUncheckSelected
			// 
			this.toolStripMenuItemUncheckSelected.Name = "toolStripMenuItemUncheckSelected";
			this.toolStripMenuItemUncheckSelected.Size = new System.Drawing.Size(169, 22);
			this.toolStripMenuItemUncheckSelected.Tag = "uncheck";
			this.toolStripMenuItemUncheckSelected.Text = "Uncheck Selected";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = global::NameFix.Properties.Settings.Default.ClientSize;
			this.Controls.Add(this.panelMain);
			this.Controls.Add(this.groupBoxLog);
			this.Controls.Add(this.statusStrip);
			this.Controls.Add(this.toolStrip1);
			this.Controls.Add(this.menuStrip1);
			this.DataBindings.Add(new System.Windows.Forms.Binding("Location", global::NameFix.Properties.Settings.Default, "Location", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.DataBindings.Add(new System.Windows.Forms.Binding("ClientSize", global::NameFix.Properties.Settings.Default, "ClientSize", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.Location = global::NameFix.Properties.Settings.Default.Location;
			this.MinimumSize = new System.Drawing.Size(625, 420);
			this.Name = "MainForm";
			this.Text = "PhotoName2Date";
			this.Load += new System.EventHandler(this.FormMain_Load);
			this.groupBoxOptions.ResumeLayout(false);
			this.panelOptions4.ResumeLayout(false);
			this.panelOptions4.PerformLayout();
			this.panelOptions3.ResumeLayout(false);
			this.panelOptions3.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownHoursShift)).EndInit();
			this.panelOptions2.ResumeLayout(false);
			this.panelOptions2.PerformLayout();
			this.panelOptions1.ResumeLayout(false);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.statusStrip.ResumeLayout(false);
			this.statusStrip.PerformLayout();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.errorProviderPath)).EndInit();
			this.groupBoxLog.ResumeLayout(false);
			this.panelMain.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewFiles)).EndInit();
			this.contextMenuGrid.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBoxOptions;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
		private System.Windows.Forms.StatusStrip statusStrip;
		private System.Windows.Forms.Panel panelOptions1;
		private System.Windows.Forms.Label labelMask;
		private System.Windows.Forms.ComboBox comboBoxMasks;
		private System.Windows.Forms.CheckBox checkBoxRecurseSubfolders;
		private System.Windows.Forms.Label labelShiftTimeBy;
		private System.Windows.Forms.Panel panelOptions2;
		private System.Windows.Forms.ComboBox comboBoxFolders;
		private System.Windows.Forms.Button buttonSelectFolder;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton toolStripButtonPreview;
		private System.Windows.Forms.ErrorProvider errorProviderPath;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
		private System.Windows.Forms.Label labelDir;
		private System.Windows.Forms.GroupBox groupBoxLog;
		private System.Windows.Forms.ListBox listBoxLog;
		private System.Windows.Forms.Panel panelOptions3;
		private System.Windows.Forms.CheckBox checkBoxNeedTouch;
		private System.Windows.Forms.NumericUpDown numericUpDownHoursShift;
		private System.Windows.Forms.Label labelHours;
		private System.Windows.Forms.ToolStripButton toolStripButtonCancel;
		private System.Windows.Forms.Panel panelMain;
		private System.Windows.Forms.DataGridView dataGridViewFiles;
		//private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
		//private System.Windows.Forms.DataGridViewTextBoxColumn fullFilenameDataGridViewTextBoxColumn;
		//private System.Windows.Forms.DataGridViewTextBoxColumn filepathDataGridViewTextBoxColumn;
		//private System.Windows.Forms.DataGridViewTextBoxColumn filenameOnlyDataGridViewTextBoxColumn;
		//private System.Windows.Forms.DataGridViewTextBoxColumn extDataGridViewTextBoxColumn;
		//private System.Windows.Forms.DataGridViewTextBoxColumn newFilenameOnlyDataGridViewTextBoxColumn;
		//private System.Windows.Forms.DataGridViewTextBoxColumn shiftedDateTimeDataGridViewTextBoxColumn;
		//private System.Windows.Forms.DataGridViewCheckBoxColumn needProcessDataGridViewCheckBoxColumn;
		private System.Windows.Forms.ToolStripButton toolStripButtonRename;
		private System.Windows.Forms.ContextMenuStrip contextMenuGrid;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemInvertSelected;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCheckSelected;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemUncheckSelected;
		private System.Windows.Forms.TextBox textBoxPattern;
		private System.Windows.Forms.Label labelPattern;
		private System.Windows.Forms.Panel panelOptions4;
		private System.Windows.Forms.CheckBox checkBoxShowAffectedOnly;
	}
}


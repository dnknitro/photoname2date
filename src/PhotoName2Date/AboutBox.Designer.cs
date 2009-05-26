namespace PhotoName2Date {
	partial class AboutBox {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutBox));
			this.logoPictureBox = new System.Windows.Forms.PictureBox();
			this.labelProductName = new System.Windows.Forms.Label();
			this.labelVersion = new System.Windows.Forms.Label();
			this.labelCopyright = new System.Windows.Forms.Label();
			this.textBoxDescription = new System.Windows.Forms.TextBox();
			this.okButton = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.linkLabelCashamplifier = new System.Windows.Forms.LinkLabel();
			this.linkLabelDonate = new System.Windows.Forms.LinkLabel();
			this.linkLabelSupport = new System.Windows.Forms.LinkLabel();
			this.linkLabelMail = new System.Windows.Forms.LinkLabel();
			((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).BeginInit();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// logoPictureBox
			// 
			this.logoPictureBox.Dock = System.Windows.Forms.DockStyle.Left;
			this.logoPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("logoPictureBox.Image")));
			this.logoPictureBox.Location = new System.Drawing.Point(15, 15);
			this.logoPictureBox.Name = "logoPictureBox";
			this.logoPictureBox.Size = new System.Drawing.Size(128, 296);
			this.logoPictureBox.TabIndex = 12;
			this.logoPictureBox.TabStop = false;
			// 
			// labelProductName
			// 
			this.labelProductName.Dock = System.Windows.Forms.DockStyle.Top;
			this.labelProductName.Location = new System.Drawing.Point(0, 34);
			this.labelProductName.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
			this.labelProductName.MaximumSize = new System.Drawing.Size(0, 17);
			this.labelProductName.Name = "labelProductName";
			this.labelProductName.Size = new System.Drawing.Size(294, 17);
			this.labelProductName.TabIndex = 19;
			this.labelProductName.Text = "Product Name";
			this.labelProductName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelVersion
			// 
			this.labelVersion.Dock = System.Windows.Forms.DockStyle.Top;
			this.labelVersion.Location = new System.Drawing.Point(0, 17);
			this.labelVersion.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
			this.labelVersion.MaximumSize = new System.Drawing.Size(0, 17);
			this.labelVersion.Name = "labelVersion";
			this.labelVersion.Size = new System.Drawing.Size(294, 17);
			this.labelVersion.TabIndex = 0;
			this.labelVersion.Text = "Version";
			this.labelVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelCopyright
			// 
			this.labelCopyright.Dock = System.Windows.Forms.DockStyle.Top;
			this.labelCopyright.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.labelCopyright.Location = new System.Drawing.Point(0, 0);
			this.labelCopyright.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
			this.labelCopyright.MaximumSize = new System.Drawing.Size(0, 17);
			this.labelCopyright.Name = "labelCopyright";
			this.labelCopyright.Size = new System.Drawing.Size(294, 17);
			this.labelCopyright.TabIndex = 21;
			this.labelCopyright.Text = "Copyright";
			this.labelCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxDescription
			// 
			this.textBoxDescription.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBoxDescription.Location = new System.Drawing.Point(0, 147);
			this.textBoxDescription.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
			this.textBoxDescription.Multiline = true;
			this.textBoxDescription.Name = "textBoxDescription";
			this.textBoxDescription.ReadOnly = true;
			this.textBoxDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textBoxDescription.Size = new System.Drawing.Size(294, 118);
			this.textBoxDescription.TabIndex = 23;
			this.textBoxDescription.TabStop = false;
			this.textBoxDescription.Text = "Description";
			// 
			// okButton
			// 
			this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.okButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.okButton.Location = new System.Drawing.Point(362, 288);
			this.okButton.Name = "okButton";
			this.okButton.Size = new System.Drawing.Size(75, 23);
			this.okButton.TabIndex = 24;
			this.okButton.Text = "&OK";
			this.okButton.Click += new System.EventHandler(this.okButton_Click);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.textBoxDescription);
			this.panel1.Controls.Add(this.linkLabelCashamplifier);
			this.panel1.Controls.Add(this.linkLabelDonate);
			this.panel1.Controls.Add(this.linkLabelSupport);
			this.panel1.Controls.Add(this.linkLabelMail);
			this.panel1.Controls.Add(this.labelProductName);
			this.panel1.Controls.Add(this.labelVersion);
			this.panel1.Controls.Add(this.labelCopyright);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(143, 15);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(294, 265);
			this.panel1.TabIndex = 13;
			// 
			// linkLabelCashamplifier
			// 
			this.linkLabelCashamplifier.Dock = System.Windows.Forms.DockStyle.Top;
			this.linkLabelCashamplifier.Location = new System.Drawing.Point(0, 123);
			this.linkLabelCashamplifier.Name = "linkLabelCashamplifier";
			this.linkLabelCashamplifier.Size = new System.Drawing.Size(294, 24);
			this.linkLabelCashamplifier.TabIndex = 27;
			this.linkLabelCashamplifier.TabStop = true;
			this.linkLabelCashamplifier.Text = "see also: www.cashamplifier.com";
			this.linkLabelCashamplifier.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.linkLabelCashamplifier.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelCashamplifier_LinkClicked);
			// 
			// linkLabelDonate
			// 
			this.linkLabelDonate.Dock = System.Windows.Forms.DockStyle.Top;
			this.linkLabelDonate.Location = new System.Drawing.Point(0, 99);
			this.linkLabelDonate.Name = "linkLabelDonate";
			this.linkLabelDonate.Size = new System.Drawing.Size(294, 24);
			this.linkLabelDonate.TabIndex = 26;
			this.linkLabelDonate.TabStop = true;
			this.linkLabelDonate.Text = "donate";
			this.linkLabelDonate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.linkLabelDonate.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelDonate_LinkClicked);
			// 
			// linkLabelSupport
			// 
			this.linkLabelSupport.Dock = System.Windows.Forms.DockStyle.Top;
			this.linkLabelSupport.Location = new System.Drawing.Point(0, 75);
			this.linkLabelSupport.Name = "linkLabelSupport";
			this.linkLabelSupport.Size = new System.Drawing.Size(294, 24);
			this.linkLabelSupport.TabIndex = 25;
			this.linkLabelSupport.TabStop = true;
			this.linkLabelSupport.Text = "program web page";
			this.linkLabelSupport.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.linkLabelSupport.Click += new System.EventHandler(this.linkLabelSupport_Click);
			// 
			// linkLabelMail
			// 
			this.linkLabelMail.Dock = System.Windows.Forms.DockStyle.Top;
			this.linkLabelMail.Location = new System.Drawing.Point(0, 51);
			this.linkLabelMail.Name = "linkLabelMail";
			this.linkLabelMail.Size = new System.Drawing.Size(294, 24);
			this.linkLabelMail.TabIndex = 24;
			this.linkLabelMail.TabStop = true;
			this.linkLabelMail.Text = "vova64@gmail.com";
			this.linkLabelMail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.linkLabelMail.Click += new System.EventHandler(this.linkLabelMail_Click);
			// 
			// AboutBox
			// 
			this.AcceptButton = this.okButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(452, 326);
			this.Controls.Add(this.okButton);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.logoPictureBox);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AboutBox";
			this.Padding = new System.Windows.Forms.Padding(15);
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "AboutBox";
			((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PictureBox logoPictureBox;
		private System.Windows.Forms.Label labelProductName;
		private System.Windows.Forms.Label labelVersion;
		private System.Windows.Forms.Label labelCopyright;
		private System.Windows.Forms.TextBox textBoxDescription;
		private System.Windows.Forms.Button okButton;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.LinkLabel linkLabelMail;
		private System.Windows.Forms.LinkLabel linkLabelSupport;
		private System.Windows.Forms.LinkLabel linkLabelDonate;
		private System.Windows.Forms.LinkLabel linkLabelCashamplifier;
	}
}

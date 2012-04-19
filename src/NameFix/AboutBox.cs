using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace NameFix
{
	internal partial class AboutBox : Form
	{
		public AboutBox()
		{
			InitializeComponent();
			Text = String.Format("About {0}", AssemblyTitle);
			labelProductName.Text = AssemblyProduct;
			labelVersion.Text = String.Format("Version {0}", AssemblyVersion);
			labelCopyright.Text = AssemblyCopyright;
			textBoxDescription.Text = AssemblyDescription;
		}

		#region Assembly Attribute Accessors

		public string AssemblyTitle
		{
			get
			{
				var attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
				if(attributes.Length > 0)
				{
					var titleAttribute = (AssemblyTitleAttribute)attributes[0];
					if(titleAttribute.Title != "")
					{
						return titleAttribute.Title;
					}
				}
				return Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
			}
		}

		public string AssemblyVersion
		{
			get {return Assembly.GetExecutingAssembly().GetName().Version.ToString();}
		}

		public string AssemblyDescription
		{
			get
			{
				var attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute),
					false);
				if(attributes.Length == 0)
				{
					return "";
				}
				return ((AssemblyDescriptionAttribute)attributes[0]).Description;
			}
		}

		public string AssemblyProduct
		{
			get
			{
				var attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
				if(attributes.Length == 0)
				{
					return "";
				}
				return ((AssemblyProductAttribute)attributes[0]).Product;
			}
		}

		public string AssemblyCopyright
		{
			get
			{
				var attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
				if(attributes.Length == 0)
				{
					return "";
				}
				return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
			}
		}

		public string AssemblyCompany
		{
			get
			{
				var attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
				if(attributes.Length == 0)
				{
					return "";
				}
				return ((AssemblyCompanyAttribute)attributes[0]).Company;
			}
		}

		#endregion

		private void okButton_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void linkLabelMail_Click(object sender, EventArgs e)
		{
			Process.Start("mailto:" + linkLabelMail.Text);
		}

		private void linkLabelSupport_Click(object sender, EventArgs e)
		{
			Process.Start("http://code.google.com/p/photoname2date/");
		}

		private void linkLabelDonate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start(
				"https://www.paypal.com/cgi-bin/webscr?cmd=_xclick&business=payments@cashamplifier.com&no_shipping=1&no_note=1&currency_code=USD&lc=US&bn=PP-DonationsBF&item_name=PhotoName2Date%20donation");
		}

		protected override bool ProcessDialogKey(Keys keyData)
		{
			var key = keyData;
			if(key == Keys.Escape)
			{
				Close();
				return true;
			}
			return base.ProcessDialogKey(keyData);
		}
	}
}
using System;
using System.Windows.Forms;

namespace moleQule.Face.Application
{
	public partial class AboutForm : moleQule.Face.ChildForm
	{

		#region Business Methods

		public const string ID = "AboutForm";
		public static Type Type { get { return typeof(AboutForm); } }

		#endregion

		#region Factory Methods

		public AboutForm() 
			: base (true, null)
		{
			InitializeComponent();
			iQ_LL.Links.Add(new LinkLabel.Link(0, 20, "iqingenieros.com"));

            this.Text = Resources.Labels.ABOUT_TITLE + " " + 
                        System.Windows.Forms.Application.ProductName + " " + 
                        System.Windows.Forms.Application.ProductVersion;
		}

		#endregion

		#region Events

		private void iQ_LL_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			string target = e.Link.LinkData as string;
			System.Diagnostics.Process.Start(e.Link.LinkData.ToString());
		}

		#endregion

	}
}


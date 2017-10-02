namespace moleQule.Autopilot
{
	partial class ProjectInstaller
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.AutopilotServiceProcessInstaller = new System.ServiceProcess.ServiceProcessInstaller();
			this.AutopilotServiceInstaller = new System.ServiceProcess.ServiceInstaller();
			// 
			// AutopilotServiceProcessInstaller
			// 
			this.AutopilotServiceProcessInstaller.Account = System.ServiceProcess.ServiceAccount.LocalService;
			this.AutopilotServiceProcessInstaller.Password = null;
			this.AutopilotServiceProcessInstaller.Username = null;
			// 
			// AutopilotServiceInstaller
			// 
			this.AutopilotServiceInstaller.Description = "Piloto automático de moleQule";
			this.AutopilotServiceInstaller.DisplayName = "moleQule Autopilot Service ";
			this.AutopilotServiceInstaller.ServiceName = "moleQule.Autopilot";
			this.AutopilotServiceInstaller.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
			// 
			// ProjectInstaller
			// 
			this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.AutopilotServiceProcessInstaller,
            this.AutopilotServiceInstaller});

		}

		#endregion

		private System.ServiceProcess.ServiceProcessInstaller AutopilotServiceProcessInstaller;
		private System.ServiceProcess.ServiceInstaller AutopilotServiceInstaller;
	}
}
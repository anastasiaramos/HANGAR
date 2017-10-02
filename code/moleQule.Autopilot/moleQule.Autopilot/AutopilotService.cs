using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Timers;

using moleQule.Library;

namespace moleQule.Autopilot
{
    public partial class AutopilotService : System.ServiceProcess.ServiceBase
	{
		#region Attibutes & Properties

		private bool _isLogEnabled = false;
		private System.Timers.Timer _timer;

		#endregion

		#region Factory Methods

		public AutopilotService()
		{
			InitializeComponent();
		}

		protected override void OnStart(string[] args)
		{
			this.InitTimer();

			_timer.Start();
		}

		protected override void OnStop()
		{
			_timer.Stop();
		}

		#endregion

		#region Business Methods
		
		protected void InitTimer()
		{
			string setting = System.Configuration.ConfigurationManager.AppSettings["LogEnabled"];
			bool.TryParse(setting, out _isLogEnabled); 
			
			try
			{
				string msg = "AUTOPILOT SERVICE START";
				this.EventLog.WriteEntry(msg, EventLogEntryType.Information, 20);

				if (_isLogEnabled) MyLogger.LogText(msg);

				_timer = new System.Timers.Timer();
				_timer.Enabled = false;
				_timer.Elapsed += new ElapsedEventHandler(_timer_Elapsed);

				setting = System.Configuration.ConfigurationManager.AppSettings["PullInterval"];
				double interval = 3600;

				if (double.TryParse(setting, out interval))
 					_timer.Interval = interval * 1000;
				else
					_timer.Interval = 3600 * 1000;

				_timer.Start();

				msg = string.Format("Tick every {0} s. EventLog is {1}\r\n",
							_timer.Interval / 1000,
							_isLogEnabled ? "enabled" : "disabled"
				);
				this.EventLog.WriteEntry(msg, EventLogEntryType.Information, 20);

				if (_isLogEnabled)	MyLogger.LogText(msg);
				
			}
			catch (Exception ex)
			{
				string msg = "AUTOPILOT SERVICE ERROR:  " + ex.Message;
				this.EventLog.WriteEntry(msg, EventLogEntryType.Error, 100);
				if (_isLogEnabled) MyLogger.LogText(msg);
			}
		}

		#endregion

		#region Events

		void _timer_Elapsed(object sender, ElapsedEventArgs e)
		{
			try
			{
				string msg = "TIMER ELAPSED START";
				this.EventLog.WriteEntry(msg, EventLogEntryType.Information, 100);

				Autopilot.Instance.Run();
				BaQup.Instance.Run();

				this.EventLog.WriteEntry("TIMER ELAPSED FINISH", EventLogEntryType.Information, 100);
			}
			catch (Exception ex)
			{
				if (_isLogEnabled) MyLogger.LogText("TIMER ELAPSED ERROR: " + ex.Message);
				this.EventLog.WriteEntry(ex.ToString(), EventLogEntryType.Error, 100);
			}
		}

		#endregion
	}
}

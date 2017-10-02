using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace moleQule.Autopilot
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		static void Main()
		{
#if DEBUG
			Autopilot.Instance.Run();
			BaQup.Instance.Run();
#else
			ServiceBase[] ServicesToRun;
			ServicesToRun = new ServiceBase[] 
			{ 
				new AutopilotService() 
			};

			ServiceBase.Run(ServicesToRun);
#endif
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using moleQule.Library;
using moleQule.Library.Common;
using moleQule.Library.Application;

namespace moleQule.Autopilot
{
    class Autopilot
	{
		#region Attributes

		EStatus Status { get; set; }

		#endregion

		#region Factory Methods

		private static Autopilot _singleton = null;

        public static Autopilot Instance { get { return _singleton != null ? _singleton : new Autopilot(); } }

        public Autopilot()
        {
            _singleton = this;

			Status = EStatus.OK;
        }

        public void Run()
        {
            if (Status == EStatus.Working) return;

            Status = EStatus.Working;

            bool _isLogEnabled = false;
            string setting = System.Configuration.ConfigurationManager.AppSettings["LogEnabled"];
            bool.TryParse(setting, out _isLogEnabled);

            CompanyList empresas = null;

            try
            {
                if (_isLogEnabled)
                {
                    string msg = "AUTOPILOT::START";
                    MyLogger.LogText(msg);
                }

                AppController.Instance.InitFromService();
                Principal.Login();

                empresas = CompanyList.GetList(AppContext.User.GetInfo(), false);

                foreach (CompanyInfo item in empresas)
                {
                    MyLogger.LogText("AUTOPILOT::INFO: SCHEMA '" + item.Name + "'");

                    AppContext.Principal.ChangeUserSchema((item as ISchemaInfo));
                    AppController.Instance.AutoPilot();
                }

                if (_isLogEnabled)
                {
                    string msg = "AUTOPILOT::FINISH";
                    MyLogger.LogText(msg);
                }

                Status = EStatus.Closed;
            }
            catch (Exception ex)
            {
                Status = EStatus.Error;

                if (_isLogEnabled)
                {
                    MyLogger.LogText("AUTOPILOT::ERROR: " + iQExceptionHandler.GetAllMessages(ex, true));
                }
            }
            finally
            {
                AppController.Instance.Close();
            }
        }

        #endregion
    }
}

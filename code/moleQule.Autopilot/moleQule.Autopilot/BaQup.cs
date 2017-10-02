using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using moleQule.Library;
using moleQule.Library.Common;
using moleQule.Library.Application;

namespace moleQule.Autopilot
{
    class BaQup
    {
        #region Attributes

        EStatus Status { get; set; }

        #endregion

        #region Factory Methods

        private static BaQup _singleton = null;

        public static BaQup Instance { get { return _singleton != null ? _singleton : new BaQup(); } }

        public BaQup()
        {
            _singleton = this;

            Status = EStatus.OK;
        }

        public void Run()
        {
            if (Status == EStatus.Working) return;

            Status = EStatus.Working;

            try
            {
                MyLogger.LogText("BAQUP START", "BaQup::Run");

                try
                {
                    AppController.Instance.InitFromService(BackupErrorHandler);
                    Principal.Login(Library.SettingsMng.GetServicesUser(), Library.SettingsMng.GetServicesPassword());

                    Library.SettingsMng.Instance.SetBackupsPath(Properties.Settings.Default.BACKUPS_PATH);

                    CompanyList companies = CompanyList.GetList(AppContext.User.GetInfo(), false);

                    AppController.AutoBackup(companies.ToList<ISchemaInfo>(), true);

                    MyLogger.LogText("BAQUP FINISH", "BaQup::Run");
                }
                catch (Exception ex)
                {
                    Status = EStatus.Error;
                    MyLogger.LogException(ex, "BaQup::Run");
                }

                Status = EStatus.Closed;
            }
            catch (Exception ex)
            {
                Status = EStatus.Error;
                MyLogger.LogException(ex, "BaQup::Run");
            }
            finally
            {
                AppController.Instance.Close();
            }
        }

        public void BackupErrorHandler(object sender, iQExceptionHandler.ErrorEventArgs e)
        {
            Status = EStatus.Error;

            switch (e.Exception.Code)
            {
                case iQExceptionCode.INFO:
                    MyLogger.LogText("BAQUP::INFO: " + e.Exception.Message);
                    break;

                default:
                    MyLogger.LogException(e.Exception, "BaQup::BackupErrorHandler");
                    break;
            }
        }

        #endregion
    }
}
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Windows.Forms;
using System.ComponentModel;

using Csla;
using Csla.Security;
using moleQule.Library;
using moleQule.Library.CslaEx;
using moleQule.Library.Common;
using moleQule.Library.Application.Resources;
using moleQule.Library.Application.Properties;
using moleQule.Library.Invoice;

namespace moleQule.Library.Application
{
    [Serializable()]
    public class Principal : moleQule.Library.PrincipalBase, IPrincipalEx
    {

        #region Factory Methods

        /// <summary>
        /// Contructor 
        /// </summary>
        /// <param name="identity"></param>
        protected Principal(IIdentityEx identity)
            : base(identity) { }

        public static void ResetDBEngine()
        {
            SetDBName();
            SetDBVersion();
            SetDBPassword();

            InitnHManager();
        }

        public override void LoadUserContext()
        {
            if (AppContext.Principal == null) return;

            base.LoadUserContext();

            CompanyInfo company = AppContext.ActiveSchema as CompanyInfo;
            if (company != null) company.SetCurrency();
        }

        #endregion

        #region Settings

        public new static void SaveSettings() { Settings.Default.Save(); }

        /// <summary>
        /// Devuelve la configuración de los backups automáticos
        /// </summary>
        public static int GetAutoBackups()
        {
            Configuration cfg = ConfigurationManager.OpenExeConfiguration(System.Windows.Forms.Application.StartupPath + Settings.Default.Project + ".exe");
            return Convert.ToInt32(cfg.AppSettings.Settings["BACKUPS"]);
        }

        public static string GetDBVersion()
        {
            return Settings.Default.DB_VERSION;
        }

        public static string GetFomentoFolder()
        {
            string folder = SettingsMng.Instance.UserSettings.GetValue(Settings.Default.SETTING_NAME_FOMENTO_FOLDER);

            return (Directory.Exists(folder) ? folder : System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop));
        }

        public static void SetFomentoFolder(string value)
        {
            SettingsMng.Instance.UserSettings.SetValue(Settings.Default.SETTING_NAME_FOMENTO_FOLDER, value);
        }
        public static string GetCurrentApplicationVersion()
        {
            return SettingsMng.Instance.GetCurrentApplicationVersion();
        }

        public static void SetCurrentApplicationVersion(string value)
        {
            SettingsMng.Instance.SetCurrentApplicationVersion(value);
            Properties.Settings.Default.APPLICATION_VERSION = value;
            Properties.Settings.Default.Save();
        }

        public static string GetLANServer()
        {
            return SettingsMng.Instance.GetLANServer();
        }

        public static void SetLANServer(string value)
        {
            SettingsMng.Instance.SetLANServer(value);
            Properties.Settings.Default.LAN_HOST = value;
            Properties.Settings.Default.Save();
        }

        public static string GetLastUser()
        {
            return SettingsMng.Instance.GetLastUser();
        }

        public static void SetLastUser(string value)
        {
            SettingsMng.Instance.SetLastUser(value);
            Properties.Settings.Default.LAST_USER = value;
            Properties.Settings.Default.Save();
        }

        public static string GetWANServer()
        {
            return SettingsMng.Instance.GetWANServer();
        }

        public static void SetWANServer(string value)
        {
            SettingsMng.Instance.SetWANServer(value);
            Properties.Settings.Default.WAN_HOST = value;
            Properties.Settings.Default.Save();
        }

        public static string GetLastServer()
        {
            return SettingsMng.Instance.GetActiveServer();
        }

        public static void SetLastServer(string value)
        {
            SettingsMng.Instance.SetActiveServer(value);
            Properties.Settings.Default.LAST_SERVER = value;
            Properties.Settings.Default.Save();
        }

        public static void SetInstructionBarView(bool value)
        {
            Settings.Default.INSTRUCTION_TOOLBAR = value;
            Settings.Default.Save();
        }
        public static bool GetInstructionBarView() { return Settings.Default.INSTRUCTION_TOOLBAR; }

        public static void SetQualityBarView(bool value)
        {
            Settings.Default.QUALITY_TOOLBAR = false;//value;
            Settings.Default.Save();
        }
        public static bool GetQualityBarView() { return false;}// Settings.Default.QUALITY_TOOLBAR; }

        public static void SetInvoiceBarView(bool value)
        {
            Settings.Default.INVOICE_TOOLBAR = false;//value;
            Settings.Default.Save();
        }
        public static bool GetInvoiceBarView() { return false; }//Settings.Default.INVOICE_TOOLBAR; }

        public static int GetPlazoMaximoGeneracionInforme()
        {
            return Settings.Default.PLAZO_MAXIMO_GENERACION_INFORME;
        }
        public static void SetPlazoMaximoGeneracionInforme(int value)
        {
            Settings.Default.PLAZO_MAXIMO_GENERACION_INFORME = value;
            Settings.Default.Save();
        }

        public static decimal GetPlazoMaximoAmpliacion()
        {
            return Settings.Default.PLAZO_MAXIMO_AMPLIACION;
        }
        public static void SetPlazoMaximoAmpliacion(decimal value)
        {
            Settings.Default.PLAZO_MAXIMO_AMPLIACION = value;
            Settings.Default.Save();
        }

        public static int GetPlazoMaximoDiscrepanciasN1()
        {
            return Settings.Default.PLAZO_MAXIMO_DISCREPANCIAS_N1;
        }
        public static void SetPlazoMaximoDiscrepanciasN1(int value)
        {
            Settings.Default.PLAZO_MAXIMO_DISCREPANCIAS_N1 = value;
            Settings.Default.Save();
        }

        public static int GetPlazoMaximoDiscrepanciasN2()
        {
            return Settings.Default.PLAZO_MAXIMO_DISCREPANCIAS_N2;
        }
        public static void SetPlazoMaximoDiscrepanciasN2(int value)
        {
            Settings.Default.PLAZO_MAXIMO_DISCREPANCIAS_N2 = value;
            Settings.Default.Save();
        }

        public static int GetPlazoMaximoDiscrepanciasN3()
        {
            return Settings.Default.PLAZO_MAXIMO_DISCREPANCIAS_N3;
        }
        public static void SetPlazoMaximoDiscrepanciasN3(int value)
        {
            Settings.Default.PLAZO_MAXIMO_DISCREPANCIAS_N3 = value;
            Settings.Default.Save();
        }

        public static int GetPlazoMaximoNotificacionDiscrepancias()
        {
            return Settings.Default.PLAZO_MAXIMO_NOTIFICACION_DISCREPANCIAS;
        }
        public static void SetPlazoMaximoNotificacionDiscrepancias(int value)
        {
            Settings.Default.PLAZO_MAXIMO_NOTIFICACION_DISCREPANCIAS = value;
            Settings.Default.Save();
        }

        public static int GetPlazoMaximoNotificacionFinAuditoria()
        {
            return Settings.Default.PLAZO_MAXIMO_NOTIFICACION_FIN_AUDITORIA;
        }
        public static void SetPlazoMaximoNotificacionFinAuditoria(int value)
        {
            Settings.Default.PLAZO_MAXIMO_NOTIFICACION_FIN_AUDITORIA = value;
            Settings.Default.Save();
        }

        public static int GetPlazoMaximoRespuestaAmpliacion()
        {
            return Settings.Default.PLAZO_MAXIMO_RESPUESTA_AMPLIACION;
        }
        public static void SetPlazoMaximoRespuestaAmpliacion(int value)
        {
            Settings.Default.PLAZO_MAXIMO_RESPUESTA_AMPLIACION = value;
            Settings.Default.Save();
        }

        public new static void UpgradeSettings(string appVersion)
        {
            if (SettingsMng.Instance.GetApplicationVersion() != appVersion.ToString())
                Properties.Settings.Default.Upgrade();
        }

        #endregion

        #region Business Methods

        /// <summary>
        /// Elimina todos los datos asociados al esquema activo
        /// tanto los propios como los de las entidades que contiene
        /// </summary>
        /// <param name="oid"></param>
        public override void DeleteSchema(ISchema schema)
        {
            Cliente.DeleteAll();

            base.DeleteSchema(schema);
        }

        #endregion

        #region Login/Logout

        public new static void Login() { Login(SettingsMng.Instance.GetDBUser(), SettingsMng.Instance.GetDBPassword(), string.Empty); }
        public new static void Login(string username, string password) { Login(username, password, string.Empty); }
        public new static bool Login(string username, string password, string server)
        {
            List<string> servers = new List<string>();

            if (server != string.Empty) servers.Add(server);
            //servers.Add(GetActiveServer());
            if (SettingsMng.Instance.GetLANServer() != string.Empty) servers.Add(SettingsMng.Instance.GetLANServer());
            if (SettingsMng.Instance.GetWANServer() != string.Empty) servers.Add(SettingsMng.Instance.GetWANServer());
            servers.Add(nHManager.Instance.Host);

            for (int i = 1; i <= servers.Count; i++)
            {
                try
                {
                    nHManager.Instance.SetCredentials(User.MapToDBUsername(username), password, string.Empty, servers[i - 1]);

                    if (DoLogin(username, password))
                    {
                        SettingsMng.Instance.SetDBUser(username);
                        SettingsMng.Instance.SetDBPassword(password);

                        return true;
                    }
                    else
                        ClearCredentials(username);

                    return false;
                }
                catch (Exception ex)
                {
                    iQException iQex = iQExceptionHandler.ConvertToiQException(ex);

                    switch (iQex.Code)
                    {
                        case iQExceptionCode.SERVER_NOT_FOUND:
                            if (i == servers.Count) throw iQex;
                            break;

                        case iQExceptionCode.DB_VERSION_MISSMATCH:
                            throw iQex;

                        case iQExceptionCode.PASSWORD_FAILED:
                            throw new iQAuthorizationException(string.Format(moleQule.Library.Resources.Errors.LOGIN_FAILED, username),
                                                                iQex.SysMessage,
                                                                iQex.Code);
                        case iQExceptionCode.LOCKED_USER:
                            throw new iQAuthorizationException(string.Format(moleQule.Library.Resources.Errors.USER_LOCKED, username),
                                                                iQex.SysMessage,
                                                                iQex.Code);

                        case iQExceptionCode.LOCKED_ROW:
                            throw new iQLockException(string.Format(moleQule.Library.Resources.Errors.USER_LOGGED, username));

                        default:
                            throw iQex;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Realiza un login en la aplicación
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        internal static bool DoLogin(string username, string password)
        {
            User user = null;

            try
            {
                //Control de SQL Injection
                if (username.Contains(" ") || password.Contains(" "))
                    throw new iQException(moleQule.Library.Resources.Messages.SQL_INYECTION);

                user = User.Get(username, password);

                if (user != null)
                {
                    if (user.EEstado == EEstadoItem.LockedOut)
                        throw new iQAuthorizationException(iQExceptionCode.LOCKED_USER);

                    user.LoadPrivileges();

                    if (user.Name != SettingsMng.Instance.GetDBUser())
                    {
                        user.LastLoginDate = DateTime.Now;
                        user.Save();
                    }

                    if (AppContext.Principal != null) AppContext.Principal.Close();

                    Principal principal = new Principal(user);
                    AppContext.Principal = principal;

                    principal.LoadUserContext();
                }

                return (user != null) && user.IsAuthenticated;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (user != null) user.CloseSession();
            }
        }

        #endregion

        #region DB

        public static void SetDBName()
        {
#if DEBUG
            SettingsMng.Instance.SetDBName("HANGAR");
#endif
#if DEMO
           SettingsMng.Instance.SetDBName(Settings.Default.DB_NAME);
#endif
#if STAGING
           SettingsMng.Instance.SetDBName(Settings.Default.DB_NAME);
#endif
#if RELEASE
           SettingsMng.Instance.SetDBName(Settings.Default.DB_NAME);
#endif
        }

        public static void SetDBVersion()
        {
            SettingsMng.Instance.SetDBVersion(Settings.Default.DB_VERSION);
        }

        public static void SetDBPassword()
        {
#if DEBUG
            SettingsMng.Instance.SetDBPassword("iQi_1998");
#endif
#if DEMO
           SettingsMng.Instance.SetDBPassword("iQi_1998");
#endif
#if STAGING
           SettingsMng.Instance.SetDBPassword("iQi_1998");
#endif
#if RELEASE
SettingsMng.Instance.SetDBPassword("iQi_1998");
#endif
        }

        #endregion

    }
}
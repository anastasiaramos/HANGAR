using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Reflection;

using Csla;
using Csla.Security;
using moleQule.Library;
using moleQule.Library.Application;
using moleQule.Library.Application.Resources;
using moleQule.Library.Application.Properties;
using moleQule.Library.Common;
using moleQule.Library.CslaEx;
using moleQule.Library.Invoice;
using moleQule.Library.Store;
using moleQule.Library.Instruction;
using moleQule.Library.Quality;

namespace moleQule.Library.Application
{
    /// <summary>
    /// 
    /// </summary>
	[Serializable()]
	public class AppController : moleQule.Library.AppControllerBase, IController
    {
        #region Labels

        public static string APP_TITLE { get { return Settings.Default.Project; } }

        #endregion

        #region Paths

        //MAIN
        public static string ICONOS_PATH { get { return Reg32GetServerPath() + Resources.Paths.RESOURCES_ROOT + Resources.Paths.ICONOS; } }

        //INVOICE
        public static string FOTOS_EMPLEADOS_PATH { get { return Library.Store.ModuleController.FOTOS_EMPLEADOS_PATH; } }

        //INSTRUCTION
        public static string FOTOS_INSTRUCTORES_PATH { get { return Reg32GetServerPath() + Resources.Paths.RESOURCES_ROOT + Resources.Paths.FOTO_INSTRUCTORES; } }
        public static string FOTOS_ALUMNOS_PATH { get { return Reg32GetServerPath() + Resources.Paths.RESOURCES_ROOT + Resources.Paths.FOTO_ALUMNOS; } }
        public static string FOTOS_PREGUNTAS_PATH { get { return Reg32GetServerPath() + Resources.Paths.RESOURCES_ROOT + Resources.Paths.FOTO_PREGUNTAS; } }
        public static string FOTOS_PREGUNTAS_EXAMEN_PATH { get { return Reg32GetServerPath() + Resources.Paths.RESOURCES_ROOT + Resources.Paths.FOTO_PREGUNTAS_EXAMENES; } }

        public static string HELP_PATH { get { return Library.Common.ModuleController.HELP_PATH; } }
        public static string LOGOS_EMPRESAS_PATH { get { return Library.Common.ModuleController.LOGOS_EMPRESAS_PATH; } }
        public static new string NH_CONFIG_FILE_PATH { get { return moleQule.Library.Resources.Paths.NH_CONFIG_FILES + moleQule.Library.Resources.Paths.NH_MAIN_CONFIG_FILE; } }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Única instancia de la clase ControlerBase (Singleton)
        /// </summary>
        protected static AppController _main;

        /// <summary>
        /// Unique Controler Class Instance
        /// </summary>
        public static AppController Instance { get { return (_main != null) ? _main : new AppController(); } }

        protected AppController()
        {
            // Singleton
            _main = this;
            AppControler = this;
        }

        public override void Close()
        {
            if (AppContext.Principal != null)
                AppContext.Principal.Close();

            _main = null;
            base.Close();
        }

        public void Init(string appVersion)
        {
            InitSettings(appVersion);

            SettingsMng.Instance.SetApplicationType(EAppType.Desktop);

            string titleAttribute = Properties.Settings.Default.APPLICATION_TITLE;

            SettingsMng.Instance.SetApplicationTitle(titleAttribute);
            SettingsMng.Instance.SetApplicationName(Properties.Settings.Default.APPLICATION_TITLE);

            ActivateModules();

            //It must be after ActivateModules and before ActivateEntities
            Principal.ResetDBEngine();

            ActivateEntities();

            base.Init(Properties.Settings.Default.APPLICATION_ALIAS, appVersion);
        }
        public override void InitFromService()
        {
            InitSettings();

            SettingsMng.Instance.SetApplicationType(EAppType.Desktop);
            SettingsMng.Instance.SetApplicationTitle(Properties.Settings.Default.APPLICATION_TITLE);

            ActivateModules();

            Principal.ResetDBEngine();

            ActivateEntities();

            base.InitFromService();
        }

        public void InitSettings(string appVersion = "")
        {
            SettingsMng.Instance.SetCurrentApplicationVersion(Properties.Settings.Default.APPLICATION_VERSION);

            if (appVersion != string.Empty && appVersion != Properties.Settings.Default.APPLICATION_VERSION)
            {
                Principal.UpgradeSettings(appVersion);
                Principal.SetCurrentApplicationVersion(Properties.Settings.Default.APPLICATION_VERSION);
            }

#if !DEBUG
            SettingsMng.Instance.SetLANServer(Properties.Settings.Default.LAN_HOST);
            SettingsMng.Instance.SetWANServer(Properties.Settings.Default.WAN_HOST);
            SettingsMng.Instance.SetLastUser(Properties.Settings.Default.LAST_USER);
            SettingsMng.Instance.SetActiveServer(Properties.Settings.Default.LAST_SERVER);
#endif
        }

        /*private static void SetDefaultUser()
        {
            SettingsMng.Instance.SetDefaultUser(Settings.Default.USER);
        }*/

        public static void SetHipatiaFTPParameters()
        {
#if DEBUG
            Library.Hipatia.ModuleController.SetHipatiaFTPParams("tea.iqingenieros.com", "iQingenieros", "WEdfg6543", "Hangar_DEV");
#endif
#if DEMO
			Library.Hipatia.Controler.SetHipatiaFTPParams(nHManager.Instance.Host, "iQingenieros", "WEdfg6543", "Hangar");   
#endif
#if STAGING
            Library.Hipatia.ModuleController.SetHipatiaFTPParams(nHManager.Instance.Host, string.Empty, string.Empty, "Hangar_PRE");
#endif
#if RELEASE
			Library.Hipatia.ModuleController.SetHipatiaFTPParams(nHManager.Instance.Host, Settings.Default.HIPATIA_FTP_USER, Settings.Default.HIPATIA_FTP_PWD, Settings.Default.HIPATIA_FTP_ROOT_PATH);
#endif
        }

        public override void ActivateModules()
        {
            ClearModules();

            ActivateModule(new Library.ModuleDef());
            ActivateModule(new Common.ModuleDef());
            ActivateModule(new Hipatia.ModuleDef());
            ActivateModule(new Instruction.ModuleDef());
            ActivateModule(new Quality.ModuleDef());
            ActivateModule(new Invoice.ModuleDef());
            ActivateModule(new Store.ModuleDef());
        }

        public override void ActivateAcreedores()
        {
            if (Library.Store.ModuleController.Instance.ActiveAcreedores != null)
                Library.Store.ModuleController.Instance.ClearAcreedores();

            Library.Store.ModuleController.Instance.ActivateAcreedor(ETipoAcreedor.Despachante, nHManager.Instance.GetSQLTable(typeof(CustomAgentRecord)));
            Library.Store.ModuleController.Instance.ActivateAcreedor(ETipoAcreedor.Naviera, nHManager.Instance.GetSQLTable(typeof(ShippingCompanyRecord)));
            Library.Store.ModuleController.Instance.ActivateAcreedor(ETipoAcreedor.Acreedor, nHManager.Instance.GetSQLTable(typeof(SupplierRecord)));
            Library.Store.ModuleController.Instance.ActivateAcreedor(ETipoAcreedor.Proveedor, nHManager.Instance.GetSQLTable(typeof(SupplierRecord)));
            Library.Store.ModuleController.Instance.ActivateAcreedor(ETipoAcreedor.TransportistaDestino, nHManager.Instance.GetSQLTable(typeof(TransporterRecord)));
            Library.Store.ModuleController.Instance.ActivateAcreedor(ETipoAcreedor.TransportistaOrigen, nHManager.Instance.GetSQLTable(typeof(TransporterRecord)));
            Library.Store.ModuleController.Instance.ActivateAcreedor(ETipoAcreedor.Empleado, nHManager.Instance.GetSQLTable(typeof(EmployeeRecord)));
            Library.Store.ModuleController.Instance.ActivateAcreedor(ETipoAcreedor.Instructor, nHManager.Instance.GetSQLTable(typeof(InstructorRecord)));
        }

        public override void ActivateEntidades()
        {
            if (Library.Common.ModuleController.Instance.ActiveEntidades != null)
                Library.Common.ModuleController.Instance.ClearEntities();

            Library.Common.ModuleController.Instance.ActivateEntidad(ETipoEntidad.FacturaRecibida, nHManager.Instance.GetSQLTable(typeof(InputInvoiceRecord)), typeof(InputInvoice), typeof(InputInvoices));
            Library.Common.ModuleController.Instance.ActivateEntidad(ETipoEntidad.FacturaEmitida, nHManager.Instance.GetSQLTable(typeof(OutputInvoiceRecord)), typeof(OutputInvoice), typeof(OutputInvoices));
            //Library.Common.ModuleController.Instance.ActivateEntidad(ETipoEntidad.Cobro, nHManager.Instance.GetSQLTable(typeof(ChargeRecord)), typeof(Cobro), typeof(Cobros));
            Library.Common.ModuleController.Instance.ActivateEntidad(ETipoEntidad.Pago, nHManager.Instance.GetSQLTable(typeof(PaymentRecord)), typeof(Payment), typeof(Payments));
            Library.Common.ModuleController.Instance.ActivateEntidad(ETipoEntidad.Nomina, nHManager.Instance.GetSQLTable(typeof(PayrollRecord)), typeof(Payroll), typeof(Payrolls));
            Library.Common.ModuleController.Instance.ActivateEntidad(ETipoEntidad.Traspaso, nHManager.Instance.GetSQLTable(typeof(BankTransferRecord)), typeof(Traspaso), typeof(Traspasos));

            Library.Common.ModuleController.Instance.ActivateEntidad(ETipoEntidad.Cliente, nHManager.Instance.GetSQLTable(typeof(ClientRecord)), typeof(Cliente), typeof(Clientes));
            Library.Common.ModuleController.Instance.ActivateEntidad(ETipoEntidad.Despachante, nHManager.Instance.GetSQLTable(typeof(CustomAgentRecord)), typeof(Despachante), typeof(Despachantes));
            Library.Common.ModuleController.Instance.ActivateEntidad(ETipoEntidad.Naviera, nHManager.Instance.GetSQLTable(typeof(ShippingCompanyRecord)), typeof(Naviera), null);
            Library.Common.ModuleController.Instance.ActivateEntidad(ETipoEntidad.Proveedor, nHManager.Instance.GetSQLTable(typeof(SupplierRecord)), typeof(Proveedor), null);
            Library.Common.ModuleController.Instance.ActivateEntidad(ETipoEntidad.Acreedor, nHManager.Instance.GetSQLTable(typeof(SupplierRecord)), typeof(Proveedor), null);
            Library.Common.ModuleController.Instance.ActivateEntidad(ETipoEntidad.TransportistaDestino, nHManager.Instance.GetSQLTable(typeof(TransporterRecord)), typeof(Transporter), null);
            Library.Common.ModuleController.Instance.ActivateEntidad(ETipoEntidad.TransportistaOrigen, nHManager.Instance.GetSQLTable(typeof(TransporterRecord)), typeof(Transporter), null);
            Library.Common.ModuleController.Instance.ActivateEntidad(ETipoEntidad.Empleado, nHManager.Instance.GetSQLTable(typeof(EmployeeRecord)), typeof(Employee), typeof(Employees));
            Library.Common.ModuleController.Instance.ActivateEntidad(ETipoEntidad.LineaFomento, nHManager.Instance.GetSQLTable(typeof(LineaFomentoRecord)), typeof(LineaFomento), typeof(LineasFomento));
            Library.Common.ModuleController.Instance.ActivateEntidad(ETipoEntidad.ExpedienteREA, nHManager.Instance.GetSQLTable(typeof(REAExpedientRecord)), typeof(REAExpedient), typeof(REAExpedients));
            Library.Common.ModuleController.Instance.ActivateEntidad(ETipoEntidad.Prestamo, nHManager.Instance.GetSQLTable(typeof(LoanRecord)), typeof(Loan), typeof(Loans));
        }

        #endregion

        #region Updates

        /// <summary>
        /// Busca actualizaciones disponibles en el FTP
        /// </summary>
        public static string LookForUpdates()
        {
            return AppControllerBase.LookForUpdates(Settings.Default.FTPHost,
                                                Settings.Default.FTPUser,
                                                Settings.Default.FTPPwd,
                                                Settings.Default.Project,
                                                Settings.Default.FTPFile,
                                                Settings.Default.Project + ".exe");
        }

        /// <summary>
        /// Busca actualizaciones disponibles en el FTP
        /// </summary>
        public static string DownloadUpdate(string remote_file, BackgroundWorker bk)
        {
            return AppControllerBase.DownloadUpdate(Settings.Default.FTPHost,
                                                Settings.Default.FTPUser,
                                                Settings.Default.FTPPwd,
                                                Settings.Default.Project + "//" + remote_file,
                                                Environment.GetFolderPath(System.Environment.SpecialFolder.DesktopDirectory), bk);
        }

        /// <summary>
        /// Ejecuta el fichero de actualización
        /// </summary>
        public new static void Update(string remote_file)
        {
            AppControllerBase.Update(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) +
                                 "\\" + remote_file);
        }

        /// <summary>
        /// Ejecuta el fichero de actualización
        /// </summary>
        public new static void Update(string remote_file, string user_name, string password, string domain)
        {
            AppControllerBase.Update(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) +
                                 "\\" + remote_file, user_name, password, domain);
        }

        #endregion

        #region Backup

        public static void AutoBackup(List<ISchemaInfo> schemas = null, bool forceBackup = false)
        {
            AppControllerBase.AutoBackup(nHManager.Instance.Host,
                                        nHManager.Instance.Database,
                                        nHManager.Instance.User,
                                        schemas,
                                        forceBackup);
        }

        public static void CreateBackup(string outputFile)
        {
            if (!AppContext.Principal.Identity.IsAdmin)
                throw new iQException(Library.Resources.Messages.USER_NOT_ALLOWED);

            AppControllerBase.DoCreateBackup(nHManager.Instance.Host,
                                        nHManager.Instance.Database,
                                        nHManager.Instance.User,
                                        null,
                                        outputFile);
        }

        public static void RestoreBackup(string filename)
        {
            if (!AppContext.Principal.Identity.IsAdmin)
                throw new iQException(Library.Resources.Messages.USER_NOT_ALLOWED);

            AppControllerBase.RestoreBackup(nHManager.Instance.Host,
                                        nHManager.Instance.Database,
                                        nHManager.Instance.User,
                                        filename);
        }

        #endregion

        #region Autopilot

        /// <summary>
        /// Realiza acciones automáticas al principio de la ejecución
        /// </summary>
        public override List<string> Autopilot(bool log)
        {
            List<string> results = new List<string>();

            List<string> base_results = base.Autopilot(log);

            foreach (string item in base_results)
                results.Add(item);

            return results;
        }

        public void AutoPilot()
        {
            //Library.Common.ModuleController.Instance.AutoPilot();
            Library.Store.ModuleController.Instance.AutoPilot();
            Library.Invoice.ModuleController.Instance.AutoPilot();
            Library.Instruction.ModuleController.Instance.AutoPilot();
            Library.Quality.ModuleController.Instance.AutoPilot();
        }

        #endregion

        #region Scripts

        public static void UpdateCostesExpedientes()
        {
            Stores almacenes = Stores.GetList(false);
            Expedients expedientes = Expedients.GetList(false);

            if (expedientes != null)
            {
                foreach (Expedient item in expedientes)
                {
                    item.LoadChilds(typeof(Expense), true, true);

                    foreach (Almacen almacen in almacenes)
                    {
                        almacen.LoadPartidasByExpediente(item.Oid, true);
                        item.UpdateTotalesProductos(almacen.Partidas, true);
                    }
                }

                expedientes.Save();
            }

            almacenes.Save();

            Cache.Instance.Remove(typeof(Stores));
            Cache.Instance.Remove(typeof(Expedients));
            Cache.Instance.Remove(typeof(ExpenseList));
            Cache.Instance.Remove(typeof(InputInvoiceLineList));
            Cache.Instance.Remove(typeof(InputDeliveryLineList));
        }

        #endregion

        #region Reports
        
        #endregion

	}
}

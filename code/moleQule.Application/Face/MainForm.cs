using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.Win32;
using System.Globalization;
using System.Security.Principal;

using moleQule.Library.CslaEx;

using moleQule.Library;
using moleQule.Library.Common;
using moleQule.Face;
using moleQule.Face.Common;
using moleQule.Library.Application;
using moleQule.Library.Instruction;
using moleQule.Library.Quality;
using moleQule.Library.Store;
using moleQule.Library.Application.Tools;
using moleQule.Face.Instruction;
using moleQule.Face.Invoice;
using moleQule.Face.Quality;
using moleQule.Face.Store;
using moleQule.Face.Hipatia;

namespace moleQule.Face.Application
{
    public partial class MainForm : moleQule.Face.MainBaseForm, 
									moleQule.Library.IBackGroundLauncher
    {

        #region Attributes

        protected WindowsImpersonationContext _context;

        /// <summary>
        /// Controlador principal de la aplicacion
        /// </summary>
        public Library.Application.AppController Controler { get { return Library.Application.AppController.Instance; } }

        /// <summary>
        /// Controlador principal de getión formularios
        /// </summary>
        public FormMng FormMng { get { return FormMng.Instance; } }

        #endregion

        #region Business Methods
        #region Business Methods

        public override void AutoPilot(bool log)
        {
            Controler.AutoPilot();
        }

        public override bool ShowNotifications(bool log)
        {
            PgMng = ProgressInfoMng.Instance;

            if (log)
            {
                NotificationMngForm form = new NotificationMngForm(this);
                FormMng.Instance.ShowFormulario(form);
            }
            
            return false;
        }

        public override void CreateBackup()
        {
            SaveFile_DLG.Filter = AppController.GetBackupExtensionFilter();
            SaveFile_DLG.AddExtension = true;

            if (SaveFile_DLG.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    AppController.CreateBackup(SaveFile_DLG.FileName);
                }
                catch (Exception ex)
                {
                    PgMng.ShowInfoException(ex);
                }
            }
        }

        public override void RestoreBackup()
        {
            OpenFile_DLG.Filter = AppController.GetBackupExtensionFilter();

            if (OpenFile_DLG.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    AppController.RestoreBackup(OpenFile_DLG.FileName);
                }
                catch (Exception ex)
                {
                    PgMng.ShowInfoException(ex);
                }
            }
        }


        public override void SetFormSkin()
        {
            int pos = System.Windows.Forms.Application.ProductVersion.IndexOf(".", System.Windows.Forms.Application.ProductVersion.IndexOf(".") + 1);
            string version = System.Windows.Forms.Application.ProductVersion.Substring(0, System.Windows.Forms.Application.ProductVersion.IndexOf(".", pos + 1));
            this.Text = SettingsMng.Instance.GetApplicationTitle() + " " + System.Windows.Forms.Application.ProductVersion;

            if (AppContext.ActiveSchema != null)
            {
                this.Text += " - " + AppContext.ActiveSchema.Name + " - " + AppContext.User.Name;
#if DEBUG
                this.Text += " (" + AppController.GetDBServerHost() + "::" + AppController.GetDBName() + ")";
                this.Text += " (DESARROLLO)";
#endif
#if PREPRO
                this.Text += " (" + AppController.GetDBServerHost() + "::" + AppController.GetDBName() + ")";
                this.Text += " (PREPRODUCCION)";
#endif
#if DEMO
                this.Text += " (" + Controler.GetDBServerHost() + ")";
                this.Text += " (DEMO)";
#endif
#if RELEASE
                this.Text += " (" + AppController.GetDBServerHost() + "::" + AppController.GetDBName() + ")";
#endif
            }

            Leyenda_SL.Text = Resources.Labels.LEYENDA;
            Status_Label.Text = Resources.Labels.POWEREDBY;

            base.SetFormSkin();
        }

        /// <summary>
        /// Reacciona ante la pulsación de teclas
        /// </summary>
        /// <param name="key_code">Código de la tecla pulsada</param>
        protected void KeysDriver(Keys key_code) { }

        #endregion

        protected void ApplyOptions()
        {
            Invoice_TS.Visible = Principal.GetInvoiceBarView();            
            Instruction_TS.Visible = Principal.GetInstructionBarView();
            Quality_TS.Visible = Principal.GetQualityBarView();
            ResumeLayout();
        }

		#endregion

		#region IBackGroundLauncher

		bool _finished = false;
        string _param = string.Empty;
        BGResult _result = BGResult.Working;


		/// <summary>
		/// La llama el backgroundworker para avisar que ha terminado
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        public bool Finished { get { return _finished; } set { _finished = value; } }
        public BGResult Result { get { return _result; } set { _result = value; } }

		/// <summary>
		/// La llama el backgroundworker para ejecutar codigo en segundo plano
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        public void BackGroundJob(BackgroundWorker bk)
		{
			try
			{
                AppController.DownloadUpdate(_param, bk);
			}
			catch (SystemException ex)
			{
				MessageBox.Show(ex.ToString());
			}

		}

        public void BackGroundJob()
        { }

		/// <summary>
		/// La llama el backgroundworker para ejecutar codigo en primer plano
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void ForeGroundJob() { }

		#endregion

		#region Factory Methods

        public MainForm()
        {
            InitializeComponent();

            Globals.Instance.MainForm = this;
            Globals.Instance.Cursor = this.Cursor;
            Globals.Instance.StatusBar = this.Principal_StatusBar;
            Globals.Instance.StatusLabel = this.Status_Label;
            Globals.Instance.AnimLabel = this.Anim_Label;
            Globals.Instance.ProgressBar = this.Progress_Bar;
            Globals.Instance.ProgressInfoMng = ProgressInfoMng.Instance;

            SaveFile_DLG.InitialDirectory = System.Windows.Forms.Application.StartupPath + Library.Resources.Paths.BACKUPS;

            //Indicamos el FormMng quien es el formulario principal
            FormMng.Instance.MainForm = this;

            FormatControls();

            try
            {
                AppController.Instance.Init(System.Windows.Forms.Application.ProductVersion);

                SettingsMng.Instance.SetApplicationName(System.Windows.Forms.Application.ProductName + " " + System.Windows.Forms.Application.ProductVersion);

                ApplyOptions();
            }
            catch (Exception ex)
            {
                MyLogger.LogException(ex, "MainForm::MainForm()");
                MessageBox.Show(ex.Message);
            }
#if TRACE
            Controler.Instance.Timer = ProgressInfoMng.Instance.Timer;
#endif
            //Fichero de ayuda
            //HelpProvider.HelpNamespace = System.Windows.Forms.Application.StartupPath + Controler.HELP_PATH;
        }

        ~MainForm()
        {
            AppDomain.CurrentDomain.UnhandledException -= new UnhandledExceptionEventHandler(MainForm.UnhandledException);
            System.Windows.Forms.Application.ThreadException -= new ThreadExceptionEventHandler(MainForm.ThreadException);
        }

        #endregion

        #region ApplyAuthorizationRules

        /// <summary>
        /// Aplica las reglas de autorización con el objetivo de habilitar o
        /// deshabilitar botones del menú según los permisos
        /// </summary>
        protected override void ApplyAuthorizationRules()
        {
            Main_MenuStrip.Enabled = true;
            Instruction_TS.Enabled = true;

            // Entidades menu
            this.Empresas_MI.Enabled = AppContext.User.IsAdmin;
            this.Empresas_MI.Visible = AppContext.User.IsAdmin;

            //Administracion
            Clientes_MI.Enabled = false;// moleQule.Library.Invoice.Cliente.CanGetObject();
            Clientes_MI.Visible = false;//moleQule.Library.Invoice.Cliente.CanGetObject();
            Proveedores_MI.Enabled = false;//moleQule.Library.Store.Proveedor.CanGetObject();
            Proveedores_MI.Visible = false;//moleQule.Library.Store.Proveedor.CanGetObject();
            Productos_MI.Enabled = false;//moleQule.Library.Store.Product.CanGetObject();
            Productos_MI.Visible = false;//moleQule.Library.Store.Product.CanGetObject();
            Albaranes_TI.Enabled = false;//moleQule.Library.Invoice.OutputDelivery.CanGetObject();
            Albaranes_TI.Visible = false;//moleQule.Library.Invoice.OutputDelivery.CanGetObject();
            AlbaranesProveedores_MI.Enabled = false;//moleQule.Library.Store.InputDelivery.CanGetObject();
            AlbaranesProveedores_MI.Visible = false;//moleQule.Library.Store.InputDelivery.CanGetObject();
            FacturaCliente_MI.Enabled = false;//moleQule.Library.Invoice.OutputInvoice.CanGetObject();
            FacturaCliente_MI.Visible = false;//moleQule.Library.Invoice.OutputInvoice.CanGetObject();
            FacturaProveedor_MI.Enabled = false;//moleQule.Library.Store.InputInvoice.CanGetObject();
            FacturaProveedor_MI.Visible = false;//moleQule.Library.Store.InputInvoice.CanGetObject();
            Cajas_MI.Enabled = false;//moleQule.Library.Invoice.Cash.CanGetObject();
            Cajas_MI.Visible = false;//moleQule.Library.Invoice.Cash.CanGetObject();
            Almacen_MI.Enabled = false;//moleQule.Library.Store.Almacen.CanGetObject();
            Almacen_MI.Visible = false;//moleQule.Library.Store.Almacen.CanGetObject();
            Pedidos_MI.Enabled = false;//moleQule.Library.Invoice.Pedido.CanGetObject();
            Pedidos_MI.Visible = false;//moleQule.Library.Invoice.Pedido.CanGetObject();


            this.Usuarios_MI.Enabled = AppContext.User.IsAdmin && (AppContext.ActiveSchema != null);
            this.Usuarios_TI.Enabled = AppContext.User.IsAdmin && (AppContext.ActiveSchema != null);
            Backup_MI.Visible = AppContext.User.IsSuperUser;
        }

        #endregion

        // Menus Response

        #region Archivo

        private void Empresas_MI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(CompanyMngForm.ID);
        }

        private void Salir_MI_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void CerrarSesion_MI_Click(object sender, EventArgs e)
        {
            DoLogin();
        }

        private void CambiarEmpresa_MI_Click(object sender, EventArgs e)
        {
            FormMng.CloseAllChilds();
            FormMng.OpenForm(CompanySelectForm.ID);
        }

        #endregion

        #region Herramientas
        
        private void Municipios_MI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(MunicipioMngForm.ID);
        }
		
        private void Cargos_MI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(CargoUIForm.ID);
        }
        
        private void DuplicadoTema_TI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(DuplicarPreguntasTemaActionForm.ID);
        }

        private void Impuestos_MI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(ImpuestoUIForm.ID);
        }

        private void TipoDocumento_TI_Click(object sender, EventArgs e)
        {

        }

		private void Updates_MI_Click(object sender, EventArgs e)
		{
            LookForUpdate(true);
		}

        private void DefaultUser_MI_Click(object sender, EventArgs e)
        {
            nHManager.Instance.DefaultUser = ApplicationContextEx.User.Identity.Name;
            nHManager.Instance.ConfigureDefaultUser(System.Windows.Forms.Application.StartupPath + "\\Asm\\hibernate.cfg.xml");
            nHManager.Instance.ConfigureDefaultUser(System.Windows.Forms.Application.StartupPath 
                                                    + "\\Asm\\hibernate_nh" 
                                                    + AppContext.ActiveSchema.Oid.ToString("0000")
                                                    + ".cfg.xml");
        }

        private void Backup_MI_Click(object sender, EventArgs e)
        {
            ProgressInfoMng.Instance.Reset(4, 1, "Copiando base de datos...", this);

            ProgressInfoMng.Instance.Grow();
            moleQule.Library.Timer.Instance.InitTickTimer(moleQule.Library.Timer.ETickTimer.Standard, CheckBackup, 1);

            try
            {
                backupThread = new Thread(new ThreadStart(AutoBackup));
                backupThread.Start();
                ProgressInfoMng.Instance.Grow();
            }
            catch (Exception ex)
            {
                ReleaseThread(backupThread);

                ProgressInfoMng.Instance.FillUp();
                ProgressInfoMng.Instance.ShowInfoException(ex);
            }
        }

        private void Restore_MI_Click(object sender, EventArgs e)
        {
            //Controler.RestoreBackup();
        }

        private void Settings_MI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(SettingsForm.ID);
            ApplyOptions();
        }

        private void Notificaciones_MI_Click(object sender, EventArgs e)
        {
            ShowNotifications(true);
        }

        private void Contabilidad_MI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(ExportarContabilidadActionForm.ID);
        }

        private void EnviarFacturas_MI_Click(object sender, EventArgs e)
        {
            try
            {
                ProgressInfoMng.Instance.Reset(3, 1, string.Empty, this);
                ProgressInfoMng.Instance.Grow();
                moleQule.Library.Invoice.ModuleController.SendMailsFacturasPendientes();
                ProgressInfoMng.Instance.FillUp();

                ProgressInfoMng.Instance.ShowInfoException("Envío finalizado con éxito. Consulte el registro para más información");
            }
            catch (Exception ex)
            {
                ProgressInfoMng.Instance.FillUp();
                ProgressInfoMng.Instance.ShowErrorException(ex);
            }
        }

        private void PermisosUsuario_TMT_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(UsersUIForm.ID, this);
        }

        private void Usuarios_MI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(UserMngForm.ID, this);
        }

        private void UserEdit_MI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(UserPasswordEditForm.ID, this);
        }
        
        private void ReindexarCaja_MI_Click(object sender, EventArgs e)
        {
            try
            {
                ProgressInfoMng.Instance.Reset(2, 1, "Reindexando entradas y salidas de caja...", this);
                Library.Invoice.ModuleController.ReindexarLineaCajasAbiertas();
                ProgressInfoMng.Instance.FillUp();
                ProgressInfoMng.Instance.ShowInfoException(Face.Resources.Messages.OPERATION_OK);
            }
            catch (Exception ex)
            {
                ProgressInfoMng.Instance.FillUp();
                ProgressInfoMng.Instance.ShowErrorException(ex);
            }
        }

        #endregion

        #region Application Menu

        private void Empresa_TI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(CompanyMngForm.ID);
        }

        private void Agentes_TI_Click(object sender, EventArgs e)
        {

        }

        private void AcercaDe_MI_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region Hipatia Menu

        private void Hipatia_TI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(moleQule.Face.Application.AgenteMngForm.ID);
        }

        private void Agentes_MI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(moleQule.Face.Application.AgenteMngForm.ID);
        }

        private void Documentos_MI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(Hipatia.DocumentoMngForm.ID);
        }

        #endregion

        #region Invoice Menu

        private void Albaran_TI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(DeliveryAllMngForm.ID);
        }

        private void AlbaranFacturados_TI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(DeliveryFacturadosMngForm.ID);
        }

        private void AlbaranPendientes_TI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(DeliveryNoFacturadosMngForm.ID);
        }

        private void Caja_TI_ButtonClick(object sender, EventArgs e)
        {
            FormMng.OpenForm(CashEditForm.ID, new object[1]{1}, this);
        }

        private void cajaA_MI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(CashEditForm.ID, new object[1]{1}, this);
        }

        private void cajaB_MI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(CashEditForm.ID, new object[1]{2}, this);
        }

        private void CierresCaja_MI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(CierreCajaMngForm.ID, new object[1] { 1 });
        }

        private void Clientes_MI_Click(object sender, EventArgs e)
        {
            //FormMng.OpenForm(ClienteMngForm.ID);
            FormMng.OpenForm(ClientMngForm.ID, new object[1] { EEstado.Todos });
        }

        private void Cobros_TI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(CobroMngForm.ID);
        }

        private void CobrosTodos_MI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(CobroMngForm.ID);
        }

        private void CobrosClientes_MI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(ClientChargeMngForm.ID);
        }

        private void Facturas_TI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(InvoiceAllMngForm.ID);
        }

        private void FCobradas_MI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(InvoiceChargedMngForm.ID);
        }

        private void FPendientes_MI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(InvoiceDueMngForm.ID);
        }

        private void MatriculaPromocionRPT_TI_Click(object sender, EventArgs e)
        {

        }

        private void Pedidos_MI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(PedidoProveedorMngForm.ID);
        }

        private void Proforma_TI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(BudgetMngForm.ID, this);
        }

        private void Series_MI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(SerieMngForm.ID);
        }

        #endregion

        #region Store Menu

        private void AlbaranesProveedores_MI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(InputDeliveryAllMngForm.ID, this);
        }

        private void Almacen_MI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(AlmacenMngForm.ID, this);
        }

        private void Despachantes_MI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(SupplierMngForm.ID, this);
        }

        private void FRecibidas_TI_ButtonClick(object sender, EventArgs e)
        {
            FormMng.OpenForm(InputInvoiceAllMngForm.ID, this);
        }

        private void FRecibidasPagadas_TI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(InputInvoicePayedMngForm.ID, this);
        }

        private void FRecibidasPendientes_TI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(InputInvoiceDueMngForm.ID, this);
        }

        private void Familias_TI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(FamilyMngForm.ID, this);
        }

        private void Inventario_MI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(InventarioAlmacenMngForm.ID, this);
        }

        private void Pagos_TI_ButtonClick(object sender, EventArgs e)
        {
            FormMng.OpenForm(ProviderPaymentMngForm.ID, this);
        }

        private void PagosTodos_MI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(PaymentMngForm.ID, new object[1]{ETipoPago.Todos}, this);
        }

        private void Productos_TI_ButtonClick(object sender, EventArgs e)
        {
            FormMng.OpenForm(ProductAllMngForm.ID, this);
        }

        private void ProductosPropios_TI_Click(object sender, EventArgs e)
        {

        }

        private void Proveedores_TI_Click(object sender, EventArgs e)
        {
            //FormMng.OpenForm(ProveedorMngForm.ID); 
            FormMng.OpenForm(SupplierMngForm.ID, new object[2] { EEstado.Todos, ETipoAcreedor.Proveedor }, this);
        }

        private void Transportistas_MI_Click(object sender, EventArgs e)
        {
            //FormMng.OpenForm(TransportistaMngForm.ID);
            FormMng.OpenForm(TransporterMngForm.ID, new object[1] { EEstado.Todos }, this);
        }

        #endregion

        #region Instruction Menu

        private void Alumnos_TI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(AlumnoMngForm.ID);
        }

        private void Cronograma_TI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(CronogramaMngForm.ID);
        }

        private void Cursos_TI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(CursoMngForm.ID);
        }

        private void Disponibilidad_TI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(DisponibilidadAddForm.ID);
        }

        private void Examenes_MI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(ExamenMngForm.ID);
        }

        private void FaltasAlumnos_MI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(FaltasAlumnosMngForm.ID);
        }

        private void FormNotasPracticas_MI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(FormularioNotasPracticasMngForm.ID);
        }

        private void Horario_TI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(HorarioMngForm.ID);
        }

        private void Instructores_TI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(InstructorMngForm.ID);
        }

        private void Material_TI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(MaterialMngForm.ID);
        }

        private void Modulos_TI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(ModuloMngForm.ID);
        }

        private void PAsistencia_TI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(ParteAsistenciaMngForm.ID);
        }

        private void PlanesDocentes_TI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(PlanEstudiosMngForm.ID);
        }

        private void Planes_Extra_TI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(PlanExtraMngForm.ID);
        }

        private void Plantillas_MI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(PlantillaMngForm.ID);
        }

        private void Pregunta_TI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(PreguntaMngForm.ID);
        }

        private void Promociones_TI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(PromocionMngForm.ID);
        }

        private void RegistroFaltas_MI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(RegistroFaltasAlumnosMngForm.ID);
        }

        private void NotasPracticas_MI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(NotasPracticasMngForm.ID);
        }

        private void DisponibilidadSemana_MI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(DisponibilidadSemanalForm.ID);
        }

        #endregion

        #region Quality Menu

        private void ActaComite_MI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(ActaComiteMngForm.ID);
        }

        private void Area_MI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(AreaMngForm.ID);
        }

        private void Auditoria_MI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(AuditoriaMngForm.ID);
        }

        private void Clase_Auditoria_MI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(ClaseAuditoriaMngForm.ID);
        }

        private void Departamentos_TI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(DepartamentoMngForm.ID);
        }

        private void Discrepancias_TI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(DiscrepanciaMngForm.ID);
        }

        private void Incidencia_MI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(IncidenciaMngForm.ID);
        }

        private void PlanAnual_MI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(PlanAnualMngForm.ID);
        }

        private void Submodulo_Instructor_Promocion_MI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(InstructoresPromocionViewForm.ID);
        }

        private void Seguimiento_MI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(SeguimientoAuditoriasActionForm.ID);
        }

        #endregion

        #region Otras tablas

        private void Puertos_MI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(PuertoUIForm.ID);
        }

        private void RazaAnimal_MI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(RazaAnimalUIForm.ID);
        }

        private void TipoAnimal_MI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(TipoAnimalUIForm.ID);
        }

        private void CuentasBancarias_MI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(BankAccountMngForm.ID);
        }

        #endregion

        #region Informes
        
        private void Balance_MI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(BalanceMngForm.ID, this);
        }

        private void Cartera_TMI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(CarteraClientesActionForm.ID);
        }

        private void InformeCobrosFacturas_MI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(CobrosActionForm.ID);
        }

        private void Precios_MI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(PricesActionForm.ID);
        }

        private void InformeCobrosFacturas_TMI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(CobrosActionForm.ID);
        }

        private void Inventario_MI_Click_1(object sender, EventArgs e)
        {
            FormMng.OpenForm(InventarioValoradoActionForm.ID);
        }

        private void MovsBancos_MI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(BankLineMngForm.ID, this);
        }

        private void MovsStock_MI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(MovsStockActionForm.ID, new object[1] { ETipoExpediente.Almacen }, this);
        }

        private void ControlPagos_MI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(PaymentsControlActionForm.ID, this);
        }

        private void ComprasProveedores_TI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(PurchasesActionForm.ID, this);
        }

        private void VentasClientes_TI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(SalesActionForm.ID, this);
        }

        private void VentasClientesMensual_MI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(VentasMensualActionForm.ID);
        }

        private void Modelos_MI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(ModelosActionForm.ID, this);
        }

        #endregion


        #region Login/Logout

#if DEBUG
        /// <summary>
        /// Función que realiza el login de usuario y carga la clase principal del
        /// programa
        /// </summary>
        /// <remarks>
        /// Esta función utiliza el usuario y password por defecto.
        /// Para utilizar un formulario personalizado de login es necesario sobrecargar
        /// esta función en el MainForm de la aplicación.
        /// </remarks>
        protected override void DoLogin()
        {
            if (AppContext.Principal != null)
                AppContext.Principal.Logout();
            SetFormSkin();

            // Cableado para que no pida usuario
            try
            {
                Principal.Login();

                if (!AppContext.User.IsAuthenticated)
                {
                    ProgressInfoMng.Instance.ShowInfoException(Resources.Messages.LOGIN_ERROR);
                    return;
                }

                LoadSchema();
                AppContext.Principal.LoadUserContext();
            }
            catch (iQLockException ex)
            {
                ProgressInfoMng.ShowException(ex, MessageBoxButtons.OK, MessageBoxIcon.Error);
                AppContext.Principal.Logout();
                FormMng.OpenForm(LoginForm.ID);
            }
            catch (Exception ex)
            {
                ProgressInfoMng.ShowException(ex, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        protected void ShowLogin()
        {
            AppContext.Principal.Logout();
            SetFormSkin();

            FormMng.OpenForm(LoginForm.ID);
        }
#else
        /// <summary>
        /// Función que realiza el login de usuario y carga la clase principal del
        /// programa
        /// </summary>
        /// <remarks>
        /// Esta función utiliza el usuario y password por defecto.
        /// Para utilizar un formulario personalizado de login es necesario sobrecargar
        /// esta función en el MainForm de la aplicación.
        /// </remarks>
        protected override void DoLogin()
        {
            if (AppContext.Principal != null)
                AppContext.Principal.Logout();

            SetFormSkin();

            try
            {
                FormMng.OpenForm(LoginForm.ID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
                throw new iQException(iQExceptionHandler.GetAllMessages(ex));
            }
        }
#endif

        /// <summary>
        /// Función que carga la clase principal del programa (Empresa). 
        /// </summary>
        /// <remarks>
        /// Si se quiere cargar el esquema por defecto basta con comentar la función
        /// y que tome el control el LoadSchema de moleQule
        /// </remarks>
        public override void LoadSchema()
        {
            try
            {
                // Obtenemos la empresa por defecto del fichero de los settings de usuario
                long oidSchema = SettingsMng.Instance.GetDefaultSchema();

                if (oidSchema != 0)
                {
                    CompanyInfo empresa = CompanyInfo.Get(oidSchema);
                    if (empresa.Code != null && empresa.Oid != 0)
                    {
                        CompanyMngForm em = new CompanyMngForm(true, this);
                        em.LoadSchema(empresa);
                        Controler.CheckModulesDBVersion();
                        AppContext.Principal.LoadUserContext();
                        AppController.SetHipatiaFTPParameters();
                    }
                    else
                        FormMng.OpenForm(CompanySelectForm.ID);
                }
                else
                    FormMng.OpenForm(CompanySelectForm.ID);
            }
            catch (Exception ex)
            {
                ProgressInfoMng.ShowException(ex);
                this.Dispose();
                System.Windows.Forms.Application.Exit();
            }

            this.Reload();
        }

        #endregion

        #region Backups

        static System.Threading.Thread backupThread;

        public void BackupErrorHandler(object sender, iQExceptionHandler.ErrorEventArgs e)
        {
            try
            {
                ProgressInfoMng.Instance.FillUp();
                ProgressInfoMng.Instance.ShowInfoException(e.Exception);
            }
            finally
            {
                ReleaseThread(backupThread);
            }
        }

        private static void ReleaseThread(Thread thread)
        {
            try
            {
                thread = null;
                AppControllerBase.ErrorHandler = null;
            }
            catch { }
        }

        public void AutoBackup()
        {
            AppControllerBase.ErrorHandler = BackupErrorHandler;

            CompanyList companies = CompanyList.GetList(AppContext.User.GetInfo(), false);

            AppController.AutoBackup();
        }
        public void CheckBackup()
        {
            try
            {
                if (backupThread.IsAlive) return;
                ProgressInfoMng.Instance.FillUp();

                moleQule.Library.Timer.Instance.CloseTickTimer(Library.Timer.ETickTimer.Standard);
            }
            catch (Exception ex)
            {
                ProgressInfoMng.Instance.FillUp();
                ProgressInfoMng.Instance.ShowInfoException(ex);
            }
            finally
            {
                ReleaseThread(backupThread);
            }
        }

        #endregion

        #region Events

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
#if !DEBUG
            if (MessageBox.Show(Resources.Messages.SALIR,
                                System.Windows.Forms.Application.ProductName,
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
                return;
            }
#endif
            this.Dispose();
        }

        private void Status_Label_Click(object sender, EventArgs e)
        {
            Process process = new Process();
            process.StartInfo = new ProcessStartInfo(Properties.Settings.Default.COMPANY_URL);
            process.Start();
        }

        /// <summary>
        /// UI not handled Exceptions
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="t"></param>
        public static void ThreadException(object sender, ThreadExceptionEventArgs t)
        {
            try
            {
                ProgressInfoMng.Instance.FillUp();
                ProgressInfoMng.Instance.ShowInfoException(t.Exception);
            }
            catch
            {
            }
            finally
            {
            }
        }

        /// <summary>
        /// NON-UI not handled Exceptions
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            try
            {
                ProgressInfoMng.Instance.FillUp();
                ProgressInfoMng.Instance.ShowInfoException((Exception)e.ExceptionObject);
            }
            catch (Exception ex)
            {
                ProgressInfoMng.Instance.FillUp();
                ProgressInfoMng.Instance.ShowInfoException(ex);
            }
            finally
            {
            }
        }

        #endregion

        private void Escandallo_TMI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(EscandalloMngForm.ID);
        }

        private void StockAgrupado_TI_Click(object sender, EventArgs e)
        {
            BatchList lista = BatchList.GetListBySerieAndStockAgrupado((long)ESerie.GENERICA, false, false);
            FormMng.OpenForm(BatchMngForm.ID, new object[2] { lista, StockAgrupado_TI.Text });
        }

        private void StockDetallado_TI_Click(object sender, EventArgs e)
        {
            BatchList lista = BatchList.GetListBySerieAndStock((long)ESerie.GENERICA, false, false);
            FormMng.OpenForm(BatchMngForm.ID, new object[2] { lista, StockDetallado_TI.Text });
        }
        
        private void Microexpedientes_TMI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(ExpedienteAlmacenMngForm.ID, new object[2] { null, Expediente_TI.Text });
        }

        private void AlbaranRecibidoPendientes_TI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(InputDeliveryNoBilledMngForm.ID, this);
        }

        private void AlbaranRecidbidoFacturados_TI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(InputDeliveryBilledMngForm.ID, this);
        }

        private void InformeComprasAProveedores_TMI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(PurchasesActionForm.ID, this);
        }

        private void PagosPorAcreedor_TMI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(ProviderPaymentMngForm.ID, this);
        }
        
        private void PagosGasto_TMI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(PaymentMngForm.ID, new object[1] { ETipoPago.Gasto });
        }

        private void PagosFactura_TMI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(PaymentMngForm.ID, new object[1] { ETipoPago.Factura });
        }

        private void PagosNomina_TMI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(PaymentMngForm.ID, new object[1] { ETipoPago.Nomina });
        }

        private void Ticket_TMI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(TicketMngForm.ID, this);
        }

        private void CobrosClientes_TMI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(CobroAClienteMngForm.ID, this);
        }

        private void CobrosPorCliente_TMI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(ClientChargeMngForm.ID, this);
        }

        private void CajaTickets_TMI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(CashEditForm.ID, new object[1] { 2 });
        }
        
        private void TarjetaCredito_TMI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(CreditCardUIForm.ID);
        }

        private void TPV_TMI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(moleQule.Face.Common.TPVUIForm.ID);
        }

        private void ExtractoTarjeta_TMI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(moleQule.Face.Invoice.CreditCardStatementMngForm.ID, this);            
        }

        private void Prestamos_TMI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(LoanMngForm.ID, this);
        }

        private void Traspaso_TMI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(TraspasoMngForm.ID, this);
        }

        private void InformeDeMovimientos_TI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(BankLinesActionForm.ID, this);
        }

        private void ClientesActivos_TMI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(ClientMngForm.ID, new object[1] { EEstado.Active }, this);
        }

        private void ClientesBaja_TMI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(ClientMngForm.ID, new object[1] { EEstado.Baja }, this);
        }

        private void AcreedoresActivos_MTI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(SupplierMngForm.ID, new object[2] { EEstado.Active, ETipoAcreedor.Acreedor });
        }

        private void AcreedoresBaja_MTI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(SupplierMngForm.ID, new object[2] { EEstado.Baja, ETipoAcreedor.Acreedor });
        }

        private void Acreedores_MTI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(SupplierMngForm.ID, new object[2] { EEstado.Todos, ETipoAcreedor.Acreedor });
        }

        private void DespachantesBaja_MTI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(SupplierMngForm.ID, new object[1] { EEstado.Baja });
        }

        private void DespachantesActivos_MTI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(SupplierMngForm.ID, new object[1] { EEstado.Active });
        }

        private void DespachantesTodos_MTI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(SupplierMngForm.ID, new object[1] { EEstado.Todos });
        }

        private void PersonalActivo_TMI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(EmployeeMngForm.ID, new object[1] { EEstado.Active });
        }

        private void PersonalBaja_TMI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(EmployeeMngForm.ID, new object[1] { EEstado.Baja });
        }

        private void Empleado_TI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(EmployeeMngForm.ID, new object[1] { EEstado.Todos });
        }

        private void NavierasTodos_MTI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(ShippingCompanyMngForm.ID, new object[1] { EEstado.Todos });
        }

        private void NavierasActivos_MTI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(ShippingCompanyMngForm.ID, new object[1] { EEstado.Active });
        }

        private void NavierasBaja_MTI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(ShippingCompanyMngForm.ID, new object[1] { EEstado.Baja });
        }

        private void ProveedoresTodos_TMI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(SupplierMngForm.ID, new object[2] { EEstado.Todos, ETipoAcreedor.Proveedor });
        }

        private void ProveedoresActivos_TMI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(SupplierMngForm.ID, new object[2] { EEstado.Active, ETipoAcreedor.Proveedor });
        }

        private void ProveedoresBaja_TMI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(SupplierMngForm.ID, new object[2] { EEstado.Baja, ETipoAcreedor.Proveedor });
        }

        private void TransportistasTodos_TMI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(TransporterMngForm.ID, new object[1] { EEstado.Todos });
        }

        private void TransportistasBaja_TMI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(TransporterMngForm.ID, new object[1] { EEstado.Baja });
        }

        private void TransportistasActivos_TMI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(TransporterMngForm.ID, new object[1] { EEstado.Active });
        }

        private void Nomina_TMI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(PayrollMngForm.ID);
        }

        private void Gastos_TI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(ExpenseMngForm.ID, new object[1] { ECategoriaGasto.Todos });
        }

        private void GastosTodos_TMI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(ExpenseMngForm.ID, new object[1] { ECategoriaGasto.Todos });
        }

        private void GastoImpuesto_TMI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(ExpenseMngForm.ID, new object[1] { ECategoriaGasto.Impuesto });
        }

        private void GastosGenerales_TMI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(ExpenseMngForm.ID, new object[1] { ECategoriaGasto.Generales });
        }

        private void GastosSeguro_TMI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(ExpenseMngForm.ID, new object[1] { ECategoriaGasto.SeguroSocial });
        }

        private void TipoGasto_TMI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(TipoGastoMngForm.ID);
        }

        private void Registro_TI_ButtonClick(object sender, EventArgs e)
        {
            FormMng.OpenForm(RegistroMngForm.ID, new object[2] { ETipoRegistro.Todos, RegistroTodos_TMI.Text });
        }

        private void LineasRegistro_TMI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(LineaRegistroMngForm.ID, new object[2] { ETipoRegistro.Todos, LineasRegistro_TMI.Text });
        }

        private void LineaRegistroContabilidad_TMI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(LineaRegistroMngForm.ID, new object[2] { ETipoRegistro.Contabilidad, LineaRegistroContabilidad_TMI.Text });
        }

        private void LineaRegistroEmail_TMI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(LineaRegistroMngForm.ID, new object[2] { ETipoRegistro.Email, LineaRegistroEmail_TMI.Text });
        }

        private void RegistroEmail_TMI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(RegistroMngForm.ID, new object[2] { ETipoRegistro.Email, RegistroEmail_TMI.Text });
        }

        private void Movimientos_TMI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(moleQule.Face.Invoice.BankLineMngForm.ID, this);
        }

        private void RemesaNominas_TI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(PayrollBatchMngForm.ID, this);
        }

        private void CierreCajaTickets_TMI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(CierreCajaMngForm.ID, new object[1] { 2 });
        }

        private void LineasCaja_TI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(CashLineMngForm.ID, new object[1] { 1 });
        }

        private void LineaCajaPrincipal_TMI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(CashLineMngForm.ID, new object[1] { 1 });
        }

        private void LineaCajaTickets_TMI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(CashLineMngForm.ID, new object[1] { 2 });
        }

        private void AlumnosAdmitidos_MI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(AlumnosAdmitidosExamenActionForm.ID, this);
        }

        private void Festivos_TI_Click(object sender, EventArgs e)
        {
            FormMng.OpenForm(DiasNoLectivosForm.ID, this);
        }
                               


    }
}


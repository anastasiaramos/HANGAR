using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using moleQule.Library;
using moleQule.Library.Application;
using moleQule.Library.Common;
using moleQule.Library.Store;
using moleQule.Library.Invoice;
using moleQule.Library.Quality;
using moleQule.Face.Common;
using moleQule.Face.Store;
using moleQule.Face.Invoice;
using moleQule.Face.Quality;

namespace moleQule.Face.Application
{
	public partial class NotificationMngForm : moleQule.Face.Common.NotificationBaseMngForm
	{
		#region Constants

		const int GASTOS_PENDIENTES = 0;
		const int INGRESOS_PENDIENTES = 1;

		const int PAGOS_BANCO_PENDIENTES = 0;

		const int PAGOS_TARJETA_PENDIENTES = 0;
		const int PAGOS_PENDIENTES = 1;
		const int COBROS_PENDIENTES = 2;

        const int DISCREPANCIAS_ABIERTAS = 0;

		#endregion

		#region Attributes & Properties

		public new const string ID = "NotificationMngForm";
		public new static Type Type { get { return typeof(NotificationMngForm); } }

		protected override int BarSteps { get { return base.BarSteps + 7; } }

		public PaymentList PagoList { get; set; }
		public InputInvoiceList FacturaRecibidaList { get; set; }
		public ExpenseList GastoList { get; set; }
		public OutputInvoiceList FacturaList { get; set; }
		public CobroList CobroList { get; set; }

		public PaymentList PagosVencidosList { get; set; }
		public List<PaymentList> PagosTarjetasList { get; set; }
		public List<PaymentList> PagosBancosList { get; set; }
		public CobroList CobrosVencidosList { get; set; }

		private DateTime _fecha_apuntes = DateTime.Today;

		protected NotifyEntity CurrentApunte
		{
			get { return (Apuntes_TV.SelectedNode != null) ? (NotifyEntity)Apuntes_TV.SelectedNode.Tag : null; }
		}
		
		#endregion

		#region Factory Methods

		public NotificationMngForm()
			: this((Form)null) { }

		public NotificationMngForm(string schema)
			: this(false, null, null) { }

		public NotificationMngForm(Form parent)
			: this(false, parent, null) { }

		public NotificationMngForm(bool isModal, Form parent, NotifyEntityList list)
			: base(isModal, parent, list)
		{
			InitializeComponent();

			SetView(molView.Tree);

			TablaBase = Tabla;

			PagosTarjetasList = new List<PaymentList>();
			PagosBancosList = new List<PaymentList>();
		}

		#endregion

		#region Style

		public override void FormatControls()
		{
			base.FormatControls();

			CheckNodes();

			MaximizeForm(new Size(400, 0));
			Tree_Panel.SplitterDistance = Tree_Panel.Height / 3;
            Tree2_Panel.SplitterDistance = Tree2_Panel.Height / 2;
		}

		protected override void ResetTree()
		{
			Entidades_TV.Nodes.Clear();
			Apuntes_TV.Nodes.Clear();
            Auditorias_TV.Nodes.Clear();
		}

		#endregion

		#region Source

		protected override void RefreshMainData()
		{
			PgMng.Message = Resources.Messages.RETRIEVING_NOTIFICATIONS;

			if (List == null) List = new NotifyEntityList();
			else List.Clear();

			List = new NotifyEntityList();
			DateTime fecha;

			FechaApuntes_TI.Text = _fecha_apuntes.ToShortDateString();

			if (Library.Store.ModulePrincipal.GetNotifyFacturasRecibidas())
			{
				fecha = DateTime.Today.AddDays((double)Library.Store.ModulePrincipal.GetNotifyPlazoFacturasRecibidas());

				FacturaRecibidaList = Library.Store.ModuleController.GetFacturasRecibidasPendientes();
				List.Add(new NotifyEntity(ETipoNotificacion.GastoPendiente
							, ETipoEntidad.FacturaRecibida
							, FacturaRecibidaList.Count
							, FacturaRecibidaList.TotalPendiente()
							, String.Format(Store.Resources.Messages.NOFITY_FACTURAS_RECIBIDAS_PENDIENTES, fecha.ToShortDateString())
							, FacturaRecibidaList));
			}
			PgMng.Grow();

			if (Library.Store.ModulePrincipal.GetNotifyPagos())
			{
				BankAccountList cuentas = BankAccountList.GetList(EEstado.Active, false);
				PagosBancosList.Clear();

				foreach (BankAccountInfo item in cuentas)
				{
					fecha = DateTime.Today.AddDays((double)Library.Store.ModulePrincipal.GetNotifyPlazoPagos());

					PaymentList pagos_banco = Library.Store.ModuleController.GetPagosPendientesVencimiento(item);
					PagosBancosList.Add(pagos_banco);

					List.Add(new NotifyEntity(ETipoNotificacion.PagoBancoPendiente
								, ETipoEntidad.Pago
								, pagos_banco.Count
								, pagos_banco.Total()
								, item.Entidad
								, pagos_banco));
				}
			}
			PgMng.Grow();

			if (Library.Store.ModulePrincipal.GetNotifyGastos())
			{
				fecha = DateTime.Today.AddDays((double)Library.Store.ModulePrincipal.GetNotifyPlazoGastos());

				GastoList = Library.Store.ModuleController.GetGastosPendientes();
				List.Add(new NotifyEntity(ETipoNotificacion.GastoPendiente
							, ETipoEntidad.Gasto
							, GastoList.Count
							, GastoList.TotalPendiente()
							, String.Format(Store.Resources.Messages.NOFITY_GASTOS_PENDIENTES, fecha.ToShortDateString())
							, GastoList));
			}
			PgMng.Grow();

			if (Library.Invoice.ModulePrincipal.GetNotifyFacturasEmitidas())
			{
				fecha = DateTime.Today.AddDays((double)Library.Invoice.ModulePrincipal.GetNotifyPlazoFacturasEmitidas());

				FacturaList = Library.Invoice.ModuleController.GetFacturasPendientes();
				List.Add(new NotifyEntity(ETipoNotificacion.IngresoPendiente
							, ETipoEntidad.FacturaEmitida
							, FacturaList.Count
							, FacturaList.TotalPendiente()
							, String.Format(Invoice.Resources.Messages.NOFITY_FACTURAS_EMITIDAS_PENDIENTES, fecha.ToShortDateString())
							, FacturaList));
			}
			PgMng.Grow();

			if (Library.Invoice.ModulePrincipal.GetNotifyCobros())
			{
				fecha = DateTime.Today.AddDays((double)Library.Invoice.ModulePrincipal.GetNotifyPlazoCobros());

				CobroList = Library.Invoice.ModuleController.GetCobrosPendientes();
				List.Add(new NotifyEntity(ETipoNotificacion.IngresoPendiente
							, ETipoEntidad.Cobro
							, CobroList.Count
							, CobroList.Total()
							, String.Format(Invoice.Resources.Messages.NOFITY_COBROS_PENDIENTES, fecha.ToShortDateString())
							, CobroList));
			}
			PgMng.Grow();

			PagosVencidosList = Library.Store.ModuleController.GetPagosVencidosSinApunte(_fecha_apuntes);
			List.Add(new NotifyEntity(ETipoNotificacion.PagoVencido
							, ETipoEntidad.Pago
							, PagosVencidosList.Count
							, PagosVencidosList.Total()
							, String.Format(Store.Resources.Messages.NOTIFY_PAGOS_VENCIDOS, _fecha_apuntes.ToShortDateString())
							, PagosVencidosList));
			PgMng.Grow();


			CreditCardList tarjetas = CreditCardList.GetList(ETipoTarjeta.Credito, false);
			PagosTarjetasList.Clear();

			foreach (CreditCardInfo item in tarjetas)
			{
				PaymentList pagos_tarjetas = Library.Store.ModuleController.GetPagosTarjetaVencidosSinApunte(_fecha_apuntes, item);
				PagosTarjetasList.Add(pagos_tarjetas);

				List.Add(new NotifyEntity(ETipoNotificacion.PagoTarjetaVencido
								, ETipoEntidad.Pago
								, pagos_tarjetas.Count
								, pagos_tarjetas.Total()
								, item.Nombre
								, pagos_tarjetas));
			}
			PgMng.Grow();

			CobrosVencidosList = Library.Invoice.ModuleController.GetCobrosVencidosSinApunte(_fecha_apuntes);
			List.Add(new NotifyEntity(ETipoNotificacion.CobroVencido
							, ETipoEntidad.Cobro
							, CobrosVencidosList.Count
							, CobrosVencidosList.Total()
							, String.Format(Invoice.Resources.Messages.NOTIFY_COBROS_VENCIDOS, _fecha_apuntes.ToShortDateString())
							, CobrosVencidosList));
			PgMng.Grow();

            if (Library.Quality.ModulePrincipal.GetNotifyAuditorias())
            {
                //Auditorías con Plazo Máximo de Generación de Informe de Auditorías próximo a vencer
                //AuditoriaList auditorias = Library.Quality.ModuleControler.GetAvisoGeneracionInforme();
                //foreach (AuditoriaInfo item in auditorias)
                //{
                //    List.Add(new NotifyEntity(ETipoNotificacion.InformeNoGenerado
                //                    , ETipoEntidad.Auditoria
                //                    , item.Referencia));
                //}

                //Auditorías con Plazo Máximo de Notificación de Discrepancias próximo a vencer

                //Auditorías con Plazo Máximo de Notificación de Fin de Auditoría próximo a vencer

                //Auditorías con Plazo Máximo de Respuesta de Solicitud de Ampliación próximo a vencer

                //Auditorías con Discrepancias abiertas próximas a cumplir fecha de cierre
                AuditoriaList auditorias = Library.Quality.ModuleController.GetAvisoDiscrepanciasAbiertas();
                foreach (AuditoriaInfo item in auditorias)
                {
                    List.Add(new NotifyEntity(ETipoNotificacion.DiscrepanciaAbierta
                                    , ETipoEntidad.Auditoria
                                    , item.Referencia));
                }
            }
		}

		protected override void BuildTree()
		{
			BuildNotificationsTree();
			BuildApuntesPendientesTree();
            BuildAuditoriasTree();

			SetTotales();
		}

		protected void BuildNotificationsTree()
		{
			if (List == null) return;

			TreeNode node = null;

			node = new TreeNode();
			node.Text = moleQule.Library.Common.EnumText<ETipoNotificacion>.GetLabel(ETipoNotificacion.GastoPendiente);
			node.Tag = new NotifyEntity(ETipoNotificacion.Node, node.Text);
			node.ImageIndex = 4;
			node.SelectedImageIndex = 4;
			Entidades_TV.Nodes.Add(node);

			node = new TreeNode();
			DateTime fecha = DateTime.Today.AddDays((double)Library.Store.ModulePrincipal.GetNotifyPlazoPagos());
			node.Text = String.Format(Store.Resources.Messages.NOFITY_PAGOS_PENDIENTES, fecha.ToShortDateString());
			node.Tag = new NotifyEntity(ETipoNotificacion.Node, node.Text, true);
			node.ImageIndex = 4;
			node.SelectedImageIndex = 4;
			Entidades_TV.Nodes[GASTOS_PENDIENTES].Nodes.Add(node);

			node = new TreeNode();
			node.Text = moleQule.Library.Common.EnumText<ETipoNotificacion>.GetLabel(ETipoNotificacion.IngresoPendiente);
			node.Tag = new NotifyEntity(ETipoNotificacion.Node, node.Text);
			node.ImageIndex = 3;
			node.SelectedImageIndex = 3;
			Entidades_TV.Nodes.Add(node);

			foreach (NotifyEntity item in List)
			{
				switch (item.ETipoNotificacion)
				{
					case ETipoNotificacion.GastoPendiente:
					case ETipoNotificacion.IngresoPendiente:
						{
							node = new TreeNode();
							node.Name = item.ETipoEntidad.ToString();
							node.Text = item.FullTitle;
							node.Tag = item;
							node.SelectedImageIndex = 1;
							node.Checked = item.Checked;

							switch (item.ETipoNotificacion)
							{
								case ETipoNotificacion.GastoPendiente:
									node.ImageIndex = 4;
									Entidades_TV.Nodes[GASTOS_PENDIENTES].Nodes.Add(node);
									break;

								case ETipoNotificacion.IngresoPendiente:
									node.ImageIndex = 3;
									Entidades_TV.Nodes[INGRESOS_PENDIENTES].Nodes.Add(node);
									break;
							}
						}
						break;


					case ETipoNotificacion.PagoBancoPendiente:
						{
							node = new TreeNode();
							node.Name = item.ETipoEntidad.ToString();
							node.Text = item.FullTitle;
							node.Tag = item;
							node.SelectedImageIndex = 1;
							node.Checked = item.Checked;
							node.ImageIndex = 6;

							Entidades_TV.Nodes[GASTOS_PENDIENTES].Nodes[PAGOS_BANCO_PENDIENTES].Nodes.Add(node);
						} break;
				}
			}

			Entidades_TV.ExpandAll();
		}

		protected void BuildApuntesPendientesTree()
		{
			if (List == null) return;

			TreeNode node = null;

			node = new TreeNode();
			node.Text = "Apuntes Bancarios Pendientes";
			node.Tag = new NotifyEntity(ETipoNotificacion.Node, node.Text);
			node.ImageIndex = 2;
			node.SelectedImageIndex = 2;
			Apuntes_TV.Nodes.Add(node);

			node = new TreeNode();
			node.Text = String.Format(Store.Resources.Messages.NOTIFY_PAGOS_TARJETAS_VENCIDOS, _fecha_apuntes.ToShortDateString());
			node.Tag = new NotifyEntity(ETipoNotificacion.Node, node.Text, true);
			node.ImageIndex = 5;
			node.SelectedImageIndex = 5;
			Apuntes_TV.TopNode.Nodes.Add(node);

			foreach (NotifyEntity item in List)
			{
				switch (item.ETipoNotificacion)
				{
					case ETipoNotificacion.CobroVencido:
					case ETipoNotificacion.PagoVencido:
					case ETipoNotificacion.PagoTarjetaVencido:
						{
							node = new TreeNode();
							node.Name = item.ETipoEntidad.ToString();
							node.Text = item.FullTitle;
							node.Tag = item;
							node.SelectedImageIndex = 1;
	
							switch (item.ETipoNotificacion)
							{
								case ETipoNotificacion.PagoTarjetaVencido:
									node.ImageIndex = 5;
									Apuntes_TV.TopNode.Nodes[PAGOS_TARJETA_PENDIENTES].Nodes.Add(node);
									break;

								case ETipoNotificacion.PagoVencido:
									node.ImageIndex = 4;
									Apuntes_TV.TopNode.Nodes.Add(node);
									break;

								case ETipoNotificacion.CobroVencido:
									node.ImageIndex = 3;
									Apuntes_TV.TopNode.Nodes.Add(node);
									break;
							}
						}
						break;
				}
			}

			CheckNodes();

			Apuntes_TV.ExpandAll();
		}
        
        protected void BuildAuditoriasTree()
        {
            if (List == null) return;

            TreeNode node = null;

            node = new TreeNode();
            node.Text = "Auditorías en curso";
            node.Tag = new NotifyEntity(ETipoNotificacion.Node, node.Text);
            node.ImageIndex = 9;
            node.SelectedImageIndex = 9;
            Auditorias_TV.Nodes.Add(node);

            node = new TreeNode();
            DateTime fecha = DateTime.Today.AddDays((double)Library.Quality.ModulePrincipal.GetAvisoDiscrepanciasAbiertasSetting());
            node.Text = String.Format(Quality.Resources.Messages.NOTIFY_AUDITORIA_DISCREPANCIAS_ABIERTAS, fecha.ToShortDateString());
            node.Tag = new NotifyEntity(ETipoNotificacion.Node, node.Text, true);
            node.ImageIndex = 10;
            node.SelectedImageIndex = 10;
            Auditorias_TV.TopNode.Nodes.Add(node);

            foreach (NotifyEntity item in List)
            {
                switch (item.ETipoNotificacion)
                {
                    case ETipoNotificacion.DiscrepanciaAbierta:
                        {
                            node = new TreeNode();
                            node.Name = item.ETipoEntidad.ToString();
                            node.Text = item.Title;
                            node.Tag = item;
                            node.SelectedImageIndex = 11;
                            node.ImageIndex = 11;
                            Auditorias_TV.TopNode.Nodes[DISCREPANCIAS_ABIERTAS].Nodes.Add(node);
                        }
                        break;
                }
            }

            CheckNodes();

            Auditorias_TV.ExpandAll();
        }

		#endregion

		#region Business Methods

		private void SetTotales()
		{
			SetSubtotales(Entidades_TV.Nodes[GASTOS_PENDIENTES]);
			SetSubtotales(Entidades_TV.Nodes[INGRESOS_PENDIENTES]);
			SetSubtotales(Apuntes_TV.Nodes[0]);
		}

		private void SetSubtotales(TreeNode node)
		{
			if (((NotifyEntity)node.Tag).ETipoNotificacion != ETipoNotificacion.Node) return;

			if (node.Nodes.Count > 0) ((NotifyEntity)node.Tag).Total = 0;

			foreach (TreeNode item in node.Nodes)
			{
				SetSubtotales(item);
				if (item.Checked) ((NotifyEntity)node.Tag).Total += ((NotifyEntity)item.Tag).Total;
			}

			node.Text = ((NotifyEntity)node.Tag).FullTitle;
		}

		private void CheckNodes()
		{
			CheckSubNodes(Apuntes_TV.Nodes[0]);
		}

		private void CheckSubNodes(TreeNode node)
		{
			node.Checked = true;

			foreach (TreeNode item in node.Nodes)
				CheckSubNodes(item);
		}

		#endregion

		#region Actions

		protected override void OpenMngFormAction(NotifyEntity item)
		{
			switch (item.ETipoEntidad)
			{
				case ETipoEntidad.Pago:
					{
						PaymentMngForm form = new PaymentMngForm(false, MainForm.Instance, ETipoPago.Todos, (PaymentList)item.List);
						FormMng.Instance.ShowFormulario(form, this);
						form.ViewMode = molView.Enbebbed;
						form.Text = item.Title;
						form.Left = this.Right + 1;
						form.Width -= this.Width;
						form.FitColumns();
					}
					break;

				case ETipoEntidad.FacturaRecibida:
					{
						InputInvoiceMngForm form = new InputInvoiceMngForm(false, MainForm.Instance, ETipoFacturas.Todas, (InputInvoiceList)item.List);
						FormMng.Instance.ShowFormulario(form, this);
						form.ViewMode = molView.Enbebbed;
						form.Text = item.Title;
						form.Left = this.Right + 1;
						form.Width -= this.Width;
						form.FitColumns();
					}
					break;

				case ETipoEntidad.Gasto:
					{
                        ExpenseMngForm form = new ExpenseMngForm(false, MainForm.Instance, ECategoriaGasto.Todos, (ExpenseList)item.List);
						FormMng.Instance.ShowFormulario(form, this);
						form.ViewMode = molView.Enbebbed;
						form.Text = item.Title;
						form.Left = this.Right + 1;
						form.Width -= this.Width;
						form.FitColumns();
					}
					break;

				case ETipoEntidad.FacturaEmitida:
					{
						InvoiceMngForm form = new InvoiceMngForm(false, MainForm.Instance, (OutputInvoiceList)item.List, ETipoFacturas.Todas);
						FormMng.Instance.ShowFormulario(form, this);
						form.ViewMode = molView.Enbebbed;
						form.Text = item.Title;
						form.Left = this.Right + 1;
						form.Width -= this.Width;
						form.FitColumns();
					}
					break;

				case ETipoEntidad.Cobro:
					{
						CobroMngForm form = new CobroMngForm(false, MainForm.Instance, (CobroList)item.List, ETipoCobro.Todos);
						FormMng.Instance.ShowFormulario(form, this);
						form.ViewMode = molView.Enbebbed;
						form.Text = item.Title;
						form.Left = this.Right + 1;
						form.Width -= this.Width;
						form.FitColumns();
					}
					break;
			}
		}

		protected virtual void SelectFechaAction()
		{
			InputDateForm form = new InputDateForm();

			form.ShowDialog(this);

			if (form.DialogResult == DialogResult.OK)
			{
				_fecha_apuntes = form.Value;
				FechaApuntes_TI.Text = _fecha_apuntes.ToShortDateString();

				RefreshAction();
			}
		}

		public override void RefreshAction()
		{
			try
			{
				ResetTree();

				PgMng.Reset(BarSteps, 1, Resources.Messages.RETRIEVING_NOTIFICATIONS, _parent);

				RefreshMainData();
				BuildTree();

				FormMng.Instance.CloseAllForms(this);
			}
			finally
			{
				PgMng.FillUp();
			}
		}

		#endregion

		#region Buttons

		private void SelectFechaApuntes_TI_Click(object sender, EventArgs e)
		{
			SelectFechaAction();
		}

		private void Submit_TI_Click(object sender, EventArgs e)
		{
			try
			{
				if (ProgressInfoMng.ShowQuestion("A continuación se generarán los apuntes bancarios asociados") == DialogResult.No) return;

				RefreshAction();

				PgMng.Reset(5, 1, "Creando apuntes bancarios...", this);

				if (Apuntes_TV.TopNode.Nodes[PAGOS_PENDIENTES].Checked)
				{
					PgMng.Grow("Creando apuntes bancarios de pagos");
					Library.Invoice.ModuleController.CreateApuntesBancarios(CobrosVencidosList);
				}

				if (Apuntes_TV.TopNode.Nodes[COBROS_PENDIENTES].Checked)
				{
					PgMng.Grow("Creando apuntes bancarios de pagos");
					Library.Invoice.ModuleController.CreateApuntesBancarios(PagosVencidosList);
				}

				PgMng.Grow("Creando apuntes bancarios de pagos por tarjeta de crédito");
				foreach (PaymentList list in PagosTarjetasList)
					if (Apuntes_TV.TopNode.Nodes[PAGOS_TARJETA_PENDIENTES].Nodes[PagosTarjetasList.IndexOf(list)].Checked)
					{
						Library.Invoice.ModuleController.CreateApuntesBancarios(list);
					}

				PgMng.FillUp();

				RefreshAction();
			}
			catch (Exception ex)
			{
				PgMng.FillUp();
				throw ex;
			}
		}

		private void Refresh_TI_Click(object sender, EventArgs e)
		{
			RefreshAction();
		}

		#endregion

		#region Events

		private void Apuntes_TV_AfterSelect(object sender, TreeViewEventArgs e)
		{
			if (e.Node == null) return;
			if (e.Node.Tag == null) return;

			OpenMngFormAction((NotifyEntity)e.Node.Tag);
		}

		#endregion
	}
}

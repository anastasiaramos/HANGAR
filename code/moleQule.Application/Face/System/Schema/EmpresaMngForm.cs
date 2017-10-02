using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

using Csla;
using CslaEx;

using moleQule.Library;
using moleQule.Library.Application;
using moleQule.Face;

namespace moleQule.Face.Application
{
    public partial class EmpresaMngForm : Skin02.SchemaLMngSkinForm
    {

        #region Attributes & Properties
		
        public const string ID = "EmpresaMngForm";
		public static Type Type { get { return typeof(EmpresaMngForm); } }

		protected override int BarSteps { get { return base.BarSteps + 6; } }
		
		/// <summary>
		///  Lista resultado del filtro
		/// </summary>
        private new SortedBindingList<EmpresaInfo> _filter_results = null;

        /// <summary>
        ///  Lista resultado de la busqueda
        /// </summary>
        private new SortedBindingList<EmpresaInfo> _search_results = null;

        /// <summary>
        ///  Lista de objetos de sÃ³lo lectura
        /// </summary>
        public new EmpresaList List { get { return _item_list as EmpresaList; } set { _item_list = value; } }

		/// <summary>
		/// Devuelve el OID del objeto activo seleccionado de la tabla
		/// </summary>
		/// <returns></returns>
		public override long ActiveOID { get { return Datos.Current != null ? ((EmpresaInfo)Datos.Current).Oid : -1; } }

        /// <summary>
        /// Devuelve el objeto activo seleccionado de la tabla
        /// </summary>
        /// <returns></returns>
        public EmpresaInfo ActiveItem { get { return (Datos.Current != null) ? (EmpresaInfo)Datos.Current : null; } }
		
        public override long ActiveFoundOID { get { return (DatosSearch.Current != null) ? ((EmpresaInfo)(DatosSearch.Current)).Oid : -1; } }

        public override string SortProperty { get { return this.GetGridSortProperty(Tabla); } }
        public override ListSortDirection SortDirection { get { return this.GetGridSortDirection(Tabla); } }

        /// <summary>
        /// Devuelve el ISchemaInfo seleccionado
        /// </summary>
        /// <returns></returns>
        public override ISchemaInfo ActiveISchema { get { return EmpresaInfo.GetISchemaInfo(ActiveOID); } }

		#endregion
		
		#region Factory Methods

		public EmpresaMngForm()
            : this(false) {}

		public EmpresaMngForm(bool isModal)
			: this(isModal, null) {}
		
		public EmpresaMngForm(bool isModal, Form parent)
			: base(isModal, parent, EmpresaMngForm.Type)
		{
			InitializeComponent();

            // Parche para poder abrir el formulario en modo diseÃ±o y no perder la configuracion de columnas
            DatosLocal_BS = Datos;
            Tabla.DataSource = DatosLocal_BS;

            TablaBase = Tabla;

            base.SortProperty = Codigo.DataPropertyName;
        }
		
		#endregion

        #region Business Methods

        protected override Type GetColumnType(string column_name)
        {
            return Tabla.Columns[column_name] != null ? Tabla.Columns[column_name].ValueType : null;
        }
        
        protected override string GetColumnProperty(string column_name)
        {
            return Tabla.Columns[column_name] != null ? Tabla.Columns[column_name].DataPropertyName : null;
        }

        #endregion
		
		#region Autorizacion

        /// <summary>
        /// Aplica las reglas de autorización con el objetivo de habilitar o
        /// deshabilitar botones del menú según los permisos
        /// </summary>
        protected override void ApplyAuthorizationRules()
        {
            if (AppContext.User == null) return;

            // Buttons
            this.Add_Button.Enabled = AppContext.User.IsAdmin;
            this.Delete_Button.Enabled = AppContext.User.IsAdmin;
            this.Edit_Button.Enabled = AppContext.User.IsAdmin;
            this.View_Button.Enabled = AppContext.User.IsAdmin;

            // Context Menu
            Mng_CMenu.Items[Nuevo_MI.Name].Enabled = AppContext.User.IsAdmin;
            Mng_CMenu.Items[Detalle_MI.Name].Enabled = AppContext.User.IsAdmin;
            Mng_CMenu.Items[Modificar_MI.Name].Enabled = AppContext.User.IsAdmin;
            Mng_CMenu.Items[Borrar_MI.Name].Enabled = AppContext.User.IsAdmin;
            Mng_CMenu.Items[Duplicar_MI.Name].Enabled = AppContext.User.IsAdmin;
            Mng_CMenu.Items[Borrar_MI.Name].Enabled = AppContext.User.IsAdmin;
            Mng_CMenu.Items[Imprimir_MI.Name].Enabled = AppContext.User.IsAdmin;
        }

		#endregion

		#region Style & Source

		/// <summary>Formatea los controles del formulario
		/// <returns>void</returns>
		/// </summary>
		public override void FormatControls()
		{
            if (Tabla == null) return;
			
			base.FormatControls();

            HideAction(molAction.Print);

			List<DataGridViewColumn> cols = new List<DataGridViewColumn>();
            Nombre.Tag = 1;

            cols.Add(Nombre);

            ControlsMng.MaximizeColumns(Tabla, cols);   
			ControlsMng.MarkGridColumn(Tabla, ControlsMng.GetCurrentColumn(Tabla));
		}

		/// <summary>
		/// Toma la lista de bancos de la base de datos y rellena la tabla.
		/// </summary>
		protected override void RefreshMainData()
		{
			Bar.Grow(string.Empty, "Empresa");
			
			_selected_oid = ActiveOID;
					
			List = EmpresaList.GetList(false);
			Bar.Grow(string.Empty, "Lista de Empresas");
        }

        protected override void RefreshSources()
        {
            Datos.DataSource = EmpresaList.SortList(List, SortProperty, SortDirection);
            PgMng.Grow(string.Empty, "Ordenar Lista");

            base.RefreshSources();
        }
				
		/// <summary>
		/// Selecciona un elemento de la tabla
		/// </summary>
		/// <param name="oid">Identificar del elemento</param>
		protected override void Select(long oid)
		{
			int foundIndex = Datos.IndexOf(List.GetItem(oid));
			Datos.Position = foundIndex;
		}

		/// <summary>
		/// Filtra la tabla
		/// </summary>
		/// <param name="oid">Identificar del elemento</param>
		protected override void SetFilter(bool on)
		{
            DataGridViewColumn col = ControlsMng.GetCurrentColumn(Tabla);

			try
			{
                Datos.DataSource = on ? _filter_results : EmpresaList.SortList(List, SortProperty, SortDirection);
			}
			catch (Exception)
			{
                Datos.DataSource = EmpresaList.SortList(List, SortProperty, SortDirection);
			}
			
			ControlsMng.OrderByColumn(Tabla, col, SortDirection);
		}

        /// <summary>
        /// Marca en la tabla el schema por defecto
        /// </summary>
        public override void MarkDefaultSchema()
        {
            List.SetPrincipal(PrincipalBase.GetDefaultSchema());
            Datos.ResetBindings(false);
        }

		#endregion

        #region Actions

        public override void LoadSchema()
        {
            base.LoadSchema();
            Controler.ActivateAcreedores();
        }

        public override void LoadSchema(ISchemaInfo schema)
        {
            base.LoadSchema(schema);
            Controler.ActivateAcreedores();
        }


        /// <summary>
        /// Abre el formulario para aÃ±adir item
        /// <returns>void</returns>
        /// </summary>
        public override void OpenAddForm()
        {
            try
            {
                if (List.Count == Convert.ToInt32(Resources.Defaults.ENTERPRISE_MAX_LIMITED))
                {
                    MessageBox.Show(Resources.Messages.ENTERPRISE_MAX_LIMITED_NOTICE,
                                    moleQule.Face.Resources.Labels.ADVISE_TITLE,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                }
                else
                    AddForm(new EmpresaAddForm());
            }
            catch (Csla.DataPortalException ex)
            {
                MessageBox.Show(ex.BusinessException.ToString(),
                                moleQule.Face.Resources.Labels.ERROR_TITLE,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(),
                                moleQule.Face.Resources.Labels.ERROR_TITLE,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
            }
		}

		/// <summary>
		/// Abre el formulario para ver item
		/// <returns>void</returns>
		/// </summary>
		public override void OpenViewForm()
		{
			
			try
			{
				AddForm(new EmpresaViewForm(ActiveOID));
			}
			catch (Csla.DataPortalException ex)
			{
				MessageBox.Show(ex.BusinessException.ToString(),
                                moleQule.Face.Resources.Labels.ERROR_TITLE,
								MessageBoxButtons.OK,
								MessageBoxIcon.Exclamation);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString(),
                                moleQule.Face.Resources.Labels.ERROR_TITLE,
								MessageBoxButtons.OK,
								MessageBoxIcon.Exclamation);
			}
		}

        /// <summary>
        /// Abre el formulario para editar item
        /// <returns>void</returns>
        /// </summary>
        public override void OpenEditForm() 
        {             
            try
            {
                EmpresaEditForm form = new EmpresaEditForm(ActiveOID);
                if(form.EntityInfo != null)
                    AddForm(form);
            }
            catch (Csla.DataPortalException ex)
            {
                MessageBox.Show(ex.BusinessException.ToString(),
                                moleQule.Face.Resources.Labels.ERROR_TITLE, 
								MessageBoxButtons.OK,
								MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(),
                                moleQule.Face.Resources.Labels.ERROR_TITLE, 
								MessageBoxButtons.OK,
								MessageBoxIcon.Exclamation);
            }
        }

		/// <summary>
		/// Abre el formulario para borrar item
		/// <returns>void</returns>
		/// </summary>
		public override void DeleteObject(long oid)
		{
			if (MessageBox.Show(moleQule.Face.Resources.Messages.DELETE_CONFIRM,
								moleQule.Face.Resources.Labels.ADVISE_TITLE,
								MessageBoxButtons.YesNoCancel, 
								MessageBoxIcon.Question) == DialogResult.Yes)
			{
				try
				{
                    
                    Empresa.Delete(oid);

                    //Se eliminan todos los formularios de ese objeto
                    foreach (ItemMngBaseForm form in _list_active_form)
                    {
                        if (form.Oid == oid)
                        {
                            form.Dispose();
                            break;
                        }
                    }
				}
				catch (Csla.DataPortalException ex)
				{
					MessageBox.Show(iQExceptionHandler.GetiQException(ex).Message);
				}
				finally
				{
					RefreshList();
				}
			}
		}

        protected override bool DoFind(object value) 
        {
            _search_results = Localize(value, ((DataGridViewColumn)(Fields_CB.SelectedItem)).Name);
            return _search_results != null; 
        }

        protected override bool DoFilter(object value) 
        {
            _filter_results = Localize(value, ((DataGridViewColumn)(Fields_CB.SelectedItem)).Name);
            return _filter_results != null; 
        }
        
        protected override bool DoFilterByFirst(string value, string column_name) 
        { 	
			if (column_name == null)
				column_name = ControlsMng.GetCurrentColumn(Tabla).Name;
			
            _filter_results = Localize(value, column_name); 
            return _filter_results != null; 
        }

        protected new SortedBindingList<EmpresaInfo> Localize(object value, string column_name)
        {
            SortedBindingList<EmpresaInfo> list = null;

            if (List == null)
            {
                MessageBox.Show(moleQule.Face.Resources.Messages.NO_RESULTS);
                return null;
            }

            FCriteria criteria = null;

            string related = "none";

            switch (column_name)
            {
                default:
                    {	
						criteria = GetCriteria(column_name, value, _operation);
                    } break;
            }

            switch (related)
            {
				case "none":
				{
                    list = List.GetSortedSubList(criteria, SortProperty, SortDirection);
				} break;
            }

            if (list.Count == 0)
            {
                MessageBox.Show(moleQule.Face.Resources.Messages.NO_RESULTS);
                return null;
            }

            DatosSearch.DataSource = list;
            DatosSearch.MoveFirst();

            return list;
        }

		#endregion

		#region Events
		
		private void EmpresaMngForm_Shown(object sender, EventArgs e)
        {
            ControlsMng.OrderByColumn(Tabla, Nombre, ListSortDirection.Ascending);
            Fields_CB.Text = Nombre.HeaderText;
            ControlsMng.MarkGridColumn(Tabla, ControlsMng.GetCurrentColumn(Tabla));
        }

		private void Tabla_KeyPress(object sender, KeyPressEventArgs e)
        {
            FilterByKey(e.KeyChar.ToString());
		}
		
		private void Tabla_DoubleClick(object sender, EventArgs e)
		{
			DefaultAction();
		}

        private void Tabla_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ControlsMng.SetCurrentCell(Tabla);
            ControlsMng.MarkGridColumn(Tabla, ControlsMng.GetCurrentColumn(Tabla));
        }
        
        private void Tabla_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ControlsMng.MarkGridColumn(Tabla, ControlsMng.GetCurrentColumn(Tabla));
        }

		private void Tabla_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
		{
            if (List == null) return;
			ControlsMng.MarkGridColumn(Tabla, ControlsMng.GetCurrentColumn(Tabla));
		}
		
		#endregion

    }
}

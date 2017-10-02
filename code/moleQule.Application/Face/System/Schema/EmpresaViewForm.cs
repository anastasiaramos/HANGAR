using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using moleQule.Face;
using moleQule.Library.Application;

namespace moleQule.Face.Application
{
	public partial class EmpresaViewForm : EmpresaForm
	{

        #region Business Methods

        /// <summary>
        /// Se trata de la empresa actual y que se va a editar.
        /// </summary>
        private EmpresaInfo _entity;

        public override EmpresaInfo EntityInfo
        {
            get { return _entity; }
        }

		public override long ContactosActiveOID()
		{
			if (Datos_Contactos.Current != null)
				return ((ContactoEmpresaInfo)(Datos_Contactos.Current)).Oid;
			else
				return -1;
		}

        #endregion

        #region Factory Methods

        public EmpresaViewForm(long oid)
            : base(oid)
        {
            InitializeComponent();
			SetFormData();
			this.Text = Resources.Labels.EMPRESA_DETAIL_TITLE + " " + EntityInfo.Name.ToUpper();
            _mf_type = ManagerFormType.MFView;

		}

        protected override void GetFormSourceData(long oid)
        {
            _entity = EmpresaInfo.Get(oid, true);
        }

        #endregion

        #region Style & Source

        /// <summary>Formatea los Controles del formulario
        /// <returns>void</returns>
        /// </summary>
        public override void FormatControls()
        {
			SetReadOnlyControls(this.Controls);
            Cancel_BT.Enabled = false;
            Cancel_BT.Visible = false;
			base.FormatControls();
        }

        /// <summary>
        /// Asigna el objeto principal al origen de datos 
        /// <returns>void</returns>
        /// </summary>
        protected override void RefreshMainData()
        {
			Datos.DataSource = _entity;
		    
			Bar.Grow();

			base.RefreshMainData();
            Bar.FillUp();
        }

        #endregion

		#region Validation & Format

		#endregion

        #region Actions

        protected override void SaveAction() { _action_result = DialogResult.Cancel; }

        #endregion

        #region Events

        #endregion
	}
}


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

using CslaEx;

using moleQule.Library;
using moleQule.Library.Security;
using moleQule.Face;
using moleQule.Library.Common;
using moleQule.Face.Common;
using moleQule.Library.Application;
using moleQule.Face.Invoice;
using moleQule.Face.Store;

namespace moleQule.Face.Application
{
	public partial class EmpresaUIForm : EmpresaForm
	{

		#region Business Methods

        /// <summary>
        /// Se trata de la empresa actual y que se va a editar.
        /// </summary>
        protected Empresa _entity;

		public override Empresa Entity { get { return _entity; } set { _entity = value; } }
		public override EmpresaInfo EntityInfo	{ get { return (_entity != null) ? _entity.GetInfo() : null; } }

        #endregion

        #region Factory Methods

        public EmpresaUIForm() 
        {
            InitializeComponent();
            //_entity = Empresa.New();
            //_entity.BeginEdit();
            //SetFormData();
        }

        public EmpresaUIForm(long oid)
            : base(oid)
        {
            InitializeComponent();
        }

		public EmpresaUIForm(Empresa empresa)
            : base()
        {
            InitializeComponent();
            _entity = empresa.Clone();
            _entity.BeginEdit();
            SetFormData();
        }

        protected override void GetFormSourceData(long oid)
        {
            _entity = Empresa.Get(oid);
            _entity.BeginEdit();
        }

        /// <summary>
        /// Guarda en la bd el objeto actual
        /// </summary>
        protected override bool SaveObject()
        {
            using (StatusBusy busy = new StatusBusy(moleQule.Face.Resources.Messages.SAVING))
            {
                // Comprobamos que no se intente insertar uno con el mismo codigo
                //if (Entity.IsNew && Empresa.Exists(Codigo_TB.Text))
                //{
                //    MessageBox.Show(moleQule.Face.Resources.Messages.OPERATION_ERROR + Messages.DUPLICATED_CODE);
                //    return false;
                //}

                this.Datos.RaiseListChangedEvents = false;
                this.Datos_Contactos.RaiseListChangedEvents = false;

                Empresa temp = _entity.Clone();
                temp.ApplyEdit();

                // do the save
                try
                {
                    _entity = temp.Save();
                    _entity.ApplyEdit();

                    // Se modifica el nombre de la foto
                    if (_entity.Logo == "00.bmp")
                    {
						Images.Rename(_entity.Logo, _entity.Code + ".bmp", Controler.LOGOS_EMPRESAS_PATH);
                        _entity.Logo = _entity.Code + ".bmp";
                        _entity.Save();
                    }

                    //_entity.BeginEdit();
                    return true;
                }
				catch (iQValidationException ex)
				{
					MessageBox.Show(iQExceptionHandler.GetAllMessages(ex) +
									Environment.NewLine + ex.SysMessage,
									System.Windows.Forms.Application.ProductName,
									MessageBoxButtons.OK,
									MessageBoxIcon.Exclamation);
					return false;

				}
				catch (Exception ex)
				{
					MessageBox.Show(moleQule.Face.Resources.Messages.OPERATION_ERROR + Environment.NewLine +
									ex.Message,
                                    System.Windows.Forms.Application.ProductName,
									MessageBoxButtons.OK,
									MessageBoxIcon.Exclamation);
					return false;
				}
                finally
                {
                    this.Datos.RaiseListChangedEvents = true;
                    this.Datos_Contactos.RaiseListChangedEvents = true;
                }
            }

        }

        #endregion

        #region Style & Source

		/// <summary>Formatea los Controles del formulario
        /// <returns>void</returns>
        /// </summary>
		public override void FormatControls()
		{
			base.FormatControls();
		}

        /// <summary>
        /// Asigna el objeto principal al origen de datos 
        /// <returns>void</returns>
        /// </summary>
        protected override void RefreshMainData()
        {
			Datos.DataSource = _entity;
			Datos_Contactos.DataSource = ContactoEmpresas.SortList(_entity.Contactos, "Nombre", ListSortDirection.Ascending);
        }

        #endregion

		#region Validation & Format

        protected override void ValidateInput()
        {
            switch (_entity.TipoID)
            {
                case (long)ETipoID.CIF:
                    Validator.ValidateCIF(ID_LB.Text, Codigo_TB.Text);
                    break;

                case (long)ETipoID.NIF:
                case (long)ETipoID.DNI:
                    Validator.ValidateNIF(ID_LB.Text, Codigo_TB.Text);
                    break;

                case (long)ETipoID.NIE:
                    Validator.ValidateNIE(ID_LB.Text, Codigo_TB.Text);
                    break;
            }
        }

		private void ID_TB_Validated(object sender, EventArgs e)
		{
			FormatData();
		}

		private void ID_TB_Validating(object sender, CancelEventArgs e)
		{
			ValidateInput();
		}

		#endregion

        #region Actions & Buttons 

        /// <summary>
        /// Implementa Save_button_Click
        /// </summary>
        protected override void SaveAction()
        {
            try
            {
                ValidateInput();
            }
            catch (iQValidationException ex)
            {
                this.Enabled = true;
                MessageBox.Show(ex.Message,
                                moleQule.Face.Resources.Labels.ADVISE_TITLE,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                _action_result = DialogResult.Ignore;
                return;
            }

            _action_result = SaveObject() ? DialogResult.OK : DialogResult.Ignore;

            if (_action_result == DialogResult.OK)
            {
                if (AppContext.PrincipalBase.ActiveSchema != null)
                {
                    if (_entity.Oid == AppContext.PrincipalBase.ActiveSchema.Oid)
                        AppContext.PrincipalBase.ActiveSchema = (ISchemaInfo)_entity.GetInfo();
                }
            }
        }

		private void CIF_RB_Click(object sender, EventArgs e)
		{
			Entity.TipoID = (long)TipoId.CIF;
			MascaraID_Label.Text = "X12345678";
			ValidateInput();
		}

		private void NIF_RB_Click(object sender, EventArgs e)
		{
			Entity.TipoID = (long)TipoId.NIF;
			MascaraID_Label.Text = "12345678-X";
			ValidateInput();
		}

		private void NIE_RB_Click(object sender, EventArgs e)
		{
			Entity.TipoID = (long)TipoId.NIE;
			MascaraID_Label.Text = "X1234567-X";
			ValidateInput();
		}

		private void Otros_RB_Click(object sender, EventArgs e)
		{
			Entity.TipoID = (long)TipoId.OTROS;
			MascaraID_Label.Text = string.Empty;
		}

        private void Examinar_Button_Click(object sender, EventArgs e)
        {
            if (Browser.ShowDialog() == DialogResult.OK)
			{
				Entity.Logo = Entity.Code + ".bmp";
                Images.Save(Browser.FileName, Controler.LOGOS_EMPRESAS_PATH, Entity.Logo);
			}

            Images.Show(Entity.Logo, Controler.LOGOS_EMPRESAS_PATH, Logo_PictureBox);
        }

        private void Ninguno_Button_Click(object sender, EventArgs e)
        {
            Images.Delete(Entity.Logo, Controler.LOGOS_EMPRESAS_PATH);
			Entity.Logo = string.Empty;
            Images.Show(Entity.Logo, Controler.LOGOS_EMPRESAS_PATH, Logo_PictureBox);
        }

        private void Municipios_Button_Click(object sender, EventArgs e)
        {
            MunicipioUIForm form = new MunicipioUIForm(this);
            if (form != null && !form.IsDisposed) form.ShowDialog();
        }

        private void Cuenta_BT_Click(object sender, EventArgs e)
        {
            CuentaBancariaSelectForm form = new CuentaBancariaSelectForm(ETipoCuenta.Todas, this);
            if (form.ShowDialog() == DialogResult.OK)
            {
                _entity.CuentaBancaria = ((CuentaBancaria)form.Selected).Valor;
            }
        }

        #endregion

        #region Events

        private void EmpresaUIForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Entity.CloseSession();
        }

		private void Municipio_CB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((Municipio_CB.SelectedItem == null) || (Municipio_CB.SelectedItem.ToString() == _entity.Municipio)) return;

            _entity.Municipio = ((MunicipioInfo)Municipio_CB.SelectedItem).Nombre;
            _entity.Provincia = ((MunicipioInfo)Municipio_CB.SelectedItem).Provincia;
            _entity.CodPostal = ((MunicipioInfo)Municipio_CB.SelectedItem).CodPostal;
            Provincia_TextBox.Text = _entity.Provincia;
            CodPostal_TextBox.Text = _entity.CodPostal;
        }

		private void Municipio_CB_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode.Equals(Keys.Add) || e.KeyCode.Equals(Keys.Oemplus))
			{
				MunicipioUIForm form = new MunicipioUIForm(this);
				if (form != null && !form.IsDisposed) form.ShowDialog();
				Municipio_CB.ResetText();
			}
		}

        #endregion

	}
}


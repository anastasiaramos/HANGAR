using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

using CslaEx;

using moleQule.Library;
using moleQule.Face;
using moleQule.Face.Skin01;

using moleQule.Library.Application;
using moleQule.Library.Common;
using moleQule.Library.Hipatia;
using moleQule.Face.Common;
using moleQule.Face.Hipatia;

namespace moleQule.Face.Application
{
    public partial class EmpresaForm : ItemMngSkinForm
    {

        #region Business Methods

        protected override int BarSteps { get { return 14; } }

		public virtual Empresa Entity { get { return null; } set { } }
		public virtual EmpresaInfo EntityInfo { get { return null; } }

        public virtual long ContactosActiveOID()
        {
            if (Datos_Contactos.Current != null)
                return ((ContactoEmpresa)(Datos_Contactos.Current)).Oid;
            else
                return -1;
        }


        #endregion

        #region Factory Methods

        public EmpresaForm()  : this(-1) {}

        public EmpresaForm(long oid)
            : base(oid)
        {
            InitializeComponent();
        }

        #endregion

        #region Style & Source

        /// <summary>Formatea los Controles del formulario
        /// <returns>void</returns>
        /// </summary>
        public override void FormatControls()
        {
            Docs_BT.Visible = true;

            base.FormatControls();

            List<DataGridViewColumn> cols = new List<DataGridViewColumn>();
            Nombre.Tag = 1;

            cols.Add(Nombre);

            ControlsMng.MaximizeColumns(Contactos_Grid, cols);
        }

		public override void RefreshSecondaryData()
		{
			MunicipioList municipios = MunicipioList.GetList(false);
			Datos_Municipios.DataSource = municipios;
			Municipio_CB.Text = EntityInfo.Municipio;
			Datos_Municipios_Contactos.DataSource = municipios;
			Bar.Grow();

			Datos_Cargos.DataSource = CargoList.GetList(false);
            Bar.Grow();
		}

		/// <summary>
		/// Asigna el objeto principal al origen de datos 
		/// <returns>void</returns>
		/// </summary>
		protected override void RefreshMainData()
		{
			Images.Show(EntityInfo.Logo, moleQule.Library.Application.Controler.LOGOS_EMPRESAS_PATH, Logo_PictureBox);
            Bar.Grow();
		}

		/// <summary>
		/// Asigna los datos de origen para controles que dependen de otros
		/// </summary>
		/// <param name="controlName"></param>
		protected override void SetDependentControlSource(string controlName)
		{
			switch (controlName)
			{
				case "ID_GB":
					{
						CIF_RB.Checked = (EntityInfo.TipoID == (long)TipoId.CIF);
						NIF_RB.Checked = (EntityInfo.TipoID == (long)TipoId.NIF);
						NIE_RB.Checked = (EntityInfo.TipoID == (long)TipoId.NIE);
						Otros_RB.Checked = (EntityInfo.TipoID == (long)TipoId.OTROS);
					} break;
			}
		}

        #endregion

		#region Validation & Format

		#endregion

        #region Actions

        /// <summary>
        /// Implementa Docs_BT_Click
        /// </summary>
        protected override void DocumentsAction()
        {
            try
            {
                AgenteEditForm form = new AgenteEditForm(typeof(Empresa), EntityInfo as IAgenteHipatia);
                form.ShowDialog();
            }
            catch (HipatiaException ex)
            {
                if (ex.Code == HipatiaCode.NO_AGENTE)
                {
                    AgenteAddForm form = new AgenteAddForm(typeof(Empresa), EntityInfo as IAgenteHipatia);
                    form.ShowDialog();
                }
            }
        }

        #endregion

        #region Buttons

        #endregion

        #region Events

		private void Datos_DataSourceChanged(object sender, EventArgs e)
		{
			SetDependentControlSource(ID_GB.Name);
		}

        private void Contactos_Grid_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                switch (e.ColumnIndex)
                {
                    case 2:
                        {
                            CargoUIForm form = new CargoUIForm(true);
                            if (form != null && !form.IsDisposed) form.ShowDialog();
                            break;
                        }
                    case 6:
                        {
                            MunicipioUIForm form = new MunicipioUIForm(this);
                            if (form != null && !form.IsDisposed) form.ShowDialog();
                            break;
                        }

                }
            }
        }

        private void Contactos_Grid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (Contactos_Grid.CurrentRow != null)
            {
                if ((Contactos_Grid.CurrentCell.Value != null) && (Contactos_Grid.CurrentCell.ColumnIndex == 6))
                {
                    Contactos_Grid.CurrentRow.Cells["CodPostal"].Value = ((MunicipioInfo)((DataGridViewComboBoxCell)Contactos_Grid.CurrentRow.Cells["Municipio"]).Items[Datos_Municipios_Contactos.Position]).CodPostal;
                    Contactos_Grid.CurrentRow.Cells["Provincia"].Value = ((MunicipioInfo)((DataGridViewComboBoxCell)Contactos_Grid.CurrentRow.Cells["Municipio"]).Items[Datos_Municipios_Contactos.Position]).Provincia;
                }
            }
        }

        #endregion

    }
}


using System;
using System.Windows.Forms;

using moleQule.Face;

using moleQule.Library.Application;

namespace moleQule.Face.Application
{
	public partial class EmpresaEditForm : moleQule.Face.Application.EmpresaUIForm
    {

        #region Factory Methods

        public EmpresaEditForm(long oid)
            : base(oid)
		{
			InitializeComponent();
            if (Entity != null)
            {
                SetFormData();
				this.Text = Resources.Labels.EMPRESA_EDIT_TITLE + " " + Entity.Name.ToUpper();
            }
            _mf_type = ManagerFormType.MFEdit;
        }

		protected override void GetFormSourceData(long oid)
		{
			_entity = Empresa.Get(oid);
			_entity.BeginEdit();
		}

        #endregion

		#region Buttons

		#endregion 

    }
}


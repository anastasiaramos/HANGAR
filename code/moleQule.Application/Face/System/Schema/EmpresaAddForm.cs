using System;
using System.Windows.Forms;

using moleQule.Library.Application;
using moleQule.Face;

namespace moleQule.Face.Application
{
	public partial class EmpresaAddForm : moleQule.Face.Application.EmpresaUIForm
    {

        #region Factory Methods

        public EmpresaAddForm() 
			: base()
        {
            InitializeComponent();
			SetFormData();
            _mf_type = ManagerFormType.MFAdd;
            this.Text = Resources.Labels.EMPRESA_ADD_TITLE;
		}

        public EmpresaAddForm(Empresa source) 
			: base()
		{
			InitializeComponent();
			_entity = source.Clone();
			_entity.BeginEdit();
			SetFormData();
            _mf_type = ManagerFormType.MFAdd;
            this.Text = Resources.Labels.EMPRESA_ADD_TITLE;
		}

		protected override void GetFormSourceData()
		{
			_entity = Empresa.New();
			_entity.BeginEdit();
		}

		#endregion

		#region Buttons

		#endregion	
	}
}


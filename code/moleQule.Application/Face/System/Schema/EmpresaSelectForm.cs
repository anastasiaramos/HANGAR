using System;
using System.Windows.Forms;

using moleQule.Face;
using moleQule.Library;

namespace moleQule.Face.Application
{
    public partial class EmpresaSelectForm : EmpresaMngForm
    {

        #region Factory Methods

        public new const string ID = "EmpresaSelectForm";
        public new static Type Type { get { return typeof(EmpresaSelectForm); } }

        public EmpresaSelectForm()
            : this(null) {}

        public EmpresaSelectForm(Form parent)
            : base(true, parent)
        {
            InitializeComponent();

            Text = "Seleccione la empresa de trabajo";
            DialogResult = DialogResult.Cancel;
        }
		
        #endregion

        #region Style & Source

        /// <summary>Formatea los controles del formulario
        /// <returns>void</returns>
        /// </summary>
        public override void FormatControls()
        {
            SetView(molView.Select);
            base.FormatControls();
        }

        #endregion

        #region Actions

        /// <summary>
        /// Accion por defecto. Se usa para el Double_Click del Grid
        /// <returns>void</returns>
        /// </summary>
        protected override void DefaultAction() 
        {
            LoadSchema();
        }

        #endregion
    }
}

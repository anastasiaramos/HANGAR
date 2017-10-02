using System;
using System.Windows.Forms;

using moleQule.Face.Application;
using moleQule.Face.Application.Resources;

using moleQule.Face.Hipatia;
using moleQule.Library.Hipatia;

namespace moleQule.Face.Application
{
    public partial class AgenteMngForm : AgenteMngBaseForm
    {
        #region Attributes & Properties

        public const string ID = "AgenteMngForm";
        public static Type Type { get { return typeof(AgenteMngForm); } }
        public override Type EntityType { get { return typeof(Agente); } }

        protected override int BarSteps { get { return base.BarSteps; } }

        #endregion

        #region Factory Methods

        public AgenteMngForm()
            : this(string.Empty) { }

        public AgenteMngForm(string schema)
            : base(false, null, schema)
        {
            InitializeComponent();

            SetView(molView.Normal);
            HideAction(molAction.Save);
        }

        #endregion

        #region Actions

        public override void OpenAddForm()
        {
            if (CurrentEntidad == null)
            {
                PgMng.ShowInfoException(Library.Hipatia.Resources.Messages.NO_ENTIDAD_SELECTED);
                _action_result = DialogResult.Ignore;
                return;
            }

            AgenteSelectForm f = new AgenteSelectForm(this, CurrentEntidad);
            if (f.ShowDialog() == DialogResult.Cancel)
            {
                _action_result = DialogResult.Ignore;
                return;
            }

            AgenteAddForm form = new AgenteAddForm(CurrentEntidad, f.Selected as IAgenteHipatia, this);
            AddForm(form);
            _entity = form.Entity;
        }

        #endregion

    }
}


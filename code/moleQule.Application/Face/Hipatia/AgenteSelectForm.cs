using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using moleQule.Face.Hipatia;
using moleQule.Library;
using moleQule.Library.Invoice;
using moleQule.Library.Store;
using moleQule.Library.Hipatia;
using moleQule.Library.Application;

namespace moleQule.Face.Application
{
    public partial class AgenteSelectForm : AgenteSelectBaseForm
    {
        #region Business Methods

        public new const string ID = "AgenteSelectForm";
        public new static Type Type { get { return typeof(AgenteSelectForm); } }

        #endregion

        #region Factory Methods

        public AgenteSelectForm()
            : this(null, null) { }

        public AgenteSelectForm(Form parent, EntidadInfo entidad)
            : base(entidad, true, parent)
        {
            InitializeComponent();
        }

        #endregion

        #region Source

        protected override IAgenteHipatiaList GetAgentes(EntidadInfo entidad)
        {
            IAgenteHipatiaList lista = new IAgenteHipatiaList(new List<IAgenteHipatia>());

            try { lista = Library.Application.AgenteSelector.GetAgentes(entidad); return lista; }
            catch { }
            try { lista = Library.Invoice.AgenteSelector.GetAgentes(entidad); return lista; }
            catch { }
            try { lista = Library.Store.AgenteSelector.GetAgentes(entidad); return lista; }
            catch { }
            try { lista = Library.Instruction.AgenteSelector.GetAgentes(entidad); return lista; }
            catch { }
            try { lista = Library.Quality.AgenteSelector.GetAgentes(entidad); return lista; }
            catch { }

            throw new iQException("No se ha encontrado el tipo de entidad " + entidad.Tipo);
        }

        #endregion
    }
}


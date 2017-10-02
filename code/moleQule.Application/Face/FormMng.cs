using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using moleQule.Library;
using moleQule.Face;
using moleQule.Face.Skin01;

using moleQule.Face.Hipatia;
using moleQule.Face.Instruction;
using moleQule.Face.Invoice;
using moleQule.Face.Quality;

namespace moleQule.Face.Application
{
    /// <summary>
    /// Clase base para manejo (apertura y cierre) de formularios
    /// Es único en el sistema (singleton)
    /// </summary>
    /// <remarks>
    /// Para utilizar el FormMng es necesario indicar cual será el MainForm padre de los formularios
    /// Este MainForm deberá ser un formulario heredado de MainFormBase
    /// </remarks>
    public class FormMng : FormMngBase
    {

        #region Factory Methods

        /// <summary>
        /// Única instancia de la clase MainBaseForm (Singleton)
        /// </summary>
        protected new static FormMng _main;

        /// <summary>
        /// Unique FormMng Class Instance
        /// </summary>
        /// <remarks>
        /// Para utilizar el FormMng es necesario inicializar el MainForm padre de los formularios
        /// </remarks>
        public new static FormMng Instance { get { return (_main != null) ? _main : new FormMng(); } }

        /// <summary>
        /// Constructor
        /// </summary>
        public FormMng()
		{
			// Singleton
			_main = this;
		}

        #endregion

        #region Business Methods

        /// <summary>
        /// Abre un nuevo manager para la entidad. Si no está abierto, lo crea, y si 
        /// lo está, lo muestra 
        /// </summary>
        /// <param name="formID">Identificador del formulario que queremos abrir</param>
        /// <param name="param">Parámetro para el formulario</param>
        public override void OpenForm(string formID, object[] parameters, Form parent)
        {
#if TRACE
            ChildForm cform = null;
#endif
            try
            {
                switch (formID)
                {
                    case AboutForm.ID:
                        {
                            if (!BuscarFormulario(AboutForm.Type))
                            {
                                AboutForm em = new AboutForm();
                                ShowFormulario(em);
                            }
                        }
                        break;

                    case AgenteMngForm.ID:
                        {
                            if (!BuscarFormulario(AgenteMngForm.Type))
                            {
                                AgenteMngForm em = new AgenteMngForm(AppContext.ActiveSchema.Code);
                                ShowFormulario(em);
                            }
                        } break;

                    case DocumentoMngForm.ID:
                        {
                            if (!BuscarFormulario(DocumentoMngForm.Type))
                            {
                                DocumentoMngForm em = new DocumentoMngForm(AppContext.ActiveSchema.Code);
                                ShowFormulario(em);
                            }
                        } break;

                    case LoginForm.ID:
                        {
                            if (!BuscarFormulario(LoginForm.Type))
                            {
                                LoginForm em = new LoginForm();
                                DialogResult res = DialogResult.None;
                                while ((res != DialogResult.Cancel) && (res != DialogResult.OK))
                                {
                                    res = em.ShowDialog();
                                }
                            }
                        } break;

                    case NewsForm.ID:
                        {
                            if (!BuscarFormulario(NewsForm.Type))
                            {
                                NewsForm em = new NewsForm(parameters[0] as List<string>, this.MainForm);
                                ShowFormulario(em);
                            }
                        } break;

                    case SettingsForm.ID:
                        {
                            if (!BuscarFormulario(SettingsForm.Type))
                            {
                                SettingsForm em = new SettingsForm();
                                ShowFormulario(em);
                            }
                        }
                        break;

                    case TipoDocumentoUIForm.ID:
                        {
                            if (!BuscarFormulario(TipoDocumentoUIForm.Type))
                            {
                                TipoDocumentoUIForm em = new TipoDocumentoUIForm();
                                ShowFormulario(em);
                            }
                        } break;

                    default:
                        {
                            try { Common.FormMng.Instance.OpenForm(formID, parameters, this.MainForm); return; }
                            catch { }
                            try { Invoice.FormMng.Instance.OpenForm(formID, parameters, this.MainForm); return; }
                            catch { }
                            try { Store.FormMng.Instance.OpenForm(formID, parameters, this.MainForm); return; }
                            catch { }
                            try { Instruction.FormMng.Instance.OpenForm(formID, parameters, this.MainForm); return; }
                            catch { }
                            try { Quality.FormMng.Instance.OpenForm(formID, parameters, this.MainForm); return; }
                            catch { }
                            try { Face.Hipatia.FormMng.Instance.OpenForm(formID, parameters, this.MainForm); return; }
                            catch { }
                            try { base.OpenForm(formID, parameters, parent); }
                            catch (Exception ex)
                            {
                                ProgressInfoMng.Instance.ShowErrorException(ex);
                            }
                        } break;
                }
#if TRACE
                Globals.Instance.ProgressInfoMng.ShowCronos();
                MessageBox.Show(Globals.Instance.Timer.GetCronos());
                if (cform != null) cform.Bar.ShowCronos();
#endif
            }
            catch (Exception ex)
            {
                MessageBox.Show(iQExceptionHandler.GetAllMessages(ex), System.Windows.Forms.Application.ProductName);
            }
        }

        #endregion

    }
}

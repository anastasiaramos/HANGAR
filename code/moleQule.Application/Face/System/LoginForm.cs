using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using moleQule.Face;
using moleQule.Library;
using moleQule.Library.Application;

namespace moleQule.Face.Application
{
    public partial class LoginForm : Skin02.LoginSkinForm
    {
        #region Attributes & Properties

        public const string ID = "LoginForm";
        public static Type Type { get { return typeof(LoginForm); } }

        #endregion

        #region Factory Methods

        public LoginForm()
            : base(MainForm.Instance)
        {
            InitializeComponent();

            UserName_TB.Text = SettingsMng.Instance.GetLastUser();
#if DEMO
            UserName_TB.Text = "Demo";
            Password_TB.Text = "iQ123456";
#endif
#if STAGING
            UserName_TB.Text = "Admin";
            Password_TB.Text = "iQi_1998";
#endif
        }

        #endregion

        #region Style & Source

        protected override void RefreshMainData()
        {
            UserName_TB.Text = SettingsMng.Instance.GetLastUser();
        }

        #endregion

        #region Actions

        /// <summary>
        /// Implementaci�n de la funci�n virtual LoginBase.LoginAction().
        /// </summary>
        /// <remarks>
        /// Realiza las tareas de login de usuario mediante el objeto Principal que gestiona el usuario activo.
        /// Dicho objeto obtiene una lista de schemas accesibles para el usuario indicado
        /// en el formulario.
        /// </remarks>
        protected override void LoginAction()
        {
            _action_result = DialogResult.None;

            try
            {
                string server = (Server_CkB.Checked) ? Server_TB.Text : string.Empty;

                if (Principal.Login(UserName_TB.Text, Password_TB.Text, server))
                {
                    PgMng.Grow();

                    SettingsMng.Instance.SetLastUser(AppContext.User.Name);

                    string version = SettingsMng.Instance.GetApplicationVersion();

                    if (String.CompareOrdinal(System.Windows.Forms.Application.ProductVersion, version) < 0)
                    {
                        PgMng.ShowInfoException(String.Format(Resources.Messages.NEW_VERSION_AVAILABLE, version));
                        _action_result = DialogResult.Ignore;
                        return;
                    }

                    MainForm.Instance.LoadSchema();

                    //Si el usuario inicia sesi�n correctamente se guarda como el �ltimo usuario
                    //La pr�xima vez que se arranque la aplicaci�n cargar� el nombre de este usuario
                    Principal.SetLastUser(AppContext.User.Name);
                    Principal.SetLastServer(Server_TB.Text);
#if DEMO
                    MessageBox.Show("��AVISO IMPORTANTE!!" + Environment.NewLine + Environment.NewLine +
                                    "Esta versi�n de evaluaci�n de " + ControlerBase.GetApplicationTitle() + " almacena los datos en un servidor remoto por lo que puede sufrir tiempos de espera" +
                                    " superiores a los de la versi�n de pago." + Environment.NewLine + Environment.NewLine +
                                    " Los datos se resetean diariamente, por esta raz�n la informaci�n que introduzca tiene car�cter temporal.", 
                                    ControlerBase.GetApplicationTitle(),
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
#endif
                    _action_result = DialogResult.OK;

                    PgMng.Grow();
                }
                else
                {
                    PgMng.ShowInfoException(Library.Resources.Messages.USER_NOT_AUTHENTIFICATED);
                }
            }
            catch (Exception ex)
            {
                iQException iQex = iQExceptionHandler<iQException>.GetiQException(ex);

                if (null != iQex)
                    PgMng.ShowInfoException(iQex.Message);
                else
                    PgMng.ShowInfoException(ex);
            }
        }

        #endregion
    }
}
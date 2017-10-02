using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;

using moleQule.Library;

namespace moleQule.Face.Application
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            PrincipalBase.SetLocale(CultureInfo.CurrentCulture.Name);

            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(UnhandledException);
            System.Windows.Forms.Application.ThreadException += new ThreadExceptionEventHandler(ThreadException);
            System.Windows.Forms.Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);

            System.Windows.Forms.Application.Run(new MainForm());
        }

        /// <summary>
        /// NON-UI Unhandled Exceptions
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            try
            {
                ProgressInfoMng.Instance.FillUp();
                ProgressInfoMng.Instance.ShowInfoException((Exception)e.ExceptionObject);
            }
            catch (Exception ex)
            {
                ProgressInfoMng.Instance.FillUp();
                ProgressInfoMng.Instance.ShowInfoException(ex);
            }
            finally
            {
            }
        }

        /// <summary>
        /// UI Unhandled Exceptions
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="t"></param>
        public static void ThreadException(object sender, ThreadExceptionEventArgs t)
        {
            try
            {
                ProgressInfoMng.Instance.FillUp();
                ProgressInfoMng.Instance.ShowInfoException(t.Exception);
            }
            catch
            {
            }
            finally
            {
            }
        }
    }
}
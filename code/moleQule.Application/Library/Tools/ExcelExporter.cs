using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Drawing;
using System.Reflection;
using Microsoft.Win32;
using System.Windows.Forms;

using moleQule.Library;
using moleQule.Library.Common;
using moleQule.Library.Invoice;
using moleQule.Library.Store;

namespace moleQule.Library.Application
{
    public class ExcelExporter : moleQule.Library.ExcelExporter
    {
        #region Attributes & Properties

        protected Library.Invoice.QueryConditions _invoice_conditions = new Library.Invoice.QueryConditions();
        protected Library.Store.QueryConditions _store_conditions = new Library.Store.QueryConditions();

        protected Registro _registro;

        #endregion

        #region Factory Methods

        public ExcelExporter()
        {
            InitExcelExporter();

            Init();
        }

        public virtual void Init() { }

        public void Cerrar()
        {
            Close();

            if (_registro != null)
            {
                _registro.Save();
                _registro.CloseSession();
            }
        }

        public virtual string GetConditions(Library.Store.QueryConditions conditions)
        {
            string filtro = string.Empty;

            if (conditions.FechaIni != DateTime.MinValue) filtro += "Fecha Inicial: " + conditions.FechaIni.ToShortDateString() + "; ";
            if (conditions.FechaFin != DateTime.MinValue) filtro += "Fecha Final: " + conditions.FechaFin.ToShortDateString() + "; ";
            filtro += "Estado: " + Library.Common.EnumText<EEstado>.GetLabel(conditions.Estado) + "; ";

            return filtro;
        }
        public virtual string GetConditions(Library.Invoice.QueryConditions conditions)
        {
            string filtro = string.Empty;

            if (conditions.FechaIni != DateTime.MinValue) filtro += "Fecha Inicial: " + conditions.FechaIni.ToShortDateString() + "; ";
            if (conditions.FechaFin != DateTime.MinValue) filtro += "Fecha Final: " + conditions.FechaFin.ToShortDateString() + "; ";
            filtro += "Estado: " + Library.Common.EnumText<EEstado>.GetLabel(conditions.Estado) + "; ";

            return filtro;
        }

        #endregion

        #region IDisposable

        // Track whether Dispose has been called.
        private bool disposed = false;

        // Implement IDisposable.
        // Do not make this method virtual.
        // A derived class should not be able to override this method.
        public void Dispose()
        {
            Dispose(true);
            // Take yourself off the Finalization queue 
            // to prevent finalization code for this object
            // from executing a second time.
            GC.SuppressFinalize(this);
        }

        // Dispose(bool disposing) executes in two distinct scenarios.
        // If disposing equals true, the method has been called directly
        // or indirectly by a user's code. Managed and unmanaged resources
        // can be disposed.
        // If disposing equals false, the method has been called by the 
        // runtime from inside the finalizer and you should not reference 
        // other objects. Only unmanaged resources can be disposed.
        protected virtual void Dispose(bool disposing)
        {
            // Check to see if Dispose has already been called.
            if (!disposed)
            {
                // If disposing equals true, dispose all managed 
                // and unmanaged resources.
                if (disposing)
                {
                }

                Cerrar();
            }
            disposed = true;
        }

        // Use C# destructor syntax for finalization code.
        // This destructor will run only if the Dispose method does not get called.
        // It gives your base class the opportunity to finalize.
        // Do not provide destructors in types derived from this class.
        ~ExcelExporter()
        {
            // Do not re-create Dispose clean-up code here.
            // Calling Dispose(false) is optimal in terms of
            // readability and maintainability.
            Dispose(false);
        }

        #endregion

        #region Business Methods

        #endregion

    }
}

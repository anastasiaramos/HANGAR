using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.ComponentModel;

using Csla;
using CslaEx;

using moleQule.Library;

using NHibernate;

namespace moleQule.Library.Application
{

    /// <summary>
    /// Editable Child Collection
    /// </summary>
    [Serializable()]
    public class CuentaEmpresas : BusinessListBaseEx<CuentaEmpresas, CuentaEmpresa>
    {

        #region Business Methods

        public CuentaEmpresa NewItem(Empresa parent)
        {
            this.NewItem(CuentaEmpresa.NewChild(parent));
            return this[Count - 1];
        }
		
        #endregion

        #region Factory Methods

        private CuentaEmpresas()
        {
            MarkAsChild();
        }

        private CuentaEmpresas(IList<CuentaEmpresa> lista)
        {
            MarkAsChild();
            Fetch(lista);
        }

        private CuentaEmpresas(IDataReader reader, bool childs)
        {
            Childs = childs;
            Fetch(reader);
        }


        public static CuentaEmpresas NewChildList() { return new CuentaEmpresas(); }

        public static CuentaEmpresas GetChildList(IList<CuentaEmpresa> lista) { return new CuentaEmpresas(lista); }

        public static CuentaEmpresas GetChildList(IDataReader reader, bool childs) { return new CuentaEmpresas(reader, childs); }

        public static CuentaEmpresas GetChildList(IDataReader reader) { return GetChildList(reader, true); }

        #endregion

        #region Child Data Access

        // called to copy objects data from list
        private void Fetch(IList<CuentaEmpresa> lista)
        {
            this.RaiseListChangedEvents = false;

            foreach (CuentaEmpresa item in lista)
                this.AddItem(CuentaEmpresa.GetChild(item));

            this.RaiseListChangedEvents = true;
        }

        private void Fetch(IDataReader reader)
        {
            this.RaiseListChangedEvents = false;

            while (reader.Read())
                this.AddItem(CuentaEmpresa.GetChild(reader));

            this.RaiseListChangedEvents = true;
        }

		
        internal void Update(Empresa parent)
        {
            this.RaiseListChangedEvents = false;

            // update (thus deleting) any deleted child objects
            foreach (CuentaEmpresa obj in DeletedList)
                obj.DeleteSelf(parent);

            // now that they are deleted, remove them from memory too
            DeletedList.Clear();

            // add/update any current child objects
            foreach (CuentaEmpresa obj in this)
            {
                if (obj.IsNew)
                    obj.Insert(parent);
                else
                    obj.Update(parent);
            }
			
            this.RaiseListChangedEvents = true;
        }
		

        #endregion

    }
}

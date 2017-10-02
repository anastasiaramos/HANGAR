using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

using Csla;
using CslaEx;

using moleQule.Library;

namespace moleQule.Library.Application
{
    /// <summary>
    /// Read Only Child Collection of Business Objects
    /// </summary>
    [Serializable()]
    public class ContactoEmpresaList : ReadOnlyListBaseEx<ContactoEmpresaList, ContactoEmpresaInfo>
    {

        #region Factory Methods

        private ContactoEmpresaList() { }

        private ContactoEmpresaList(IList<ContactoEmpresa> lista)
        {
            Fetch(lista);
        }

        private ContactoEmpresaList(IDataReader reader)
        {
            Fetch(reader);
        }

        /// <summary>
        /// Builds a ContactoEmpresaList from IList<!--<ContactoEmpresa>-->
        /// </summary>
        /// <param name="list"></param>
        /// <returns>ContactoEmpresaList</returns>
        public static ContactoEmpresaList GetChildList(IList<ContactoEmpresa> lista) { return new ContactoEmpresaList(lista); }

        public static ContactoEmpresaList GetChildList(IDataReader reader) { return new ContactoEmpresaList(reader); }

        /// <summary>
        /// Devuelve una lista de todos los elementos
        /// </summary>
        /// <returns>Lista de elementos</returns>
        public static ContactoEmpresaList GetList(CriteriaEx criteria)
        {
            return ContactoEmpresaList.RetrieveList(typeof(ContactoEmpresa), AppContext.ActiveSchema.Code, criteria);
        }

        #endregion

        #region Data Access

        // called to retrieve data from database
        protected override void Fetch(CriteriaEx criteria)
        {
            this.RaiseListChangedEvents = false;

            SessionCode = criteria.SessionCode;

            try
            {
                if (nHMng.UseDirectSQL)
                {
					ContactoEmpresa.DoLOCK("COMMON", Session());

                    IDataReader reader = nHManager.Instance.SQLNativeSelect(criteria.Query, Session()); ;

                    IsReadOnly = false;

                    while (reader.Read())
                    {
                        this.AddItem(ContactoEmpresaInfo.Get(reader, Childs));
                    }

                    IsReadOnly = true;
                }
                else
                {
                    IList list = criteria.List();

                    if (list.Count > 0)
                    {
                        IsReadOnly = false;

                        foreach (ContactoEmpresa item in list)
                            this.AddItem(item.GetInfo());

                        IsReadOnly = true;
                    }
                }
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            this.RaiseListChangedEvents = true;
        }

        // called to load data from list
        private void Fetch(IList<ContactoEmpresa> lista)
        {
            this.RaiseListChangedEvents = false;

            IsReadOnly = false;
            foreach (ContactoEmpresa item in lista)
                this.AddItem(item.GetInfo());
            IsReadOnly = true;

            this.RaiseListChangedEvents = true;
        }

        // called to load data from list
        private void Fetch(IDataReader reader)
        {
            this.RaiseListChangedEvents = false;

            IsReadOnly = false;
            while (reader.Read())
                this.AddItem(ContactoEmpresa.GetChild(reader).GetInfo());
            IsReadOnly = true;

            this.RaiseListChangedEvents = true;
        }

        #endregion

    }
}

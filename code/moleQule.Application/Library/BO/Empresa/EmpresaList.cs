using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

using Csla;
using CslaEx;

using moleQule.Library;

namespace moleQule.Library.Application
{
    /// <summary>
    /// Read Only Root Collection of Business Objects With Child Collection
    /// </summary>
    [Serializable()]
    public class EmpresaList : ReadOnlyListBaseEx<EmpresaList, EmpresaInfo>
    {
        #region Business Methods

        public void SetPrincipal(string code)
        {
            foreach (ISchemaInfo item in this)
                item.Principal = item.Code.Equals(code);
        }

        #endregion

        #region Factory Methods

        public EmpresaList() { }

        /// <summary>
        /// Retrieve the complete list from db
        /// </summary>
        /// <returns>EmpresaList</returns>
        public static EmpresaList GetList(bool childs)
        {
            CriteriaEx criteria = Empresa.GetCriteria(Empresa.OpenSession());
            criteria.Query = EmpresaList.SELECT(typeof(Empresa), "COMMON");
            criteria.Childs = childs;

            //No criteria. Retrieve all de List
            EmpresaList list = DataPortal.Fetch<EmpresaList>(criteria);

            CloseSession(criteria.SessionCode);

            return list;
        }

        /// <summary>
        /// Retrieve the complete list from db
        /// </summary>
        /// <returns>EmpresaList</returns>
        public static EmpresaList GetList()
        {
            return GetList(true);
        }


        /// <summary>
        /// Devuelve una lista de todos los elementos
        /// </summary>
        /// <returns>Lista de elementos</returns>
        public static EmpresaList GetList(CriteriaEx criteria)
        {
            criteria.Query = EmpresaList.SELECT(typeof(Empresa), "COMMON");
            return EmpresaList.RetrieveList(typeof(Empresa), AppContext.ActiveSchema.Code, criteria);
        }

        /// <summary>
        /// Builds a EmpresaList from a IList<!--<EmpresaInfo>-->.
        /// Doesn`t retrieve child data from DB.
        /// </summary>
        /// <param name="list"></param>
        /// <returns>EmpresaList</returns>
        public static EmpresaList GetList(IList<EmpresaInfo> list)
        {
            EmpresaList flist = new EmpresaList();

            if (list.Count > 0)
            {
                flist.IsReadOnly = false;

                foreach (EmpresaInfo item in list)
                    flist.AddItem(item);

                flist.IsReadOnly = true;
            }

            return flist;
        }

        /// <summary>
        /// Devuelve una lista ordenada de todos los elementos
        /// </summary>
        /// <param name="sortProperty">Campo de ordenación</param>
        /// <param name="sortDirection">Sentido de ordenación</param>
        /// <returns>Lista ordenada de elementos</returns>
        public static SortedBindingList<EmpresaInfo> GetSortedList(string sortProperty,
                                                                    ListSortDirection sortDirection)
        {
            SortedBindingList<EmpresaInfo> sortedList =
                new SortedBindingList<EmpresaInfo>(GetList());
            sortedList.ApplySort(sortProperty, sortDirection);
            return sortedList;
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
                    IDataReader reader = nHManager.Instance.SQLNativeSelect(criteria.Query, Session());

                    IsReadOnly = false;

                    while (reader.Read())
                    {
                        this.AddItem(EmpresaInfo.Get(reader, Childs));
                    }

                    IsReadOnly = true;
                }
                else
                {
                    IList list = criteria.List();

                    if (list.Count > 0)
                    {
                        IsReadOnly = false;

                        foreach (Empresa item in list)
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


        #endregion

    }
}




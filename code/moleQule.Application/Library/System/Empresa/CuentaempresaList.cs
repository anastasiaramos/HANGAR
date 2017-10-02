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
	/// Read Only Child Collection of Business Objects
	/// </summary>
    [Serializable()]
	public class CuentaEmpresaList : ReadOnlyListBaseEx<CuentaEmpresaList, CuentaEmpresaInfo>
	{
		 
		 
		#region Factory Methods

		private CuentaEmpresaList() { }
		
		/// <summary>
		/// Builds a CuentaEmpresaList
		/// </summary>
		/// <param name="list"></param>
		/// <returns>CuentaEmpresaList</returns>
		public static CuentaEmpresaList GetList(bool childs)
		{
			CriteriaEx criteria = CuentaEmpresa.GetCriteria(CuentaEmpresa.OpenSession());
            criteria.Childs = childs;
			
			

			CuentaEmpresaList list = DataPortal.Fetch<CuentaEmpresaList>(criteria);

            CloseSession(criteria.SessionCode);
			return list;
		}

		/// <summary>
		/// Builds a CuentaEmpresaList
		/// </summary>
		/// <param name="list"></param>
		/// <returns>CuentaEmpresaList</returns>
		public static CuentaEmpresaList GetList()
		{ 
			return CuentaEmpresaList.GetList(true); 
		}

		/// <summary>
        /// Devuelve una lista de todos los elementos
        /// </summary>
        /// <returns>Lista de elementos</returns>
        public static CuentaEmpresaList GetList(CriteriaEx criteria)
        {
            return CuentaEmpresaList.RetrieveList(typeof(CuentaEmpresa), AppContext.CommonSchema, criteria);
        }

		
		#endregion

		#region Data Access

		// called to retrieve data from db
		protected override void Fetch(CriteriaEx criteria)
		{
			this.RaiseListChangedEvents = false;

			SessionCode = criteria.SessionCode;
			Childs = criteria.Childs;

			try
			{
				if (nHMng.UseDirectSQL)
				{
					IDataReader reader = nHManager.Instance.SQLNativeSelect(criteria.Query, Session());

					IsReadOnly = false;

					while (reader.Read())
					{
						this.AddItem(CuentaEmpresaInfo.Get(reader,Childs));
					}

					IsReadOnly = true;
				}
				else
				{
					IList list = criteria.List();

					if (list.Count > 0)
					{
						IsReadOnly = false;

						foreach (CuentaEmpresa item in list)
							this.AddItem(item.GetInfo());

						IsReadOnly = true;
					}
				}
			}
			catch (Exception ex)
			{
				throw new iQPersistentException(iQExceptionHandler.GetAllMessages(ex));
			}

			this.RaiseListChangedEvents = true;
		}

		#endregion

	
	}
}


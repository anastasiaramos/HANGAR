using System;
using System.Collections.Generic;

using moleQule.Library.Hipatia;
using moleQule.Library.Common;

namespace moleQule.Library.Application
{
    public partial class AgenteSelector : AgenteSelectorBase
    {
        #region Business Methods

        #endregion

        #region Style & Source

        public new static IAgenteHipatiaList GetAgentes(EntidadInfo entidad)
        {
            IAgenteHipatiaList lista = new IAgenteHipatiaList(new List<IAgenteHipatia>());

            if (entidad.Tipo == typeof(Company).Name)
            {
                CompanyList list = CompanyList.GetList(false);

                foreach (CompanyInfo obj in list)
                {
                    if (entidad.Agentes.GetItemByProperty("Oid", obj.Oid) == null)
                        lista.Add(obj);
                }
            }
            else
                throw new iQException("No se ha encontrado el tipo de entidad " + entidad.Tipo);

            return lista;
        }

        #endregion
    }
}
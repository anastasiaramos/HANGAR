using System;
using System.Collections.Generic;

using moleQule.Library;
using moleQule.Library.Store;

namespace moleQule.Library.Application
{
    public enum ETipoElementos { Naviera, TransporteOrigen, TransporteDestino, Proveedor, Despachante }

    public enum ETipoAsociacion { Puerto, Despachante }

    public enum Grupo { A = 1, B = 2 }

    public class EnumText<T> : EnumTextBase<T>
    {
        public static ComboBoxList<T> GetList()
        {
            return GetList(Resources.Enums.ResourceManager);
        }

        public static string GetLabel(object value)
        {
            return GetLabel(Resources.Enums.ResourceManager, value);
        }
    }
}

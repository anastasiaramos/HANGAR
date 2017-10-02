using System;
using System.Collections.Generic;
using System.Text;

using moleQule.Library;

namespace moleQule.Library.Application
{
    public class HComboBoxSourceList : ComboBoxSourceList
    {
        public HComboBoxSourceList() { }

        public HComboBoxSourceList(UserList lista)
        :this(lista, true){}

        public HComboBoxSourceList(UserList lista, bool empty_item)
        {
            if (empty_item) AddEmptyItem();

            foreach (UserInfo item in lista)
            {
                ComboBoxSource combo = new ComboBoxSource();

                combo.Texto = item.Name;
                combo.Oid = item.Oid;

                this.Add(combo);
            }

        }
        
        public HComboBoxSourceList(Type tipo)
        {          
            string[] nombres = Enum.GetNames(tipo);
           
            foreach (string item in nombres)
            {
                ComboBoxSource combo = new ComboBoxSource();             
                object estado = Enum.Parse(tipo, item);                
                combo.Texto = estado.ToString().Replace('_',' ');
                combo.Oid = (int)estado;
                this.Add(combo);        
            }

        }       

    }
}

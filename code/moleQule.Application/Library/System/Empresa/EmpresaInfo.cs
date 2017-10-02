using System;
using System.Collections;
using System.Data;
using System.IO;

using Csla;
using CslaEx;

using moleQule.Library;
using NHibernate;

namespace moleQule.Library.Application
{
    [Serializable()]
    public class EmpresaInfo : ReadOnlyBaseEx<EmpresaInfo>, moleQule.Library.ISchemaInfo, moleQule.Library.Hipatia.IAgenteHipatia
    {
        #region IAgenteHipatia

        public string NombreHipatia { get { return Name; } }
        public string IDHipatia { get { return Code; } }
        public string ObservacionesHipatia { get { return string.Empty; } }

        #endregion

        #region ISchemaInfo

        private string _code;
        private string _name;
        private bool _principal;

        public string Code { get { return _code; } }
        public string Name { get { return _name; } }
        public bool Principal { get { return _principal; } set { _principal = value; } }

        #endregion

        #region Attributes

        private long _serial;
        private string _id;
        private long _tipo_id;
        private string _cta_cotizacion;
        private string _direccion;
        private string _municipio;
        private string _codigo_postal;
        private string _provincia;
        private string _telefonos;
        private string _fax;
        private string _url;
        private string _email;
        private string _responsable;
        private string _logo;
        protected string _cuenta_bancaria = string.Empty;

        private ContactoEmpresaList _contactos = null;

        #endregion

        #region Properties

        public long Serial { get { return _serial; } }
        public string ID { get { return _id.ToUpper(); } }
        public long TipoID { get { return _tipo_id; } }
        public string CtaCotizacion { get { return _cta_cotizacion.ToUpper(); } }
        public string Direccion { get { return _direccion; } }
        public string Municipio { get { return _municipio; } }
        public string CodPostal { get { return _codigo_postal; } }
        public string Provincia { get { return _provincia; } }
        public string Telefonos { get { return _telefonos; } }
        public string Fax { get { return _fax; } }
        public string Url { get { return _url; } }
        public string Email { get { return _email; } }
        public string Responsable { get { return _responsable; } }
        public string Logo { get { return _logo; } }
        public string CuentaBancaria { get { return _cuenta_bancaria; } /*set { _cuenta_bancaria = value; }*/ }

        public virtual ContactoEmpresaList Contactos { get { return _contactos; } }

        #endregion

        #region Business Methods

        /// <summary>
        /// Copia los atributos del objeto
        /// </summary>
        /// <param name="source">Objeto origen</param>
        protected void CopyValues(Empresa source)
        {
            if (source == null) return;

            _oid = source.Oid;
            _serial = source.Serial;
            _code = source.Code;
            _name = source.Name;
            _id = source.ID;
            _tipo_id = source.TipoID;
            _cta_cotizacion = source.CtaCotizacion;
            _direccion = source.Direccion;
            _municipio = source.Municipio;
            _codigo_postal = source.CodPostal;
            _provincia = source.Provincia;
            _telefonos = source.Telefonos;
            _fax = source.Fax;
            _url = source.Url;
            _email = source.Email;
            _responsable = source.Responsable;
            _logo = source.Logo;
            _cuenta_bancaria = source.CuentaBancaria;
        }

        /// <summary>
        /// Copia los atributos del objeto
        /// </summary>
        /// <param name="source">Objeto origen</param>
        protected override void CopyValues(IDataReader source)
        {
            if (source == null) return;

            _oid = Format.DataReader.GetInt64(source, "OID");
            _serial = Format.DataReader.GetInt64(source, "SERIAL");
            _code = Format.DataReader.GetString(source, "CODIGO");
            _name = Format.DataReader.GetString(source, "NOMBRE");
            _id = Format.DataReader.GetString(source, "ID");
            _tipo_id = Format.DataReader.GetInt64(source, "TIPO_ID");
            _cta_cotizacion = Format.DataReader.GetString(source, "CTA_COTIZACION");
            _direccion = Format.DataReader.GetString(source, "DIRECCION");
            _municipio = Format.DataReader.GetString(source, "MUNICIPIO");
            _codigo_postal = Format.DataReader.GetString(source, "COD_POSTAL");
            _provincia = Format.DataReader.GetString(source, "PROVINCIA");
            _telefonos = Format.DataReader.GetString(source, "TELEFONOS");
            _fax = Format.DataReader.GetString(source, "FAX");
            _url = Format.DataReader.GetString(source, "URL");
            _email = Format.DataReader.GetString(source, "EMAIL");
            _responsable = Format.DataReader.GetString(source, "RESPONSABLE");
            _logo = Format.DataReader.GetString(source, "LOGO");
            _cuenta_bancaria = Format.DataReader.GetString(source, "CUENTA_BANCARIA");
        }

        public void CopyFrom(Empresa source) { CopyValues(source); }

        public System.Byte[] GetImage()
        {
            System.Byte[] _logo_emp = null;

            string path = Controler.LOGOS_EMPRESAS_PATH + Logo;

            // Cargamos la imagen en el buffer
            if (File.Exists(path))
            {
                //Declaramos fs para poder abrir la imagen.
                FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);

                // Declaramos un lector binario para pasar la imagen a bytes
                BinaryReader br = new BinaryReader(fs);
                _logo_emp = new byte[(int)fs.Length];
                br.Read(_logo_emp, 0, (int)fs.Length);
                br.Close();
                fs.Close();
            }

            return _logo_emp;
        }

        #endregion

        #region Factory Methods

        private EmpresaInfo()
        { /* require use of factory methods */ }

        private EmpresaInfo(IDataReader source, bool childs)
        {
            Childs = childs;
            Fetch(source);
        }

		internal EmpresaInfo(Empresa item, bool copy_childs)
		{
			CopyValues(item);
			
			if (copy_childs)
			{
				_contactos = (item.Contactos != null) ? ContactoEmpresaList.GetChildList(item.Contactos) : null;
			}
		}

        public static EmpresaInfo Get(long oid)
        {
            return Get(oid, false);
        }

        public static EmpresaInfo Get(long oid, bool childs)
        {
            CriteriaEx criteria = Empresa.GetCriteria(Empresa.OpenSession());
            criteria.AddOidSearch(oid);
            criteria.Childs = childs;
            EmpresaInfo obj = DataPortal.Fetch<EmpresaInfo>(criteria);
            Empresa.CloseSession(criteria.SessionCode);
            return obj;
        }

        public static EmpresaInfo GetByCode(string code)
        {
            CriteriaEx criteria = Empresa.GetCriteria(Empresa.OpenSession());
            criteria.AddEq("Code", code);
            EmpresaInfo obj = DataPortal.Fetch<EmpresaInfo>(criteria);
            Empresa.CloseSession(criteria.SessionCode);
            return obj;
        }

        public static EmpresaInfo Get(IDataReader reader, bool childs)
        {
            return new EmpresaInfo(reader, childs);
        }

        public static ISchemaInfo GetISchemaInfo(long oid)
        {
            return (ISchemaInfo)EmpresaInfo.Get(oid);
        }

        public static ISchema GetISchema(long oid)
        {
            return (ISchema)Empresa.Get(oid);
        }

        public static string GetLogoPath(long oid)
        {
            EmpresaInfo empresa = EmpresaInfo.Get(oid);
            return (empresa != null) ? Controler.LOGOS_EMPRESAS_PATH + empresa.Logo : string.Empty;
        }

        #endregion

        #region ISchemaInfo

        public ISchemaInfo IGet(long oid)
        {
            return (ISchemaInfo)EmpresaInfo.Get(oid);
        }

        public ISchema IGetSchema(long oid)
        {
            return (ISchema)Empresa.Get(oid);
        }

        #endregion

        #region Data Access

        private void DataPortal_Fetch(CriteriaEx criteria)
        {
            try
            {
                CopyValues((Empresa)(criteria.UniqueResult()));
                SessionCode = criteria.SessionCode;
                Childs = criteria.Childs;

                if (Childs)
                {
                    criteria = ContactoEmpresa.GetCriteria(Session());
                    criteria.AddEq("OidEmpresa", this.Oid);
                    _contactos = ContactoEmpresaList.GetChildList(criteria.List<ContactoEmpresa>());
                }

            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }
        }

        //called to copy data from IDataReader
        private void Fetch(IDataReader source)
        {
            try
            {
                CopyValues(source);

                if (Childs)
                {
                    string query = ContactoEmpresas.SELECT_BY_FIELD("OidEmpresa", this.Oid);
                    IDataReader reader = nHManager.Instance.SQLNativeSelect(query, Session());
                    _contactos = ContactoEmpresaList.GetChildList(reader);
                }
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }
        }

        #endregion

    }
}
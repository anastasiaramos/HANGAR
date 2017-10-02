using System;
using System.Collections.Generic;
using System.Data;

using Csla;
using CslaEx;

using moleQule.Library;

namespace moleQule.Library.Application
{
    /// <summary>
    /// ReadOnly Child Business Object
    /// </summary>
    [Serializable()]
    public class ContactoEmpresaInfo : ReadOnlyBaseEx<ContactoEmpresaInfo>
    {

        #region Business Methods

        private long _oid_empresa;
        private string _nombre = string.Empty;
        private string _cargo = string.Empty;
        private string _dni = string.Empty;
        private string _direccion = string.Empty;
        private string _cod_postal = string.Empty;
        private string _municipio = string.Empty;
        private string _provincia = string.Empty;
        private string _telefonos = string.Empty;

        [System.ComponentModel.DataObjectField(true)]
        public virtual long OidEmpresa
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _oid_empresa;
            }
        }
        public virtual string Nombre
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _nombre;
            }
        }
        public virtual string Cargo
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _cargo;
            }
        }
        public virtual string Dni
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _dni;
            }
        }
        public virtual string Direccion
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _direccion;
            }
        }
        public virtual string CodPostal
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _cod_postal;
            }
        }
        public virtual string Municipio
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _municipio;
            }
        }
        public virtual string Provincia
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _provincia;
            }
        }
        public virtual string Telefonos
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _telefonos;
            }
        }

        /// <summary>
        /// Copia los atributos del objeto
        /// </summary>
        /// <param name="source">Objeto origen</param>
        protected override void CopyValues(IDataReader source)
        {
            if (source == null) return;

            _oid = Format.DataReader.GetInt64(source, "OID");
            _oid_empresa = Format.DataReader.GetInt64(source, "OID_EMPRESA");
            _cargo = Format.DataReader.GetString(source, "CARGO");
            _nombre = Format.DataReader.GetString(source, "NOMBRE");
            _dni = Format.DataReader.GetString(source, "DNI");
            _direccion = Format.DataReader.GetString(source, "DIRECCION");
            _cod_postal = Format.DataReader.GetString(source, "COD_POSTAL");
            _municipio = Format.DataReader.GetString(source, "MUNICIPIO");
            _provincia = Format.DataReader.GetString(source, "PROVINCIA");
            _telefonos = Format.DataReader.GetString(source, "TELEFONOS");

        }

        #endregion

        #region Factory Methods

        private ContactoEmpresaInfo() { /* require use of factory methods */ }

        private ContactoEmpresaInfo(IDataReader reader, bool childs)
        {
            Childs = childs;
            Fetch(reader);
        }

        internal ContactoEmpresaInfo(long oid,
                                long oidEmpresa,
                                string nombre,
                                string cargo,
                                string dni,
                                string direccion,
                                string codPostal,
                                string municipio,
                                string provincia,
                                string telefonos)
        {
            _oid = oid;
            _oid_empresa = oidEmpresa;
            _nombre = nombre;
            _cargo = cargo;
            _dni = dni;
            _direccion = direccion;
            _cod_postal = codPostal;
            _municipio = municipio;
            _provincia = provincia;
            _telefonos = telefonos;
        }

        /// <summary>
        /// Copia los datos al objeto desde un IDataReader 
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static ContactoEmpresaInfo Get(IDataReader reader, bool childs)
        {
            return new ContactoEmpresaInfo(reader, childs);
        }

        #endregion

        #region Data Access

        //called to copy data from IDataReader
        private void Fetch(IDataReader source)
        {
            try
            {
                CopyValues(source);
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }
        }

        #endregion


    }
}

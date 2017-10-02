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
	/// ReadOnly Child Business Object
    /// </summary>
	[Serializable()]
	public class CuentaEmpresaInfo : ReadOnlyBaseEx<CuentaEmpresaInfo>
	{
	
        #region Attributes

        protected long _oid_empresa;
        protected long _entidad;
        protected long _sucursal;
        protected long _dc;
        protected long _numero;

        #endregion

        #region Properties

        public long OidEmpresa { get { return _oid_empresa; } /*set { _oid_empresa = value; }*/ }
        public long Entidad { get { return _entidad; } /*set { _entidad = value; }*/ }
        public long Sucursal { get { return _sucursal; } /*set { _sucursal = value; }*/ }
        public long Dc { get { return _dc; } /*set { _dc = value; }*/ }
        public long Numero { get { return _numero; } /*set { _numero = value; }*/ }

        #endregion

        #region Business Methods

        /// <summary>
        /// Copia los atributos del objeto
        /// </summary>
        /// <param name="source">Objeto origen</param>
        protected void CopyValues(CuentaEmpresa source)
        {
            if (source == null) return;

            _oid = source.Oid;
            _oid_empresa = source.OidEmpresa;
            _entidad = source.Entidad;
            _sucursal = source.Sucursal;
            _dc = source.Dc;
            _numero = source.Numero;
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
            _entidad = Format.DataReader.GetInt64(source, "ENTIDAD");
            _sucursal = Format.DataReader.GetInt64(source, "SUCURSAL");
            _dc = Format.DataReader.GetInt64(source, "DC");
            _numero = Format.DataReader.GetInt64(source, "NUMERO");
        }

        #endregion

		#region Factory Methods
		 
		protected CuentaEmpresaInfo() { /* require use of factory methods */ }

		private CuentaEmpresaInfo(IDataReader reader, bool childs)
		{
			Childs = childs;
			Fetch(reader);
		}
			
		internal CuentaEmpresaInfo(CuentaEmpresa source)
		{
            CopyValues(source);
		}

		/// <summary>
		/// Copia los datos al objeto desde un IDataReader 
		/// </summary>
		/// <param name="reader"></param>
		/// <returns></returns>
		public static CuentaEmpresaInfo Get(IDataReader reader, bool childs)
		{
			return new CuentaEmpresaInfo(reader, childs);
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


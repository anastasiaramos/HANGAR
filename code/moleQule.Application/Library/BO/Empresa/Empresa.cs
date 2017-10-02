using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

using Csla;
using Csla.Validation;
using CslaEx;
using NHibernate;

using moleQule.Library;
using moleQule.Library.Security;

namespace moleQule.Library.Application
{
    /// <summary>
    /// Editable Root Business Object With Editable Child Collection
    /// </summary>
    [Serializable()]
    public class Empresa : BusinessBaseEx<Empresa>, moleQule.Library.ISchema
    {
        #region ISchema

        private string _codigo = string.Empty;
        private string _nombre = string.Empty;
        private bool _principal = false;

        public virtual string Code
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _codigo;
            }

            set
            {
                CanWriteProperty(true);

                if (_codigo != value)
                {
                    _codigo = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual string Name
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _nombre;
            }
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                CanWriteProperty(true);
                if (value == null) value = string.Empty;
                if (_nombre != value)
                {
                    _nombre = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual bool Principal
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _principal;
            }
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                CanWriteProperty(true);
                if (_principal != value)
                {
                    _principal = value;
                    PropertyHasChanged();
                }
            }
        }

        #endregion

        #region Attributes

        private long _serial;
        private string _id = string.Empty;
        private long _tipo_id;
        private string _cta_cotizacion = string.Empty;
        private string _direccion = string.Empty;
        private string _municipio = string.Empty;
        private string _cod_postal = string.Empty;
        private string _provincia = string.Empty;
        private string _telefonos = string.Empty;
        private string _fax = string.Empty;
        private string _url = string.Empty;
        private string _email = string.Empty;
        private string _responsable = string.Empty;
        private string _logo = string.Empty;
        private string _cuenta_bancaria = string.Empty;

        private ContactoEmpresas _contactos = ContactoEmpresas.NewChildList();

        #endregion

        #region Properties

        public virtual long Serial
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _serial;
            }

            set
            {
                CanWriteProperty(true);
                _serial = value;
            }
        }
        public virtual string ID
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _id.ToUpper();
            }

            set
            {
                CanWriteProperty(true);
                if (value == null) value = string.Empty;
                if (_id != value)
                {
                    _id = value.ToUpper();
                    PropertyHasChanged();
                }
            }
        }
        public virtual long TipoID
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _tipo_id;
            }
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                CanWriteProperty(true);
                if (!_tipo_id.Equals(value))
                {
                    _tipo_id = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual string CtaCotizacion
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _cta_cotizacion.ToUpper();
            }

            set
            {
                CanWriteProperty(true);
                if (value == null) value = string.Empty;
                if (_cta_cotizacion != value)
                {
                    _cta_cotizacion = value.ToUpper();
                    PropertyHasChanged();
                }
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

            set
            {
                CanWriteProperty(true);
                if (value == null) value = string.Empty;
                if (_direccion != value)
                {
                    _direccion = value;
                    PropertyHasChanged();
                }
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

            set
            {
                CanWriteProperty(true);
                if (value == null) value = string.Empty;
                if (_municipio != value)
                {
                    _municipio = value;
                    PropertyHasChanged();
                }
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

            set
            {
                CanWriteProperty(true);
                if (value == null) value = string.Empty;
                if (_cod_postal != value)
                {
                    _cod_postal = value;
                    PropertyHasChanged();
                }
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

            set
            {
                CanWriteProperty(true);
                if (value == null) value = string.Empty;
                if (_provincia != value)
                {
                    _provincia = value;
                    PropertyHasChanged();
                }
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

            set
            {
                CanWriteProperty(true);
                if (value == null) value = string.Empty;
                if (_telefonos != value)
                {
                    _telefonos = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual string Fax
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _fax;
            }

            set
            {
                CanWriteProperty(true);
                if (value == null) value = string.Empty;
                if (_fax != value)
                {
                    _fax = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual string Url
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _url;
            }

            set
            {
                CanWriteProperty(true);
                if (value == null) value = string.Empty;
                if (_url != value)
                {
                    _url = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual string Email
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _email;
            }

            set
            {
                CanWriteProperty(true);
                if (value == null) value = string.Empty;
                if (_email != value)
                {
                    _email = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual string Responsable
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _responsable;
            }

            set
            {
                CanWriteProperty(true);
                if (value == null) value = string.Empty;
                if (_responsable != value)
                {
                    _responsable = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual string Logo
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _logo;
            }

            set
            {
                CanWriteProperty(true);
                if (value == null) value = string.Empty;
                if (_logo != value)
                {
                    _logo = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual string CuentaBancaria
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _cuenta_bancaria;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                CanWriteProperty(true);

                if (value == null) value = string.Empty;

                if (!_cuenta_bancaria.Equals(value))
                {
                    _cuenta_bancaria = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual ContactoEmpresas Contactos
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _contactos;
            }
        }

        public override bool IsValid
        {
            get { return base.IsValid && _contactos.IsValid; }
        }
        public override bool IsDirty
        {
            get { return base.IsDirty || _contactos.IsDirty; }
        }

        /// <summary>
        /// Clona la entidad y sus subentidades y las marca como nuevas
        /// </summary>
        /// <returns>Una entidad clon</returns>
        public virtual Empresa CloneAsNew()
        {
            Empresa clon = null;
            clon = base.Clone();

            // Se definen el Oid y el Codigo como nueva entidad
            Random rd = new Random();
            clon.Oid = rd.Next();
            clon.Code = (0).ToString(Resources.Defaults.EMPRESA_CODE_FORMAT);

            clon.SessionCode = Empresa.OpenSession();
            Empresa.BeginTransaction(clon.SessionCode);

            clon.MarkNew();
            clon.Contactos.MarkAsNew();

            return clon;
        }

        /// <summary>
        /// Copia los atributos del objeto
        /// </summary>
        /// <param name="source">Objeto origen</param>
        protected override void CopyValues(Empresa source)
        {
            if (source == null) return;

            _oid = source.Oid;
            _serial = source.Serial;
            _codigo = source.Code;
            _nombre = source.Name;
            _id = source.ID;
            _tipo_id = source.TipoID;
            _cta_cotizacion = source.CtaCotizacion;
            _direccion = source.Direccion;
            _municipio = source.Municipio;
            _cod_postal = source.CodPostal;
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
        /// Devuelve el siguiente código de Empresa.
        /// </summary>
        /// <returns>Código de 9 cifras</returns>
        public virtual void GetNewCode()
        {
            Serial = Empresa.GetNewSerial();
            Code = Serial.ToString(Resources.Defaults.EMPRESA_CODE_FORMAT);
        }

        /// <summary>
        /// Devuelve el siguiente Serial de Empresa.
        /// </summary>
        /// <returns>Código de 9 cifras</returns>
        protected static Int64 GetNewSerial()
        {
            // Obtenemos la lista de empresas ordenadas por serial
            SortedBindingList<EmpresaInfo> emps = EmpresaList.GetSortedList("Serial", ListSortDirection.Ascending);

            // Obtenemos el último código de empresa
            Int64 lastcode = 0;

            if (emps.Count > 0)
            {
                for (int i = 1; i < 11; i++)
                {
                    if (emps.Find("Serial", i) == -1)
                    {
                        lastcode = i;
                        return i;
                    }
                }
            }
            else
                lastcode = 1;

            return lastcode;
        }

        #endregion

        #region Validation Rules

        protected override void AddBusinessRules()
        {
            ValidationRules.AddRule(
              Csla.Validation.CommonRules.StringRequired, "Code");

            ValidationRules.AddRule(
              Csla.Validation.CommonRules.StringRequired, "Name");
        }

        #endregion

        #region Authorization Rules

        public static bool CanAddObject() { return AppContext.User.IsAdmin; }

        public static bool CanGetObject() { return true; }

        public static bool CanDeleteObject() { return AppContext.User.IsAdmin; }

        public static bool CanEditObject() { return AppContext.User.IsAdmin; }

        #endregion

        #region Factory Methods

        /// <summary>
        /// NO UTILIZAR DIRECTAMENTE, SE DEBE USA LA FUNCION New
        /// Debería ser private para CSLA porque la creación requiere el uso de los factory methods,
        /// pero es protected por exigencia de NHibernate.
        /// </summary>
        protected Empresa() { }

        public static Empresa New()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            return DataPortal.Create<Empresa>(new CriteriaCs(-1));
        }

        public static Empresa Get(long oid)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            CriteriaEx criteria = Empresa.GetCriteria(Empresa.OpenSession());
            criteria.AddOidSearch(oid);
            Empresa.BeginTransaction(criteria.Session);
            return DataPortal.Fetch<Empresa>(criteria);
        }

        public virtual EmpresaInfo GetInfo()
        {
            return GetInfo(true);
        }

        public virtual EmpresaInfo GetInfo(bool copy_childs)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            return new EmpresaInfo(this, copy_childs);
        }

        /// <summary>
        /// Borrado inmediato, no cabe "undo"
        /// (La función debe ser "estática")
        /// </summary>
        /// <param name="oid"></param>
        public static void Delete(long oid)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            DataPortal.Delete(new CriteriaCs(oid));
        }

        public override Empresa Save()
        {
            // Por la posible doble interfaz Root/Child
            if (IsChild) throw new iQException(moleQule.Library.Resources.Messages.CHILD_SAVE_NOT_ALLOWED);

            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);
            else if (!CanEditObject())
            {
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);
            }

            // Guardamos si es nuevo pq tras el Save la propiedad IsNew es false
            // y necesitamos saber si es un Insert para crear el eschema de usuarios
            // tras guardar la empresa
            Boolean isNew = IsNew;

            try
            {
                ValidationRules.CheckRules();

                base.Save();

                _contactos.Update(this);

                Transaction().Commit();
                BeginTransaction();

                // Si es una inserción de una nueva empresa tenemos que crear 
                // el mapa de permisos de los usuarios
                if (isNew) PrincipalBase.NewSchema(this.Oid);

                return this;
            }
            catch (Exception ex)
            {
                if (Transaction() != null) Transaction().Rollback();
                iQExceptionHandler.TreatException(ex);
                return this;
            }
        }

        #endregion

        #region ISchema

        /// <summary>
        /// Borrado inmediato, no cabe "undo"
        /// </summary>
        /// <param name="oid"></param>
        public void IDelete(long oid)
        {
            CloseDBObject();
            Empresa.Delete(oid);
        }

        public ISchema IGet(long oid)
        {
            return (ISchema)Empresa.Get(oid);
        }

        #endregion

        #region Common Data Access

        [RunLocal()]
        private void DataPortal_Create(CriteriaCs criteria)
        {
            Random rd = new Random();
            Oid = rd.Next();
            Code = (0).ToString(Resources.Defaults.EMPRESA_CODE_FORMAT);
            _contactos = ContactoEmpresas.NewChildList();
        }

        #endregion

        #region Root Data Access

        //private void DataPortal_Fetch(CriteriaEx criteria)
        //{
        //    try
        //    {
        //        SessionCode = criteria.SessionCode;

        //        CopyValues((Empresa)(criteria.UniqueResult()));

        //        Session().Lock(Session().Get<Empresa>(Oid), LockMode.UpgradeNoWait);

        //        criteria = ContactoE.GetCriteria(Session());
        //        criteria.AddEq("OidEmpresa", this.Oid);
        //        _contactos = ContactosE.GetChildList(criteria.List<ContactoE>());

        //    }
        //    catch (NHibernate.ADOException)
        //    {
        //        if (Transaction() != null) Transaction().Rollback();
        //        throw new iQLockException(Resources.Messages.LOCK_ERROR);
        //    }
        //    catch (Exception ex)
        //    {
        //        if (Transaction() != null) Transaction().Rollback();
        //        iQExceptionHandler.TreatException(ex);
        //    }
        //}

        private void DataPortal_Fetch(CriteriaEx criteria)
        {
            try
            {
                SessionCode = criteria.SessionCode;
                Childs = criteria.Childs;

                if (nHMng.UseDirectSQL)
                {

					Empresa.DoLOCK("COMMON", Session());

                    IDataReader reader = Empresa.DoSELECT("COMMON", Session(), criteria.Oid);

                    if (reader.Read())
                        CopyValues(reader);

                    if (Childs)
                    {
						ContactoEmpresa.DoLOCK("COMMON", Session());

                        string query = ContactoEmpresas.SELECT_BY_FIELD("COMMON", "OidEmpresa", this.Oid);
                        reader = nHManager.Instance.SQLNativeSelect(query, Session());
                        _contactos = ContactoEmpresas.GetChildList(reader);
                    }
                }
                else
                {
                    CopyValues((Empresa)(criteria.UniqueResult()));

                    Session().Lock(Session().Get<Empresa>(Oid), LockMode.UpgradeNoWait);

                    if (Childs)
                    {
                        criteria = ContactoEmpresa.GetCriteria(Session());
                        criteria.AddEq("OidEmpresa", this.Oid);
                        _contactos = ContactoEmpresas.GetChildList(criteria.List<ContactoEmpresa>());
                    }
                }
            }
            catch (NHibernate.ADOException)
            {
                if (Transaction() != null) Transaction().Rollback();
                throw new iQLockException(moleQule.Library.Resources.Messages.LOCK_ERROR);
            }
            catch (Exception ex)
            {
                if (Transaction() != null) Transaction().Rollback();
                iQExceptionHandler.TreatException(ex);
            }
        }

        [Transactional(TransactionalTypes.TransactionScope)]
        protected override void DataPortal_Insert()
        {
            try
            {
                SessionCode = OpenSession();
                BeginTransaction();
                GetNewCode();
                Serial = GetNewSerial();
                Session().Save(this);
            }
            catch (ValidationException ex)
            {
                throw new iQValidationException(ex.Message);
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }
        }

        [Transactional(TransactionalTypes.TransactionScope)]
        protected override void DataPortal_Update()
        {
            if (IsDirty)
            {
                try
                {
                    Empresa obj = Session().Get<Empresa>(Oid);
                    obj.CopyValues(this);
                    Session().Update(obj);
                }
                catch (Exception ex)
                {
                    iQExceptionHandler.TreatException(ex);
                }
            }
        }

        [Transactional(TransactionalTypes.TransactionScope)]
        protected override void DataPortal_DeleteSelf()
        {
            DataPortal_Delete(new CriteriaCs(Oid));
        }

        [Transactional(TransactionalTypes.TransactionScope)]
        private void DataPortal_Delete(CriteriaCs criteria)
        {
            // Iniciamos la conexion y la transaccion
            SessionCode = OpenSession();
            BeginTransaction();

            try
            {
                CriteriaEx criterio = GetCriteria();
                criterio.AddOidSearch(criteria.Oid);
                Session().Delete((Empresa)(criterio.UniqueResult()));

                Transaction().Commit();

                //Borramos los usuarios que únicamente tenían acceso a esta empresa
                Users usuarios = Users.GetNoSchemaList();

                foreach (User usr in usuarios)
                    User.Delete(usr.Oid);

            }
            catch (Exception ex)
            {
                if (Transaction() != null) Transaction().Rollback();
                iQExceptionHandler.TreatException(ex);
            }
            finally
            {
                CloseSession();
            }
        }

        #endregion

        #region Commands

        public static bool Exists(string codigo)
        {
            ExistsCmd result;
            result = DataPortal.Execute<ExistsCmd>(new ExistsCmd(codigo));
            return result.Exists;
        }

        [Serializable()]
        private class ExistsCmd : CommandBase
        {
            private string _codigo = string.Empty;
            private bool _exists = false;

            public bool Exists
            {
                get { return _exists; }
            }

            public ExistsCmd(string codigo)
            {
                _codigo = codigo;
            }

            protected override void DataPortal_Execute()
            {
                // Buscar por codigo
                CriteriaEx criteria = Empresa.GetCriteria(Empresa.OpenSession());
                criteria.AddEq("Code", _codigo);
                EmpresaList lista = EmpresaList.GetList(criteria);
                _exists = !(lista.Count == 0);
            }
        }

        #endregion

    }
}

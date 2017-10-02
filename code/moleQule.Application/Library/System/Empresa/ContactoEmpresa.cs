using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

using Csla;
using Csla.Validation;
using CslaEx;

using moleQule.Library;

using NHibernate;

namespace moleQule.Library.Application
{
    /// <summary>
    /// Editable Child Business Object
    /// </summary>
    [Serializable()]
    public class ContactoEmpresa : BusinessBaseEx<ContactoEmpresa>
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

        public virtual long OidEmpresa
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _oid_empresa;
            }

            set
            {
                CanWriteProperty(true);
                _oid_empresa = value;
                PropertyHasChanged();
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

            set
            {
                CanWriteProperty(true);
                if (value == null) value = string.Empty;
                if (!_nombre.Equals(value))
                {
                    _nombre = value;
                    PropertyHasChanged();
                }
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

            set
            {
                CanWriteProperty(true);
                if (value == null) value = string.Empty;
                if (!_cargo.Equals(value))
                {
                    _cargo = value;
                    PropertyHasChanged();
                }
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

            set
            {
                CanWriteProperty(true);
                if (value == null) value = string.Empty;
                if (!_dni.Equals(value))
                {
                    _dni = value;
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
                if (!_direccion.Equals(value))
                {
                    _direccion = value;
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
                if (!_cod_postal.Equals(value))
                {
                    _cod_postal = value;
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
                if (!_municipio.Equals(value))
                {
                    _municipio = value;
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
                if (!_provincia.Equals(value))
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
                if (!_telefonos.Equals(value))
                {
                    _telefonos = value;
                    PropertyHasChanged();
                }
            }
        }

        /// <summary>
        /// Copia los atributos del objeto
        /// </summary>
        /// <param name="_s">Objeto origen</param>
        protected override void CopyValues(ContactoEmpresa source)
        {
            if (source == null) return;

            _oid = source.Oid;
            _oid_empresa = source.OidEmpresa;
            _cargo = source.Cargo;
            _nombre = source.Nombre;
            _dni = source.Dni;
            _direccion = source.Direccion;
            _cod_postal = source.CodPostal;
            _municipio = source.Municipio;
            _provincia = source.Provincia;
            _telefonos = source.Telefonos;
        }

        public override bool IsValid
        {
            get { return base.IsValid; }
        }

        public override bool IsDirty
        {
            get { return base.IsDirty; }
        }

        protected override object GetIdValue() { return _oid; }

        #endregion

        #region Validation Rules

        protected override void AddBusinessRules()
        {
            ValidationRules.AddRule(
                Csla.Validation.CommonRules.StringRequired, "Nombre");
        }

        #endregion

        #region Authorization Rules

        protected override void AddAuthorizationRules()
        {
        }

        public static bool CanAddObject()
        {
            return ApplicationContextEx.User.Identity.IsAdmin;
        }

        public static bool CanGetObject()
        {
            return true;
        }

        public static bool CanDeleteObject()
        {
            return ApplicationContextEx.User.Identity.IsAdmin;
        }

        public static bool CanEditObject()
        {
            return ApplicationContextEx.User.Identity.IsAdmin;
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// NO UTILIZAR DIRECTAMENTE, SE DEBE USAR LA FUNCION NewChild
        /// Debería ser private para CSLA porque la creación requiere el uso de los factory methods,
        /// pero debe ser protected por exigencia de NHibernate
        /// y public para que funcionen los DataGridView
        /// </summary>
        public ContactoEmpresa()
        {
            MarkAsChild();
            Random r = new Random();
            _oid = (long)r.Next();
        }

        private ContactoEmpresa(ContactoEmpresa source)
        {
            MarkAsChild();
            Fetch(source);
        }

        private ContactoEmpresa(IDataReader reader)
        {
            MarkAsChild();
            Fetch(reader);
        }

        public static ContactoEmpresa NewChild(Empresa parent)
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException(
                    moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            ContactoEmpresa obj = new ContactoEmpresa();
            obj.OidEmpresa = parent.Oid;
            return obj;
        }

        internal static ContactoEmpresa GetChild(ContactoEmpresa source)
        {
            return new ContactoEmpresa(source);
        }

        internal static ContactoEmpresa GetChild(IDataReader reader)
        {
            return new ContactoEmpresa(reader);
        }

        public virtual ContactoEmpresaInfo GetInfo()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            return new ContactoEmpresaInfo(Oid, OidEmpresa, Nombre, Cargo, Dni, Direccion,
                                     CodPostal, Municipio, Provincia, Telefonos);

        }

        /// <summary>
        /// Borrado aplazado, es posible el undo 
        /// (La función debe ser "no estática")
        /// </summary>
        public override void Delete()
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException(
                    moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            MarkDeleted();
        }

        /// <summary>
        /// No se debe utilizar esta función para guardar. Hace falta el padre.
        /// Utilizar Insert o Update en sustitución de Save.
        /// </summary>
        /// <returns></returns>
        public override ContactoEmpresa Save()
        {
            throw new iQException(moleQule.Library.Resources.Messages.CHILD_SAVE_NOT_ALLOWED);
        }

        #endregion

        #region Child Data Access

        private void Fetch(ContactoEmpresa source)
        {
            CopyValues(source);
            MarkOld();
        }

        private void Fetch(IDataReader source)
        {
            CopyValues(source);
            MarkOld();
        }

        internal void Insert(Empresa parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            _oid_empresa = parent.Oid;

            try
            {
                ValidationRules.CheckRules();

                if (!IsValid)
                    throw new iQValidationException(moleQule.Library.Resources.Messages.GENERIC_VALIDATION_ERROR);

                parent.Session().Save(this);
            }
            catch (Exception ex)
            {
                throw new iQPersistentException(iQExceptionHandler.GetAllMessages(ex));
            }

            MarkOld();
        }

        internal void Update(Empresa parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            _oid_empresa = parent.Oid;

            try
            {
                ValidationRules.CheckRules();

                if (!IsValid)
                    throw new iQValidationException(moleQule.Library.Resources.Messages.GENERIC_VALIDATION_ERROR);

                ContactoEmpresa obj = parent.Session().Get<ContactoEmpresa>(Oid);
                obj.CopyValues(this);
                parent.Session().Update(obj);
            }
            catch (Exception ex)
            {
                throw new iQPersistentException(iQExceptionHandler.GetAllMessages(ex));
            }

            MarkOld();
        }

        internal void DeleteSelf(Empresa parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            // if we're new then don't update the database
            if (this.IsNew) return;

            try
            {
                parent.Session().Delete(parent.Session().Get<ContactoEmpresa>(Oid));
            }
            catch (Exception ex)
            {
                throw new iQPersistentException(iQExceptionHandler.GetAllMessages(ex));
            }

            MarkNew();
        }

        #endregion

        #region Commands

        public static bool Exists(long oid)
        {
            ExistsCmd result;
            result = DataPortal.Execute<ExistsCmd>(new ExistsCmd(oid));
            return result.Exists;
        }

        [Serializable()]
        private class ExistsCmd : CommandBase
        {
            private long _codigo;
            private bool _exists = false;

            public bool Exists
            {
                get { return _exists; }
            }

            public ExistsCmd(long oid)
            {
                _codigo = oid;
            }

            protected override void DataPortal_Execute()
            {
                // Buscar por Oid
                CriteriaEx criteria = ContactoEmpresa.GetCriteria(ContactoEmpresa.OpenSession());
                criteria.AddOidSearch(_codigo);
                ContactoEmpresaList list = ContactoEmpresaList.GetList(criteria);
                _exists = (list.Count > 0);
            }
        }

        #endregion

    }
}


using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.ComponentModel;
using NHibernate;

using Csla;
using CslaEx;

using moleQule.Library;

namespace moleQule.Library.Application
{

	/// <summary>
	/// Editable Child Business Object
	/// </summary>
    [Serializable()]
	public class CuentaEmpresa : BusinessBaseEx<CuentaEmpresa>
	{
	
	    #region Business Methods
		 
		private long _oid_empresa;
		private long _entidad;
		private long _sucursal;
		private long _dc;
		private long _numero;
		public virtual long OidEmpresa
		{
			
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				CanReadProperty(true);
				return _oid_empresa;
            }
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				CanWriteProperty(true);
				if (!_oid_empresa.Equals(value))
				{
					_oid_empresa = value;
					PropertyHasChanged();
				}
			}
		}
		
		public virtual long Entidad
		{
			
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				CanReadProperty(true);
				return _entidad;
            }
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				CanWriteProperty(true);
				if (!_entidad.Equals(value))
				{
					_entidad = value;
					PropertyHasChanged();
				}
			}
		}
		
		public virtual long Sucursal
		{
			
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				CanReadProperty(true);
				return _sucursal;
            }
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				CanWriteProperty(true);
				if (!_sucursal.Equals(value))
				{
					_sucursal = value;
					PropertyHasChanged();
				}
			}
		}
		
		public virtual long Dc
		{
			
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				CanReadProperty(true);
				return _dc;
            }
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				CanWriteProperty(true);
				if (!_dc.Equals(value))
				{
					_dc = value;
					PropertyHasChanged();
				}
			}
		}
		
		public virtual long Numero
		{
			
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				CanReadProperty(true);
				return _numero;
            }
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				CanWriteProperty(true);
				if (!_numero.Equals(value))
				{
					_numero = value;
					PropertyHasChanged();
				}
			}
		}
		
			 
		/// <summary>
		/// Copia los atributos del objeto
		/// </summary>
		/// <param name="source">Objeto origen</param>
		protected override void CopyValues (CuentaEmpresa source)
		{
			if (source == null) return;
			_oid = source.Oid;
			_oid_empresa = source.OidEmpresa;
			_entidad = source.Entidad;
			_sucursal = source.Sucursal;
			_dc = source.Dc;
			_numero = source.Numero;
			
		}

		protected override object GetIdValue() { return _oid; }
				
			
		#endregion
		 
	    #region Validation Rules
		 
		//región a rellenar si hay campos requeridos o claves ajenas
		
		//Descomentar en caso de existir reglas de validación
		/*protected override void AddBusinessRules()
        {	
			//Agregar reglas de validación
        }*/
		
		#endregion
		 
		#region Authorization Rules
		 
		public static bool CanAddObject()
		{
			return ApplicationContextEx.User.CanWriteObject(Resources.ElementosSeguros.EMPRESA);
		}
		
		public static bool CanGetObject()
		{
            return ApplicationContextEx.User.CanReadObject(Resources.ElementosSeguros.EMPRESA);
		}
		
		public static bool CanDeleteObject()
		{
            return ApplicationContextEx.User.CanWriteObject(Resources.ElementosSeguros.EMPRESA);
		}
		
		public static bool CanEditObject()
		{
            return ApplicationContextEx.User.CanWriteObject(Resources.ElementosSeguros.EMPRESA);
		}
		 
		#endregion
		 
		#region Factory Methods
		 
		/// <summary>
		/// NO UTILIZAR DIRECTAMENTE, SE DEBE USAR LA FUNCION NewChild
		/// Debería ser private para CSLA porque la creación requiere el uso de los Factory Methods,
		/// pero debe ser protected por exigencia de NHibernate
		/// y public para que funcionen los DataGridView
		/// </summary>
		public CuentaEmpresa() 
		{ 
			MarkAsChild();
			Random r = new Random();
			_oid = (long)r.Next();
			//Rellenar si hay más campos que deban ser inicializados aquí
		}	
		
		private CuentaEmpresa(CuentaEmpresa source)
		{
			MarkAsChild();
			Fetch(source);
		}
		
		private CuentaEmpresa(IDataReader reader)
		{
			MarkAsChild();
			Fetch(reader);
		}
		
		//Por cada padre que tenga la clase
		public static CuentaEmpresa NewChild()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException(
					moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);
			
			return new CuentaEmpresa();
		}
		
		public static CuentaEmpresa NewChild(Empresa parent)
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException(
					moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);
			
			CuentaEmpresa obj = new CuentaEmpresa();
			obj.OidEmpresa = parent.Oid;
			
			return obj;
		}
		
		
		internal static CuentaEmpresa GetChild(CuentaEmpresa source)
		{
			return new CuentaEmpresa(source);
		}
		
		internal static CuentaEmpresa GetChild(IDataReader reader)
		{
			return new CuentaEmpresa(reader);
		}
		
		public virtual CuentaEmpresaInfo GetInfo()
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException(
				  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);
			
			return new CuentaEmpresaInfo(this);
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
		public override CuentaEmpresa Save()
		{
            throw new iQException(moleQule.Library.Resources.Messages.CHILD_SAVE_NOT_ALLOWED);
		}
		
			
		#endregion
		 
		#region Child Data Access
		 
		private void Fetch(CuentaEmpresa source)
		{
			CopyValues(source);
			MarkOld();
		}
		
		private void Fetch(IDataReader reader)
		{
			CopyValues(reader);
			MarkOld();
		}
		
		internal void Insert(Empresa parent)
		{
			// if we're not dirty then don't update the database
			if (!this.IsDirty) return;
			
			try
			{	
				parent.Session().Save(this);
			}
			catch (Exception ex)
			{
				iQExceptionHandler.TreatException(ex);
			}
			
			MarkOld();
		}

		internal void Update(Empresa parent)
		{
			// if we're not dirty then don't update the database
			if (!this.IsDirty) return;
			
			
			try
			{
				SessionCode = parent.SessionCode;
				CuentaEmpresa obj = Session().Get<CuentaEmpresa>(Oid);
				obj.CopyValues(this);
				Session().Update(obj);
			}
			catch (Exception ex)
			{
				iQExceptionHandler.TreatException(ex);
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
				SessionCode = parent.SessionCode;
				Session().Delete(Session().Get<CuentaEmpresa>(Oid));
			}
			catch (Exception ex)
			{
				iQExceptionHandler.TreatException(ex);
			}
		
			MarkNew(); 
		}
		
		
		#endregion
	
	}
}


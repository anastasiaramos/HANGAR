﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.586
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace moleQule.Library.Application.Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Messages {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Messages() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("moleQule.Library.Application.Resources.Messages", typeof(Messages).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No ha sido posible realizar el backup de la base de datos..
        /// </summary>
        internal static string BACKUP_ERROR {
            get {
                return ResourceManager.GetString("BACKUP_ERROR", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to La hora de salida es anterior a la hora de entrada..
        /// </summary>
        internal static string END_BEFORE_BEGIN {
            get {
                return ResourceManager.GetString("END_BEFORE_BEGIN", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Error en los datos del formulario.
        ///
        ///Los campos marcados con * necesitan un valor.
        ///Los campos marcados con ! tienen valores inadecuados..
        /// </summary>
        internal static string GENERIC_VALIDATION_ERROR {
            get {
                return ResourceManager.GetString("GENERIC_VALIDATION_ERROR", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Imposible bloquear el elemento seleccionado.
        ///Otro usuario está modificándolo en este momento. .
        /// </summary>
        internal static string LOCK_ERROR {
            get {
                return ResourceManager.GetString("LOCK_ERROR", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No ha sido posible realizar la operación.
        ///.
        /// </summary>
        internal static string OPERATION_ERROR {
            get {
                return ResourceManager.GetString("OPERATION_ERROR", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No se ha encontrado una clave en el registro de Windows..
        /// </summary>
        internal static string REGISTRYKEY_NOT_FOUND {
            get {
                return ResourceManager.GetString("REGISTRYKEY_NOT_FOUND", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Usuario no autentificado.
        ///
        ///Compruebe su nombre de usuario y contraseña.
        ///
        ///Intentando conectarse al servidor: .
        /// </summary>
        internal static string USER_NOT_AUTHENTIFICATED {
            get {
                return ResourceManager.GetString("USER_NOT_AUTHENTIFICATED", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Comprobando permisos....
        /// </summary>
        internal static string USER_VALIDATION_MSG {
            get {
                return ResourceManager.GetString("USER_VALIDATION_MSG", resourceCulture);
            }
        }
    }
}

﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión del motor en tiempo de ejecución:2.0.50727.5446
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace moleQule.Library.Application.Resources {
    using System;
    
    
    /// <summary>
    ///   Clase de recurso con establecimiento inflexible de tipos, para buscar cadenas traducidas, etc.
    /// </summary>
    // StronglyTypedResourceBuilder generó automáticamente esta clase
    // a través de una herramienta como ResGen o Visual Studio.
    // Para agregar o quitar un miembro, edite el archivo .ResX y, a continuación, vuelva a ejecutar ResGen
    // con la opción /str o vuelva a generar su proyecto de VS.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "2.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Conf {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Conf() {
        }
        
        /// <summary>
        ///   Devuelve la instancia de ResourceManager almacenada en caché utilizada por esta clase.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("moleQule.Library.Application.Resources.Conf", typeof(Conf).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Reemplaza la propiedad CurrentUICulture del subproceso actual para todas las
        ///   búsquedas de recursos mediante esta clase de recurso con establecimiento inflexible de tipos.
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
        ///   Busca una cadena traducida similar a TebaP2G.
        /// </summary>
        internal static string DB_PASSWORD {
            get {
                return ResourceManager.GetString("DB_PASSWORD", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a HangarUpdate.exe.
        /// </summary>
        internal static string FTPFile {
            get {
                return ResourceManager.GetString("FTPFile", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a ftp.iqingenieros.com.
        /// </summary>
        internal static string FTPHost {
            get {
                return ResourceManager.GetString("FTPHost", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a WEdfg6543.
        /// </summary>
        internal static string FTPPwd {
            get {
                return ResourceManager.GetString("FTPPwd", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a iQPre.
        /// </summary>
        internal static string FTPUser {
            get {
                return ResourceManager.GetString("FTPUser", resourceCulture);
            }
        }
    }
}

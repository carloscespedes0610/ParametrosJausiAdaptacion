﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Parametros.resources {
    using System;
    
    
    /// <summary>
    ///   Clase de recurso fuertemente tipado, para buscar cadenas traducidas, etc.
    /// </summary>
    // StronglyTypedResourceBuilder generó automáticamente esta clase
    // a través de una herramienta como ResGen o Visual Studio.
    // Para agregar o quitar un miembro, edite el archivo .ResX y, a continuación, vuelva a ejecutar ResGen
    // con la opción /str o recompile su proyecto de VS.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Devuelve la instancia de ResourceManager almacenada en caché utilizada por esta clase.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Parametros.resources.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Reemplaza la propiedad CurrentUICulture del subproceso actual para todas las
        ///   búsquedas de recursos mediante esta clase de recurso fuertemente tipado.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Gestion.
        /// </summary>
        public static string Gestion {
            get {
                return ResourceManager.GetString("Gestion", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a La gestion seleccionada no cuenta con periodos registrados..
        /// </summary>
        public static string GestionSinPeriodo {
            get {
                return ResourceManager.GetString("GestionSinPeriodo", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Índice nulo.
        /// </summary>
        public static string IndiceNulo {
            get {
                return ResourceManager.GetString("IndiceNulo", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Actualizacion fallida.
        /// </summary>
        public static string NoActualizado {
            get {
                return ResourceManager.GetString("NoActualizado", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a No se encontro elementos para el indice seleccionado.
        /// </summary>
        public static string ObjetoNoEncontrado {
            get {
                return ResourceManager.GetString("ObjetoNoEncontrado", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Periodo.
        /// </summary>
        public static string Periodo {
            get {
                return ResourceManager.GetString("Periodo", resourceCulture);
            }
        }
    }
}

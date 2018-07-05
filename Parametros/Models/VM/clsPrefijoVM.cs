using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Parametros.Models.VM
{
    public class clsPrefijoVM

    {  
        [Key]
        public long PrefijoId { get; set; }

        [Display(Name = "Prefijo"), Required(ErrorMessage = "{0} es requerido")]
        [Range(1, long.MaxValue, ErrorMessage = "{0} es Requerido")]
        public int PrefijoNro { get; set; }

        [Display(Name = "Descripción"), Required(ErrorMessage = "{0} es requerido")]
        public string PrefijoDes { get; set; }

        [NotMapped, Display(Name = "Documento"), Required(ErrorMessage = "{0} es requerido")]
        [Range(1, long.MaxValue, ErrorMessage = "{0} es Requerido")]
        public long DocId { get; set; }

        [Display(Name = "Nemónico")]
        public string DocNemonico { get; set; }

        [Display(Name = "Documento")]
        public string DocDes { get; set; }

        [Display(Name = "Modulo"), Required(ErrorMessage = "{0} es requerido")]
        public long ModuloId { get; set; }

        [Display(Name = "Modulo")]
        public string ModuloDes { get; set; }

        [NotMapped, Display(Name = "Aplicación"), Required(ErrorMessage = "{0} es requerido")]
        public long AplicacionId { get; set; }

        [Display(Name = "Aplicación")]
        public string AplicacionDes { get; set; }
        
        [Display(Name = "Numeración"), Required(ErrorMessage = "{0} es requerido")]
        [Range(1, long.MaxValue, ErrorMessage = "{0} es Requerido")]
        public long PrefijoTipoId { get; set; }

        [Display(Name = "Tipo")]
        public string PrefijoTipoDes { get; set; }

        [Display(Name = "Inicializar cada Gestion?")]
        public bool PrefijoIniGes { get; set; }

        [NotMapped,Display(Name = "Formato Impresíon"), Required(ErrorMessage = "{0} es requerido")]
        [Range(1, long.MaxValue, ErrorMessage = "{0} es Requerido")]
        public long FormatoImpId { get; set; }

        [Display(Name = "Formato Impresíon")]
        public string FormatoImpDes { get; set; }

        [Display(Name = "Mensaje de Formato")]
        public string MensajeFor { get; set; }

        [Display(Name = "Número de copias"), Required(ErrorMessage = "{0} es requerido")]
        [Range(1, long.MaxValue, ErrorMessage = "{0} es Requerido")]
        public long PrefijoCopiaId { get; set; }

        [Display(Name = "Número de copias")]
        public String PrefijoCopiaDes { get; set; }

        [Display(Name = "Número de Item máximo"), Required(ErrorMessage = "{0} es requerido")]
        public int ItemMax { get; set; }

        [Display(Name = "Imprime usuario?")]
        public bool ImprimeUsr { get; set; }

        [Display(Name = "Imprime fecha?")]
        public bool ImprimeFec { get; set; }

        [NotMapped,Display(Name = "Encabezado"), Required(ErrorMessage = "{0} es requerido")]
        [Range(1, long.MaxValue, ErrorMessage = "{0} es Requerido")]
        public long TipoEncabezadoId { get; set; }

        [Display(Name = "Encabezado")]
        public string TipoEncabezadoDes { get; set; }

        [Display(Name = "Razón Social")]
        public string RazonSoc { get; set; }

        [Display(Name = "Abreviatura")]
        public string RazonSocAbr { get; set; }


        public string ObsUno { get; set; }
        public string ObsDos { get; set; }

        [Display(Name = "")]
        public string FirmaUno { get; set; }
        [Display(Name = "")]
        public string FirmaSeg { get; set; }
        [Display(Name = "")]
        public string FirmaTre { get; set; }
        [Display(Name = "")]
        public string FirmaCua { get; set; }

        [NotMapped,Display(Name = "Estado"), Required(ErrorMessage = "{0} es requerido")]
        [Range(1, long.MaxValue, ErrorMessage = "{0} es Requerido")]
        public long EstadoId { get; set; }

        [Display(Name = "Estado")]       
        public string EstadoDes { get; set; }
    }
}
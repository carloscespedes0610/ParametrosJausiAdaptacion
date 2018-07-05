using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Parametros.Models.VM
{
    public class clsCorrelativoVM

    {  
        [Key]
        public long CorreId { get; set; }

        [Display(Name = "Prefijo"), Required(ErrorMessage = "{0} es requerido")]
        public long PrefijoId { get; set; }

        [Display(Name = "Prefijo")]
        public int  PrefijoNro { get; set; }

        [Display(Name = "Descripción")]
        public string PrefijoDes { get; set; }

        [NotMapped, Display(Name = "Documento")]
        [Range(1, long.MaxValue, ErrorMessage = "{0} es Requerido")]
        public long DocId { get; set; }

        [Display(Name = "Nemónico")]
        public string DocNemonico { get; set; }

        [Display(Name = "Documento")]
        public string DocDes { get; set; }

        [Display(Name = "Modulo")]
        public long ModuloId { get; set; }

        [Display(Name = "Modulo")]
        public string ModuloDes { get; set; }

        [NotMapped, Display(Name = "Aplicación")]
        public long AplicacionId { get; set; }

        [Display(Name = "Aplicación")]
        public string AplicacionDes { get; set; }

        [NotMapped, Display(Name = "Gestión"), Required(ErrorMessage = "{0} es requerido")]
        [Range(1, long.MaxValue, ErrorMessage = "{0} es Requerido")]
        public long GestionId { get; set; }

        [Display(Name = "Gestión")]
        public int GestionNro { get; set; }

        [Display(Name = "Numeración Actual"), Required(ErrorMessage = "{0} es requerido")]
        public int CorreNroAct { get; set; }

        [Display(Name = "Máximo"), Required(ErrorMessage = "{0} es requerido")]
        public int CorreNroMax { get; set; }

        [Display(Name = "Inicial") , Required(ErrorMessage = "{0} es requerido")]
        public DateTime FecIni { get; set; }

        [Display(Name = "Final"), Required(ErrorMessage = "{0} es requerido")]
        public DateTime FecFin { get; set; }

        
    }
}
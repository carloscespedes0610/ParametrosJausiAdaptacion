using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Parametros.Models.VM
{
    public class clsDocumentoVM
    {   [Key]
        public long DocId { get; set; }

        [Display(Name = "Código"), Required(ErrorMessage = "{0} es requerido")]
        public String DocCod { get; set; }

        [Display(Name = "Nemónico"), Required(ErrorMessage = "{0} es requerido")]
        public String DocNem { get; set; }

        [Display(Name = "Descripción"), Required(ErrorMessage = "{0} es requerido")]
        public String DocDes { get; set; }

        [Display(Name = "ISO")]
        public String DocIso { get; set; }

        [Display(Name = "Revision")]
        public String DocRev { get; set; }

       [Display(Name = "Vencimiento")]
        public String DocFec { get; set; }

        [NotMapped, Display(Name = "Módulo")]
        public long ModuloId { get; set; }

        [Display(Name = "Módulo")]
        public String ModuloDes { get; set; }

        [NotMapped, Display(Name = "Aplicación")]
        public long AplicacionId { get; set; }

        [NotMapped, Display(Name = "Aplicación")]
        public String AplicacionDes { get; set; }

        [NotMapped, Display(Name = "Estado")]
        public long EstadoId { get; set; }

        [NotMapped, Display(Name = "Estado")]
        public String EstadoDes { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Parametros.Models.VM
{
    public class clsDocumentoVM
    {
        [Key]
        public long DocId { get; set; }

        [Display(Name = "Código"), Required(ErrorMessage = "{0} es requerido")]
        [StringLength(5)]
        public String DocCod { get; set; }

        [Display(Name = "Nemónico"), Required(ErrorMessage = "{0} es requerido")]
        [StringLength(255)]
        public String DocNem { get; set; }

        [Display(Name = "Descripción"), Required(ErrorMessage = "{0} es requerido")]
        [StringLength(50)]
        public String DocDes { get; set; }

        [Display(Name = "ISO")]
        [StringLength(50)]
        public String DocIso { get; set; }

        [Display(Name = "Revision")]
        [StringLength(50)]
        public String DocRev { get; set; }

        // Modificado por Carlos:
        [Display(Name = "Vencimiento")]
        public DateTime DocFec { get; set; }

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

        public static string _DocId = nameof(DocId);
        public static string _DocCod = nameof(DocCod);
        public static string _DocNem = nameof(DocNem);
        public static string _DocDes = nameof(DocDes);
        public static string _DocIso = nameof(DocIso);
        public static string _DocRev = nameof(DocRev);
        public static string _DocFec = nameof(DocFec);
        public static string _ModuloId = nameof(ModuloId);
        public static string _ModuloDes = nameof(ModuloDes);
        public static string _AplicacionId = nameof(AplicacionId);
        public static string _AplicacionDes = nameof(AplicacionDes);
        public static string _EstadoId = nameof(EstadoId);
        public static string _EstadoDes = nameof(EstadoDes);


    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Parametros.Models.VM
{
    public class clsGestionVM
    {
        [Key]
        public long GestionId { get; set; }

        [Display(Name = "Gestión"), Required(ErrorMessage = "{0} es requerido")]
        [Range(1901,9999, ErrorMessage = "ingrese una gestión válida ")]
        [RegularExpression(@"([0-9]+)", ErrorMessage = "{0} debe ser un número")]
        public int GestionNro { get; set; }

        [Display(Name = "Fecha Inicio"), Required(ErrorMessage = "{0} es requerido"), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
        public DateTime GestionFecIni { get; set; }

        [Display(Name = "Fecha Fin"), Required(ErrorMessage = "{0} es requerido"), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime GestionFecFin { get; set; }

        [NotMapped, Display(Name = "Estados")]
        public long EstadoId { get; set; }

        [Display(Name = "Estado")]
        public string EstadoDes { get; set; }

        [Display(Name = "Generar Periodo?")]
        public bool GenerarPeriodo { get; set; }

        public static string _GestionId = nameof(GestionId);
        public static string _GestionNro= nameof(GestionNro);
        public static string _GestionFecIni = nameof(GestionFecIni);
        public static string _GestionFecFin = nameof(GestionFecFin);
        public static string _EstadoId = nameof(EstadoId);
        public static string _EstadoDes = nameof(EstadoDes);
    }
}
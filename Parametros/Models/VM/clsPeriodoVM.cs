using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Parametros.Models.VM
{
    public class clsPeriodoVM

    {   [Key]
        public long PeriodoId { get; set; }

        [NotMapped, Display(Name = "Mes"), Required(ErrorMessage = "{0} es requerido")]
        public long MesId { get; set; }

        [Display(Name = "Mes")]
        public string MesDes { get; set; }


        [NotMapped, Display(Name = "Gestión"), Required(ErrorMessage = "{0} es requerido")]
        public long GestionId { get; set; }

        [Display(Name = "Gestión")]
        public string GestionNro { get; set; }


        [Display(Name = "Inicio"), Required(ErrorMessage = "{0} es requerido")]
        public DateTime PeriodoFecIni { get; set; }

        [Display(Name = "Fin"), Required(ErrorMessage = "{0} es requerido")]
        public DateTime PeriodoFecFin { get; set; }

        [NotMapped, Display(Name = "Estado"), Required(ErrorMessage = "{0} es requerido")]
        public long EstadoId { get; set; }

        [Display(Name = "Estado")]
        public string EstadoDes { get; set; }

        public static string _PeriodoId = nameof(PeriodoId);
        public static string _MesId = nameof(MesId);
        public static string _MesDes = nameof(MesDes);
        public static string _GestionId = nameof(GestionId);
        public static string _GestionNro = nameof(GestionNro);
        public static string _PeriodoFecIni = nameof(PeriodoFecIni);
        public static string _PeriodoFecFin = nameof(PeriodoFecFin);
        public static string _EstadoId = nameof(EstadoId);
        public static string _EstadoDes = nameof(EstadoDes);

    }
}
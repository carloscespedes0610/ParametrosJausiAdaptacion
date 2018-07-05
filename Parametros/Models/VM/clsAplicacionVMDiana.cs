using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Parametros.Models.VM
{
    public class clsAplicacionVM

    {   [Key]
        public long AplicacionId { get; set; }

        [Display(Name = "Aplicación")]
        public string AplicacionDes { get; set; }

        [Display(Name = "Modulo")]
        public long ModuloId { get; set; }
    }
}
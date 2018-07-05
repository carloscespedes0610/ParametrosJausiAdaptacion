using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Parametros.Models.VM
{
    public class clsModuloVM

    {   [Key]
        public long ModuloId { get; set; }

        [Display(Name = "Módulo")]
        public string ModuloDes { get; set; }

        
    }
}
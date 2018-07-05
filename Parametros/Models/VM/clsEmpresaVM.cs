using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Parametros.Models.VM
{
    public class clsEmpresaVM
    {
        [Key]
        public long EmpresaId { get; set; }

        [Display(Name = "Empresa")]
        public string EmpresaDes { get; set; }

        public string DataSource { get; set; }

        public string InitialCatalog { get; set; }
    }
}
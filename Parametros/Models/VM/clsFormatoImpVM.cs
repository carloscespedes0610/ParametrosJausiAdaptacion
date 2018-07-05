using System.ComponentModel.DataAnnotations;

namespace Parametros.Models.VM
{
    public class clsFormatoImpVM
    {
        [Key]
        public long FormatoImpId { get; set; }

        [Display(Name = "Formato de Impresión"), Required(ErrorMessage = "{0} es requerido")]        
        public string FormatoImpDes { get; set; }

        
    }
}
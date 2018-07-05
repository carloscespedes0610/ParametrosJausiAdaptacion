using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Parametros.Models.VM
{
    public class clsMesVM
    {
        public int MesId { get; set; }
        public string MesCod { get; set; }
        public string MesDes { get; set; }

       public clsMesVM(int id, string des) {
            MesId = id;
            MesDes = des;
        }

        public static string _MesId = nameof(MesId);
        public static string _MesCod = nameof(MesCod);
        public static string _MesDes = nameof(MesDes);
    }
}
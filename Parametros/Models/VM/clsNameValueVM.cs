using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Parametros.Models.VM
{
    public class clsNameValueVM
    {
        public long Value { get; set; }
       
        public string Name { get; set; }

       public clsNameValueVM(long id, string des) {
            Value = id;
            Name = des;
        }

        public clsNameValueVM()
        {
           
        }
    }
}
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Newtonsoft.Json;
using Parametros.Models.Modules;
using Parametros.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Parametros.Controllers
{
    public class ComboBoxController : Controller
    {
        [HttpGet]
        public ActionResult EstadoList(DataSourceLoadOptions loadOptions)
        {
            loadOptions.Sort = new[] { new SortingInfo { Selector = clsEstadoVM._EstadoDes } };

            return Content(JsonConvert.SerializeObject(DataSourceLoader.Load(ComboBox.EstadoList(), loadOptions)), "application/json");
        }

        [HttpGet]
        public ActionResult GestionList(DataSourceLoadOptions loadOptions)
        {
            loadOptions.Sort = new[] { new SortingInfo { Selector = clsGestionVM._GestionNro} };

            return Content(JsonConvert.SerializeObject(DataSourceLoader.Load(ComboBox.GestionList(), loadOptions)), "application/json");
        }

        [HttpGet]
        public ActionResult MesList(DataSourceLoadOptions loadOptions)
        {
            //loadOptions.Sort = new[] { new SortingInfo { Selector = clsMesVM._MesDes } };

            return Content(JsonConvert.SerializeObject(DataSourceLoader.Load(ComboBox.MesList(), loadOptions)), "application/json");
        }


    }
       
}

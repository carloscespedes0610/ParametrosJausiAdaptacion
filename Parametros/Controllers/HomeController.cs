using Seguridad.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Parametros.Controllers {
    public class HomeController : Controller {
        public ActionResult Index() {
            this.GetDefaultData();
            return View();
        }
    }
}
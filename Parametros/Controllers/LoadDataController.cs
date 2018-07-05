
using Parametros.Models.DAC;
using System.Web.Mvc;

namespace Parametros.Controllers
{
    public static class LoadDataController
    {
        public static void GetDefaultData(this ControllerBase controller)
        {
            controller.ViewBag.UsuarioDes = clsAppInfo.UsuarioDes;
            controller.ViewBag.UsuarioFotoPath = clsAppInfo.AppPath + clsAppInfo.UsuarioFotoPath;
        }
    }
}
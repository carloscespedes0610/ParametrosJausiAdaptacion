using DevExtreme.AspNet.Mvc;
using Newtonsoft.Json;
using Parametros.Models.DAC;
using Parametros.Models.Modules;
using Parametros.Models.VM;

using Parametros.resources;
using Seguridad.Controllers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Parametros.Controllers
{
    [SessionExpireFilter]
    public class GestionController : Controller
    {
        // GET: Gestion
        public ActionResult Index()
        {
            try
            {
                this.GetDefaultData(); 
                return View();
            }

            catch (Exception exp)
            {
                return RedirectToAction("httpErrorMsg", "Error", new { MessageErr = exp.Message });
            }
        }

        // GET: Gestion/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                this.GetDefaultData();

                if (ReferenceEquals(id, null))
                {
                   ViewBag.MessageErr = Resources.IndiceNulo;
                }

                clsGestionVM oGestionVM = GestionFind(Convert.ToInt32(id));

                if (ReferenceEquals(oGestionVM, null))
                {
                    return RedirectToAction("httpErrorMsg", "Error", new { MessageErr = "Índice no encontrado" });
                }

                // Comentado Carlos: ya no necesita ya pide la vista directamente al controlador
                //ViewBag.EstadoId = ComboBox.EstadoList();
                return View(oGestionVM);
            }

            catch (Exception exp)
            {
                return RedirectToAction("httpErrorMsg", "Error", new { MessageErr = exp.Message });
            }
        }

        // GET: Gestion/Create
        public ActionResult Create()
        {
            try
            {
                this.GetDefaultData();
                clsGestionVM oGestionVm = new clsGestionVM();
                oGestionVm.EstadoId = ConstEstado.Activo;
               
               
                return View(oGestionVm);
            }

            catch (Exception exp)
            {
                return RedirectToAction("httpErrorMsg", "Error", new { MessageErr = exp.Message });
            }
        }

        // POST: Gestion/Create
        [HttpPost]
        [ValidateAntiForgeryToken()]
        public ActionResult Create(clsGestionVM oGestionVM)
        {
            try
            {
                String error = null;
                if (ModelState.IsValid)
                {
                    clsGestion oGestion = new clsGestion(clsAppInfo.Connection);

                    
                    int gestionIni = oGestionVM.GestionFecIni.Year;
                    int gestionFin = oGestionVM.GestionFecFin.Year;
                   
                    if (oGestionVM.GestionNro != gestionIni ) {
                        error = "El nro gestion debe coincidir con las fechas";
                    }

                    if (SysData.FechaMayor(oGestionVM.GestionFecIni, oGestionVM.GestionFecFin) == cFecha.Mayor || SysData.FechaMayor(oGestionVM.GestionFecIni, oGestionVM.GestionFecFin) == cFecha.Igual)
                    {
                        error = error + " - La fecha inicio debe ser menor a la fecha fin";
                    }

                    if (String.IsNullOrEmpty(error))
                    {
                        DataMove(oGestionVM, oGestion, false);
                        if (oGestion.Insert())
                        {
                            return RedirectToAction("Index");
                        }
                    }
                    
                }
                ViewBag.MessageErr = error;
                return View(oGestionVM);
            }

            catch (Exception exp)
            {
               
                ViewBag.MessageErr = exp.Message;
                return View(oGestionVM);
            }
        }

        // GET: Gestion/Edit/5
        public ActionResult Edit(int? id)
        {
            try
            {
                this.GetDefaultData();

                if (ReferenceEquals(id, null))
                {
                    return RedirectToAction("httpErrorMsg", "Error", new { MessageErr = "Índice nulo o no encontrado" });
                }

                clsGestionVM oTipoUsuarioVM = GestionFind(Convert.ToInt32(id));

                if (ReferenceEquals(oTipoUsuarioVM, null))
                {
                    return RedirectToAction("httpErrorMsg", "Error", new { MessageErr = "Índice no encontrado" });
                }

              
                return View(oTipoUsuarioVM);
            }

            catch (Exception exp)
            {
                return RedirectToAction("httpErrorMsg", "Error", new { MessageErr = exp.Message });
            }
        }

        // POST: Gestion/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken()]
        public ActionResult Edit(clsGestionVM oGestionVM)
        {
            try
            {
                String error = null;
                if (ModelState.IsValid)
                {
                    clsGestion oGestion = new clsGestion(clsAppInfo.Connection);

                    int gestionIni = oGestionVM.GestionFecIni.Year;
                    int gestionFin = oGestionVM.GestionFecFin.Year;

                    if (oGestionVM.GestionNro != gestionIni || oGestionVM.GestionNro != gestionFin)
                    {
                        error = "El nro gestion debe coincidir con las fechas";
                    }

                    if (SysData.FechaMayor(oGestionVM.GestionFecIni, oGestionVM.GestionFecFin) == cFecha.Mayor || SysData.FechaMayor(oGestionVM.GestionFecIni, oGestionVM.GestionFecFin) == cFecha.Igual)
                    {
                        error = error + " - La fecha inicio debe ser menor a la fecha fin";
                    }

                    if (String.IsNullOrEmpty(error))
                    {

                        DataMove(oGestionVM, oGestion, true);
                        if (oGestion.Update())
                        {
                            return RedirectToAction("Index");
                        }
                    }
                }
                ViewBag.MessageErr = error;               
                return View(oGestionVM);
            }

            catch (Exception exp)
            {               
                ViewBag.MessageErr = exp.Message;
                return View(oGestionVM);
            }
        }

        // GET: Gestion/Delete/5
        public ActionResult Delete(int? id)
        {
            try
            {
                this.GetDefaultData();

                if (ReferenceEquals(id, null))
                {
                    return RedirectToAction("httpErrorMsg", "Error", new { MessageErr = "Índice nulo o no encontrado" });
                }

                clsGestionVM oGestionVM = GestionFind(Convert.ToInt32(id));

                if (ReferenceEquals(oGestionVM, null))
                {
                    return RedirectToAction("httpErrorMsg", "Error", new { MessageErr = "Índice no encontrado" });
                }

               
                return View(oGestionVM);
            }

            catch (Exception exp)
            {
                return RedirectToAction("httpErrorMsg", "Error", new { MessageErr = exp.Message });
            }
        }

        // POST: Gestion/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken()]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                if (ReferenceEquals(id, null))
                {
                    return RedirectToAction("httpErrorMsg", "Error", new { MessageErr = "Índice nulo o no encontrado" });
                }

                clsGestion oGestion = new clsGestion(clsAppInfo.Connection);

                oGestion.WhereFilter = clsGestion.WhereFilters.PrimaryKey;
                oGestion.VM.GestionId = id;

                if (oGestion.Delete())
                {
                    return RedirectToAction("Index");
                }

                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            catch (Exception exp)
            {
                return RedirectToAction("httpErrorMsg", "Error", new { MessageErr = exp.Message });
            }
        }

        [HttpGet]
        public ActionResult GestionGrid(DataSourceLoadOptions loadOptions) { return Content(JsonConvert.SerializeObject(GestionList()), "application/json"); }

        //---------------------

        private void DataMove(clsGestionVM oGestionVM, clsGestion oGestion, bool boolEditing)
        {
            if (boolEditing)
            {
                oGestion.VM.GestionId = SysData.ToLong(oGestionVM.GestionId);
            }

            oGestion.VM.GestionNro = SysData.ToInteger(oGestionVM.GestionNro);
            oGestion.VM.GestionFecIni = SysData.ToDate(oGestionVM.GestionFecIni);
            oGestion.VM.GestionFecFin = SysData.ToDate(oGestionVM.GestionFecFin);
            oGestion.VM.EstadoId = SysData.ToLong(oGestionVM.EstadoId);
        }

        public List<clsGestionVM> GestionList()
        {
           
            clsGestion oGestion = new clsGestion(clsAppInfo.Connection);
            List<clsGestionVM> oGestionVM = new List<clsGestionVM>();

           

            try
            {
                oGestion.SelectFilter = clsGestion.SelectFilters.Grid;
                oGestion.WhereFilter = clsGestion.WhereFilters.Grid;
                oGestion.OrderByFilter = clsGestion.OrderByFilters.Grid;

                if (oGestion.Open())
                {

                    foreach (DataRow dr in oGestion.DataSet.Tables[oGestion.TableName].Rows)
                    {
                        oGestionVM.Add(new clsGestionVM()
                        {
                            GestionId = SysData.ToLong(dr[clsGestionVM._GestionId]),
                            GestionNro = SysData.ToInteger(dr[clsGestionVM._GestionNro]),
                            GestionFecIni = SysData.ToDate(dr[clsGestionVM._GestionFecIni]),
                            GestionFecFin = SysData.ToDate(dr[clsGestionVM._GestionFecFin]),
                            EstadoDes = SysData.ToStr(dr[clsGestionVM._EstadoDes])
                        });
                    }
                }

                return oGestionVM;

            }
            catch (Exception exp)
            {
                throw exp;

            }
            finally
            {
                oGestion.Dispose();
            }
            return oGestionVM;
        }


        private clsGestionVM GestionFind(int gestionId)
        {           
            clsGestion oGestion = new clsGestion(clsAppInfo.Connection);
            clsGestionVM oGestionVM = new clsGestionVM();
                       
            try
            {
                oGestion.VM.GestionId = gestionId;

                if (oGestion.FindByPK())
                {
                    oGestionVM = oGestion.VM;

                    return oGestionVM;
                }

                return null;

            }
            catch (Exception exp)
            {
                throw exp;

            }
            finally
            {
                oGestion.Dispose();
            }
            return oGestionVM;
        }



    }
}

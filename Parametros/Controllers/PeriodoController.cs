using DevExtreme.AspNet.Mvc;
using Newtonsoft.Json;
using Parametros.Models.DAC;
using Parametros.Models.Modules;
using Parametros.Models.VM;
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
    public class PeriodoController : Controller
    {
        // GET: Periodo
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

      

        // GET: Periodo/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                this.GetDefaultData();

                if (ReferenceEquals(id, null))
                {
                    return RedirectToAction("httpErrorMsg", "Error", new { MessageErr = "Índice nulo o no encontrado" });
                }

                clsPeriodoVM oGestionVM = PeriodoFind(Convert.ToInt32(id));

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

     



        // GET: Periodo/Create
        public ActionResult Create()
        {
            try
            {
                clsPeriodoVM oPeriodo = new clsPeriodoVM();
                oPeriodo.EstadoId = ConstEstado.Activo;
                this.GetDefaultData();
               
                return View(oPeriodo);
            }
            catch (Exception e) {
                return RedirectToAction("httpErrorMsg", "Error", new { MessageErr = e.Message });
            }
        }

        // POST: Periodo/Create
        [HttpPost]
        [ValidateAntiForgeryToken()]
        public ActionResult Create(clsPeriodoVM oPeriodoVM)
        {
            try
            {
                if (ModelState.IsValid) {
                    clsPeriodo oPeriodo = new clsPeriodo(clsAppInfo.Connection);
                    DataMove(oPeriodo, oPeriodoVM, false);
                    if (oPeriodo.Insert()) {
                        return RedirectToAction("Index");
                    }
                }
               
                return View(oPeriodoVM);
            }
            catch( Exception e)
            {
                return RedirectToAction("httpErrorMsg", "Error", new { MessageErr = e.Message });
            }
        }

        // GET: Periodo/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                this.GetDefaultData();
                if (ReferenceEquals(id, null)) {
                   ViewBag.MessageErr = resources.Resources.IndiceNulo;
                }
                clsPeriodoVM oPeriodoVm = PeriodoFind(id);
                if (ReferenceEquals(oPeriodoVm, null)) {
                    ViewBag.MessageErr = "Ninguna referencia para el indice";
                }              

               
                return View(oPeriodoVm);

            }
            catch (Exception e) {
                return RedirectToAction("httpErrorMsg", "Error", new { MessageErr = e.Message });
            }

            return View();
        }

        // POST: Periodo/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken()]
        public ActionResult Edit(clsPeriodoVM oPeriodoVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    clsPeriodo oPeriodo = new clsPeriodo(clsAppInfo.Connection);
                    DataMove(oPeriodo, oPeriodoVM, true);

                    if (oPeriodo.Update())
                    {
                        return RedirectToAction("Index");
                    }
                    else {
                        ViewBag.MessageErr = resources.Resources.NoActualizado;
                    }
                }

               
                return View(oPeriodoVM);
            }

            catch (Exception exp)
            {
                
                ViewBag.MessageErr = exp.Message;
                return View(oPeriodoVM);
            }
        }

        // GET: Periodo/Delete/5
        public ActionResult Delete(int? id)
        {
            try
            {
                this.GetDefaultData();

                if (ReferenceEquals(id, null))
                {
                    return RedirectToAction("httpErrorMsg", "Error", new { MessageErr = resources.Resources.IndiceNulo });
                }

                clsPeriodoVM oPeriodoVM = PeriodoFind(Convert.ToInt32(id));

                if (ReferenceEquals(oPeriodoVM, null))
                {
                    ViewBag.Mesagge = resources.Resources.ObjetoNoEncontrado;
                }

               
                return View(oPeriodoVM);
            }

            catch (Exception exp)
            {
                return RedirectToAction("httpErrorMsg", "Error", new { MessageErr = exp.Message });
            }
        }

        // POST: Periodo/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken()]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                if (ReferenceEquals(id, null))
                {
                    ViewBag.MessageErr = resources.Resources.IndiceNulo;
                }

                clsPeriodo oPeriodo = new clsPeriodo(clsAppInfo.Connection);

                oPeriodo.WhereFilter = clsPeriodo.WhereFilters.PrimaryKey;
                oPeriodo.VM.PeriodoId = id;

                if (oPeriodo.Delete())
                {
                    return RedirectToAction("Index");
                }

               
                clsPeriodoVM periodoVM = PeriodoFind(id);
                return View(periodoVM);
            }

            catch (Exception exp)
            {
                return RedirectToAction("httpErrorMsg", "Error", new { MessageErr = exp.Message });
            }
        }

        [HttpGet]
        public ActionResult PeriodoGrid(DataSourceLoadOptions loadOptions) { return Content(JsonConvert.SerializeObject(PeriodoList()), "application/json"); }


        //---------------

         private void DataMove(clsPeriodo oPeriodo, clsPeriodoVM oPeriodoVM, Boolean editing) {

            if (editing){
                oPeriodo.VM.PeriodoId = SysData.ToLong(oPeriodoVM.PeriodoId);
            }
                       
            oPeriodo.VM.GestionId = SysData.ToLong(oPeriodoVM.GestionId);
            oPeriodo.VM.MesId = SysData.ToLong(oPeriodoVM.MesId);
            oPeriodo.VM.PeriodoFecIni = SysData.ToDate(oPeriodoVM.PeriodoFecIni);
            oPeriodo.VM.PeriodoFecFin = SysData.ToDate(oPeriodoVM.PeriodoFecFin);
            oPeriodo.VM.EstadoId = SysData.ToLong(oPeriodoVM.EstadoId);
        }

        private clsPeriodoVM PeriodoFind(int periodoId)
        {
            clsPeriodo oPeriodo = new clsPeriodo(clsAppInfo.Connection);
            clsPeriodoVM oPeriodoVM = new clsPeriodoVM();

            try
            {
                oPeriodo.VM.PeriodoId = periodoId;

                if (oPeriodo.FindByPK()) {
                    oPeriodoVM = oPeriodo.VM;
                }

            }
            catch(Exception exp)
            {
                throw exp;
            }
            finally {
                oPeriodo.Dispose();
            }
            return oPeriodoVM;

        }


        private List<clsPeriodoVM> PeriodoList()
        {
            clsPeriodo oPeriodo = new clsPeriodo(clsAppInfo.Connection);
            List<clsPeriodoVM> oPeriodoVM = new List<clsPeriodoVM>();



            try
            {
                oPeriodo.SelectFilter = clsPeriodo.SelectFilters.Grid;
                oPeriodo.WhereFilter = clsPeriodo.WhereFilters.Grid;
                oPeriodo.OrderByFilter = clsPeriodo.OrderByFilters.Grid;

                if (oPeriodo.Open())
                {
                    foreach (DataRow dr in oPeriodo.DataSet.Tables[oPeriodo.TableName].Rows)
                    {
                        oPeriodoVM.Add(new clsPeriodoVM()
                        {
                            PeriodoId = SysData.ToLong(dr[clsPeriodoVM._PeriodoId]),
                            GestionNro = SysData.ToStr(dr[clsPeriodoVM._GestionNro]),
                            MesDes = SysData.ToStr(dr[clsPeriodoVM._MesDes]),
                            PeriodoFecIni = SysData.ToDate(dr[clsPeriodoVM._PeriodoFecIni]),
                            PeriodoFecFin = SysData.ToDate(dr[clsPeriodoVM._PeriodoFecFin]),
                            EstadoDes = SysData.ToStr(dr[clsPeriodoVM._EstadoDes])
                        });
                    }
                }

                return oPeriodoVM;

            }
            catch (Exception exp)
            {
                throw exp;

            }
            finally
            {
                oPeriodo.Dispose();
            }
            return oPeriodoVM;
        }

       

        }
}

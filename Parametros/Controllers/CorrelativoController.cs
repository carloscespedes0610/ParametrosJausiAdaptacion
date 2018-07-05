using Parametros.Models.DAC;
using Parametros.Models.Modules;
using Parametros.Models.VM;
using Seguridad.Controllers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Parametros.Controllers
{
    [SessionExpireFilter]
    public class CorrelativoController : Controller
    {
        // GET: Correlativo
        public ActionResult Index()
        {
            try
            {
                this.GetDefaultData();
                var PrefijoList = Correlativos();
                return View(PrefijoList);
            }

            catch (Exception exp)
            {
                return RedirectToAction("httpErrorMsg", "Error", new { MessageErr = exp.Message });
            }
        }

        

        // GET: Correlativo/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                this.GetDefaultData();

                if (ReferenceEquals(id, null))
                {
                    return RedirectToAction("httpErrorMsg", "Error", new { MessageErr = "Índice nulo o no encontrado" });
                }

                clsCorrelativoVM oCorrelativoVM = CorrelativoFind(Convert.ToInt32(id));

                if (ReferenceEquals(oCorrelativoVM, null))
                {
                    return RedirectToAction("httpErrorMsg", "Error", new { MessageErr = "Índice no encontrado" });
                }


                return View(oCorrelativoVM);
            }

            catch (Exception exp)
            {
                return RedirectToAction("httpErrorMsg", "Error", new { MessageErr = exp.Message });
            }
        }

        

        // GET: Correlativo/Create
        public ActionResult Create()
        {

            clsCorrelativoVM oCorrelativoVm = new clsCorrelativoVM();

            try
            {
                this.GetDefaultData();
                oCorrelativoVm.CorreNroMax = 99999;
                oCorrelativoVm.CorreNroAct = 0;
                
                ViewBagLoad();
                return View(oCorrelativoVm);
            }

            catch (Exception exp)
            {
                return RedirectToAction("httpErrorMsg", "Error", new { MessageErr = exp.Message });
            }
        }

        
        // POST: Correlativo/Create
        [HttpPost]
        public ActionResult Create(clsCorrelativoVM oCorrelativoVm)
        {
            try
            {
                if (ModelState.IsValid) {
                    clsCorrelativo oCorrelativo = new clsCorrelativo(clsAppInfo.Connection);
                    DataMove(oCorrelativo, oCorrelativoVm, false);
                    if (oCorrelativo.Insert())
                    {
                        return RedirectToAction("Index");
                    }
                }
                ViewBagLoad();
                return View(oCorrelativoVm);
               
            }
            catch(Exception ex)
            {
                return RedirectToAction("httpErrorMsg", "Error", new { MessageErr = ex.Message });

            }
        }

        

        // GET: Correlativo/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                this.GetDefaultData();
                if (ReferenceEquals(id, null))
                {
                    return RedirectToAction("httpErrorMsg", "Error", new { MessageErr = "Índice nulo o no encontrado" });
                }

                clsCorrelativoVM oCorrelativoVm = CorrelativoFind(Convert.ToInt32(id));

                if (ReferenceEquals(oCorrelativoVm, null))
                {
                    return RedirectToAction("httpErrorMsg", "Error", new { MessageErr = "Índice no encontrado" });
                }

                ViewBagLoad();
                return View(oCorrelativoVm);
            }
            catch (Exception exp)
            {
                return RedirectToAction("httpErrorMsg", "Error", new { MessageErr = exp.Message });
            }
        }

        // POST: Correlativo/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken()]
        public ActionResult Edit(clsCorrelativoVM oCorrelativoVm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    clsCorrelativo oCorrelativo = new clsCorrelativo(clsAppInfo.Connection);
                    DataMove(oCorrelativo, oCorrelativoVm, true);
                    if (oCorrelativo.Update())
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ViewBag.MessageErr = resources.Resources.NoActualizado;
                    }
                }
                ViewBagLoad();
                return View(oCorrelativoVm);
            }
            catch(Exception ex)
            {
                return RedirectToAction("httpErrorMsg", "Error", new { MessageErr = ex.Message }); ;
            }
        }

        // GET: Correlativo/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                this.GetDefaultData();

                if (ReferenceEquals(id, null))
                {
                    return RedirectToAction("httpErrorMsg", "Error", new { MessageErr = resources.Resources.IndiceNulo });
                }

                clsCorrelativoVM oCorrelativoVm = CorrelativoFind(Convert.ToInt32(id));

                if (ReferenceEquals(oCorrelativoVm, null))
                {
                    ViewBag.Mesagge = resources.Resources.ObjetoNoEncontrado;
                }

                ViewBagLoad();
                return View(oCorrelativoVm);
            }

            catch (Exception exp)
            {
                return RedirectToAction("httpErrorMsg", "Error", new { MessageErr = exp.Message });
            }
        }

        // POST: Correlativo/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken()]
        public ActionResult DeleteConfirmed(int? id)
        {
            try
            {
                if (ReferenceEquals(id, null))
                {
                    return RedirectToAction("httpErrorMsg", "Error", new { MessageErr = resources.Resources.IndiceNulo });
                }

                clsCorrelativo oCorrelativo = new clsCorrelativo(clsAppInfo.Connection);

                oCorrelativo.WhereFilter = clsCorrelativo.WhereFilters.PrimaryKey;
                oCorrelativo.CorreId = Convert.ToInt32(id);

                if (oCorrelativo.Delete())
                {
                    return RedirectToAction("Index");
                }

                ViewBagLoad();
                clsCorrelativoVM oCorrelativoVm = CorrelativoFind(Convert.ToInt32(id));
                return View(oCorrelativoVm);
            }

            catch (Exception exp)
            {
                return RedirectToAction("httpErrorMsg", "Error", new { MessageErr = exp.Message });
            }
        }


        // POST: Correlativo/GenerarCorrelativo/5 
       [HttpPost]
        public ActionResult GenerarCorrelativo(int tipo, int prefijo ,int gestion)
        {
            clsPrefijo oPrefijo = new clsPrefijo(clsAppInfo.Connection);
            try
            {
                clsCorrelativo oCorrelativo = new clsCorrelativo(clsAppInfo.Connection);
                clsPrefijo oPrefijoSel= PrefijoFind(prefijo);                
                clsGestionVM oGestion= GestionFind(gestion);

                if (tipo == TipoCorrelativo.Anual)
                {

                    oCorrelativo = new clsCorrelativo(clsAppInfo.Connection);                   

                    DataMoveCorrelativ(oCorrelativo, oPrefijoSel, oGestion);

                    if (oCorrelativo.Insert())
                    {
                        return Content("ok");
                    }
                }
                else if (tipo == TipoCorrelativo.Periodo)
                {
                    int maxPrefijoNro = oPrefijoSel.PrefijoNro;
                    if (ExistePrefijo(maxPrefijoNro + 1)){
                        return Content("El Prefijo nro " + (maxPrefijoNro+1)+" ya existe");
                    }
                    
                    List<clsPeriodoVM> periodoList = PeriodoList(oGestion.GestionId);
                    if (periodoList.Count ==0 ) {
                        return Content(resources.Resources.GestionSinPeriodo);
                    }

                    // para el primer periodo de la gestion
                    clsPeriodoVM firtP = periodoList[0];
                    periodoList.RemoveAt(0);
                    int inserted = 0;
                   
                    DataMovePref(oPrefijo, oPrefijoSel, firtP.MesDes);
                    oPrefijo.PrefijoId = oPrefijoSel.PrefijoId;
                    oPrefijo.BeginTransaction();
                   
                    if (oPrefijo.Update()) {
                        oCorrelativo.Transaction = oPrefijo.Transaction;
                        oGestion.GestionFecIni = firtP.PeriodoFecIni;
                        oGestion.GestionFecFin = firtP.PeriodoFecFin;
                        DataMoveCorrelativ(oCorrelativo, oPrefijo, oGestion);
                        if (oCorrelativo.Insert()) {
                            inserted++;
                        }

                        //los demas
                        foreach (clsPeriodoVM periodo in periodoList)
                        {
                            DataMovePref(oPrefijo, oPrefijoSel, periodo.MesDes);
                            maxPrefijoNro = maxPrefijoNro + 1;
                            oPrefijo.PrefijoNro = maxPrefijoNro ;
                            if (oPrefijo.Insert()) {
                                oGestion.GestionFecIni = periodo.PeriodoFecIni;
                                oGestion.GestionFecFin = periodo.PeriodoFecFin;
                                
                                DataMoveCorrelativ(oCorrelativo, oPrefijo, oGestion);
                                oCorrelativo.PrefijoId = oPrefijo.Id;
                                if (oCorrelativo.Insert())
                                {
                                    inserted++;
                                }
                            }
                        }
                        if (inserted == periodoList.Count + 1) {
                            oPrefijo.Commit();
                            return Content("ok");
                        }
                    }
                    oPrefijo.Rollback();                
                                   
                }
                    

                return RedirectToAction("Index");
            }
            catch(Exception exp)
            {
                oPrefijo.Rollback();
                return Content(exp.Message);              
                
            }
        }



        //-----------------------------------------------------

        private void DataMove(clsCorrelativo oCorrelativo, clsCorrelativoVM oCorrelativoVm, bool editing)
        {
            if (editing) {
                oCorrelativo.CorreId = oCorrelativoVm.CorreId;
            }
            oCorrelativo.PrefijoId = SysData.ToLong(oCorrelativoVm.PrefijoId);
            oCorrelativo.GestionId = SysData.ToLong(oCorrelativoVm.GestionId);
            oCorrelativo.ModuloId = SysData.ToLong(oCorrelativoVm.ModuloId);
            oCorrelativo.AplicacionId = SysData.ToLong(oCorrelativoVm.AplicacionId);
            oCorrelativo.DocId = SysData.ToLong(oCorrelativoVm.DocId);
            oCorrelativo.CorreNroAct = SysData.ToInteger(oCorrelativoVm.CorreNroAct);
            oCorrelativo.CorreNroMax = SysData.ToInteger(oCorrelativoVm.CorreNroMax);
            oCorrelativo.FecIni = SysData.ToDate(oCorrelativoVm.FecIni);
            oCorrelativo.FecFin = SysData.ToDate(oCorrelativo.FecFin);
        }

        private void ViewBagLoad()
        {
           ViewBag.PrefijoId= PrefijoList();
            ViewBag.GestionId = ComboBox.GestionList();
        }

        private List<clsPrefijoVM> PrefijoList()
        {
            clsPrefijo oPrefijo = new clsPrefijo(clsAppInfo.Connection);
            List<clsPrefijoVM> oPrefijoVM = new List<clsPrefijoVM>();

            try
            {
                oPrefijo.SelectFilter = clsPrefijo.SelectFilters.Grid;
                oPrefijo.WhereFilter = clsPrefijo.WhereFilters.Grid;
                oPrefijo.OrderByFilter = clsPrefijo.OrderByFilters.Grid;

                if (oPrefijo.Open())
                {

                    foreach (DataRow dr in oPrefijo.DataSet.Tables[oPrefijo.TableName].Rows)
                    {
                        oPrefijoVM.Add(new clsPrefijoVM()
                        {
                            PrefijoId = SysData.ToLong(dr["PrefijoId"]),
                            DocId = SysData.ToLong(dr["DocId"]),
                            DocNemonico = SysData.ToStr(dr["DocNem"]),
                            DocDes = SysData.ToStr(dr["DocDes"]),
                            ModuloId = SysData.ToLong(dr["ModuloId"]),
                            ModuloDes = SysData.ToStr(dr["ModuloDes"]),
                            AplicacionId = SysData.ToLong(dr["AplicacionId"]),
                            AplicacionDes = SysData.ToStr(dr["AplicacionDes"]),
                            PrefijoDes = SysData.ToStr(dr["PrefijoDes"]),
                            PrefijoNro = SysData.ToInteger(dr["PrefijoNro"])
                            
                        });
                    }
                }

                return oPrefijoVM;

            }
            catch (Exception exp)
            {
                throw exp;

            }
            finally
            {
                oPrefijo.Dispose();
            }
            return oPrefijoVM;
        }

        private clsCorrelativoVM CorrelativoFind(int correlativoId)
        {
            clsCorrelativo oCorrelativo = new clsCorrelativo(clsAppInfo.Connection);
          
            clsCorrelativoVM oCorrelativoVm = new clsCorrelativoVM();

            try
            {
                oCorrelativo.SelectFilter = clsCorrelativo.SelectFilters.All;
                oCorrelativo.WhereFilter = clsCorrelativo.WhereFilters.Details;
                oCorrelativo.CorreId = correlativoId;

                if (oCorrelativo.Open())
                {
                    DataRow dr = oCorrelativo.DataSet.Tables[oCorrelativo.TableName].Rows[0];

                    oCorrelativoVm.CorreId = SysData.ToLong(dr["CorreId"]);
                    oCorrelativoVm.PrefijoId = SysData.ToInteger(dr["PrefijoId"]);
                    oCorrelativoVm.PrefijoNro = SysData.ToInteger(dr["PrefijoNro"]);
                    oCorrelativoVm.PrefijoDes = SysData.ToStr(dr["PrefijoDes"]);
                    oCorrelativoVm.DocId = SysData.ToLong(dr["DocId"]);
                    oCorrelativoVm.DocDes = SysData.ToStr(dr["DocDes"]);
                    oCorrelativoVm.ModuloId = SysData.ToLong(dr["ModuloId"]);
                    oCorrelativoVm.ModuloDes = SysData.ToStr(dr["ModuloDes"]);
                    oCorrelativoVm.AplicacionId = SysData.ToLong(dr["AplicacionId"]);
                    oCorrelativoVm.AplicacionDes = SysData.ToStr(dr["AplicacionDes"]);
                    oCorrelativoVm.CorreNroAct = SysData.ToInteger(dr["CorreNroAct"]);
                    oCorrelativoVm.CorreNroMax = SysData.ToInteger(dr["CorreNroMax"]);
                    oCorrelativoVm.FecIni = SysData.ToDate(dr["CorreFecIni"]);
                    oCorrelativoVm.FecFin = SysData.ToDate(dr["CorreFecFin"]);
                    oCorrelativoVm.GestionNro = SysData.ToInteger(dr["GestionNro"]);

                    return oCorrelativoVm;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally {
                oCorrelativo.Dispose();
            }

            return null;
        }


        private bool ExistePrefijo(int prefijoNro)
        {
            clsPrefijo oPrefijo = new clsPrefijo(clsAppInfo.Connection);

            try
            {
                oPrefijo.SelectFilter = clsPrefijo.SelectFilters.PrefijoNro;
                oPrefijo.WhereFilter = clsPrefijo.WhereFilters.PrefijoNro;
                oPrefijo.PrefijoNro = prefijoNro;
                return oPrefijo.Find();
               
            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                oPrefijo.Dispose();
            }
            return false;
        }

        private void DataMovePref(clsPrefijo oPrefijo, clsPrefijo oPrefijoSel, String mes)
        {
            oPrefijo.PrefijoId=oPrefijoSel.PrefijoId;
            oPrefijo.DocId = oPrefijoSel.DocId;
            oPrefijo.ModuloId = oPrefijoSel.ModuloId;
            oPrefijo.AplicacionId = oPrefijoSel.AplicacionId;
            oPrefijo.PrefijoNro = oPrefijoSel.PrefijoNro;
            oPrefijo.PrefijoDes = oPrefijoSel.PrefijoDes + " - " + mes;
            oPrefijo.PrefijoTipo = oPrefijoSel.PrefijoTipo;
            oPrefijo.PrefijoIniGes = oPrefijoSel.PrefijoIniGes;
            oPrefijo.FormatoImpId = oPrefijoSel.FormatoImpId;
            oPrefijo.MensajeFor = oPrefijoSel.MensajeFor;
            oPrefijo.PrefijoCopiaId = oPrefijoSel.PrefijoCopiaId;
            oPrefijo.ImprimeUsr = oPrefijoSel.ImprimeUsr;
            oPrefijo.ImprimeFec = oPrefijoSel.ImprimeFec;
            oPrefijo.TipoEncabezadoId = oPrefijoSel.TipoEncabezadoId;
            oPrefijo.RazonSoc = oPrefijoSel.RazonSoc;
            oPrefijo.RazonSocAbr = oPrefijoSel.RazonSocAbr;
            oPrefijo.ObsUno = oPrefijoSel.ObsUno;
            oPrefijo.ObsDos = oPrefijoSel.ObsDos;
            oPrefijo.FirmaUno = oPrefijoSel.FirmaUno;
            oPrefijo.FirmaSeg = oPrefijoSel.FirmaSeg;
            oPrefijo.FirmaTre = oPrefijoSel.FirmaTre;
            oPrefijo.FirmaCua = oPrefijoSel.FirmaCua;
            oPrefijo.EstadoId = oPrefijoSel.EstadoId;

        }

        private void DataMoveCorrelativ(clsCorrelativo oCorrelativo, clsPrefijo oPrefijo, clsGestionVM oGestion)
        {
            oCorrelativo.DocId = SysData.ToLong(oPrefijo.DocId);
            oCorrelativo.PrefijoId = SysData.ToLong(oPrefijo.PrefijoId);
            oCorrelativo.GestionId = SysData.ToLong(oGestion.GestionId);
            oCorrelativo.ModuloId = SysData.ToLong(oPrefijo.ModuloId);
            oCorrelativo.AplicacionId = SysData.ToLong(oPrefijo.AplicacionId);
            oCorrelativo.CorreNroAct = 0;
            oCorrelativo.CorreNroMax = 99999;
            oCorrelativo.FecIni = SysData.ToDate(oGestion.GestionFecIni);
            oCorrelativo.FecFin = SysData.ToDate(oGestion.GestionFecFin);
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
                    return oGestion.VM;
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

        private clsPrefijo PrefijoFind(int prefijoId)
        {
            clsPrefijo oPrefijo = new clsPrefijo(clsAppInfo.Connection);
           
            try
            {
                oPrefijo.SelectFilter = clsPrefijo.SelectFilters.All;
                oPrefijo.WhereFilter = clsPrefijo.WhereFilters.PrimaryKey;
                oPrefijo.PrefijoId = prefijoId;
                if (oPrefijo.FindByPK())
                {
                    return oPrefijo;                    
                }                
            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                oPrefijo.Dispose();
            }
            return oPrefijo;
        }


        private object Correlativos()
        {
            clsCorrelativo oCorrelativo = new clsCorrelativo(clsAppInfo.Connection);
            List<clsCorrelativoVM> oCorrelativoVM = new List<clsCorrelativoVM>();

            try
            {
                oCorrelativo.SelectFilter = clsCorrelativo.SelectFilters.Grid;
                oCorrelativo.WhereFilter = clsCorrelativo.WhereFilters.Grid;
                oCorrelativo.OrderByFilter = clsCorrelativo.OrderByFilters.Grid;

                if (oCorrelativo.Open())
                {

                    foreach (DataRow dr in oCorrelativo.DataSet.Tables[oCorrelativo.TableName].Rows)
                    {
                        oCorrelativoVM.Add(new clsCorrelativoVM()
                        {
                            CorreId = SysData.ToLong(dr["CorreId"]),
                            PrefijoId = SysData.ToLong(dr["PrefijoId"]),
                            PrefijoDes = SysData.ToStr(dr["PrefijoDes"]),
                            DocId = SysData.ToLong(dr["DocId"]),
                            DocDes = SysData.ToStr(dr["DocDes"]),
                            ModuloId = SysData.ToLong(dr["ModuloId"]),
                            ModuloDes = SysData.ToStr(dr["ModuloDes"]),
                            AplicacionId = SysData.ToLong(dr["AplicacionId"]),
                            AplicacionDes = SysData.ToStr(dr["AplicacionDes"]),
                            CorreNroAct = SysData.ToInteger(dr["CorreNroAct"]),                           
                            CorreNroMax = SysData.ToInteger(dr["CorreNroMax"]),
                            FecIni=SysData.ToDate(dr["CorreFecIni"]),
                            FecFin = SysData.ToDate(dr["CorreFecFin"]),
                            GestionNro = SysData.ToInteger(dr["GestionNro"])
                        });
                    }
                }

                return oCorrelativoVM;

            }
            catch (Exception exp)
            {
                throw exp;

            }
            finally
            {
                oCorrelativo.Dispose();
            }
            return oCorrelativoVM;
        }

        private List<clsPeriodoVM> PeriodoList(long gestionId)
        {
            clsPeriodo oPeriodo = new clsPeriodo(clsAppInfo.Connection);
            List<clsPeriodoVM> periodos = new List<clsPeriodoVM>();

            try
            {
                oPeriodo.SelectFilter = clsPeriodo.SelectFilters.All;
                oPeriodo.WhereFilter = clsPeriodo.WhereFilters.Gestion;
                oPeriodo.VM.GestionId = gestionId;

                if (oPeriodo.Open())
                {
                    foreach (DataRow dr in oPeriodo.DataSet.Tables[oPeriodo.TableName].Rows)
                    {
                        periodos.Add(new clsPeriodoVM()
                        {
                            PeriodoId = SysData.ToLong(dr["PeriodoId"]),
                            GestionId = SysData.ToInteger(dr["GestionId"]),
                            MesId = SysData.ToLong(dr["MesId"]),
                            MesDes = SysData.ToStr(dr["MesDes"]),
                            PeriodoFecIni = SysData.ToDate(dr["PeriodoFecIni"]),
                            PeriodoFecFin = SysData.ToDate(dr["PeriodoFecFin"]),
                            EstadoId = SysData.ToLong(dr["EstadoId"])
                        });                      

                    }
                  
                }

                

            }
            catch (Exception exp)
            {
                throw exp;

            }
            finally
            {
                oPeriodo.Dispose();
            }
            return periodos;
        }

    }
}

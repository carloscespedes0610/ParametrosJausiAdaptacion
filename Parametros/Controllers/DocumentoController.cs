using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Parametros.Models.DAC;
using Parametros.Models.Modules;
using Parametros.Models.VM;
using Seguridad.Controllers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Web.Mvc;
using static Parametros.Models.DAC.clsAppInfo;

namespace Parametros.Controllers
{
    [SessionExpireFilter]
    public class DocumentoController : Controller
    {
        // GET: Documento
        public ActionResult Index()
        {
            try
            {
                this.GetDefaultData();
                var DocList = Documentos();
                return View(DocList);
            }

            catch (Exception exp)
            {
                return RedirectToAction("httpErrorMsg", "Error", new { MessageErr = exp.Message });
            }
        }

       

        // GET: Documento/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                this.GetDefaultData();

                if (ReferenceEquals(id, null))
                {
                    return RedirectToAction("httpErrorMsg", "Error", new { MessageErr = "Índice nulo o no encontrado" });
                }

                clsDocumentoVM oDocVM = DocumentoFind(Convert.ToInt32(id));

                if (ReferenceEquals(oDocVM, null))
                {
                    return RedirectToAction("httpErrorMsg", "Error", new { MessageErr = "Índice no encontrado" });
                }

                ViewBagLoad();
                return View(oDocVM);
            }

            catch (Exception exp)
            {
                return RedirectToAction("httpErrorMsg", "Error", new { MessageErr = exp.Message });
            }
        }

        // GET: Documento/Create
        public ActionResult Create()
        {
            try
            {
                clsDocumentoVM docVm = new clsDocumentoVM();
                docVm.EstadoId = ConstEstado.Activo;
                this.GetDefaultData();
                ViewBagLoad();
                return View(docVm);
            }
            catch (Exception e)
            {
                return RedirectToAction("httpErrorMsg", "Error", new { MessageErr = e.Message });
            }
        }

        // POST: Documento/Create
        [HttpPost]
        [ValidateAntiForgeryToken()]
        public ActionResult Create(clsDocumentoVM oDocVM)
        {
            try
            {
                if (ModelState.IsValid) {
                    clsDocumento oDocumento = new clsDocumento(clsAppInfo.Connection);

                    DataMove(oDocumento, oDocVM, false);
                    
                    if (oDocumento.Insert()) {
                        return RedirectToAction("Index");
                    }
                    
                }
                ViewBagLoad();
                return View(oDocVM);
            }
            catch (Exception ex) {
                return RedirectToAction("httpErrorMsg", "Error", new { MessageErr = ex.Message });
            }
          
            
        }

       



        // GET: Documento/Edit/5
        public ActionResult Edit(int? id)
        {
            try
            {
                this.GetDefaultData();
                if (ReferenceEquals(id, null))
                {
                    return RedirectToAction("httpErrorMsg", "Error", new { MessageErr = "Índice nulo o no encontrado" });
                }

                clsDocumentoVM oDocumentoVM = DocumentoFind(Convert.ToInt32(id));

                if (ReferenceEquals(oDocumentoVM, null))
                {
                    return RedirectToAction("httpErrorMsg", "Error", new { MessageErr = "Índice no encontrado" });
                }

                ViewBagLoad();
                return View(oDocumentoVM);
            }
            catch(Exception exp) {
                return RedirectToAction("httpErrorMsg", "Error", new { MessageErr = exp.Message });
            }
        }

        

        // POST: Documento/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken()]
        public ActionResult Edit(clsDocumentoVM oDocVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    clsDocumento oDocumento = new clsDocumento(clsAppInfo.Connection);
                    DataMove(oDocumento, oDocVM, true);
                    if (oDocumento.Update()) {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ViewBag.MessageErr = resources.Resources.NoActualizado;
                    }
                }
                ViewBagLoad();
                return View(oDocVM);
            }
            catch
            {
                return View();
            }
        }

        // GET: Documento/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                this.GetDefaultData();

                if (ReferenceEquals(id, null))
                {
                    return RedirectToAction("httpErrorMsg", "Error", new { MessageErr = resources.Resources.IndiceNulo });
                }

                clsDocumentoVM oDocVM = DocumentoFind(Convert.ToInt32(id));

                if (ReferenceEquals(oDocVM, null))
                {
                    ViewBag.Mesagge = resources.Resources.ObjetoNoEncontrado;
                }

                ViewBagLoad();
                return View(oDocVM);
            }

            catch (Exception exp)
            {
                return RedirectToAction("httpErrorMsg", "Error", new { MessageErr = exp.Message });
            }
        }

        // POST: Documento/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken()]
        public ActionResult DeleteConfirmed(int?  DocId)
        {
            try
            {
                if (ReferenceEquals(DocId, null))
                {
                    return RedirectToAction("httpErrorMsg", "Error", new { MessageErr = resources.Resources.IndiceNulo });
                }

                clsDocumento oDocumento = new clsDocumento(clsAppInfo.Connection);

                oDocumento.WhereFilter = clsDocumento.WhereFilters.PrimaryKey;
                oDocumento.VM.DocId = Convert.ToInt32(DocId);

                if (oDocumento.Delete())
                {
                    return RedirectToAction("Index");
                }

                ViewBagLoad();
                clsDocumentoVM oDocVM = DocumentoFind(Convert.ToInt32(DocId));
                return View(oDocVM);
            }

            catch (Exception exp)
            {
                return RedirectToAction("httpErrorMsg", "Error", new { MessageErr = exp.Message });
            }
        }



        //-----------------------------------------
        // Modificado por Carlos:
        private clsDocumentoVM DocumentoFind(int DocId)
        {
            clsDocumento oDocumento = new clsDocumento(clsAppInfo.Connection);
            clsDocumentoVM oDocumentoVM = new clsDocumentoVM();

            try
            {
                oDocumento.VM.DocId = DocId;
                if (oDocumento.FindByPK())
                {
                    oDocumentoVM.DocId = SysData.ToLong(oDocumento.VM.DocId);
                    oDocumentoVM.DocCod = SysData.ToStr(oDocumento.VM.DocCod);
                    oDocumentoVM.DocNem = SysData.ToStr(oDocumento.VM.DocNem);
                    oDocumentoVM.DocDes = SysData.ToStr(oDocumento.VM.DocDes);
                    oDocumentoVM.DocIso = SysData.ToStr(oDocumento.VM.DocIso);
                    oDocumentoVM.DocRev = SysData.ToStr(oDocumento.VM.DocRev);
                    oDocumentoVM.DocFec = SysData.ToDateTime(oDocumento.VM.DocFec);
                    oDocumentoVM.AplicacionId = SysData.ToLong(oDocumento.VM.AplicacionId);
                    oDocumentoVM.ModuloId = SysData.ToLong(oDocumento.VM.ModuloId);
                    oDocumentoVM.EstadoId = SysData.ToLong(oDocumento.VM.EstadoId);
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally {
                oDocumento.Dispose();
            }
            return oDocumentoVM;
        }

        // Modificado por Carlos:
        private void DataMove(clsDocumento oDocumento, clsDocumentoVM oDocVM, bool editing)
        {

            if (editing) {
                oDocumento.VM.DocId = SysData.ToLong(oDocVM.DocId);
            }

            oDocumento.VM.DocCod = SysData.ToStr(oDocVM.DocCod);
            oDocumento.VM.DocNem = SysData.ToStr(oDocVM.DocNem);
            oDocumento.VM.DocDes = SysData.ToStr(oDocVM.DocDes);
            oDocumento.VM.DocIso = SysData.ToStr(oDocVM.DocIso);
            oDocumento.VM.DocRev = SysData.ToStr(oDocVM.DocRev);
            oDocumento.VM.DocFec = SysData.ToDateTime(oDocVM.DocFec);
            oDocumento.VM.AplicacionId = SysData.ToLong(oDocVM.AplicacionId);
            oDocumento.VM.ModuloId = SysData.ToLong(oDocVM.ModuloId);
            oDocumento.VM.EstadoId = SysData.ToLong(oDocVM.EstadoId);
        }


        private void ViewBagLoad()
        {
         
            ViewBag.AplicacionId = AplicacionList();
            ViewBag.ModuloId = ModuloList();
            ViewBag.EstadoId = ComboBox.EstadoList();
        }

        private IEnumerable<clsModuloVM> ModuloList()
        {
            clsModulo oModulo = new clsModulo(clsAppInfo.Connection);
            List<clsModuloVM> oModVM = new List<clsModuloVM>();


            try
            {
                oModulo.SelectFilter = clsModulo.SelectFilters.Grid;
                oModulo.WhereFilter = clsModulo.WhereFilters.Grid;
                oModulo.OrderByFilter = clsModulo.OrderByFilters.Grid;

                if (oModulo.Open())
                {

                    foreach (DataRow dr in oModulo.DataSet.Tables[oModulo.TableName].Rows)
                    {
                        oModVM.Add(new clsModuloVM()                        {
                            ModuloId = SysData.ToLong(dr[clsModuloVM._ModuloId]),
                            ModuloDes = SysData.ToStr(dr[clsModuloVM._ModuloDes])
                        });
                    }
                }

                return oModVM;

            }
            catch (Exception exp)
            {
                throw exp;

            }
            finally
            {
                oModulo.Dispose();
            }
            return ((IEnumerable<clsModuloVM>)oModVM);
        }

        private List<clsAplicacionVM> AplicacionList()
        {
            clsAplicacion oAplicacion = new clsAplicacion(clsAppInfo.Connection);
            List<clsAplicacionVM> oAppVM = new List<clsAplicacionVM>();


            try
            {
                oAplicacion.SelectFilter = clsAplicacion.SelectFilters.Grid;
                oAplicacion.WhereFilter = clsAplicacion.WhereFilters.Grid;
                oAplicacion.OrderByFilter = clsAplicacion.OrderByFilters.Grid;

                if (oAplicacion.Open())
                {

                    foreach (DataRow dr in oAplicacion.DataSet.Tables[oAplicacion.TableName].Rows)
                    {
                        oAppVM.Add(new clsAplicacionVM()
                        {
                            AplicacionId = SysData.ToLong(dr[clsAplicacionVM._AplicacionId]),
                            AplicacionDes = SysData.ToStr(dr[clsAplicacionVM._AplicacionDes]),
                            ModuloId = SysData.ToLong(dr[clsModuloVM._ModuloId])
                        });
                    }
                }

                return oAppVM;

            }
            catch (Exception exp)
            {
                throw exp;

            }
            finally
            {
                oAplicacion.Dispose();
            }
            return oAppVM;
        }

        // Modificado por Carlos:
        private object Documentos()
        {
            clsDocumento oDocumento = new clsDocumento(clsAppInfo.Connection);
            List<clsDocumentoVM> oDocVM = new List<clsDocumentoVM>();
            

            try
            {
                oDocumento.SelectFilter = clsDocumento.SelectFilters.Grid;
                oDocumento.WhereFilter = clsDocumento.WhereFilters.Grid;
                oDocumento.OrderByFilter = clsDocumento.OrderByFilters.Grid;

                if (oDocumento.Open())
                {

                    foreach (DataRow dr in oDocumento.DataSet.Tables[oDocumento.TableName].Rows)
                    {
                        oDocVM.Add(new clsDocumentoVM()
                        {
                            DocId = SysData.ToLong(dr[clsDocumentoVM._DocId]),
                            DocCod = SysData.ToStr(dr[clsDocumentoVM._DocCod]),
                            DocNem = SysData.ToStr(dr[clsDocumentoVM._DocNem]),
                            DocDes = SysData.ToStr(dr[clsDocumentoVM._DocDes]),
                            DocIso = SysData.ToStr(dr[clsDocumentoVM._DocCod]),
                            DocRev = SysData.ToStr(dr[clsDocumentoVM._DocRev]),
                            DocFec = SysData.ToDateTime(dr[clsDocumentoVM._DocRev]),
                            ModuloDes = SysData.ToStr(dr[clsDocumentoVM._ModuloDes]),
                            AplicacionDes = SysData.ToStr(dr[clsDocumentoVM._AplicacionDes]),
                            EstadoDes = SysData.ToStr(dr[clsDocumentoVM._EstadoDes])
                        });
                    }
                }

                return oDocVM;

            }
            catch (Exception exp)
            {
                throw exp;

            }
            finally
            {
                oDocumento.Dispose();
            }
            return oDocVM;
        }
    }
}

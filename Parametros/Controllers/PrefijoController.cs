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
{   [SessionExpireFilter]
    public class PrefijoController : Controller
    {
        // GET: Prefijo
        public ActionResult Index()
        {
            try
            {
                this.GetDefaultData();
                ViewBag.GestionId = ComboBox.GestionList();
                var PrefijoList = Prefijos();
                return View(PrefijoList);
            }

            catch (Exception exp)
            {
                return RedirectToAction("httpErrorMsg", "Error", new { MessageErr = exp.Message });
            }
        }

       

        // GET: Prefijo/Details/5
        public ActionResult Details(int? id)
        {
            try
            {
                this.GetDefaultData();

                if (ReferenceEquals(id, null))
                {
                    return RedirectToAction("httpErrorMsg", "Error", new { MessageErr = "Índice nulo o no encontrado" });
                }

                clsPrefijoVM oPrefijoVM = PrefijoFind(Convert.ToInt32(id));

                if (ReferenceEquals(oPrefijoVM, null))
                {
                    return RedirectToAction("httpErrorMsg", "Error", new { MessageErr = "Índice no encontrado" });
                }

               
                return View(oPrefijoVM);
            }

            catch (Exception exp)
            {
                return RedirectToAction("httpErrorMsg", "Error", new { MessageErr = exp.Message });
            }
        }

        // GET: Prefijo/Create
        public ActionResult Create()
        {
            try
            {
                this.GetDefaultData();

                clsPrefijoVM oPrefijo = new clsPrefijoVM();
                oPrefijo.EstadoId = ConstEstado.Activo;
                oPrefijo.ItemMax = 99;
                oPrefijo.PrefijoTipoId = 2;
                oPrefijo.PrefijoCopiaId = 1;
                oPrefijo.FormatoImpId = 1;
                oPrefijo.TipoEncabezadoId = 1;

                ViewBagLoad();
                return View(oPrefijo);
            }
            catch (Exception e)
            {
                return RedirectToAction("httpErrorMsg", "Error", new { MessageErr = e.Message });
            }
        }

        // POST: Prefijo/Create
        [HttpPost]
        [ValidateAntiForgeryToken()]
        public ActionResult Create(clsPrefijoVM oPrefijoVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    clsPrefijo oPrefijo = new clsPrefijo(clsAppInfo.Connection);

                    DataMove(oPrefijo, oPrefijoVM, false);

                    if (oPrefijo.Insert())
                    {
                        return RedirectToAction("Index");
                    }

                }
                ViewBagLoad();
                return View(oPrefijoVM);
            }
            catch (Exception ex)
            {
                return RedirectToAction("httpErrorMsg", "Error", new { MessageErr = ex.Message });
            }
        }

       
        
        // GET: Prefijo/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                this.GetDefaultData();
                if (ReferenceEquals(id, null))
                {
                    return RedirectToAction("httpErrorMsg", "Error", new { MessageErr = "Índice nulo o no encontrado" });
                }

                clsPrefijoVM oPrefijoVM = PrefijoFind(Convert.ToInt32(id));

                if (ReferenceEquals(oPrefijoVM, null))
                {
                    return RedirectToAction("httpErrorMsg", "Error", new { MessageErr = "Índice no encontrado" });
                }

                ViewBagLoad();
                return View(oPrefijoVM);
            }
            catch (Exception exp)
            {
                return RedirectToAction("httpErrorMsg", "Error", new { MessageErr = exp.Message });
            }
        }

        // POST: Prefijo/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken()]
        public ActionResult Edit(clsPrefijoVM  oPrefijoVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    clsPrefijo oPrefijo = new clsPrefijo(clsAppInfo.Connection);
                    DataMove(oPrefijo, oPrefijoVM, true);
                    if (oPrefijo.Update())
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ViewBag.MessageErr = resources.Resources.NoActualizado;
                    }
                }
                ViewBagLoad();
                return View(oPrefijoVM);
            }
            catch
            {
                return View();
            }
        }

        // GET: Prefijo/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                this.GetDefaultData();

                if (ReferenceEquals(id, null))
                {
                    return RedirectToAction("httpErrorMsg", "Error", new { MessageErr = resources.Resources.IndiceNulo });
                }

                clsPrefijoVM oPrefijoVM = PrefijoFind(Convert.ToInt32(id));

                if (ReferenceEquals(oPrefijoVM, null))
                {
                    ViewBag.Mesagge = resources.Resources.ObjetoNoEncontrado;
                }

                ViewBagLoad();
                return View(oPrefijoVM);
            }

            catch (Exception exp)
            {
                return RedirectToAction("httpErrorMsg", "Error", new { MessageErr = exp.Message });
            }
        }

        // POST: Prefijo/Delete/5
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

                clsPrefijo oPrefijo = new clsPrefijo(clsAppInfo.Connection);

                oPrefijo.WhereFilter = clsPrefijo.WhereFilters.PrimaryKey;
                oPrefijo.PrefijoId = Convert.ToInt32(id);

                if (oPrefijo.Delete())
                {
                    return RedirectToAction("Index");
                }

                ViewBagLoad();
                clsPrefijoVM oPrefijoVM = PrefijoFind(Convert.ToInt32(id));
                return View(oPrefijoVM);
            }

            catch (Exception exp)
            {
                return RedirectToAction("httpErrorMsg", "Error", new { MessageErr = exp.Message });
            }
        }

        // GET: Prefijo/Correlativo/5
        public ActionResult Correlativo(int id)
        {
            try
            {
                this.GetDefaultData();

                if (ReferenceEquals(id, null))
                {
                    return RedirectToAction("httpErrorMsg", "Error", new { MessageErr = resources.Resources.IndiceNulo });
                }

                clsPrefijoVM oPrefijoVM = PrefijoFind(Convert.ToInt32(id));

                if (ReferenceEquals(oPrefijoVM, null))
                {
                    ViewBag.Mesagge = resources.Resources.ObjetoNoEncontrado;
                }

                ViewBagLoad();
                return View(oPrefijoVM);
            }

            catch (Exception exp)
            {
                return RedirectToAction("httpErrorMsg", "Error", new { MessageErr = exp.Message });
            }
        }


        //--------------------------------------------------------------------------

        private void ViewBagLoad()
        {
            ViewBag.DocId = DocumentoLoad();
            
            ViewBag.PrefijoCopiaId = ComboBox.PrefijoCopiaList();
            ViewBag.FormatoImpId = FormatoImpLoad();

            ViewBag.PrefijoTipoId = ComboBox.PrefijoTipoList();
            ViewBag.TipoEncabezadoId = ComboBox.TipoEncabezadoList();
            ViewBag.EstadoId = ComboBox.EstadoList();
        }

        private void DataMove(clsPrefijo oPrefijo, clsPrefijoVM oPrefijoVM, bool editing)
        {
            if (editing)
            {
                oPrefijo.PrefijoId = oPrefijoVM.PrefijoId;
            }
            oPrefijo.DocId = SysData.ToLong(oPrefijoVM.DocId);
            oPrefijo.ModuloId = SysData.ToLong(oPrefijoVM.ModuloId);
            oPrefijo.AplicacionId = SysData.ToLong(oPrefijoVM.AplicacionId);
            oPrefijo.PrefijoNro = SysData.ToInteger(oPrefijoVM.PrefijoNro);
            oPrefijo.PrefijoDes = SysData.ToStr(oPrefijoVM.PrefijoDes);
            oPrefijo.PrefijoTipo = SysData.ToLong(oPrefijoVM.PrefijoTipoId);
            oPrefijo.PrefijoIniGes = SysData.ToBoolean(oPrefijoVM.PrefijoIniGes);
            oPrefijo.FormatoImpId = SysData.ToLong(oPrefijoVM.FormatoImpId);
            oPrefijo.MensajeFor = SysData.ToStr(oPrefijoVM.MensajeFor);
            oPrefijo.PrefijoCopiaId = SysData.ToInteger(oPrefijoVM.PrefijoCopiaId);
            oPrefijo.ItemMax = SysData.ToInteger(oPrefijoVM.ItemMax);
            oPrefijo.ImprimeUsr = SysData.ToBoolean(oPrefijoVM.ImprimeUsr);
            oPrefijo.ImprimeFec = SysData.ToBoolean(oPrefijoVM.ImprimeFec);
            oPrefijo.TipoEncabezadoId = SysData.ToLong(oPrefijoVM.TipoEncabezadoId);
            oPrefijo.RazonSoc = SysData.ToStr(oPrefijoVM.RazonSoc);
            oPrefijo.RazonSocAbr = SysData.ToStr(oPrefijoVM.RazonSocAbr);
            oPrefijo.ObsUno = SysData.ToStr(oPrefijoVM.ObsUno);
            oPrefijo.ObsDos = SysData.ToStr(oPrefijoVM.ObsDos);
            oPrefijo.FirmaUno = SysData.ToStr(oPrefijoVM.FirmaUno);
            oPrefijo.FirmaSeg = SysData.ToStr(oPrefijoVM.FirmaSeg);
            oPrefijo.FirmaTre = SysData.ToStr(oPrefijoVM.FirmaTre);
            oPrefijo.FirmaCua = SysData.ToStr(oPrefijoVM.FirmaCua);
            oPrefijo.EstadoId = SysData.ToLong(oPrefijoVM.EstadoId);
        }


        private List<clsFormatoImpVM> FormatoImpLoad()
        {
            clsFormatoImp oFormatoImp = new clsFormatoImp(clsAppInfo.Connection);
            List<clsFormatoImpVM> oFormatoImpVM = new List<clsFormatoImpVM>();


            try
            {
                oFormatoImp.SelectFilter = clsFormatoImp.SelectFilters.Grid;
                oFormatoImp.WhereFilter = clsFormatoImp.WhereFilters.Grid;
                oFormatoImp.OrderByFilter = clsFormatoImp.OrderByFilters.Grid;

                if (oFormatoImp.Open())
                {

                    foreach (DataRow dr in oFormatoImp.DataSet.Tables[oFormatoImp.TableName].Rows)
                    {
                        oFormatoImpVM.Add(new clsFormatoImpVM()
                        {
                            FormatoImpId = SysData.ToLong(dr["FormatoImpId"]),
                            FormatoImpDes = SysData.ToStr(dr["FormatoImpDes"])

                        });
                    }
                }

                return oFormatoImpVM;

            }
            catch (Exception exp)
            {
                throw exp;

            }
            finally
            {
                oFormatoImp.Dispose();
            }
            return oFormatoImpVM;
        }

        private IEnumerable<clsDocumentoVM> DocumentoLoad()
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
                            DocId = SysData.ToLong(dr["DocId"]),                                                      
                            DocDes = SysData.ToStr(dr["DocNem"])+" - "+ SysData.ToStr(dr["DocDes"]),
                            ModuloId =SysData.ToLong(dr["ModuloId"]),
                            ModuloDes=SysData.ToStr(dr["ModuloDes"]),
                            AplicacionId = SysData.ToLong(dr["AplicacionId"]),
                            AplicacionDes = SysData.ToStr(dr["AplicacionDes"])

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
            return ((IEnumerable<clsDocumentoVM>)oDocVM);
        }


        private clsPrefijoVM PrefijoFind(int PrefijoId)
        {
            clsPrefijo oPrefijo = new clsPrefijo(clsAppInfo.Connection);
            List<clsPrefijoVM> prefijoVMLst = new List<clsPrefijoVM>();
            clsPrefijoVM oPrefijoVm = new clsPrefijoVM();
            try
            {
                oPrefijo.SelectFilter = clsPrefijo.SelectFilters.All;
                oPrefijo.WhereFilter = clsPrefijo.WhereFilters.Details;
                oPrefijo.PrefijoId = PrefijoId;
                if (oPrefijo.Open())
                {

                    foreach (DataRow dr in oPrefijo.DataSet.Tables[oPrefijo.TableName].Rows)
                    {
                        prefijoVMLst.Add(new clsPrefijoVM()
                        {
                            PrefijoId = SysData.ToLong(dr["PrefijoId"]),
                            DocId = SysData.ToLong(dr["DocId"]),
                            DocNemonico = SysData.ToStr(dr["DocNem"]),
                            DocDes = SysData.ToStr(dr["DocDes"]),
                            ModuloId = SysData.ToLong(dr["ModuloId"]),
                            ModuloDes = SysData.ToStr(dr["ModuloDes"]),
                            AplicacionId = SysData.ToLong(dr["AplicacionId"]),
                            AplicacionDes=SysData.ToStr(dr["AplicacionDes"]),
                            PrefijoDes = SysData.ToStr(dr["PrefijoDes"]),
                            PrefijoNro = SysData.ToInteger(dr["PrefijoNro"]),
                            PrefijoTipoId = SysData.ToLong(dr["PrefijoTipo"]),
                            PrefijoTipoDes = SysData.ToStr(dr["PrefijoTipoDes"]),
                            PrefijoIniGes = SysData.ToBoolean(dr["PrefijoIniGes"]),
                            FormatoImpId = SysData.ToLong(dr["FormatoImpId"]),
                            FormatoImpDes = SysData.ToStr(dr["FormatoImpDes"]),
                            MensajeFor = SysData.ToStr(dr["MensajeFor"]),
                            PrefijoCopiaId = SysData.ToLong(dr["PrefijoCopiaId"]),
                            PrefijoCopiaDes = SysData.ToStr(dr["PrefijoCopiaDes"]),
                            ItemMax = SysData.ToInteger(dr["ItemMax"]),
                            ImprimeUsr = SysData.ToBoolean(dr["ImprimeUsr"]),
                            ImprimeFec = SysData.ToBoolean(dr["ImprimeFec"]),
                            TipoEncabezadoId = SysData.ToLong(dr["TipoEncabezadoId"]),
                            TipoEncabezadoDes = SysData.ToStr(dr["TipoEncabezadoDes"]),
                            RazonSoc = SysData.ToStr(dr["RazonSoc"]),
                            RazonSocAbr = SysData.ToStr(dr["RazonSocAbr"]),
                            ObsUno = SysData.ToStr(dr["ObsUno"]),
                            ObsDos = SysData.ToStr(dr["ObsDos"]),
                            FirmaUno = SysData.ToStr(dr["FirmaUno"]),
                            FirmaSeg = SysData.ToStr(dr["FirmaSeg"]),
                            FirmaTre = SysData.ToStr(dr["FirmaTre"]),
                            FirmaCua = SysData.ToStr(dr["FirmaCua"]),
                            EstadoId = SysData.ToLong(dr["EstadoId"]),
                            EstadoDes = SysData.ToStr(dr["EstadoDes"])
                        });
                    }
                }

                if (prefijoVMLst.Count > 0)
                {
                    oPrefijoVm = prefijoVMLst[0];
                }

                return oPrefijoVm;

            }
            catch (Exception exp)
            {
                throw exp;

            }
            finally
            {
                oPrefijo.Dispose();
            }
            return oPrefijoVm;
        }

        private List<clsPrefijoVM> Prefijos()
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
                            PrefijoDes= SysData.ToStr(dr["PrefijoDes"]),
                            PrefijoNro = SysData.ToInteger(dr["PrefijoNro"]),
                            PrefijoTipoId = SysData.ToLong(dr["PrefijoTipo"]),
                            PrefijoTipoDes= SysData.ToStr(dr["PrefijoTipoDes"]),
                            PrefijoIniGes = SysData.ToBoolean(dr["PrefijoIniGes"]),
                            FormatoImpId = SysData.ToLong(dr["FormatoImpId"]),
                            FormatoImpDes = SysData.ToStr(dr["FormatoImpDes"]),
                            MensajeFor = SysData.ToStr(dr["MensajeFor"]),
                            PrefijoCopiaId=SysData.ToLong(dr["PrefijoCopiaId"]),
                            PrefijoCopiaDes=SysData.ToStr(dr["PrefijoCopiaDes"]),
                            ItemMax = SysData.ToInteger(dr["ItemMax"]),
                            ImprimeUsr = SysData.ToBoolean(dr["ImprimeUsr"]),
                            ImprimeFec = SysData.ToBoolean(dr["ImprimeFec"]),
                            TipoEncabezadoId = SysData.ToLong(dr["TipoEncabezadoId"]),
                            TipoEncabezadoDes = SysData.ToStr(dr["TipoEncabezadoDes"]),
                            RazonSoc = SysData.ToStr(dr["RazonSoc"]),
                            RazonSocAbr = SysData.ToStr(dr["RazonSocAbr"]),
                            ObsUno = SysData.ToStr(dr["ObsUno"]),
                            ObsDos = SysData.ToStr(dr["ObsDos"]),
                            FirmaUno = SysData.ToStr(dr["FirmaUno"]),
                            FirmaSeg = SysData.ToStr(dr["FirmaSeg"]),
                            FirmaTre = SysData.ToStr(dr["FirmaTre"]),
                            FirmaCua = SysData.ToStr(dr["FirmaCua"]),                           
                            EstadoDes = SysData.ToStr(dr["EstadoDes"])
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
    }
}

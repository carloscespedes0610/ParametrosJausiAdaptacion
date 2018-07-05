using Parametros.Models.DAC;
using Parametros.Models.Modules;
using Parametros.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;

namespace Parametros.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            try
            {
                clsLoginVM oLogin = new clsLoginVM();

                oLogin.UsuarioCod = "jmercado";
                oLogin.UsuarioPass = "123";
                ViewBag.EmpresaId = new SelectList(EmpresaList(), "EmpresaId", "EmpresaDes");
                return View(oLogin);
            }
            catch (Exception ex) {
                return RedirectToAction("ErrorMsg","Error", new {@MessageErr= ex.Message });
            }

           
        }

        [HttpPost, ValidateAntiForgeryToken()]
        public ActionResult Index(clsLoginVM oLoginDAO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    clsEmpresaVM oEmpresaDAO = EmpresaList().Find((x) => x.EmpresaId == oLoginDAO.EmpresaId);

                    try
                    {
                        clsAppInfo.Init(oEmpresaDAO.DataSource, oEmpresaDAO.InitialCatalog, (string)(oLoginDAO.UsuarioCod), oLoginDAO.UsuarioPass);

                        if (clsAppInfo.OpenConection())
                        {
                            if (AppCode.AplicacionFind(1))
                            {
                                if (UsuarioCodFind((oLoginDAO.UsuarioCod)))
                                {
                                    if (AppCode.AutorizaFind(clsAppInfo.TipoUsuarioId, "segAplicacion", 1))
                                    {
                                        Session["User"] = clsAppInfo.UsuarioCod;
                                        clsAppInfo.AppPath = Request.UrlReferrer.OriginalString;
                                        return RedirectToAction("Index", "Home");

                                    }
                                    else
                                    {
                                        ViewBag.MessageErr = "Aplicación no Autorizada para el Usuario";
                                        ViewBag.EmpresaId = new SelectList(EmpresaList(), "EmpresaId", "EmpresaDes");
                                        return View(oLoginDAO);
                                    }

                                }
                                else
                                {
                                    ViewBag.MessageErr = "Usuario no Registrado";
                                    ViewBag.EmpresaId = new SelectList(EmpresaList(), "EmpresaId", "EmpresaDes");
                                    return View(oLoginDAO);
                                }

                            }
                            else
                            {
                                ViewBag.MessageErr = "Aplicación no Autorizada";
                                ViewBag.EmpresaId = new SelectList(EmpresaList(), "EmpresaId", "EmpresaDes");
                                return View(oLoginDAO);
                            }
                        }

                    }
                    catch (Exception exp)
                    {
                        ViewBag.MessageErr = Convert.ToString(exp.Message);
                        ViewBag.EmpresaId = new SelectList(EmpresaList(), "EmpresaId", "EmpresaDes");
                        return View(oLoginDAO);
                    }
                }

                ViewBag.EmpresaId = new SelectList(EmpresaList(), "EmpresaId", "EmpresaDes");
                return View(oLoginDAO);

            }
            catch (Exception exp)
            {
                return RedirectToAction("ErrorMsg", "Error", new { MessageErr = exp.Message });
            }
        }

      


        // GET: Login/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Login/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Login/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Login/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Login/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Login/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Login/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        private List<clsEmpresaVM> EmpresaList() {
            List<clsEmpresaVM> empresaList = new List<clsEmpresaVM>();
            XmlDocument xml;
            XmlNodeList nodeList;
           // XmlNode node;

            try
            {
                xml = new XmlDocument();
                xml.Load(Server.MapPath("~/Models/Empresa.xml"));
                nodeList = xml.SelectNodes("/EmpresaList/Empresa");

                foreach ( XmlNode node in nodeList){

                    empresaList.Add(new clsEmpresaVM()
					{
						EmpresaId = long.Parse((node.Attributes.GetNamedItem("EmpresaId").Value)),
						EmpresaDes = (node.Attributes.GetNamedItem("EmpresaDes").Value),
						DataSource = (node.Attributes.GetNamedItem("DataSource").Value),
						InitialCatalog = (node.Attributes.GetNamedItem("InitialCatalog").Value)
					});

                }


            }
            catch (Exception ex) {
               
            }


            return empresaList;
        }


        public bool UsuarioCodFind(string strUsuarioCod)
        {
            bool tempUsuarioCodFind = false;
            clsUsuario oUsuario = new clsUsuario(clsAppInfo.Connection);

            tempUsuarioCodFind = false;

            clsAppInfo.TipoUsuarioId = 0;
            clsAppInfo.UsuarioId = 0;
            clsAppInfo.UsuarioCod = "";
            clsAppInfo.UsuarioDes = "";

            try
            {
                oUsuario.SelectFilter = clsUsuario.SelectFilters.All;
                oUsuario.WhereFilter = clsUsuario.WhereFilters.UsuarioCod;
                oUsuario.UsuarioCod = strUsuarioCod;

                if (oUsuario.Find())
                {
                    if (oUsuario.EstadoId == ConstEstado.Activo)
                    {
                        clsAppInfo.TipoUsuarioId = oUsuario.TipoUsuarioId;
                        clsAppInfo.UsuarioId = oUsuario.UsuarioId;
                        clsAppInfo.UsuarioCod = oUsuario.UsuarioCod;
                        clsAppInfo.UsuarioDes = oUsuario.UsuarioDes;
                        clsAppInfo.UsuarioFotoPath = oUsuario.UsuarioFotoPath;

                        tempUsuarioCodFind = true;
                    }
                }

            }
            catch (Exception exp)
            {
                throw exp;

            }
            finally
            {
                oUsuario.Dispose();
            }
            return tempUsuarioCodFind;
        }


    }
}

using Parametros.Models.DAC;
using Parametros.Models.VM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Parametros.Models.Modules
{
    public static class ComboBox
    {
        public static IEnumerable<clsEstadoVM> EstadoList()
        {
            clsEstado oEstado = new clsEstado(clsAppInfo.Connection);
            List<clsEstadoVM> oEstadoVM = new List<clsEstadoVM>();

            try
            {
                oEstado.SelectFilter = clsEstado.SelectFilters.ListBox;
                oEstado.WhereFilter = clsEstado.WhereFilters.AplicacionId;
                oEstado.OrderByFilter = clsEstado.OrderByFilters.EstadoDes;
                oEstado.AplicacionId = clsAppInfo.AplicacionId;

                if (oEstado.Open())
                {
                    foreach (DataRow dr in oEstado.DataSet.Tables[oEstado.TableName].Rows)
                    {
                        oEstadoVM.Add(new clsEstadoVM()
                        {
                            EstadoId = SysData.ToLong(dr["EstadoId"]),
                            EstadoDes = SysData.ToStr(dr["EstadoDes"])
                        });
                    }
                }
            }

            catch (Exception exp)
            {
                throw (exp);

            }
            finally
            {
                oEstado.Dispose();
            }

            return ((IEnumerable<clsEstadoVM>)oEstadoVM);
        }
    

        public static IEnumerable<clsMesVM> MesList()
        {
            List<clsMesVM> mlist = new List<clsMesVM>();

            clsMesVM mes = new clsMesVM(1,"Enero");       
            mlist.Add(mes);

            mes = new clsMesVM(2, "Febrero");
            mlist.Add(mes);

            mes = new clsMesVM(3, "Marzo");
            mlist.Add(mes);

            mes = new clsMesVM(4, "Abril");
            mlist.Add(mes);

            mes = new clsMesVM(5, "Mayo");
            mlist.Add(mes);

            mes = new clsMesVM(6, "Junio");
            mlist.Add(mes);

            mes = new clsMesVM(7, "Julio");
            mlist.Add(mes);

            mes = new clsMesVM(8, "Agosto");
            mlist.Add(mes);

            mes = new clsMesVM(9, "Septiembre");
            mlist.Add(mes);

            mes = new clsMesVM(10, "Octubre");
            mlist.Add(mes);

            mes = new clsMesVM(11, "Noviembre");
            mlist.Add(mes);

            mes = new clsMesVM(12, "Diciembre");
            mlist.Add(mes);

            return ((IEnumerable<clsMesVM>)mlist);
        }


        public static IEnumerable<clsNameValueVM> PrefijoTipoList()
        {
            clsPrefijoTipo oPrefijoTipo = new clsPrefijoTipo(clsAppInfo.Connection);
            List<clsNameValueVM> lstPrefijoTipoVM = new List<clsNameValueVM>();
            
            try
            {
                oPrefijoTipo.SelectFilter = clsPrefijoTipo.SelectFilters.Grid;
                oPrefijoTipo.WhereFilter = clsPrefijoTipo.WhereFilters.Grid;
                oPrefijoTipo.OrderByFilter = clsPrefijoTipo.OrderByFilters.Grid;

                if (oPrefijoTipo.Open())
                {

                    foreach (DataRow dr in oPrefijoTipo.DataSet.Tables[oPrefijoTipo.TableName].Rows)
                    {
                        lstPrefijoTipoVM.Add(new clsNameValueVM()
                        {
                            Value = SysData.ToLong(dr["PrefijoTipoId"]),
                            Name = SysData.ToStr(dr["PrefijoTipoDes"])

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
                oPrefijoTipo.Dispose();
            }
            return ((IEnumerable<clsNameValueVM>)lstPrefijoTipoVM);
        }

        public static IEnumerable<clsNameValueVM> TipoEncabezadoList()
        {
            clsTipoEncabezado oTipoEncabezado = new clsTipoEncabezado(clsAppInfo.Connection);
            List<clsNameValueVM> lstTipoEncVM = new List<clsNameValueVM>();

            try
            {
                oTipoEncabezado.SelectFilter = clsTipoEncabezado.SelectFilters.Grid;
                oTipoEncabezado.WhereFilter = clsTipoEncabezado.WhereFilters.Grid;
                oTipoEncabezado.OrderByFilter = clsTipoEncabezado.OrderByFilters.Grid;

                if (oTipoEncabezado.Open())
                {

                    foreach (DataRow dr in oTipoEncabezado.DataSet.Tables[oTipoEncabezado.TableName].Rows)
                    {
                        lstTipoEncVM.Add(new clsNameValueVM()
                        {
                            Value = SysData.ToLong(dr["TipoEncabezadoId"]),
                            Name = SysData.ToStr(dr["TipoEncabezadoDes"])

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
                oTipoEncabezado.Dispose();
            }
            return ((IEnumerable<clsNameValueVM>)lstTipoEncVM);
        }

        public static IEnumerable<clsNameValueVM> TipoNumeracionList()
        {
            List<clsNameValueVM> mPrefijoTipoList = new List<clsNameValueVM>();

            clsNameValueVM prefijoTipo = new clsNameValueVM(1, "Anual");
            mPrefijoTipoList.Add(prefijoTipo);

            prefijoTipo = new clsNameValueVM(2, "Por Periodo");
            mPrefijoTipoList.Add(prefijoTipo);



            return ((IEnumerable<clsNameValueVM>)mPrefijoTipoList);
        }

        public static IEnumerable<clsNameValueVM> PrefijoCopiaList()
        {
            clsPrefijoCopia oPrefijoCopia = new clsPrefijoCopia(clsAppInfo.Connection);
            List<clsNameValueVM> lstPrefijoCopia = new List<clsNameValueVM>();

            try
            {
                oPrefijoCopia.SelectFilter = clsPrefijoCopia.SelectFilters.Grid;
                oPrefijoCopia.WhereFilter = clsPrefijoCopia.WhereFilters.Grid;
                oPrefijoCopia.OrderByFilter = clsPrefijoCopia.OrderByFilters.Grid;

                if (oPrefijoCopia.Open())
                {

                    foreach (DataRow dr in oPrefijoCopia.DataSet.Tables[oPrefijoCopia.TableName].Rows)
                    {
                        lstPrefijoCopia.Add(new clsNameValueVM()
                        {
                            Value = SysData.ToLong(dr["PrefijoCopiaId"]),
                            Name = SysData.ToStr(dr["PrefijoCopiaDes"])

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
                oPrefijoCopia.Dispose();
            }
            return ((IEnumerable<clsNameValueVM>)lstPrefijoCopia);
        }

        public static List<clsGestionVM> GestionList()
        {

            clsGestion oGestion = new clsGestion(clsAppInfo.Connection);
            List<clsGestionVM> oGestionVM = new List<clsGestionVM>();



            try
            {
                DateTime date = DateTime.Today;
                oGestion.SelectFilter = clsGestion.SelectFilters.Grid;
                oGestion.WhereFilter = clsGestion.WhereFilters.Grid;
               

                if (oGestion.Open())
                {

                    foreach (DataRow dr in oGestion.DataSet.Tables[oGestion.TableName].Rows)
                    {
                        oGestionVM.Add(new clsGestionVM()
                        {
                            GestionId = SysData.ToLong(dr["GestionId"]),
                            GestionNro = SysData.ToInteger(dr["GestionNro"]),
                            GestionFecIni=SysData.ToDate(dr["GestionFecIni"]),
                            GestionFecFin=SysData.ToDate(dr["GestionFecFin"])
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

    }
}
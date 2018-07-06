using Parametros.Models.VM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Parametros.Models.DAC
{
    public class clsDocumento : clsBase, IDisposable
    {
        public clsDocumentoVM VM;

        // Comentado por Carlos:
        /*private long mlngDocId;
        private String mstrDocCod;       
        private String mstrDocNem;
        private String mstrDocDes;
        private String mstrDocIso;
        private String mstrDocRev;
        private String mdatDocFec;
        private long mlngModuloId;
        private long mlngAplicacionId;
        private long mlngEstadoId;

        public long DocId { get => mlngDocId; set => mlngDocId = value; }
        public string DocCod { get => mstrDocCod; set => mstrDocCod = value; }
        public long ModuloId { get => mlngModuloId; set => mlngModuloId = value; }
        public long AplicacionId { get => mlngAplicacionId; set => mlngAplicacionId = value; }
        public string DocNem { get => mstrDocNem; set => mstrDocNem = value; }
        public string DocDes { get => mstrDocDes; set => mstrDocDes = value; }
        public string DocIso { get => mstrDocIso; set => mstrDocIso = value; }
        public string DocRev { get => mstrDocRev; set => mstrDocRev = value; }
        public string DocFec { get => mdatDocFec; set => mdatDocFec = value; }
        public long EstadoId { get => mlngEstadoId; set => mlngEstadoId = value; }*/



        //******************************************************
        //* The following enumerations will change for each
        //* data access class
        //******************************************************
        public enum SelectFilters : byte
        {
            All = 0,
            RowCount = 1,
            ListBox = 2,
            Grid = 3,
            GridCheck = 4
        }

        public enum WhereFilters : byte
        {
            None = 0,
            PrimaryKey = 1,
            MesId = 2,
            Grid = 3,
            GridCheck = 4,

        }

        public enum OrderByFilters : byte
        {
            None = 0,
            PeriodoId = 1,
            Mes = 2,
            Grid = 3,
            GridCheck = 4
        }

        public enum InsertFilters : byte
        {
            All = 0
        }

        public enum UpdateFilters : byte
        {
            All = 0
        }

        public enum DeleteFilters : byte
        {
            All = 0
        }

        public enum RowCountFilters : byte
        {
            All = 0
        }

        //*********************************************************
        //* The following filters will change for each
        //* data access class
        //*********************************************************
        private SelectFilters mintSelectFilter;
        private WhereFilters mintWhereFilter;
        private OrderByFilters mintOrderByFilter;
        private InsertFilters mintInsertFilter;
        private UpdateFilters mintUpdateFilter;
        private DeleteFilters mintDeleteFilter;
        private RowCountFilters mintRowCountFilter;

        public SelectFilters SelectFilter { get => mintSelectFilter; set => mintSelectFilter = value; }
        public WhereFilters WhereFilter { get => mintWhereFilter; set => mintWhereFilter = value; }
        public OrderByFilters OrderByFilter { get => mintOrderByFilter; set => mintOrderByFilter = value; }
        public InsertFilters InsertFilter { get => mintInsertFilter; set => mintInsertFilter = value; }
        public UpdateFilters UpdateFilter { get => mintUpdateFilter; set => mintUpdateFilter = value; }
        public DeleteFilters DeleteFilter { get => mintDeleteFilter; set => mintDeleteFilter = value; }
        public RowCountFilters RowCountFilter { get => mintRowCountFilter; set => mintRowCountFilter = value; }


        //************************************************************
        //* Method Name  : New()
        //* Syntax       : Constructor
        //* Parameters   : None
        //*
        //* Description  : This event is called when the object is created.
        //* It can be used to initialize private data variables.
        //*
        //************************************************************
        public clsDocumento()
        {
            mstrTableName = "parDoc";
            mstrClassName = "clsDocumento";

            PropertyInit();
            FilterInit();


        }



        public clsDocumento(string ConnectString) : this()
        {

            moConnection = new SqlConnection();

            mstrConnectionString = ConnectString;
        }

        public clsDocumento(SqlConnection oConnection) : this()
        {
            moConnection = oConnection;
        }

        public clsDocumento(SqlConnection oConnection, SelectFilters bytSelectFilter) : this()
        {
            moConnection = oConnection;
            mintSelectFilter = bytSelectFilter;
        }

        public clsDocumento(SqlConnection oConnection, SelectFilters bytSelectFilter, WhereFilters bytWhereFilter) : this()
        {
            moConnection = oConnection;
            mintSelectFilter = bytSelectFilter;
            mintWhereFilter = bytWhereFilter;
        }

        public clsDocumento(SqlConnection oConnection, SelectFilters bytSelectFilter, WhereFilters bytWhereFilter, OrderByFilters bytOrderByFilter) : this()
        {
            moConnection = oConnection;
            mintSelectFilter = bytSelectFilter;
            mintWhereFilter = bytWhereFilter;
            mintOrderByFilter = bytOrderByFilter;
        }

        public void PropertyInit()
        {
            // Modificado por Carlos: 
            VM = new clsDocumentoVM();
            VM.DocId = 0;
            VM.DocCod = String.Empty;
            VM.DocNem = String.Empty;
            VM.DocDes = String.Empty;
            VM.DocIso = String.Empty;
            VM.DocRev = String.Empty;
            VM.DocFec = DateTime.Now;
            VM.ModuloId = 0;
            VM.ModuloDes = String.Empty;
            VM.AplicacionId = 0;
            VM.AplicacionDes = String.Empty;
            VM.EstadoId = 0;
            VM.EstadoDes = String.Empty;

        }

        // Modificado por Carlos:
        protected override void SelectParameter()
        {
            string strSQL = null;

            mstrStoreProcName = "parDocSelect";

            switch (mintSelectFilter)
            {
                case SelectFilters.All:
                    strSQL = " SELECT  " +
                           "    parDoc.DocId, " +
                           "    parDoc.DocCod, " +
                           "    parDoc.DocDes, " +
                           "    parDoc.DocNem, " +
                           "    parDoc.DocIso, " +
                           "    parDoc.DocRev, " +
                           "    parDoc.DocFec, " +
                           "    parDoc.ModuloId, " +
                           "    parDoc.AplicacionId, " +
                           "    parDoc.EstadoId " +
                           " FROM parDoc ";
                    break;

                case SelectFilters.ListBox:
                    strSQL = " SELECT  " +
                          "    parDoc.DocId, " +
                          "    parDoc.DocCod, " +
                          "    parDoc.DocDes, " +
                          " FROM parDoc ";
                    break;

                case SelectFilters.Grid:
                    strSQL = " SELECT  " +
                            "    parDoc.DocId, " +
                            "    parDoc.DocCod, " +
                            "    parDoc.DocDes, " +
                            "    parDoc.DocNem, " +
                            "    parDoc.DocIso, " +
                            "    parDoc.DocRev, " +
                            "    parDoc.DocFec, " +
                            "    parDoc.ModuloId, " +
                            "    segModulo.ModuloDes, " +
                            "    parDoc.AplicacionId, " +
                            "    segAplicacion.AplicacionDes, " +
                            "    parDoc.EstadoId, " +
                            "    parEstado.EstadoDes " +
                            " FROM parDoc " +
                            "   LEFT JOIN segAplicacion ON parDoc.AplicacionId = segAplicacion.AplicacionId " +
                            "   LEFT JOIN segModulo ON parDoc.ModuloId = segModulo.ModuloId " +
                            "   LEFT JOIN parEstado ON parDoc.EstadoId = parEstado.EstadoId ";
                    break;

                case SelectFilters.GridCheck:
                    break;
            }

            strSQL += WhereFilterGet() + OrderByFilterGet();

            Array.Resize(ref moParameters, 1);
            moParameters[0] = new SqlParameter("@SQL", strSQL);
        }

        // Agregado por Carlos: 
        private string WhereFilterGet()
        {
            string strSQL = null;

            switch (mintWhereFilter)
            {
                case WhereFilters.PrimaryKey:
                    strSQL = " WHERE DocId = " + SysData.NumberToField(VM.DocId);
                    break;

                case WhereFilters.Grid:
                    break;

                case WhereFilters.MesId:
                    break;

                case WhereFilters.GridCheck:
                    break;

            }

            return strSQL;
        }

        // Agregado por Carlos: 
        private string OrderByFilterGet()
        {
            string strSQL = null;

            switch (mintOrderByFilter)
            {
                case OrderByFilters.Grid:
                    strSQL = " ORDER BY parDoc.DocDes ";
                    break;

                case OrderByFilters.GridCheck:
                    break;

                case OrderByFilters.Mes:
                    break;

                case OrderByFilters.PeriodoId:
                    break;
            }

            return strSQL;
        }


        // Comentado por Carlos: 
        /*protected override void SelectParameter()
        {
            Array.Resize(ref moParameters, 3);
            moParameters[0] = new SqlParameter("@SelectFilter", mintSelectFilter);
            moParameters[1] = new SqlParameter("@WhereFilter", mintWhereFilter);
            moParameters[2] = new SqlParameter("@OrderByFilter", mintOrderByFilter);

            switch (mintSelectFilter)
            {
                case SelectFilters.All:
                    mstrStoreProcName = "parDocSelect";

                    break;
                case SelectFilters.RowCount:
                    mstrStoreProcName = "parDocSelect";

                    break;
                case SelectFilters.ListBox:
                    mstrStoreProcName = "parDocSelect";

                    break;
                case SelectFilters.Grid:
                    mstrStoreProcName = "parDocSelect";

                    break;
                case SelectFilters.GridCheck:

                    break;
            }

            WhereParameter();

            //Call OrderByParameter()
        }

        private void WhereParameter()
        {
            switch (mintWhereFilter)
            {
                case WhereFilters.PrimaryKey:
                    Array.Resize(ref moParameters, moParameters.Length + 2);
                    moParameters[3] = new SqlParameter("@DocId", mlngDocId);
                    moParameters[4] = new SqlParameter("@EstadoId", Convert.ToInt32(0));

                    break;
                case WhereFilters.MesId:
                    //strSQL = " WHERE  segTipoUsuario.TipoUsuarioDes = " & StringToField(mstrTipoUsuarioDes)

                    break;
                case WhereFilters.Grid:
                    Array.Resize(ref moParameters, moParameters.Length + 2);
                    moParameters[3] = new SqlParameter("@DocId", Convert.ToInt32(0));
                    
                    moParameters[4] = new SqlParameter("@EstadoId", Convert.ToInt32(0));

                    break;


            }
        }*/

        protected override void InsertParameter()
        {
            switch (mintInsertFilter)
            {
                case InsertFilters.All:
                    mstrStoreProcName = "parDocInsert";
                    moParameters = new SqlParameter[11]
                    {
                    new SqlParameter("@InsertFilter", mintInsertFilter),
                    new SqlParameter("@Id", SqlDbType.Int),
                    new SqlParameter(clsDocumentoVM._DocCod, VM.DocCod),                   
                    new SqlParameter(clsDocumentoVM._DocNem, VM.DocNem),
                    new SqlParameter(clsDocumentoVM._DocDes, VM.DocDes),
                    new SqlParameter(clsDocumentoVM._DocIso, VM.DocIso),
                    new SqlParameter(clsDocumentoVM._DocRev, VM.DocRev),
                    new SqlParameter(clsDocumentoVM._DocFec, VM.DocFec),
                    new SqlParameter(clsDocumentoVM._ModuloId, VM.ModuloId),
                    new SqlParameter(clsDocumentoVM._AplicacionId, VM.AplicacionId),
                    new SqlParameter(clsDocumentoVM._EstadoId, VM.EstadoId)
                    };
                    moParameters[1].Direction = ParameterDirection.Output;

                    break;
            }
        }

        protected override void UpdateParameter()
        {
            switch (mintUpdateFilter)
            {
                case UpdateFilters.All:
                    mstrStoreProcName = "parDocUpdate";
                    moParameters = new SqlParameter[11]
                    {
                    new SqlParameter("@UpdateFilter", mintUpdateFilter),
                    new SqlParameter(clsDocumentoVM._DocId, VM.DocId),
                    new SqlParameter(clsDocumentoVM._DocCod, VM.DocCod),                   
                    new SqlParameter(clsDocumentoVM._DocNem, VM.DocNem),
                    new SqlParameter(clsDocumentoVM._DocDes, VM.DocDes),
                    new SqlParameter(clsDocumentoVM._DocIso, VM.DocIso),
                    new SqlParameter(clsDocumentoVM._DocRev, VM.DocRev),
                    new SqlParameter(clsDocumentoVM._DocFec, VM.DocFec),
                    new SqlParameter(clsDocumentoVM._ModuloId, VM.ModuloId),
                    new SqlParameter(clsDocumentoVM._AplicacionId, VM.AplicacionId),
                    new SqlParameter(clsDocumentoVM._EstadoId, VM.EstadoId)
                    };

                    break;
            }
        }

        protected override void DeleteParameter()
        {
            switch (mintDeleteFilter)
            {
                case DeleteFilters.All:
                    mstrStoreProcName = "parDocDelete";
                    moParameters = new SqlParameter[2]
                    {
                    new SqlParameter("@DeleteFilter", mintDeleteFilter),
                    new SqlParameter(clsDocumentoVM._DocId, VM.DocId)
                    };

                    break;
            }
        }

        protected override void Retrieve(DataRow oDataRow)
        {
            try
            {
                PropertyInit();

                switch (mintSelectFilter)
                {
                    case SelectFilters.All:
                        VM.DocId = SysData.ToLong(oDataRow[clsDocumentoVM._DocId]);
                        VM.DocCod = SysData.ToStr(oDataRow[clsDocumentoVM._DocCod]);
                        VM.DocNem = SysData.ToStr(oDataRow[clsDocumentoVM._DocNem]);
                        VM.DocDes = SysData.ToStr(oDataRow[clsDocumentoVM._DocDes]);
                        VM.DocRev = SysData.ToStr(oDataRow[clsDocumentoVM._DocRev]);
                        VM.DocIso = SysData.ToStr(oDataRow[clsDocumentoVM._DocIso]);
                        VM.DocFec = SysData.ToDateTime(oDataRow[clsDocumentoVM._DocFec]);
                        VM.AplicacionId = SysData.ToLong(oDataRow[clsDocumentoVM._AplicacionId]);
                        VM.ModuloId = SysData.ToLong(oDataRow[clsDocumentoVM._ModuloId]);
                        VM.EstadoId = SysData.ToLong(oDataRow[clsDocumentoVM._EstadoId]);
                        break;

                    case SelectFilters.ListBox:
                        //mlngTipoUsuarioId = ToLong(oDataRow("TipoUsuarioId"))
                        //mstrTipoUsuarioCod = ToStr(oDataRow("TipoUsuarioCod"))
                        //mstrTipoUsuarioDes = ToStr(oDataRow("TipoUsuarioDes"))

                        break;
                }

            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        public override bool Validate()
        {
            bool tempValidate = false;
            string strMsg = string.Empty;

            if (!string.IsNullOrEmpty(strMsg.Trim()))
            {
                throw new Exception(strMsg);
                tempValidate = false;
            }
            else
            {
                tempValidate = true;
            }
            return tempValidate;
        }

        public bool FindByPK()
        {
            bool tempFindByPK = false;
            tempFindByPK = false;

            try
            {
                mintSelectFilter = SelectFilters.All;
                mintWhereFilter = WhereFilters.PrimaryKey;
                mintOrderByFilter = OrderByFilters.None;

                if (Open())
                {
                    if (Read())
                    {
                        tempFindByPK = true;
                    }
                }

            }
            catch (Exception exp)
            {
                throw exp;
            }
            return tempFindByPK;
        }

        public void FilterInit()
        {
            mintWhereFilter = 0;
            mintOrderByFilter = 0;
            mintSelectFilter = 0;
            mintInsertFilter = 0;
            mintUpdateFilter = 0;
            mintDeleteFilter = 0;
            mintRowCountFilter = 0;
        }

        public virtual void Dispose()
        {
            //Call CloseConection()
        }

        // Agregado por Carlos: 
        protected override void SetPrimaryKey()
        {
            VM.DocId = mlngId;
        }
    }
}
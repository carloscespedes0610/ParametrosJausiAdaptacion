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
        private long mlngDocId;
        private String mstrDocCod;       
        private String mstrDocNem;
        private String mstrDocDes;
        private String mstrDocIso;
        private String mstrDocRev;
        private String mdatDocFec;
        private long mlngModuloId;
        private long mlngAplicacionId;
        private long mlngEstadoId;

        //******************************************************
        // Private Data To Match the Table Definition
        //******************************************************



        public long DocId { get => mlngDocId; set => mlngDocId = value; }
        public string DocCod { get => mstrDocCod; set => mstrDocCod = value; }
        public long ModuloId { get => mlngModuloId; set => mlngModuloId = value; }
        public long AplicacionId { get => mlngAplicacionId; set => mlngAplicacionId = value; }
        public string DocNem { get => mstrDocNem; set => mstrDocNem = value; }
        public string DocDes { get => mstrDocDes; set => mstrDocDes = value; }
        public string DocIso { get => mstrDocIso; set => mstrDocIso = value; }
        public string DocRev { get => mstrDocRev; set => mstrDocRev = value; }
        public string DocFec { get => mdatDocFec; set => mdatDocFec = value; }
        public long EstadoId { get => mlngEstadoId; set => mlngEstadoId = value; }



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
            mlngDocId = 0;
            mstrDocCod = "";           
            mstrDocNem = "";
            mstrDocDes = "";
            mstrDocIso = "";
            mstrDocRev = "";
            mdatDocFec = "";
            mlngModuloId = 0;
            mlngAplicacionId = 0;
            mlngEstadoId = 0;

        }

        protected override void SelectParameter()
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
        }

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
                    new SqlParameter("@DocCod", mstrDocCod),                   
                    new SqlParameter("@DocNem", mstrDocNem),
                    new SqlParameter("@DocDes", mstrDocDes),
                    new SqlParameter("@DocIso", mstrDocIso),
                    new SqlParameter("@DocRev", mstrDocRev),
                    new SqlParameter("@DocFec", mdatDocFec),
                    new SqlParameter("@ModuloId", mlngModuloId),
                    new SqlParameter("@AplicacionId", mlngAplicacionId),
                    new SqlParameter("@EstadoId", mlngEstadoId)
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
                    new SqlParameter("@DocId", mlngDocId),
                    new SqlParameter("@DocCod", mstrDocCod),                   
                    new SqlParameter("@DocNem", mstrDocNem),
                    new SqlParameter("@DocDes", mstrDocDes),
                    new SqlParameter("@DocIso", mstrDocIso),
                    new SqlParameter("@DocRev", mstrDocRev),
                    new SqlParameter("@DocFec", mdatDocFec),
                    new SqlParameter("@ModuloId", mlngModuloId),
                    new SqlParameter("@AplicacionId", mlngAplicacionId),
                    new SqlParameter("@EstadoId", mlngEstadoId)
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
                    new SqlParameter("@DocId", mlngDocId)
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
                        mlngDocId = SysData.ToLong(oDataRow["DocId"]);
                        mstrDocCod= SysData.ToStr(oDataRow["DocCod"]);
                        mstrDocNem = SysData.ToStr(oDataRow["DocNem"]);
                        mstrDocDes = SysData.ToStr(oDataRow["DocDes"]);
                        mstrDocRev = SysData.ToStr(oDataRow["DocRev"]);
                        mstrDocIso = SysData.ToStr(oDataRow["DocIso"]);
                        mdatDocFec = SysData.ToStr(oDataRow["DocFec"]);
                        mlngAplicacionId = SysData.ToLong(oDataRow["AplicacionId"]);
                        mlngModuloId= SysData.ToLong(oDataRow["ModuloId"]);
                        mlngEstadoId = SysData.ToLong(oDataRow["EstadoId"]);
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

        protected override void SetPrimaryKey()
        {
            throw new NotImplementedException();
        }
    }
}
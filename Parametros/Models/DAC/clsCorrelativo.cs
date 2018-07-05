using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Parametros.Models.DAC
{
    public class clsCorrelativo : clsBase, IDisposable
    {
        private long mlngCorreId;        
        private long mlngPrefijoId;
        private long mlngDocId;
        private long mlngGestionId;       
        private long mlngModuloId;
        private long mlngAplicacionId;
        private int mintCorreNroAct;
        private int mintCorreNroMax;
        private DateTime mdatFecIni;
        private DateTime mdatFecFin;


        //******************************************************
        // Private Data To Match the Table Definition
        //******************************************************
        public long CorreId { get => mlngCorreId; set => mlngCorreId = value; }
        public long PrefijoId { get => mlngPrefijoId; set => mlngPrefijoId = value; }
        public long DocId { get => mlngDocId; set => mlngDocId = value; }
        public long GestionId { get => mlngGestionId; set => mlngGestionId = value; }
        public long ModuloId { get => mlngModuloId; set => mlngModuloId = value; }
        public long AplicacionId { get => mlngAplicacionId; set => mlngAplicacionId = value; }
        public int CorreNroAct { get => mintCorreNroAct; set => mintCorreNroAct = value; }
        public int CorreNroMax { get => mintCorreNroMax; set => mintCorreNroMax = value; }
        public DateTime FecIni { get => mdatFecIni; set => mdatFecIni = value; }
        public DateTime FecFin { get => mdatFecFin; set => mdatFecFin = value; }


        
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
            Details = 4
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
        public clsCorrelativo()
        {
            mstrTableName = "parCorre";
            mstrClassName = "clsCorrelativo";

            PropertyInit();
            FilterInit();
        }



        public clsCorrelativo(string ConnectString) : this()
        {

            moConnection = new SqlConnection();

            mstrConnectionString = ConnectString;
        }

        public clsCorrelativo(SqlConnection oConnection) : this()
        {
            moConnection = oConnection;
        }

        public clsCorrelativo(SqlConnection oConnection, SelectFilters bytSelectFilter) : this()
        {
            moConnection = oConnection;
            mintSelectFilter = bytSelectFilter;
        }

        public clsCorrelativo(SqlConnection oConnection, SelectFilters bytSelectFilter, WhereFilters bytWhereFilter) : this()
        {
            moConnection = oConnection;
            mintSelectFilter = bytSelectFilter;
            mintWhereFilter = bytWhereFilter;
        }

        public clsCorrelativo(SqlConnection oConnection, SelectFilters bytSelectFilter, WhereFilters bytWhereFilter, OrderByFilters bytOrderByFilter) : this()
        {
            moConnection = oConnection;
            mintSelectFilter = bytSelectFilter;
            mintWhereFilter = bytWhereFilter;
            mintOrderByFilter = bytOrderByFilter;
        }

        public void PropertyInit()
        {
            mlngCorreId=0;
            mlngPrefijoId=0;
            mlngGestionId=0;
            mlngModuloId=0;
            mlngAplicacionId=0;
            mintCorreNroAct=0;
            mintCorreNroMax=0;
            mdatFecIni=SysData.ToDate("");
            mdatFecFin=SysData.ToDate("");

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
                    mstrStoreProcName = "parCorrelativoSelect";

                    break;
                case SelectFilters.RowCount:
                    mstrStoreProcName = "parCorrelativoSelect";

                    break;
                case SelectFilters.ListBox:
                    mstrStoreProcName = "parCorrelativoSelect";

                    break;
                case SelectFilters.Grid:
                    mstrStoreProcName = "parCorrelativoSelect";

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
                    moParameters[3] = new SqlParameter("@CorreId", mlngCorreId);
                    
                    break;
                case WhereFilters.MesId:
                    //strSQL = " WHERE  segTipoUsuario.TipoUsuarioDes = " & StringToField(mstrTipoUsuarioDes)

                    break;
                case WhereFilters.Grid:
                    Array.Resize(ref moParameters, moParameters.Length + 1);
                    moParameters[3] = new SqlParameter("@CorreId", Convert.ToInt32(0));
                   
                    break;
                case WhereFilters.Details:
                    Array.Resize(ref moParameters, moParameters.Length + 1);
                    moParameters[3] = new SqlParameter("@CorreId", mlngCorreId);

                    break;


            }
        }

        protected override void InsertParameter()
        {
            switch (mintInsertFilter)
            {
                case InsertFilters.All:
                    mstrStoreProcName = "parCorrelativoInsert";
                    moParameters = new SqlParameter[11]
                    {                   
                    new SqlParameter("@InsertFilter", mintInsertFilter),
                    new SqlParameter("@Id", SqlDbType.Int),
                    new SqlParameter("@DocId", mlngDocId),
                    new SqlParameter("@PrefijoId", mlngPrefijoId),                   
                    new SqlParameter("@GestionId", mlngGestionId),
                    new SqlParameter("@ModuloId", mlngModuloId),
                    new SqlParameter("@AplicacionId", mlngAplicacionId),
                    new SqlParameter("@CorreNroAct", mintCorreNroAct),
                    new SqlParameter("@CorreNroMax", mintCorreNroMax),
                    new SqlParameter("@CorreFecIni", mdatFecIni),
                    new SqlParameter("@CorreFecFin", mdatFecFin)                   
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
                    mstrStoreProcName = "parCorrelativoUpdate";
                    moParameters = new SqlParameter[11]
                    {
                    new SqlParameter("@UpdateFilter", mintUpdateFilter),
                    new SqlParameter("@CorreId", mlngCorreId),
                    new SqlParameter("@DocId", mlngDocId),
                    new SqlParameter("@PrefijoId", mlngPrefijoId),
                    new SqlParameter("@GestionId", mlngGestionId),
                    new SqlParameter("@ModuloId", mlngModuloId),
                    new SqlParameter("@AplicacionId", mlngAplicacionId),
                    new SqlParameter("@CorreNroAct", mintCorreNroAct),
                    new SqlParameter("@CorreNroMax", mintCorreNroMax),
                    new SqlParameter("@CorreFecIni", mdatFecIni),
                    new SqlParameter("@CorreFecFin", mdatFecFin)
                    };

                    break;
            }
        }

        protected override void DeleteParameter()
        {
            switch (mintDeleteFilter)
            {
                case DeleteFilters.All:
                    mstrStoreProcName = "parCorrelativoDelete";
                    moParameters = new SqlParameter[2]
                    {
                    new SqlParameter("@DeleteFilter", mintDeleteFilter),
                    new SqlParameter("@CorreId", mlngCorreId)
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
                        
                        mlngCorreId = SysData.ToLong(CorreId);
                        mlngPrefijoId = SysData.ToLong(mlngPrefijoId);
                        mlngGestionId = SysData.ToLong(mlngGestionId);
                        mlngModuloId = SysData.ToLong(mlngModuloId);
                        mlngAplicacionId = SysData.ToLong(mlngAplicacionId);
                        mintCorreNroAct = SysData.ToInteger(mintCorreNroAct);
                        mintCorreNroMax= SysData.ToInteger(mintCorreNroMax);
                        mdatFecIni = SysData.ToDate(mdatFecIni);
                        mdatFecFin= SysData.ToDate(mdatFecFin);
                        break;

                    case SelectFilters.ListBox:
                      
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
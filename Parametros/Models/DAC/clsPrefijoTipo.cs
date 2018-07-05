using System;
using System.Data.SqlClient;
using System.Data;

namespace Parametros.Models.DAC
{
    public class clsPrefijoTipo : clsBase, IDisposable
    {
        private long mlngPrefijoTipoId;
        private string mstPrefijoTipoDes;

        //******************************************************
        // Private Data To Match the Table Definition
        //******************************************************
        public long PrefijoTipoId { get => mlngPrefijoTipoId; set => mlngPrefijoTipoId = value; }
        public string PrefijoTipoDes { get => mstPrefijoTipoDes; set => mstPrefijoTipoDes = value; }


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
            EstadoDes = 2,
            Grid = 3,
            GridCheck = 4,
            EstadoCod = 5,
            GridEstadoId = 6,
            AplicacionId = 7
        }

        public enum OrderByFilters : byte
        {
            None = 0,
            EstadoId = 1,
            EstadoDes = 2,
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
        public clsPrefijoTipo()
        {
            mstrTableName = "parPrefijoTipo";
            mstrClassName = "clsPrefijoTipo";

            PropertyInit();
            FilterInit();
        }

        public clsPrefijoTipo(string ConnectString) : this()
        {
            moConnection = new SqlConnection();

            mstrConnectionString = ConnectString;
        }

        public clsPrefijoTipo(SqlConnection oConnection) : this()
        {
            moConnection = oConnection;
        }

        public clsPrefijoTipo(SqlConnection oConnection, SelectFilters bytSelectFilter) : this()
        {
            moConnection = oConnection;
            mintSelectFilter = bytSelectFilter;
        }

        public clsPrefijoTipo(SqlConnection oConnection, SelectFilters bytSelectFilter, WhereFilters bytWhereFilter) : this()
        {
            moConnection = oConnection;
            mintSelectFilter = bytSelectFilter;
            mintWhereFilter = bytWhereFilter;
        }

        public clsPrefijoTipo(SqlConnection oConnection, SelectFilters bytSelectFilter, WhereFilters bytWhereFilter, OrderByFilters bytOrderByFilter) : this()
        {
            moConnection = oConnection;
            mintSelectFilter = bytSelectFilter;
            mintWhereFilter = bytWhereFilter;
            mintOrderByFilter = bytOrderByFilter;
        }

        public void PropertyInit()
        {
            mlngPrefijoTipoId = 0;           
            mstPrefijoTipoDes= "";
           
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
                    mstrStoreProcName = "parPrefijoTipoSelect";
                    break;

                case SelectFilters.RowCount:
                    mstrStoreProcName = "parPrefijoTipoSelect";
                    break;

                case SelectFilters.ListBox:
                    mstrStoreProcName = "parPrefijoTipoSelect";
                    break;

                case SelectFilters.Grid:
                    mstrStoreProcName = "parPrefijoTipoSelect";
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
                    Array.Resize(ref moParameters, moParameters.Length + 1);
                    moParameters[3] = new SqlParameter("@PrefijoTipoId", mlngPrefijoTipoId);
                  
                    break;

                case WhereFilters.EstadoDes:
                    break;
                

                case WhereFilters.Grid:
                    Array.Resize(ref moParameters, moParameters.Length + 1);
                    moParameters[3] = new SqlParameter("@PrefijoTipoId", mlngPrefijoTipoId);
                   
                    break;

                case WhereFilters.EstadoCod:
                    break;

                case WhereFilters.GridCheck:
                    break;

                case WhereFilters.GridEstadoId:
                   
                    break;

                case WhereFilters.AplicacionId:
                   
                    break;
            }
        }

        protected override void InsertParameter()
        {
            switch (mintInsertFilter)
            {
                case InsertFilters.All:
                    mstrStoreProcName = "parPrefijoTipoInsert";
                    moParameters = new SqlParameter[2] {
                        new SqlParameter("@InsertFilter", mintInsertFilter),
                        new SqlParameter("@Id", SqlDbType.Int) };
                      
                    moParameters[1].Direction = ParameterDirection.Output;
                    break;
            }
        }

        protected override void UpdateParameter()
        {
            switch (mintUpdateFilter)
            {
                case UpdateFilters.All:
                    mstrStoreProcName = "parPrefijoTipoUpdate";
                    moParameters = new SqlParameter[1] {
                        new SqlParameter("@UpdateFilter", mintUpdateFilter) };
                       
                    break;
            }
        }

        protected override void DeleteParameter()
        {
            switch (mintDeleteFilter)
            {
                case DeleteFilters.All:
                    mstrStoreProcName = "parPrefijoTipoDelete";
                    moParameters = new SqlParameter[2] {
                        new SqlParameter("@DeleteFilter", mintDeleteFilter),
                        new SqlParameter("@PrefijoTipoId", mlngPrefijoTipoId)};
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
                      
                        break;

                    case SelectFilters.ListBox:
                      
                        break;
                }
            }

            catch (Exception exp)
            {
                throw (exp);
            }
        }

        public override bool Validate()
        {
            bool returnValue = false;
            string strMsg = string.Empty;

            

            if (strMsg.Trim() != string.Empty)
            {
                returnValue = false;
                throw (new Exception(strMsg));
            }
            else
            {
                returnValue = true;
            }

            return returnValue;
        }

        public bool FindByPK()
        {
            bool returnValue = false;
            returnValue = false;

            try
            {
                mintSelectFilter = SelectFilters.All;
                mintWhereFilter = WhereFilters.PrimaryKey;
                mintOrderByFilter = OrderByFilters.None;

                if (Open())
                {
                    if (Read())
                    {
                        returnValue = true;
                    }
                }
            }

            catch (Exception exp)
            {
                throw (exp);
            }

            return returnValue;
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

        virtual public void Dispose()
        {
            //Call CloseConection()
        }

        protected override void SetPrimaryKey()
        {
            throw new NotImplementedException();
        }
    }
}
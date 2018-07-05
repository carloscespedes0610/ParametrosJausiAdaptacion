﻿using System;
using System.Data.SqlClient;
using System.Data;

namespace Parametros.Models.DAC
{
    public class clsTipoUsuario : clsBase, IDisposable
    {
        private long mlngTipoUsuarioId;
        private string mstrTipoUsuarioCod;
        private string mstrTipoUsuarioDes;
        private long mlngEstadoId;

        //******************************************************
        // Private Data To Match the Table Definition
        //******************************************************
        public long TipoUsuarioId
        {
            get
            {
                return mlngTipoUsuarioId;
            }

            set
            {
                mlngTipoUsuarioId = value;
            }
        }

        public string TipoUsuarioCod
        {
            get
            {
                return mstrTipoUsuarioCod;
            }

            set
            {
                mstrTipoUsuarioCod = value;
            }
        }

        public string TipoUsuarioDes
        {
            get
            {
                return mstrTipoUsuarioDes;
            }

            set
            {
                mstrTipoUsuarioDes = value;
            }
        }

        public long EstadoId
        {
            get
            {
                return mlngEstadoId;
            }

            set
            {
                mlngEstadoId = value;
            }
        }

        public long Id
        {
            get
            {
                return mlngId;
            }

            set
            {
                mlngId = value;
            }
        }

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
            TipoUsuarioDes = 2,
            Grid = 3,
            GridCheck = 4,
            TipoUsuarioCod = 5,
        }

        public enum OrderByFilters : byte
        {
            None = 0,
            TipoUsuarioId = 1,
            TipoUsuarioDes = 2,
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

        public SelectFilters SelectFilter
        {
            get
            {
                return mintSelectFilter;
            }

            set
            {
                mintSelectFilter = value;
            }
        }

        public WhereFilters WhereFilter
        {
            get
            {
                return mintWhereFilter;
            }

            set
            {
                mintWhereFilter = value;
            }
        }

        public OrderByFilters OrderByFilter
        {
            get
            {
                return mintOrderByFilter;
            }

            set
            {
                mintOrderByFilter = value;
            }
        }

        public InsertFilters InsertFilter
        {
            get
            {
                return mintInsertFilter;
            }

            set
            {
                mintInsertFilter = value;
            }
        }

        public UpdateFilters UpdateFilter
        {
            get
            {
                return mintUpdateFilter;
            }

            set
            {
                mintUpdateFilter = value;
            }
        }

        public DeleteFilters DeleteFilter
        {
            get
            {
                return mintDeleteFilter;
            }

            set
            {
                mintDeleteFilter = value;
            }
        }

        public RowCountFilters RowCountFilter
        {
            get
            {
                return mintRowCountFilter;
            }

            set
            {
                mintRowCountFilter = value;
            }
        }

        //************************************************************
        //* Method Name  : New()
        //* Syntax       : Constructor
        //* Parameters   : None
        //*
        //* Description  : This event is called when the object is created.
        //* It can be used to initialize private data variables.
        //*
        //************************************************************
        public clsTipoUsuario()
        {
            mstrTableName = "segTipoUsuario";
            mstrClassName = "clsTipoUsuario";

            PropertyInit();
            FilterInit();
        }

        public clsTipoUsuario(string ConnectString) : this()
        {
            moConnection = new SqlConnection();

            mstrConnectionString = ConnectString;
        }

        public clsTipoUsuario(SqlConnection oConnection) : this()
        {
            moConnection = oConnection;
        }

        public clsTipoUsuario(SqlConnection oConnection, SelectFilters bytSelectFilter) : this()
        {
            moConnection = oConnection;
            mintSelectFilter = bytSelectFilter;
        }

        public clsTipoUsuario(SqlConnection oConnection, SelectFilters bytSelectFilter, WhereFilters bytWhereFilter) : this()
        {
            moConnection = oConnection;
            mintSelectFilter = bytSelectFilter;
            mintWhereFilter = bytWhereFilter;
        }

        public clsTipoUsuario(SqlConnection oConnection, SelectFilters bytSelectFilter, WhereFilters bytWhereFilter, OrderByFilters bytOrderByFilter) : this()
        {
            moConnection = oConnection;
            mintSelectFilter = bytSelectFilter;
            mintWhereFilter = bytWhereFilter;
            mintOrderByFilter = bytOrderByFilter;
        }

        public void PropertyInit()
        {
            mlngTipoUsuarioId = 0;
            mstrTipoUsuarioCod = "";
            mstrTipoUsuarioDes = "";
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
                    mstrStoreProcName = "segTipoUsuarioSelect";
                    break;

                case SelectFilters.RowCount:
                    mstrStoreProcName = "segTipoUsuarioSelect";
                    break;

                case SelectFilters.ListBox:
                    mstrStoreProcName = "segTipoUsuarioSelect";
                    break;

                case SelectFilters.Grid:
                    mstrStoreProcName = "segTipoUsuarioSelect";
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
                    moParameters[3] = new SqlParameter("@TipoUsuarioId", mlngTipoUsuarioId);
                    moParameters[4] = new SqlParameter("@EstadoId", Convert.ToInt32(0));
                    break;

                case WhereFilters.TipoUsuarioDes:
                    break;
                //strSQL = " WHERE  segTipoUsuario.TipoUsuarioDes = " & StringToField(mstrTipoUsuarioDes)

                case WhereFilters.Grid:
                    Array.Resize(ref moParameters, moParameters.Length + 2);
                    moParameters[3] = new SqlParameter("@TipoUsuarioId", Convert.ToInt32(0));
                    moParameters[4] = new SqlParameter("@EstadoId", Convert.ToInt32(0));
                    break;

                case WhereFilters.TipoUsuarioCod:
                    break;

                case WhereFilters.GridCheck:
                    break;
            }
        }

        protected override void InsertParameter()
        {
            switch (mintInsertFilter)
            {
                case InsertFilters.All:
                    mstrStoreProcName = "segTipoUsuarioInsert";
                    moParameters = new SqlParameter[5] {
                        new SqlParameter("@InsertFilter", mintInsertFilter),
                        new SqlParameter("@Id", SqlDbType.Int),
                        new SqlParameter("@TipoUsuarioCod", mstrTipoUsuarioCod),
                        new SqlParameter("@TipoUsuarioDes", mstrTipoUsuarioDes),
                        new SqlParameter("@EstadoId", mlngEstadoId)};
                    moParameters[1].Direction = ParameterDirection.Output;
                    break;
            }
        }

        protected override void UpdateParameter()
        {
            switch (mintUpdateFilter)
            {
                case UpdateFilters.All:
                    mstrStoreProcName = "segTipoUsuarioUpdate";
                    moParameters = new SqlParameter[5] {
                        new SqlParameter("@UpdateFilter", mintUpdateFilter),
                        new SqlParameter("@TipoUsuarioId", mlngTipoUsuarioId),
                        new SqlParameter("@TipoUsuarioCod", mstrTipoUsuarioCod),
                        new SqlParameter("@TipoUsuarioDes", mstrTipoUsuarioDes),
                        new SqlParameter("@EstadoId", mlngEstadoId)};
                    break;
            }
        }

        protected override void DeleteParameter()
        {
            switch (mintDeleteFilter)
            {
                case DeleteFilters.All:
                    mstrStoreProcName = "segTipoUsuarioDelete";
                    moParameters = new SqlParameter[2] {
                        new SqlParameter("@DeleteFilter", mintDeleteFilter),
                        new SqlParameter("@TipoUsuarioId", mlngTipoUsuarioId)};
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
                        mlngTipoUsuarioId = SysData.ToLong(oDataRow["TipoUsuarioId"]);
                        mstrTipoUsuarioCod = SysData.ToStr(oDataRow["TipoUsuarioCod"]);
                        mstrTipoUsuarioDes = SysData.ToStr(oDataRow["TipoUsuarioDes"]);
                        mlngEstadoId = SysData.ToLong(oDataRow["EstadoId"]);
                        break;

                    case SelectFilters.ListBox:
                        mlngTipoUsuarioId = SysData.ToLong(oDataRow["TipoUsuarioId"]);
                        mstrTipoUsuarioCod = SysData.ToStr(oDataRow["TipoUsuarioCod"]);
                        mstrTipoUsuarioDes = SysData.ToStr(oDataRow["TipoUsuarioDes"]);
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

            if (mstrTipoUsuarioCod.Length == 0)
            {
                strMsg += "Ingrese el Código <br />";
            }

            if (mstrTipoUsuarioDes.Length == 0)
            {
                strMsg += "Ingrese el TipoUsuario <br />";
            }

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

    }
}
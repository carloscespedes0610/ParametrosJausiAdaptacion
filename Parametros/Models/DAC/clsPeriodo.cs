﻿using Parametros.Models.VM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Parametros.Models.DAC
{
    public class clsPeriodo : clsBase, IDisposable
    {
        public clsPeriodoVM VM;


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
            Gestion = 4
        }

        public enum WhereFilters : byte
        {
            None = 0,
            PrimaryKey = 1,
            MesId = 2,
            Grid = 3,
            Gestion = 4,
           
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
        public clsPeriodo()
        {
            mstrTableName = "parPeriodo";
            mstrClassName = "clsPeriodo";

            PropertyInit();
            FilterInit();
        }



        public clsPeriodo(string ConnectString) : this()
        {

            moConnection = new SqlConnection();

            mstrConnectionString = ConnectString;
        }

        public clsPeriodo(SqlConnection oConnection) : this()
        {
            moConnection = oConnection;
        }

        public clsPeriodo(SqlConnection oConnection, SelectFilters bytSelectFilter) : this()
        {
            moConnection = oConnection;
            mintSelectFilter = bytSelectFilter;
        }

        public clsPeriodo(SqlConnection oConnection, SelectFilters bytSelectFilter, WhereFilters bytWhereFilter) : this()
        {
            moConnection = oConnection;
            mintSelectFilter = bytSelectFilter;
            mintWhereFilter = bytWhereFilter;
        }

        public clsPeriodo(SqlConnection oConnection, SelectFilters bytSelectFilter, WhereFilters bytWhereFilter, OrderByFilters bytOrderByFilter) : this()
        {
            moConnection = oConnection;
            mintSelectFilter = bytSelectFilter;
            mintWhereFilter = bytWhereFilter;
            mintOrderByFilter = bytOrderByFilter;
        }

        public void PropertyInit()
        {
            VM = new clsPeriodoVM();
            VM.PeriodoId = 0;
            VM.GestionId = 0;
            VM.MesId = 0;
            VM.PeriodoFecIni = new DateTime();
            VM.PeriodoFecFin = new DateTime();
            VM.EstadoId = 0;

        }

        protected override void SelectParameter()
        {
            string strSQL = null;

            mstrStoreProcName = "parPeriodoSelect";

            switch (mintSelectFilter)
            {
                case SelectFilters.All:
                    strSQL = " SELECT " +
                    " parPeriodo.PeriodoId, " +
                    " parPeriodo.GestionId, " +
                    " parPeriodo.MesId, " +
                    " parPeriodo.PeriodoFecIni, " +
                    " parPeriodo.PeriodoFecFin, " +
                    " parPeriodo.EstadoId " +
                    " FROM parPeriodo ";

                    break;
                case SelectFilters.RowCount:
                    mstrStoreProcName = "parPeriodoSelect";

                    break;
                case SelectFilters.ListBox:
                    mstrStoreProcName = "parPeriodoSelect";

                    break;
                case SelectFilters.Grid:
                    strSQL = " SELECT " +
                    " parPeriodo.PeriodoId, " +
                    " parPeriodo.GestionId, " +
                    " parGestion.GestionNro, " +
                    " parPeriodo.MesId, " +
                    " parMes.MesDes, " +
                    " parPeriodo.PeriodoFecIni, " +
                    " parPeriodo.PeriodoFecFin, " +
                    " parEstado.EstadoId, " +
                    " parEstado.EstadoDes " +
                    " FROM parPeriodo " +
                    " LEFT JOIN parGestion ON parPeriodo.GestionId = parGestion.GestionId " +
                    " LEFT JOIN parMes ON parPeriodo.MesId = parMes.MesId " +
                    " LEFT JOIN parEstado ON parPeriodo.EstadoId = parEstado.EstadoId ";

                    break;
                case SelectFilters.Gestion:

                    strSQL = " SELECT " +
                    " parPeriodo.PeriodoId, " +
                    " parPeriodo.GestionId, " +
                    " parPeriodo.MesId, " +
                    " parMes.MesDes, " +
                    " parPeriodo.PeriodoFecIni, " +
                    " parPeriodo.PeriodoFecFin, " +
                    " parPeriodo.EstadoId " +
                    " FROM parPeriodo " +
                    " LEFT JOIN parMes ON parPeriodo.MesId= parMes.MesId ";

                    break;
            }

            strSQL += WhereFilterGet() + OrderByFilterGet();
            Array.Resize(ref moParameters, 1);
            moParameters[0] = new SqlParameter("@SQL", strSQL);
        }

        private string WhereFilterGet()
        {
            string strSQL = null;

            switch (mintWhereFilter)
            {
                case WhereFilters.None:
                    break;
                case WhereFilters.Grid:
                    break;
                case WhereFilters.PrimaryKey:
                    strSQL = " WHERE parPeriodo.PeriodoId = " + SysData.NumberToField(VM.PeriodoId);
                    
                    break;
                case WhereFilters.Gestion:
                    strSQL = " WHERE parPeriodo.GestionId = " + SysData.NumberToField(VM.GestionId);
                    break;

            }

            return strSQL;
        }


        private string OrderByFilterGet()
        {
            string strSQL = null;

            switch (mintOrderByFilter)
            {
                case OrderByFilters.Mes:
                    strSQL = " ORDER BY parPeriodo.MesId ";
                    break;

                case OrderByFilters.GridCheck:
                    break;
                case OrderByFilters.Grid:
                    strSQL = " ORDER BY parGestion.GestionNro DESC, parPeriodo.MesId ";
                    break;

            }

            return strSQL;
        }

        protected override void InsertParameter()
        {
            switch (mintInsertFilter)
            {
                case InsertFilters.All:
                    mstrStoreProcName = "parPeriodoInsert";
                    moParameters = new SqlParameter[7]
                    {
                    new SqlParameter("@InsertFilter", mintInsertFilter),
                    new SqlParameter("@Id", SqlDbType.Int),
                    new SqlParameter(clsPeriodoVM._GestionId, VM.GestionId),
                    new SqlParameter(clsPeriodoVM._MesId, VM.MesId),
                    new SqlParameter(clsPeriodoVM._PeriodoFecIni, VM.PeriodoFecIni),
                    new SqlParameter(clsPeriodoVM._PeriodoFecFin, VM.PeriodoFecFin),
                    new SqlParameter(clsPeriodoVM._EstadoId, VM.EstadoId)
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
                    mstrStoreProcName = "parPeriodoUpdate";
                    moParameters = new SqlParameter[7]
                    {
                    new SqlParameter("@UpdateFilter", mintUpdateFilter),
                    new SqlParameter(clsPeriodoVM._PeriodoId, VM.PeriodoId),
                    new SqlParameter(clsPeriodoVM._GestionId, VM.GestionId),
                    new SqlParameter(clsPeriodoVM._MesId, VM.MesId),
                    new SqlParameter(clsPeriodoVM._PeriodoFecIni, VM.PeriodoFecIni),
                    new SqlParameter(clsPeriodoVM._PeriodoFecFin, VM.PeriodoFecFin),
                    new SqlParameter(clsPeriodoVM._EstadoId, VM.EstadoId)
                    };

                    break;
            }
        }

        protected override void DeleteParameter()
        {
            switch (mintDeleteFilter)
            {
                case DeleteFilters.All:
                    mstrStoreProcName = "parPeriodoDelete";
                    moParameters = new SqlParameter[2]
                    {
                    new SqlParameter("@DeleteFilter", mintDeleteFilter),
                    new SqlParameter(clsPeriodoVM._PeriodoId, VM.PeriodoId)
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
                        VM.PeriodoId = SysData.ToLong(oDataRow[clsPeriodoVM._PeriodoId]);
                        VM.GestionId = SysData.ToLong(oDataRow[clsPeriodoVM._GestionId]);
                        VM.MesId = SysData.ToLong(oDataRow[clsPeriodoVM._MesId]);

                        VM.PeriodoFecIni = SysData.ToDate(oDataRow[clsPeriodoVM._PeriodoFecIni]);
                        VM.PeriodoFecFin = SysData.ToDate(oDataRow[clsPeriodoVM._PeriodoFecFin]);
                        VM.EstadoId = SysData.ToLong(oDataRow[clsPeriodoVM._EstadoId]);

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
using Parametros.Models.VM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Parametros.Models.DAC
{
    public class clsGestion : clsBase, IDisposable
    {
        public clsGestionVM VM;

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
            GestionDes = 2,
            Grid = 3,
            GestionNro = 4,
            GridCheck = 5,
           
        }

        public enum OrderByFilters : byte
        {
            None = 0,
            GestionId = 1,
            GestionDes = 2,
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
        public clsGestion()
        {
            mstrTableName = "parGestion";
            mstrClassName = "clsGestion";

            PropertyInit();
            FilterInit();
        }

        public clsGestion(string ConnectString) : this()
        {

            moConnection = new SqlConnection();

            mstrConnectionString = ConnectString;
        }

        public clsGestion(SqlConnection oConnection) : this()
        {

            moConnection = oConnection;
        }

        public clsGestion(SqlConnection oConnection, SelectFilters bytSelectFilter) : this()
        {

            moConnection = oConnection;
            mintSelectFilter = bytSelectFilter;
        }

        public clsGestion(SqlConnection oConnection, SelectFilters bytSelectFilter, WhereFilters bytWhereFilter) : this()
        {

            moConnection = oConnection;
            mintSelectFilter = bytSelectFilter;
            mintWhereFilter = bytWhereFilter;
        }

        public clsGestion(SqlConnection oConnection, SelectFilters bytSelectFilter, WhereFilters bytWhereFilter, OrderByFilters bytOrderByFilter) : this()
        {

            moConnection = oConnection;
            mintSelectFilter = bytSelectFilter;
            mintWhereFilter = bytWhereFilter;
            mintOrderByFilter = bytOrderByFilter;
        }

        public void PropertyInit()
        {
            VM = new clsGestionVM();
            VM.GestionId = 0;
            VM.GestionNro = 0;
            VM.GestionFecIni = new DateTime();
            VM.GestionFecFin = new DateTime();
            VM.EstadoId = 0;

        }

        protected override void SelectParameter()
        {
            string strSQL = null;

            mstrStoreProcName = "parGestionSelect";

            switch (mintSelectFilter)
            {
                case SelectFilters.All:
                    strSQL = "  SELECT " +
                        "parGestion.GestionId, "+
                        " parGestion.GestionId, "+
						" parGestion.GestionNro, "+
                        " parGestion.GestionFecIni, "+
                        " parGestion.GestionFecFin, "+
                        " parGestion.EstadoId "+
                        " FROM    parGestion ";

                    break;
                case SelectFilters.RowCount:
                    mstrStoreProcName = "parGestionSelect";

                    break;
                case SelectFilters.ListBox:
                    mstrStoreProcName = "parGestionSelect";

                    break;
                case SelectFilters.Grid:
                    strSQL = "  SELECT " +
                        "parGestion.GestionId, " +
                        " parGestion.GestionId, " +
                        " parGestion.GestionNro, " +
                        " parGestion.GestionFecIni, " +
                        " parGestion.GestionFecFin, " +
                        " parGestion.EstadoId, " +
                        " parEstado.EstadoDes " +
                        " FROM    parGestion " +
                        " LEFT JOIN parEstado ON parGestion.EstadoId=parEstado.EstadoId ";

                    break;
                case SelectFilters.GridCheck:

                    break;

            }

            strSQL += WhereFilterGet() + OrderByFilterGet();
            Array.Resize(ref moParameters, 1);
            moParameters[0] = new SqlParameter("@SQL", strSQL);

            //Call OrderByParameter()
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
                    strSQL = " WHERE parGestion.GestionId = " + SysData.NumberToField(VM.GestionId);
                    break;

                
            }

            return strSQL;
        }


        private string OrderByFilterGet()
        {
            string strSQL = null;

            switch (mintOrderByFilter)
            {
                case OrderByFilters.Grid:
                    strSQL = " ORDER BY parGestion.GestionNro ";
                    break;

                case OrderByFilters.GridCheck:
                    break;

                
            }

            return strSQL;
        }

        // Comentado por Carlos: 
        /*private void WhereParameter()
        {
            switch (mintWhereFilter)
            {
                case WhereFilters.PrimaryKey:
                    Array.Resize(ref moParameters, moParameters.Length + 3);
                    moParameters[3] = new SqlParameter(clsGestionVM._GestionId, VM.GestionId);
                    moParameters[4] = new SqlParameter(clsGestionVM._EstadoId, Convert.ToInt32(0));
                    moParameters[5] = new SqlParameter(clsGestionVM._GestionNro, Convert.ToInt32(0));

                    break;
                case WhereFilters.GestionDes:
                   

                    break;
                case WhereFilters.Grid:
                    Array.Resize(ref moParameters, moParameters.Length + 3);
                    moParameters[3] = new SqlParameter(clsGestionVM._GestionId, Convert.ToInt32(0));
                    moParameters[4] = new SqlParameter(clsGestionVM._EstadoId, Convert.ToInt32(0));
                    moParameters[5] = new SqlParameter(clsGestionVM._GestionNro, Convert.ToInt32(0));
                    break;

                case WhereFilters.GestionNro:
                    Array.Resize(ref moParameters, moParameters.Length + 3);
                    moParameters[3] = new SqlParameter(clsGestionVM._GestionId, Convert.ToInt32(0));
                    moParameters[4] = new SqlParameter(clsGestionVM._EstadoId, Convert.ToInt32(0));
                    moParameters[5] = new SqlParameter(clsGestionVM._GestionNro, VM.GestionNro);
                    break;

            }
        }*/

        protected override void InsertParameter()
        {
            switch (mintInsertFilter)
            {
                case InsertFilters.All:
                    mstrStoreProcName = "parGestionInsert";
                    moParameters = new SqlParameter[6]
                    {
                    new SqlParameter("@InsertFilter", mintInsertFilter),
                    new SqlParameter("@Id", SqlDbType.Int),
                    new SqlParameter(clsGestionVM._GestionNro, VM.GestionNro),
                    new SqlParameter(clsGestionVM._GestionFecIni, VM.GestionFecIni),
                    new SqlParameter(clsGestionVM._GestionFecFin, VM.GestionFecFin),
                    new SqlParameter(clsGestionVM._EstadoId, VM.EstadoId)
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
                    mstrStoreProcName = "parGestionUpdate";
                    moParameters = new SqlParameter[6]
                    {
                    new SqlParameter("@UpdateFilter", mintUpdateFilter),
                    new SqlParameter(clsGestionVM._GestionId, VM.GestionId),
                    new SqlParameter(clsGestionVM._GestionNro, VM.GestionNro),
                    new SqlParameter(clsGestionVM._GestionFecIni, VM.GestionFecIni),
                    new SqlParameter(clsGestionVM._GestionFecFin, VM.GestionFecFin),
                    new SqlParameter(clsGestionVM._EstadoId, VM.EstadoId)
                    };

                    break;
            }
        }

        protected override void DeleteParameter()
        {
            switch (mintDeleteFilter)
            {
                case DeleteFilters.All:
                    mstrStoreProcName = "parGestionDelete";
                    moParameters = new SqlParameter[2]
                    {
                    new SqlParameter("@DeleteFilter", mintDeleteFilter),
                    new SqlParameter(clsGestionVM._GestionId, VM.GestionId)
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
                        VM.GestionId = SysData.ToLong(oDataRow[clsGestionVM._GestionId]);
                        VM.GestionNro = SysData.ToInteger(oDataRow[clsGestionVM._GestionNro]);
                        VM.GestionFecIni = SysData.ToDate(oDataRow[clsGestionVM._GestionFecIni]);
                        VM.GestionFecFin = SysData.ToDate(oDataRow[clsGestionVM._GestionFecFin]);
                        VM.EstadoId = SysData.ToLong(oDataRow[clsGestionVM._EstadoId]);

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

            //If mstrTipoUsuarioCod.Length() = 0 Then
            //    strMsg &= "Ingrese el Código <br />"
            //End If

            //If mstrTipoUsuarioDes.Length() = 0 Then
            //    strMsg &= "Ingrese el TipoUsuario <br />"
            //End If

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
            VM.GestionId = mlngId;
            
        }
    }
}
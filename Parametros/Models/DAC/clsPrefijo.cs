using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Parametros.Models.DAC
{
    public class clsPrefijo : clsBase, IDisposable
    {
        private long mlngPrefijoId;
        private long mlngDocId;
        private long mlngModuloId;
        private long mlngAplicacionId;
        private int mintPrefijoNro;
        private string mstrPrefijoDes;
        private long mlngPrefijoTipo;
        private bool mboolPrefijoIniGes;
        private long mlngFormatoImpId;
        private string mstrMensajeFor;
        private long mlngPrefijoCopiaId;
        private int mintItemMax;
        private bool mboolImprimeUsr;
        private bool mboolImprimeFec;
        private long mlngTipoEncabezadoId;
        private string mstrRazonSoc;
        private string mstrRazonSocAbr;
        private string mstrObsUno;
        private string mstrObsDos;
        private string mstrFirmaUno;
        private string mstrFirmaSeg;
        private string mstrFirmaTre;
        private string mstrFirmaCua;
       
        private long mlngEstadoId;

        //******************************************************
        // Private Data To Match the Table Definition
        //******************************************************
                      
            
        public long PrefijoId { get => mlngPrefijoId; set => mlngPrefijoId = value; }
        public long DocId { get => mlngDocId; set => mlngDocId = value; }
        public long ModuloId { get => mlngModuloId; set => mlngModuloId = value; }
        public long AplicacionId { get => mlngAplicacionId; set => mlngAplicacionId = value; }
        public int PrefijoNro { get => mintPrefijoNro; set => mintPrefijoNro = value; }
        public string PrefijoDes { get => mstrPrefijoDes; set => mstrPrefijoDes = value; }
        public long PrefijoTipo { get => mlngPrefijoTipo; set => mlngPrefijoTipo = value; }
        public bool PrefijoIniGes { get => mboolPrefijoIniGes; set => mboolPrefijoIniGes = value; }
        public long FormatoImpId { get => mlngFormatoImpId; set => mlngFormatoImpId = value; }
        public string MensajeFor { get => mstrMensajeFor; set => mstrMensajeFor = value; }
        public long PrefijoCopiaId { get => mlngPrefijoCopiaId; set => mlngPrefijoCopiaId = value; }
        public int ItemMax { get => mintItemMax; set => mintItemMax = value; }
        public bool ImprimeUsr { get => mboolImprimeUsr; set => mboolImprimeUsr = value; }
        public bool ImprimeFec { get => mboolImprimeFec; set => mboolImprimeFec = value; }
        public long TipoEncabezadoId { get => mlngTipoEncabezadoId; set => mlngTipoEncabezadoId = value; }
        public string RazonSoc { get => mstrRazonSoc; set => mstrRazonSoc = value; }
        public string RazonSocAbr { get => mstrRazonSocAbr; set => mstrRazonSocAbr = value; }
        public string ObsUno { get => mstrObsUno; set => mstrObsUno = value; }
        public string ObsDos { get => mstrObsDos; set => mstrObsDos = value; }
        public string FirmaUno { get => mstrFirmaUno; set => mstrFirmaUno = value; }
        public string FirmaSeg { get => mstrFirmaSeg; set => mstrFirmaSeg = value; }
        public string FirmaTre { get => mstrFirmaTre; set => mstrFirmaTre = value; }
        public string FirmaCua { get => mstrFirmaCua; set => mstrFirmaCua = value; }
        public long EstadoId { get => mlngEstadoId; set => mlngEstadoId = value; }
        public long Id { get => mlngId; set => mlngId = value; }
           


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
            PrefijoNro = 4
        }

        public enum WhereFilters : byte
        {
            None = 0,
            PrimaryKey = 1,           
            Grid = 3,
            Details = 4,
            PrefijoNro = 5,
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
            All = 0,
            PrefijoDes=1
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
        public clsPrefijo()
        {
            mstrTableName = "parPrefijo";
            mstrClassName = "clsPrefijo";

            PropertyInit();
            FilterInit();
        }



        public clsPrefijo(string ConnectString) : this()
        {

            moConnection = new SqlConnection();

            mstrConnectionString = ConnectString;
        }

        public clsPrefijo(SqlConnection oConnection) : this()
        {
            moConnection = oConnection;
        }

        public clsPrefijo(SqlConnection oConnection, SelectFilters bytSelectFilter) : this()
        {
            moConnection = oConnection;
            mintSelectFilter = bytSelectFilter;
        }

        public clsPrefijo(SqlConnection oConnection, SelectFilters bytSelectFilter, WhereFilters bytWhereFilter) : this()
        {
            moConnection = oConnection;
            mintSelectFilter = bytSelectFilter;
            mintWhereFilter = bytWhereFilter;
        }
        
        public clsPrefijo(SqlConnection oConnection, SelectFilters bytSelectFilter, WhereFilters bytWhereFilter, OrderByFilters bytOrderByFilter) : this()
        {
            moConnection = oConnection;
            mintSelectFilter = bytSelectFilter;
            mintWhereFilter = bytWhereFilter;
            mintOrderByFilter = bytOrderByFilter;
        }

        public void PropertyInit()
        {
            mlngPrefijoId=0;
            mlngDocId=0;
            mlngModuloId=0;
            mlngAplicacionId=0;
            mintPrefijoNro=0;
            mstrPrefijoDes = "";
            mlngPrefijoTipo=0;
            mboolPrefijoIniGes=false;
            mlngFormatoImpId=0;
            mstrMensajeFor="";
            mlngPrefijoCopiaId=0;
            mintItemMax=0;
            mboolImprimeUsr=false;
            mboolImprimeFec=false;
            mlngTipoEncabezadoId=0;
            mstrRazonSoc="";
            mstrRazonSocAbr="";
            mstrObsUno="";
            mstrObsDos="";
            mstrFirmaUno="";
            mstrFirmaSeg="";
            mstrFirmaTre="";
            mstrFirmaCua="";
            mlngEstadoId=0;

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
                    mstrStoreProcName = "parPrefijoSelect";

                    break;
                case SelectFilters.RowCount:
                    mstrStoreProcName = "parPrefijoSelect";

                    break;
                case SelectFilters.ListBox:
                    mstrStoreProcName = "parPrefijoSelect";

                    break;
                case SelectFilters.Grid:
                    mstrStoreProcName = "parPrefijoSelect";

                    break;
                case SelectFilters.PrefijoNro:
                    mstrStoreProcName = "parPrefijoSelect";
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
                    Array.Resize(ref moParameters, moParameters.Length + 3);
                    moParameters[3] = new SqlParameter("@PrefijoId", mlngPrefijoId);
                    moParameters[4] = new SqlParameter("@EstadoId", Convert.ToInt32(0));
                    moParameters[5] = new SqlParameter("@PrefijoNro", Convert.ToInt32(0));
                    break;
                                 
                case WhereFilters.Grid:
                    Array.Resize(ref moParameters, moParameters.Length + 3);
                    moParameters[3] = new SqlParameter("@PrefijoId", Convert.ToInt32(0));
                    moParameters[4] = new SqlParameter("@EstadoId", Convert.ToInt32(0));
                    moParameters[5] = new SqlParameter("@PrefijoNro", Convert.ToInt32(0));
                    break;
                case WhereFilters.Details:
                    Array.Resize(ref moParameters, moParameters.Length + 3);
                    moParameters[3] = new SqlParameter("@PrefijoId", mlngPrefijoId);
                    moParameters[4] = new SqlParameter("@EstadoId", Convert.ToInt32(0));
                    moParameters[5] = new SqlParameter("@PrefijoNro", Convert.ToInt32(0));
                    break;
                case WhereFilters.PrefijoNro:
                    Array.Resize(ref moParameters, moParameters.Length + 3);
                    moParameters[3] = new SqlParameter("@PrefijoId", Convert.ToInt32(0));
                    moParameters[4] = new SqlParameter("@EstadoId", Convert.ToInt32(0));
                    moParameters[5] = new SqlParameter("@PrefijoNro", mintPrefijoNro);
                    break;

            }
        }

        protected override void InsertParameter()
        {
            switch (mintInsertFilter)
            {
                case InsertFilters.All:
                    mstrStoreProcName = "parPrefijoInsert";
                    moParameters = new SqlParameter[25]
                    {
                    new SqlParameter("@InsertFilter", mintInsertFilter),
                    new SqlParameter("@Id", SqlDbType.Int),                                
                    new SqlParameter("@DocId", mlngDocId),
                    new SqlParameter("@ModuloId", mlngModuloId),
                    new SqlParameter("@AplicacionId", mlngAplicacionId),                    
                    new SqlParameter("@PrefijoNro", mintPrefijoNro),
                    new SqlParameter("@PrefijoDes", mstrPrefijoDes),
                    new SqlParameter("@PrefijoTipo", mlngPrefijoTipo),
                    new SqlParameter("@PrefijoIniGes", mboolPrefijoIniGes),
                    new SqlParameter("@FormatoImpId", mlngFormatoImpId),
                    new SqlParameter("@MensajeFor", mstrMensajeFor),
                    new SqlParameter("@PrefijoCopiaId", mlngPrefijoCopiaId),
                    new SqlParameter("@ItemMax", mintItemMax),
                    new SqlParameter("@ImprimeUsr", mboolImprimeUsr),
                    new SqlParameter("@ImprimeFec", mboolImprimeFec),
                    new SqlParameter("@TipoEncabezadoId", mlngTipoEncabezadoId),
                    new SqlParameter("@RazonSoc", mstrRazonSoc),
                    new SqlParameter("@RazonSocAbr", mstrRazonSocAbr),
                    new SqlParameter("@ObsUno", mstrObsUno),
                    new SqlParameter("@ObsDos", mstrObsDos),
                    new SqlParameter("@FirmaUno", mstrFirmaUno),
                    new SqlParameter("@FirmaSeg", mstrFirmaSeg),
                    new SqlParameter("@FirmaTre", mstrFirmaTre),
                    new SqlParameter("@FirmaCua", mstrFirmaCua),
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
                    mstrStoreProcName = "parPrefijoUpdate";
                    moParameters = new SqlParameter[25]
                    {
                    new SqlParameter("@UpdateFilter", mintUpdateFilter),
                    new SqlParameter("@PrefijoId", mlngPrefijoId),
                    new SqlParameter("@DocId", mlngDocId),
                    new SqlParameter("@ModuloId", mlngModuloId),
                    new SqlParameter("@AplicacionId", mlngAplicacionId),
                    new SqlParameter("@PrefijoNro", mintPrefijoNro),
                    new SqlParameter("@PrefijoDes", mstrPrefijoDes),
                    new SqlParameter("@PrefijoTipo", mlngPrefijoTipo),
                    new SqlParameter("@PrefijoIniGes", mboolPrefijoIniGes),
                    new SqlParameter("@FormatoImpId", mlngFormatoImpId),
                    new SqlParameter("@MensajeFor", mstrMensajeFor),
                    new SqlParameter("@PrefijoCopiaId", mlngPrefijoCopiaId),
                    new SqlParameter("@ItemMax", mintItemMax),
                    new SqlParameter("@ImprimeUsr", mboolImprimeUsr),
                    new SqlParameter("@ImprimeFec", mboolImprimeFec),
                    new SqlParameter("@TipoEncabezadoId", mlngTipoEncabezadoId),
                    new SqlParameter("@RazonSoc", mstrRazonSoc),
                    new SqlParameter("@RazonSocAbr", mstrRazonSocAbr),
                    new SqlParameter("@ObsUno", mstrObsUno),
                    new SqlParameter("@ObsDos", mstrObsDos),
                    new SqlParameter("@FirmaUno", mstrFirmaUno),
                    new SqlParameter("@FirmaSeg", mstrFirmaSeg),
                    new SqlParameter("@FirmaTre", mstrFirmaTre),
                    new SqlParameter("@FirmaCua", mstrFirmaCua),
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
                    mstrStoreProcName = "parPrefijoDelete";
                    moParameters = new SqlParameter[2]
                    {
                    new SqlParameter("@DeleteFilter", mintDeleteFilter),
                    new SqlParameter("@PrefijoId", mlngPrefijoId)
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
                        mlngPrefijoId = SysData.ToLong(oDataRow["PrefijoId"]);
                        mlngDocId = SysData.ToLong(oDataRow["DocId"]);
                        mlngModuloId = SysData.ToLong(oDataRow["ModuloId"]);
                        mlngAplicacionId = SysData.ToLong(oDataRow["AplicacionId"]);
                        mintPrefijoNro = SysData.ToInteger(oDataRow["PrefijoNro"]);
                        mstrPrefijoDes = SysData.ToStr(oDataRow["PrefijoDes"]);
                        mlngPrefijoTipo = SysData.ToLong(oDataRow["PrefijoTipo"]);
                        mboolPrefijoIniGes = SysData.ToBoolean(oDataRow["PrefijoIniGes"]);                       
                        mlngFormatoImpId = SysData.ToLong(oDataRow["FormatoImpId"]);
                        mstrMensajeFor = SysData.ToStr(oDataRow["MensajeFor"]);

                        mlngPrefijoCopiaId = SysData.ToInteger(oDataRow["PrefijoCopiaId"]);
                        mboolImprimeUsr = SysData.ToBoolean(oDataRow["ImprimeUsr"]);
                        mboolImprimeFec = SysData.ToBoolean(oDataRow["ImprimeFec"]);
                        mlngTipoEncabezadoId = SysData.ToLong(oDataRow["TipoEncabezadoId"]);
                        mstrRazonSoc = SysData.ToStr(oDataRow["RazonSoc"]);

                        mstrRazonSocAbr = SysData.ToStr(oDataRow["RazonSocAbr"]);
                        mstrObsUno= SysData.ToStr(oDataRow["ObsUno"]);
                        mstrObsDos = SysData.ToStr(oDataRow["ObsDos"]);
                        mstrFirmaUno= SysData.ToStr(oDataRow["FirmaUno"]);
                        mstrFirmaSeg = SysData.ToStr(oDataRow["FirmaSeg"]);
                        mstrFirmaTre = SysData.ToStr(oDataRow["FirmaTre"]);
                        mstrFirmaCua = SysData.ToStr(oDataRow["FirmaCua"]);
                        mlngEstadoId = SysData.ToLong(oDataRow["EstadoId"]);
                        break;

                    case SelectFilters.PrefijoNro:
                        mintPrefijoNro = SysData.ToInteger(oDataRow["PrefijoNro"]);

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



    }
}
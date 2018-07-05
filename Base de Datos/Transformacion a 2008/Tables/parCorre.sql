/********************************************************************/
/*  TABLA			: parCorre    								*/
/*  AUTOR			: Joel Mercado									*/
/*  FECHA			: 15/12/2017									*/
/*  DESCRIPCION		: Correlativo de documento por gestion           */
/********************************************************************/

Print 'Creating table dbo.parCorre'

CREATE TABLE parCorre 
(     
   --** Llave
   CorreId			int identity(1,1) NOT NULL,		--** Id. del correlativo
       
   --** Atributos
   PrefijoId        int NOT NULL,					--** Id. del prefijo(parPrefijo)
   DocId			int NOT NULL,					--** ID. del Documento
   GestionId		int NOT NULL,					--** Gestion
   ModuloId	        int NOT NULL,					--** ID. del Modulo(segModulo)
   AplicacionId		int NOT NULL,					--** ID. de aplicacion(segModulo)
   CorreNroAct		int NOT NULL,					--** Contador
   CorreNroMax		int NOT NULL,					--** Limite Superior
   CorreFecIni		datetime NOT NULL,              --** Fecha Inicial
   CorreFecFin		datetime NOT NULL               --** Fecha Final
   
   CONSTRAINT CorrePK PRIMARY KEY NONCLUSTERED (CorreId)
)

GO

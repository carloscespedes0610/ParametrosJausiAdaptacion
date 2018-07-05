/********************************************************************/
/*  TABLA			: parDoc      				        	   	    */
/*  AUTOR			: Joel Mercado									*/
/*  FECHA			: 15/12/2017									*/
/*  DESCRIPCION		: Documento.                                         */
/********************************************************************/

Print 'Creating table dbo.parDoc'

CREATE TABLE parDoc
(
   --** Llave
   DocId			int identity(1,1) NOT NULL,  --** Id. del Doc

   --** Atributos
   DocCod			varchar(05) NOT NULL,        --** Codigo del Documento
   ModuloId			int NOT NULL,                --** ID. del Modulo(segModulo)
   AplicacionId		int NOT NULL,                --** ID. de aplicacion(segModulo)
   DocNem			varchar(50) NOT NULL,        --** Nemonico del Documento
   DocDes			varchar(255) NOT NULL,       --** Descripcion del Documento
   DocIso			varchar(50) NOT NULL,        --** ISO del Documento
   DocRev			varchar(50) NOT NULL,        --** REvision del Documento
   DocFec			varchar(50) NOT NULL,        --** Fecha del Documento
   EstadoId         int NOT NULL                 --** Estado(Activo/Inactivo)

   CONSTRAINT DocPK PRIMARY KEY NONCLUSTERED (DocId)
)

GO

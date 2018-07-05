/********************************************************************/
/*  TABLA			: parTipoRelacion		           	            */
/*  AUTOR			: Joel Mercado									*/
/*  FECHA			: 31/01/2018									*/
/*  DESCRIPCION		:                                               */
/********************************************************************/

Print 'Creating table dbo.parTipoRelacion'
CREATE TABLE dbo.parTipoRelacion
(
   --** Llave
   TipoRelacionId		    int NOT NULL,  --** Id. Tipo Relacion

   --** Atributos     
   TipoRelacionCod          varchar(50) NOT NULL,        --** Codigo del tipo de Relacion
   TipoRelacionDes          varchar(255) NOT NULL,       --** Descripcion del tipo de Relacion
   EstadoId			        int NOT NULL,                --** Estado(Activo/Inactivo)

   CONSTRAINT TipoRelacionPK PRIMARY KEY NONCLUSTERED (TipoRelacionId)
)

GO
  
/********************************************************************/
/*  TABLA			: parTipoEntidad		           	            */
/*  AUTOR			: Joel Mercado									*/
/*  FECHA			: 31/01/2018									*/
/*  DESCRIPCION		:                                               */
/********************************************************************/

Print 'Creating table dbo.parTipoEntidad'
CREATE TABLE dbo.parTipoEntidad
(
   --** Llave
   TipoEntidadId		   int NOT NULL,  --** Id. Tipo Entidad

   --** Atributos     
   TipoEntidadCod          varchar(50) NOT NULL,        --** Codigo del tipo de Entidad
   TipoEntidadDes          varchar(255) NOT NULL,       --** Descripcion del tipo de Entidad
   EstadoId			       int NOT NULL,                --** Estado(Activo/Inactivo)

   CONSTRAINT TipoEntidadPK PRIMARY KEY NONCLUSTERED (TipoEntidadId)
)

GO
  
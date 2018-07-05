/********************************************************************/
/*  TABLA			: parEstado								*/
/*  AUTOR			: Joel Mercado									*/
/*  FECHA			: 15/12/2017									*/
/*  DESCRIPCION		:									            */
/********************************************************************/

Print 'Creating table dbo.parEstado'
CREATE TABLE dbo.parEstado
(
   EstadoId			int NOT NULL,  --** Id. del tipo de usuario 

   EstadoCod		varchar(50) NOT NULL,        --** Codigo del tipo de usuario
   EstadoDes		varchar(255) NOT NULL,       --** Descripcion del tipo de usuario
   AplicacionId     int NOT NULL                 --** Estado(Activo/Inactivo)

   CONSTRAINT EstadoPK PRIMARY KEY NONCLUSTERED(EstadoId)
)

GO

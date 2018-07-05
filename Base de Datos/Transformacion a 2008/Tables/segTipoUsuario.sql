/********************************************************************/
/*  TABLA			: segTipoUsuario								*/
/*  AUTOR			: Joel Mercado									*/
/*  FECHA			: 15/12/2017									*/
/*  DESCRIPCION		:									            */
/********************************************************************/

Print 'Creating table dbo.segTipoUsuario'
CREATE TABLE dbo.segTipoUsuario
(
   TipoUsuarioId    int identity(1,1) NOT NULL,  --** Id. del tipo de usuario 

   TipoUsuarioCod   varchar(50) NOT NULL,        --** Codigo del tipo de usuario
   TipoUsuarioDes   varchar(255) NOT NULL,       --** Descripcion del tipo de usuario
   EstadoId         int NOT NULL                 --** Estado(Activo/Inactivo)

   CONSTRAINT TipoUsuarioPK PRIMARY KEY NONCLUSTERED(TipoUsuarioId)
)

GO

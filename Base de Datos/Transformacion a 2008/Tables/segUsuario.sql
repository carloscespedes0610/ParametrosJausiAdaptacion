/********************************************************************/
/*  TABLA			: segUsuario							   	    */
/*  AUTOR			: Joel Mercado									*/
/*  FECHA			: 15/12/2017									*/
/*  DESCRIPCION		:									            */
/********************************************************************/

Print 'Creating table dbo.segUsuario'
CREATE TABLE dbo.segUsuario
(
   --** Llave
   UsuarioId		int identity(1,1) NOT NULL,  --** Id. Del Usuario

   --** Atributos
   UsuarioCod		varchar(50) NOT NULL,   --** Codigo del Usuario
   UsuarioDes		varchar(255) NOT NULL,	--** Nombre del Usuario
   TipoUsuarioId	int NOT NULL,           --** Tipo Usuario(segTipoUsuario)
   UsuarioDocPath	varchar(255) NULL,      --** El Camino de los doc. del usuario
   UsuarioFotoPath	varchar(255) NULL,      --** El camino de la foto del usuario
   UsuarioMaxSes	int NOT NULL,           --** Nro. maximo de sesiones del usuario
   EstadoId			int NOT NULL			--** Estado(Activo/Inactivo

   CONSTRAINT UsuarioPK PRIMARY KEY NONCLUSTERED(UsuarioId)
)

GO
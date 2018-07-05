/********************************************************************/
/*  TABLA			: parTipoCaracte    	           	        */
/*  AUTOR			: Joel Mercado									*/
/*  FECHA			: 31/01/2018									*/
/*  DESCRIPCION		: Tipo de Caracteristica de persona             */
/********************************************************************/

Print 'Creating table dbo.parTipoCaracteristica'
CREATE TABLE dbo.parTipoCaracte
(
   --** Llave
   TipoCaracteId		int identity(1,1) NOT NULL,  --** Id. Del tipo de caracteristica
   --** Atributos
   TipoInfoId	int NOT NULL,           --** Tipo de informacion
     												--** 1 General; 2 Ventas; 3 Compras
													--** 4 Personal
   TipoCaracteDes	varchar(255) NOT NULL,	--** Descripcion del tipo de caracteristica
   CaracteId			int NOT NULL,            --** Caracteristica por defecto
   EstadoId			        int NOT NULL           --** Estado(Activo/Inactivo
  CONSTRAINT TipoCaractePK PRIMARY KEY CLUSTERED(TipoCaracteId)
)
GO

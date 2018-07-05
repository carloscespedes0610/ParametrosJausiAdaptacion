/********************************************************************/
/*  TABLA			: parTipoCaracteristica	    	           	        */
/*  AUTOR			: Joel Mercado									*/
/*  FECHA			: 31/01/2018									*/
/*  DESCRIPCION		: Tipo de Caracteristica de persona             */
/********************************************************************/

Print 'Creating table dbo.parTipoCaracteristica'
CREATE TABLE dbo.parTipoCaracteristica
(
   --** Llave
   TipoCaracteristicaId		int identity(1,1) NOT NULL,  --** Id. Del tipo de caracteristica
   --** Atributos
   TipoInfoId	int NOT NULL,           --** Tipo de informacion
     												--** 1 General; 2 Ventas; 3 Compras
													--** 4 Personal
   TipoCaracteristicaDes	varchar(255) NOT NULL,	--** Descripcion del tipo de caracteristica
   CaracteristicaId			int NOT NULL,            --** Caracteristica por defecto
   EstadoId			        int NOT NULL           --** Estado(Activo/Inactivo
  CONSTRAINT TipoCaracteristicaPK PRIMARY KEY CLUSTERED(TipoCaracteristicaId)
)
GO

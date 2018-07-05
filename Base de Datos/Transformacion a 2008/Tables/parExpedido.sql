/********************************************************************/
/*  TABLA			: parExpedido		           	            */
/*  AUTOR			: Joel Mercado									*/
/*  FECHA			: 31/01/2018									*/
/*  DESCRIPCION		:                                               */
/********************************************************************/

Print 'Creating table dbo.parExpedido'
CREATE TABLE dbo.parExpedido
(
   --** Llave
   ExpedidoId			int identity(1,1) NOT NULL,  --** Id. Tipo Entidad

   --** Atributos     
   ExpedidoCod          varchar(50) NOT NULL,        --** Codigo del tipo de Entidad
   ExpedidoDes          varchar(255) NOT NULL,       --** Descripcion del tipo de Entidad
   EstadoId			    int NOT NULL,                --** Estado(Activo/Inactivo)

   CONSTRAINT ExpedidoPK PRIMARY KEY NONCLUSTERED (ExpedidoId)
)

GO
  
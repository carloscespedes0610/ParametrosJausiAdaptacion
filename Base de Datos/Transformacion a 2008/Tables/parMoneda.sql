/********************************************************************/
/*  TABLA			: parMoneda								*/
/*  AUTOR			: Joel Mercado									*/
/*  FECHA			: 15/12/2017									*/
/*  DESCRIPCION		:									            */
/********************************************************************/

Print 'Creating table dbo.parMoneda'
CREATE TABLE dbo.parMoneda
(
   MonedaId    int NOT NULL,  --** Id. del tipo de usuario 

   MonedaCod   varchar(50) NOT NULL,        --** Codigo del tipo de usuario
   MonedaDes   varchar(255) NOT NULL       --** Descripcion del tipo de usuario

   CONSTRAINT MonedaPK PRIMARY KEY NONCLUSTERED(MonedaId)
)

GO

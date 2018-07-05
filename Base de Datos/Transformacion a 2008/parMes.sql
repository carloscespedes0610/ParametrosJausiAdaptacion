/********************************************************************/
/*  TABLA			: parMes								*/
/*  AUTOR			: Joel Mercado									*/
/*  FECHA			: 15/12/2017									*/
/*  DESCRIPCION		:									            */
/********************************************************************/

Print 'Creating table dbo.parMes'
CREATE TABLE dbo.parMes
(
   MesId    int NOT NULL,  --** Id. del tipo de usuario 

   MesCod   varchar(50) NOT NULL,        --** Codigo del tipo de usuario
   MesDes   varchar(255) NOT NULL       --** Descripcion del tipo de usuario

   CONSTRAINT MesPK PRIMARY KEY NONCLUSTERED(MesId)
)

GO

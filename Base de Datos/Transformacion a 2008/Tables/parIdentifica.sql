/********************************************************************/
/*  TABLA			: parIdentifica		           	            */
/*  AUTOR			: Joel Mercado									*/
/*  FECHA			: 31/01/2018									*/
/*  DESCRIPCION		:                                               */
/********************************************************************/

Print 'Creating table dbo.parIdentifica'
CREATE TABLE dbo.parIdentifica
(
   --** Llave
   IdentificaId			  int identity(1,1) NOT NULL,  --** Id. Tipo Entidad
   
   --** Atributos     
   IdentificaCod          varchar(50) NOT NULL,        --** Codigo del tipo de Entidad
   IdentificaDes          varchar(255) NOT NULL,       --** Descripcion del tipo de Entidad
   EstadoId			      int NOT NULL,                --** Estado(Activo/Inactivo)

   CONSTRAINT IdentificaPK PRIMARY KEY NONCLUSTERED (IdentificaId)
)

GO
  
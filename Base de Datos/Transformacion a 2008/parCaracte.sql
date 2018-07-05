/********************************************************************/
/*  TABLA			: parCaracteristica   	            */
/*  AUTOR			: Joel Mercado									*/
/*  FECHA			: 31/01/2018									*/
/*  DESCRIPCION		: Definicion de Caracteristicas de las persona  */
/********************************************************************/

Print 'Creating table dbo.parCaracteristica'
CREATE TABLE dbo.parCaracte
(
   --** Llave
   CaracteId		int identity(1,1) NOT NULL,  --** Id. caracteristica
   --** Atributos
   TipoCaracteId	int NOT NULL,            --** Id. Del tipo de caracteristica
   CaracteDes    varchar(255) NOT NULL,	 --** Descripcion de la caracteristica
   EstadoId			    int NOT NULL             --** Estado(Activo/Inactivo   
   CONSTRAINT CaractePK PRIMARY KEY NONCLUSTERED (CaracteId)
)
GO

/********************************************************************/
/*  TABLA			: segAutorizacion   					   	    */
/*  AUTOR			: Joel Mercado									*/
/*  FECHA			: 15/12/2017									*/
/*  DESCRIPCION		: Autorizacion a usuario por item.              */
/********************************************************************/
	 
Print 'Creating table dbo.segAutoriza'

CREATE TABLE segAutoriza
(
   --** Llave
   AutorizaId		int identity(1,1) NOT NULL,  --** Id. de la Autorizacion

   --** Atributos
   ModuloId	        int NOT NULL,                --** ID. del Modulo(segModulo)
   TipoUsuarioId	int NOT NULL,				 --** Id. Del Usuario(segUsuario)   
   AutorizaDes		varchar(50) NOT NULL,        --** Nombre de la Tabla.
   AutorizaItemId	int NOT NULL,                 --** Id Item autorizado
   RegistroId		int NOT NULL                 --** Id Item autorizado

   CONSTRAINT AutorizaPK PRIMARY KEY NONCLUSTERED (AutorizaId)
)
GO


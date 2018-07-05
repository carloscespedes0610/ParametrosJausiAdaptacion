/********************************************************************/
/*  TABLA			: parPersonaCaracte			    	            */
/*  AUTOR			: Joel Mercado									*/
/*  FECHA			: 31/01/2018									*/
/*  DESCRIPCION		: Caracteristicas de las personas               */
/********************************************************************/

Print 'Creating table dbo.parPersonaCaracte'
CREATE TABLE dbo.parPersonaCaracte
(
   --** Llave
   PersonaCaracteId	      int identity(1,1) NOT NULL,  --** Id. caracteristica personas

   --** Atributos
   PersonaId		      int NOT NULL,                --** Id. de la persona
   TipoCaracteId		  int NOT NULL,                --** Id. Del tipo de caracteristica      
   CaracteId		      int NOT NULL                 --** Id. caracteristica

   CONSTRAINT PersonaCaractePK PRIMARY KEY NONCLUSTERED (PersonaCaracteId)
)

GO
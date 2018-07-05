/********************************************************************/
/*  TABLA			: parPersonaInfo		           	    */
/*  AUTOR			: Joel Mercado									*/
/*  FECHA			: 31/01/2018									*/
/*  DESCRIPCION		: Informacion Adicional de persona              */
/********************************************************************/

Print 'Creating table dbo.parPersonaInfo'
CREATE TABLE dbo.parPersonaInfo
(
   --** Llave
   PersonaInfoId		int identity(1,1) NOT NULL,  --** Id. Informacion Persona
   
   --** Atributos
   PersonaId		    int NOT NULL,                 --** Id. de la persona
   InfoAdicionalId		int NOT NULL,                --** Id. InformacionAdicional
   InfoAdicionalObs     Varchar(255) NOT NULL        --** Observacion <Información adicional

   CONSTRAINT PersonaInfoPK PRIMARY KEY NONCLUSTERED (PersonaInfoId)
)

GO
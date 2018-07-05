/********************************************************************/
/*  TABLA			: parTipoPersona		           	            */
/*  AUTOR			: Joel Mercado									*/
/*  FECHA			: 31/01/2018									*/
/*  DESCRIPCION		:                                               */
/********************************************************************/

Print 'Creating table dbo.parTipoPersona'
CREATE TABLE dbo.parTipoPersona
(
   --** Llave
   TipoPersonaId		    int identity(1,1) NOT NULL,		--** Id. Tipo Persona

   --** Atributos     
   TipoPersonaCod           varchar(50) NOT NULL,			--** Codigo del tipo de persona
   TipoPersonaDes           varchar(255) NOT NULL,			--** Descripcion del tipo de persona
   TipoRelacionId           int NOT NULL,					--** Id. Tipo de relacion con la empresa
   EstadoId			        int NOT NULL					--** Estado(Activo/Inactivo)
															--** (C=Cliente; P=Proveedor; E=Empleado)

   CONSTRAINT TipoPersonaPK PRIMARY KEY NONCLUSTERED (TipoPersonaId)
)

GO
  
/********************************************************************/
/*  TABLA			: ctbPlanGrupoTipo						   	    */
/*  AUTOR			: Joel Mercado									*/
/*  FECHA			: 02/01/2018									*/
/*  DESCRIPCION		: Grupo de Centro de Costo.  		            */
/********************************************************************/

Print 'Creating table dbo.ctbPlanGrupoTipo'
CREATE TABLE dbo.ctbPlanGrupoTipo
(
   --** Llave
   PlanGrupoTipoId	int identity(1,1) NOT NULL,		--** Id. Del grupo de C.C.

   --** Atributos 
   PlanGrupoTipoCod	varchar(50) NOT NULL,			--** Codigo del grupo de C.C.
   PlanGrupoTipoDes	varchar(255) NOT NULL,			--** Nombre del Grupo C.C.
   PlanGrupoTipoEsp	varchar(255) NULL,				--** Descripcion Grupo C.C.
   EstadoId	  		int NOT NULL					--** Estado(Activo/Inactivo

   CONSTRAINT PlanGrupoTipoPK PRIMARY KEY NONCLUSTERED (PlanGrupoTipoId)
)

GO

 
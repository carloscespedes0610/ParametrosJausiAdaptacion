/********************************************************************/
/*  TABLA			: ctbPlanGrupoTipoDet						   	            */
/*  AUTOR			: Joel Mercado									*/
/*  FECHA			: 02/01/2018									*/
/*  DESCRIPCION		: Centro de Costo.  		                    */
/********************************************************************/

Print 'Creating table dbo.ctbPlanGrupoTipoDet'
CREATE TABLE dbo.ctbPlanGrupoTipoDet
(
   --** Llave
   PlanGrupoTipoDetId	    int identity(1,1) NOT NULL,		--** Id. Del Centro de Costo

   --** Atributos
   PlanGrupoTipoId			int NOT NULL,					--** Id. Del grupo Centro de Costo(conGrupoPlanGrupoTipoDet)
   PlanGrupoTipoDetCod	    varchar(50) NOT NULL,			--** Codigo del Centro de Costo
   PlanGrupoTipoDetDes	    varchar(255) NOT NULL,			--** Nombre del Centro de Costo
   PlanGrupoTipoDetEsp	    varchar(255) NULL,				--** Descripcion Centro de Costo
   EstadoId	  				int NOT NULL					--** Estado(Activo/Inactivo

   CONSTRAINT PlanGrupoTipoDetPK PRIMARY KEY NONCLUSTERED (PlanGrupoTipoDetId)
)

GO

 
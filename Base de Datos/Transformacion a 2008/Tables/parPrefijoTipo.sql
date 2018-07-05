/********************************************************************/
/*  TABLA			: parPrefijoTipo							*/
/*  AUTOR			: Carlos Cespedes									*/
/*  FECHA			: 05/07/2018									*/
/*  DESCRIPCION		: Establece el Tipo de Prefijo(Manual o Automatico).
					  Script creado durante el trabajo de Transformación
					  de B.D. Sql Server 2014 a 2008R2, del módulo Parametros,
					  la tabla estaba creada pero no existia el script.										            */
/********************************************************************/

Print 'Creating table dbo.parFormatoImp'
CREATE TABLE dbo.parPrefijoTipo
(
   PrefijoTipoId			int NOT NULL,  --** Id. del Formato de Impresion

   PrefijoTipoDes		varchar(255) NOT NULL       --** Descripcion del Formato de Impresion

   CONSTRAINT PrefijoTipoPK PRIMARY KEY NONCLUSTERED(PrefijoTipoId)
)

GO

/********************************************************************/
/*  TABLA			: parTipoEncabezado						*/
/*  AUTOR			: Carlos Cespedes									*/
/*  FECHA			: 05/07/2018									*/
/*  DESCRIPCION		: Establece el Tipo de Encabezado
					  (ej: Nombre de la Empresa, Razon Social).
					  Script creado durante el trabajo de Transformación
					  de B.D. Sql Server 2014 a 2008R2, del módulo Parametros,
					  la tabla estaba creada pero no existia el script.										            */
/********************************************************************/

Print 'Creating table dbo.parTipoEncabezado'
CREATE TABLE dbo.parTipoEncabezado
(
   TipoEncabezadoId			int NOT NULL,  --** Id. del Tipo de Encabezado

   TipoEncabezadoDes		varchar(255) NOT NULL       --** Descripcion del Tipo de Encabezado

   CONSTRAINT TipoEncabezadoPK PRIMARY KEY NONCLUSTERED(TipoEncabezadoId)
)

GO

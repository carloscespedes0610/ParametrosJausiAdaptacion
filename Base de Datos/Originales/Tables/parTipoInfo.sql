/********************************************************************/
/*  TABLA			: parTipoInfo		           	    */
/*  AUTOR			: Joel Mercado									*/
/*  FECHA			: 31/01/2018									*/
/*  DESCRIPCION		: Informacion Adicional de persona              */
/********************************************************************/

Print 'Creating table dbo.parTipoInfo'
CREATE TABLE dbo.parTipoInfo
(
   --** Llave
--   TipoInfoId	    int identity(1,1) NOT NULL,  --** Id. parTipoInfo
   TipoInfoId	    int NOT NULL,  --** Id. parTipoInfo
   --** Atributos
   TipoInfoDes     Varchar(255) NOT NULL,        --** Descripcion Información adicional
   EstadoId       int NOT NULL                --** Estado 

   CONSTRAINT TipoInfoPK PRIMARY KEY NONCLUSTERED (TipoInfoId)
)
GO

INSERT INTO parTipoInfo(TipoInfoId,TipoInfoDes,EstadoId) VALUES (1,'Generales'	,101)
INSERT INTO parTipoInfo(TipoInfoId,TipoInfoDes,EstadoId) VALUES (2,'Ventas'		,101)
INSERT INTO parTipoInfo(TipoInfoId,TipoInfoDes,EstadoId) VALUES (3,'Compras'	,101)
INSERT INTO parTipoInfo(TipoInfoId,TipoInfoDes,EstadoId) VALUES (4,'Iventarios'	,101)
INSERT INTO parTipoInfo(TipoInfoId,TipoInfoDes,EstadoId) VALUES (5,'Zonas'		,101)
INSERT INTO parTipoInfo(TipoInfoId,TipoInfoDes,EstadoId) VALUES (6,'Rutas'		,101)
INSERT INTO parTipoInfo(TipoInfoId,TipoInfoDes,EstadoId) VALUES (7,'Personal'	,101)


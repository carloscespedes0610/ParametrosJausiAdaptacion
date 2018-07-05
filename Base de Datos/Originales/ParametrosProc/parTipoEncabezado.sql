/*
Navicat SQL Server Data Transfer

Source Server         : DEV9
Source Server Version : 120000
Source Host           : (local):1433
Source Database       : Jausi
Source Schema         : dbo

Target Server Type    : SQL Server
Target Server Version : 120000
File Encoding         : 65001

Date: 2018-07-04 17:41:34
*/


-- ----------------------------
-- Procedure structure for parTipoEncabezadoSelect
-- ----------------------------
DROP PROCEDURE [parTipoEncabezadoSelect]
GO
CREATE PROCEDURE [parTipoEncabezadoSelect]
	@SelectFilter smallint,
	@WhereFilter smallint,
	@OrderByFilter smallint,
	@TipoEncabezadoId int
AS
BEGIN
	IF (@SelectFilter =0)       --All
		AND (@WhereFilter=1)			--PrimaryKey
		BEGIN
			SELECT TipoEncabezadoId,
						 TipoEncabezadoDes						
			FROM 	parTipoEncabezado
			WHERE  parTipoEncabezado.TipoEncabezadoId=@TipoEncabezadoId

		END
	ELSE IF (@SelectFilter = 3)
				AND (@WhereFilter=3)
	BEGIN
		SELECT   TipoEncabezadoId,
						 TipoEncabezadoDes
						 
			FROM 	parTipoEncabezado
						
			ORDER BY parTipoEncabezado.TipoEncabezadoDes
	END
END

GO

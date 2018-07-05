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

Date: 2018-07-04 17:39:35
*/


-- ----------------------------
-- Procedure structure for parPrefijoTipoSelect
-- ----------------------------
DROP PROCEDURE [parPrefijoTipoSelect]
GO
CREATE PROCEDURE [parPrefijoTipoSelect]
	@SelectFilter smallint,
	@WhereFilter smallint,
	@OrderByFilter smallint,
	@PrefijoTipoId int
AS
BEGIN
	IF (@SelectFilter =0)       --All
		AND (@WhereFilter=1)			--PrimaryKey
		BEGIN
			SELECT PrefijoTipoId,
						 PrefijoTipoDes						
			FROM 	parPrefijoTipo
			WHERE  parPrefijoTipo.PrefijoTipoId=@PrefijoTipoId

		END
	ELSE IF (@SelectFilter = 3)
				AND (@WhereFilter=3)
	BEGIN
		SELECT   PrefijoTipoId,
						 PrefijoTipoDes
						 
			FROM 	parPrefijoTipo
						
			ORDER BY parPrefijoTipo.PrefijoTipoDes
	END
END

GO

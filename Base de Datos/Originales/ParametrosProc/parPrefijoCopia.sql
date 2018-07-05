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

Date: 2018-07-04 17:40:24
*/


-- ----------------------------
-- Procedure structure for parPrefijoCopiaSelect
-- ----------------------------
DROP PROCEDURE [parPrefijoCopiaSelect]
GO
CREATE PROCEDURE [parPrefijoCopiaSelect]
	@SelectFilter smallint,
	@WhereFilter smallint,
	@OrderByFilter smallint,
	@PrefijoCopiaId int
AS
BEGIN
	IF (@SelectFilter =0)       --All
		AND (@WhereFilter=1)			--PrimaryKey
		BEGIN
			SELECT PrefijoCopiaId,
						 PrefijoCopiaDes						
			FROM 	parPrefijoCopia
			WHERE  parPrefijoCopia.PrefijoCopiaId=@PrefijoCopiaId

		END
	ELSE IF (@SelectFilter = 3)
				AND (@WhereFilter=3)
	BEGIN
		SELECT   PrefijoCopiaId,
						 PrefijoCopiaDes						 
			FROM 	parPrefijoCopia						
			ORDER BY parPrefijoCopia.PrefijoCopiaId
	END
END

GO

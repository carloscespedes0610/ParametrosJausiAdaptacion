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

Date: 2018-07-04 17:37:41
*/


-- ----------------------------
-- Procedure structure for parFormatoImpSelect
-- ----------------------------
DROP PROCEDURE [parFormatoImpSelect]
GO
CREATE PROCEDURE [parFormatoImpSelect]
	@SelectFilter smallint,
	@WhereFilter smallint,
	@OrderByFilter smallint,
	@FormatoImpId int
AS
BEGIN
	IF (@SelectFilter =0)       --All
		AND (@WhereFilter=1)			--PrimaryKey
		BEGIN
			SELECT FormatoImpId,
						 FormatoImpDes						
			FROM 	parFormatoImp
			WHERE  parFormatoImp.FormatoImpId=@FormatoImpId

		END
	ELSE IF (@SelectFilter = 3)
				AND (@WhereFilter=3)
	BEGIN
		SELECT   FormatoImpId,
						 FormatoImpDes
						 
			FROM 	parFormatoImp
						
			ORDER BY parFormatoImp.FormatoImpDes
	END
END

GO

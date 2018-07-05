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

Date: 2018-07-04 17:36:04
*/


-- ----------------------------
-- Procedure structure for parCorrelativoDelete
-- ----------------------------
DROP PROCEDURE [parCorrelativoDelete]
GO
CREATE PROCEDURE [parCorrelativoDelete]
		@DeleteFilter smallint,
		@CorreId INT
AS
BEGIN
	 IF EXISTS ( 
			SELECT CorreId
			FROM parCorre
			WHERE CorreId=@CorreId
		)
		BEGIN
			IF @DeleteFilter = 0 --ALL
			BEGIN
					DELETE 
					FROM parCorre
					WHERE CorreId=@CorreId
			END
		END
END
GO

-- ----------------------------
-- Procedure structure for parCorrelativoInsert
-- ----------------------------
DROP PROCEDURE [parCorrelativoInsert]
GO
CREATE PROCEDURE [parCorrelativoInsert]
	@InsertFilter smallint,
	@Id int OUT,	
	@DocId AS INT,
	@PrefijoId AS INT,
	@GestionId AS INT,
	@ModuloId AS INT,
	@AplicacionId AS INT,
	@CorreNroAct AS INT,
	@CorreNroMax AS INT,
	@CorreFecIni AS DATE,
	@CorreFecFin AS DATE

AS
BEGIN
	IF @InsertFilter = 0	--All
	BEGIN
		IF NOT EXISTS (	SELECT	CorreId 
					FROM	parCorre
					WHERE	PrefijoId = @PrefijoId AND GestionId=@GestionId)
		BEGIN
			INSERT INTO parCorre(
				DocId,
				PrefijoId,
				GestionId,
				ModuloId,
				AplicacionId,
				CorreNroAct,
				CorreNroMax,
				CorreFecIni,
				CorreFecFin
			)VALUES(
				@DocId,
				@PrefijoId,
				@GestionId,
				@ModuloId,
				@AplicacionId,
				@CorreNroAct,
				@CorreNroMax,
				@CorreFecIni,
				@CorreFecFin
			)
		SET @Id = SCOPE_IDENTITY()
		END
		ELSE
		BEGIN
			RAISERROR('Correlativo duplicado', 16, 1)
			RETURN
		END
	END
END

GO

-- ----------------------------
-- Procedure structure for parCorrelativoSelect
-- ----------------------------
DROP PROCEDURE [parCorrelativoSelect]
GO
CREATE PROCEDURE [parCorrelativoSelect]
	@SelectFilter smallint,
	@WhereFilter smallint,
	@OrderByFilter smallint,
	@CorreId int 
AS
BEGIN
	IF (@SelectFilter =0)       --All
		AND (@WhereFilter=1)			--PrimaryKey
		BEGIN
			SELECT parCorre.CorreId,
						 parCorre.PrefijoId,	
						 parCorre.DocId,	
						 parCorre.GestionId,				 
						 parCorre.ModuloId,
						 parCorre.AplicacionId,
						 parCorre.CorreNroAct,
						 parCorre.CorreNroMax,
						 parCorre.CorreFecIni,
						 parCorre.CorreFecFin
			FROM 	parCorre
			WHERE  CorreId=@CorreId
		END

	ELSE IF (@SelectFilter = 3) --GRID
				AND (@WhereFilter=3)
	BEGIN
		SELECT   parCorre.CorreId,
						 parCorre.PrefijoId,
						 parPrefijo.PrefijoDes,
						 parCorre.DocId,
						 parDoc.DocCod,
						 parDoc.DocDes,
						 parCorre.GestionId,
						 parGestion.GestionNro,
						 parCorre.ModuloId,
						 segModulo.ModuloDes,
						 parCorre.AplicacionId,
						 segAplicacion.AplicacionDes,
						 parCorre.CorreNroAct,
						 parCorre.CorreNroMax,
						 parCorre.CorreFecIni,
						 parCorre.CorreFecFin
			FROM 	parCorre
						LEFT JOIN parDoc ON parCorre.DocId=parDoc.DocId
						LEFT JOIN parPrefijo ON parCorre.PrefijoId=parPrefijo.PrefijoId
						LEFT JOIN parGestion ON parCorre.GestionId=parGestion.GestionId 
						LEFT JOIN segModulo ON parCorre.ModuloId=segModulo.ModuloId
			  		LEFT JOIN segAplicacion ON parCorre.AplicacionId=segAplicacion.AplicacionId
												
			
  END
  ELSE IF (@SelectFilter = 0) --All
				 AND (@WhereFilter=4)--Details
	BEGIN
			SELECT   parCorre.CorreId,
						 parCorre.PrefijoId,
						 parPrefijo.PrefijoDes,
						 parPrefijo.PrefijoNro,
						 parCorre.DocId,
						 parDoc.DocCod,
						 parDoc.DocDes,
						 parCorre.GestionId,
						 parGestion.GestionNro,
						 parCorre.ModuloId,
						 segModulo.ModuloDes,
						 parCorre.AplicacionId,
						 segAplicacion.AplicacionDes,
						 parCorre.CorreNroAct,
						 parCorre.CorreNroMax,
						 parCorre.CorreFecIni,
						 parCorre.CorreFecFin
			FROM 	parCorre
						LEFT JOIN parDoc ON parCorre.DocId=parDoc.DocId
						LEFT JOIN parPrefijo ON parCorre.PrefijoId=parPrefijo.PrefijoId
						LEFT JOIN parGestion ON parCorre.GestionId=parGestion.GestionId 
						LEFT JOIN segModulo ON parCorre.ModuloId=segModulo.ModuloId
			  		LEFT JOIN segAplicacion ON parCorre.AplicacionId=segAplicacion.AplicacionId
		WHERE parCorre.CorreId=@CorreId
	END
END

GO

-- ----------------------------
-- Procedure structure for parCorrelativoUpdate
-- ----------------------------
DROP PROCEDURE [parCorrelativoUpdate]
GO
CREATE PROCEDURE [parCorrelativoUpdate]
	@UpdateFilter smallint,
	@CorreId AS INT,
	@PrefijoId AS INT,	
	@DocId AS INT,	
	@GestionId AS INT,				 
	@ModuloId AS INT,
	@AplicacionId AS INT,
	@CorreNroAct AS INT,
	@CorreNroMax AS INT,
	@CorreFecIni AS DATE,
	@CorreFecFin AS DATE
AS
BEGIN
	IF @UpdateFilter=0  --All
	BEGIN
		DECLARE @Id INT
		SET @Id=0

		SELECT @Id=CorreId
		FROM parCorre
		WHERE parCorre.CorreId=@CorreId
		IF @Id>0
		BEGIN
				IF NOT EXISTS(
					SELECT CorreId
					FROM parCorre
					WHERE PrefijoId=@PrefijoId 
						AND GestionId=@GestionId
						AND CorreId<> @CorreId
				)
				BEGIN
					 UPDATE parCorre
					 SET						
						PrefijoId= @PrefijoId,	
						DocId= @DocId,	
						GestionId=	@GestionId,				 
						ModuloId=	@ModuloId,
						AplicacionId=	@AplicacionId,
						CorreNroAct=	@CorreNroAct,
						CorreNroMax=	@CorreNroMax,
						CorreFecIni=	@CorreFecIni,
						CorreFecFin=	@CorreFecFin
					WHERE CorreId=@CorreId
				END
				ELSE
				BEGIN
					RAISERROR('Correlativo duplicado',16,1)
					RETURN
				END
		END
	END
END

GO

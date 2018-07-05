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

Date: 2018-07-04 17:36:56
*/


-- ----------------------------
-- Procedure structure for parDocDelete
-- ----------------------------
DROP PROCEDURE [parDocDelete]
GO
CREATE PROCEDURE [parDocDelete]
		@DeleteFilter smallint,
		@DocId INT
AS
BEGIN
	 IF EXISTS ( 
			SELECT DocId
			FROM parDoc
			WHERE DocId=@DocId
		)
		BEGIN
			IF @DeleteFilter = 0 --ALL
			BEGIN
					DELETE 
					FROM parDoc
					WHERE DocId=@DocId
			END
		END
END
GO

-- ----------------------------
-- Procedure structure for parDocInsert
-- ----------------------------
DROP PROCEDURE [parDocInsert]
GO
CREATE PROCEDURE [parDocInsert]
			@InsertFilter smallint,
			@Id int OUT,	
			@DocCod VARCHAR(5),
			@DocDes VARCHAR(255),
			@DocNem VARCHAR(50),
			@DocIso VARCHAR(50),
			@DocRev VARCHAR(50),
			@DocFec DATE,
			@ModuloId INTEGER,
			@AplicacionId INTEGER,
			@EstadoId INTEGER
AS
BEGIN
	IF NOT EXISTS (	SELECT	DocCod 
					FROM	parDoc
					WHERE	DocCod = @DocCod) 
	BEGIN
		IF @InsertFilter = 0	--All
		BEGIN
			INSERT INTO parDoc(DocCod, 										
										DocDes,
										DocNem,
										DocIso,
										DocRev,
										DocFec,
										ModuloId,
										AplicacionId,
										EstadoId)
								VALUES (@DocCod, 
										@DocDes, 
										@DocNem,
										@DocIso,
										@DocRev,
										@DocFec,
										@ModuloId,
										@AplicacionId,
										@EstadoId)
		
			SET @Id = SCOPE_IDENTITY()
		END
	END
	ELSE
	BEGIN
		RAISERROR('Nro de gestión Duplicado', 16, 1)
		RETURN
    END 
END

GO

-- ----------------------------
-- Procedure structure for parDocSelect
-- ----------------------------
DROP PROCEDURE [parDocSelect]
GO
CREATE PROCEDURE [parDocSelect]
	@SelectFilter smallint,
	@WhereFilter smallint,
	@OrderByFilter smallint,
	@DocId int,
  @EstadoId int 
AS
BEGIN
	IF (@SelectFilter =0)       --All
		AND (@WhereFilter=1)			--PrimaryKey
		BEGIN
			SELECT parDoc.DocId,
						 parDoc.DocCod,
						 parDoc.DocDes,
						 parDoc.DocNem,
						 parDoc.DocIso,
						 parDoc.DocRev,
						 parDoc.DocFec,
						 parDoc.ModuloId,
						 parDoc.AplicacionId,
						 parDoc.EstadoId
			FROM 	parDoc
			WHERE  DocId=@DocId

		END
	ELSE IF (@SelectFilter = 3)
				AND (@WhereFilter=3)
	BEGIN
		SELECT   parDoc.DocId,
						 parDoc.DocCod,
						 parDoc.DocDes,
						 parDoc.DocNem,
						 parDoc.DocIso,
						 parDoc.DocRev,
						 parDoc.DocFec,
						 parDoc.ModuloId,
						 segModulo.ModuloDes,
						 parDoc.AplicacionId,
						 segAplicacion.AplicacionDes,						
						 parDoc.EstadoId,
						 parEstado.EstadoDes
			FROM 	parDoc,segAplicacion, segModulo, parEstado
			WHERE parDoc.AplicacionId=segAplicacion.AplicacionId
							AND parDoc.ModuloId=segModulo.ModuloId
							AND parDoc.EstadoId=parEstado.EstadoId
			ORDER BY parDoc.DocDes
	END
END

GO

-- ----------------------------
-- Procedure structure for parDocUpdate
-- ----------------------------
DROP PROCEDURE [parDocUpdate]
GO
CREATE PROCEDURE [parDocUpdate]
	@UpdateFilter SMALLINT,
	@DocId INTEGER,
	@DocCod  VARCHAR(5),
	@DocNem VARCHAR(50),
	@DocDes VARCHAR(255),
	@ModuloId INTEGER,
	@AplicacionId INTEGER,
	@DocIso VARCHAR(50),
	@DocRev VARCHAR(50),
	@DocFec VARCHAR(50),
	@EstadoId INTEGER
AS
BEGIN
	DECLARE @Id int 
		SET @Id = 0

		SELECT	@Id = DocId 
		FROM	parDoc
		WHERE	parDoc.DocId = @DocId
		
		IF (@Id > 0)
		BEGIN 
		IF @UpdateFilter = 0	--All
		BEGIN
				IF NOT EXISTS (
						SELECT DocCod
						FROM parDoc
						WHERE DocCod = @DocCod
							AND DocId <> @DocId
				)
				BEGIN 
						UPDATE parDoc
						SET					
						DocNem=@DocNem,
						DocDes=@DocDes ,
						ModuloId=@ModuloId,
						AplicacionId=@AplicacionId,
						DocIso=@DocIso,
						DocRev=@DocRev,
						DocFec=@DocFec,
						EstadoId=@EstadoId
						WHERE DocId=@DocId
				END
				ELSE
				BEGIN
					RAISERROR('Documento duplicado',16,1)
					RETURN
				END			  
		END
		END
END

GO

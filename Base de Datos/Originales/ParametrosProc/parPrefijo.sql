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

Date: 2018-07-04 17:38:54
*/


-- ----------------------------
-- Procedure structure for parPrefijoDelete
-- ----------------------------
DROP PROCEDURE [parPrefijoDelete]
GO
CREATE PROCEDURE [parPrefijoDelete]
	@DeleteFilter smallint,
	@PrefijoId INT
AS
BEGIN
	IF @DeleteFilter = 0 --ALL
	BEGIN
		 IF EXISTS ( 
			SELECT PrefijoId
			FROM parPrefijo
			WHERE PrefijoId=@PrefijoId
		 )
		BEGIN
				DELETE
				FROM parPrefijo
				WHERE PrefijoId=@PrefijoId				
		END
	END
END

GO

-- ----------------------------
-- Procedure structure for parPrefijoInsert
-- ----------------------------
DROP PROCEDURE [parPrefijoInsert]
GO
CREATE PROCEDURE [parPrefijoInsert]
			@InsertFilter smallint,
			@Id int OUT,	
			@DocId INT,
		  @ModuloId INT,
			@AplicacionId INT,
			@PrefijoNro INT,
			@PrefijoDes VARCHAR(255),
			@PrefijoTipo INT,
			@PrefijoIniGes INT,
			@FormatoImpId INT,
			@MensajeFor VARCHAR(255),
			@PrefijoCopiaId INT,
			@ItemMax INT,
			@ImprimeUsr BIT,
			@ImprimeFec BIT,
			@TipoEncabezadoId INT,
			@RazonSoc VARCHAR(255),
			@RazonSocAbr VARCHAR(100),
			@ObsUno VARCHAR(255),
			@ObsDos VARCHAR(255),
			@FirmaUno VARCHAR(100),
			@FirmaSeg VARCHAR(100),
			@FirmaTre VARCHAR(100),
			@FirmaCua VARCHAR(100),
			@EstadoId INT
AS
BEGIN
	IF NOT EXISTS (	SELECT	PrefijoNro 
					FROM	parPrefijo
					WHERE	PrefijoNro = @PrefijoNro) 
	BEGIN
		IF @InsertFilter = 0	--All
		BEGIN
			INSERT INTO parPrefijo(DocId,
												ModuloId,
												AplicacionId,
												PrefijoNro,
												PrefijoDes,
												PrefijoTipo,
												PrefijoIniGes,
												FormatoImpId,
												MensajeFor,
												PrefijoCopiaId,
												ItemMax,
												ImprimeUsr,
												ImprimeFec,
												TipoEncabezadoId,
												RazonSoc,
												RazonSocAbr,
												ObsUno,
												ObsDos,
												FirmaUno,
												FirmaSeg,
												FirmaTre,
												FirmaCua,
												EstadoId)
								VALUES (@DocId,
												@ModuloId,
												@AplicacionId,
												@PrefijoNro,
												@PrefijoDes,
												@PrefijoTipo,
												@PrefijoIniGes,
												@FormatoImpId,
												@MensajeFor,
												@PrefijoCopiaId,
												@ItemMax,
												@ImprimeUsr,
												@ImprimeFec,
												@TipoEncabezadoId,
												@RazonSoc,
												@RazonSocAbr,
												@ObsUno,
												@ObsDos,
												@FirmaUno,
												@FirmaSeg,
												@FirmaTre,
												@FirmaCua,
												@EstadoId)
		
			SET @Id = SCOPE_IDENTITY()
		END
	END
	ELSE
	BEGIN
		RAISERROR('Nro prefijo Duplicado', 16, 1)
		RETURN
    END 
END

GO

-- ----------------------------
-- Procedure structure for parPrefijoSelect
-- ----------------------------
DROP PROCEDURE [parPrefijoSelect]
GO
CREATE PROCEDURE [parPrefijoSelect]
	@SelectFilter smallint,
	@WhereFilter smallint,
	@OrderByFilter smallint,
	@PrefijoId int,
  @EstadoId int,
  @PrefijoNro int 
AS
BEGIN
	IF (@SelectFilter =0)       --All
		AND (@WhereFilter=1)			--PrimaryKey
		BEGIN
			SELECT parPrefijo.PrefijoId,
						 parPrefijo.DocId,
						 parPrefijo.ModuloId,
						 parPrefijo.AplicacionId,
						 parPrefijo.PrefijoNro,
						 parPrefijo.PrefijoDes,
						 parPrefijo.PrefijoTipo,
						 parPrefijo.PrefijoIniGes,
						 parPrefijo.FormatoImpId,
						 parPrefijo.MensajeFor,

						 parPrefijo.PrefijoCopiaId,
						 parPrefijo.ImprimeUsr,
						 parPrefijo.ImprimeFec,
						 parPrefijo.TipoEncabezadoId,
						 parPrefijo.RazonSoc,

						 parPrefijo.RazonSocAbr,
						 parPrefijo.ObsUno,
						 parPrefijo.ObsDos,
						 parPrefijo.FirmaUno,
						 parPrefijo.FirmaSeg,
						 parPrefijo.FirmaTre,
						 parPrefijo.FirmaCua,
						 parPrefijo.EstadoId
			FROM 	parPrefijo
			WHERE  PrefijoId=@PrefijoId

		END
	ELSE IF (@SelectFilter = 3) --GRID
				AND (@WhereFilter=3)
	BEGIN
		SELECT   parPrefijo.PrefijoId,
						 parPrefijo.DocId,
						 parDoc.DocDes,
						 parDoc.DocNem,
						 parPrefijo.ModuloId,
						 segModulo.ModuloDes,
						 parPrefijo.AplicacionId,
						 segAplicacion.AplicacionDes,
						 parPrefijo.PrefijoDes,
						 parPrefijo.PrefijoNro,
						 parPrefijo.PrefijoTipo,
						 parPrefijoTipo.PrefijoTipoDes,
						 parPrefijo.PrefijoIniGes,
						 parPrefijo.FormatoImpId,
						 parFormatoImp.FormatoImpDes,
						 parPrefijo.MensajeFor,

						 parPrefijo.PrefijoCopiaId,
						 parPrefijoCopia.PrefijoCopiaDes,
						 parPrefijo.ItemMax,
						 parPrefijo.ImprimeUsr,
						 parPrefijo.ImprimeFec,
						 parPrefijo.TipoEncabezadoId,
						 parTipoEncabezado.TipoEncabezadoDes,
						 parPrefijo.RazonSoc,

						 parPrefijo.RazonSocAbr,
						 parPrefijo.ObsUno,
						 parPrefijo.ObsDos,
						 parPrefijo.FirmaUno,
						 parPrefijo.FirmaSeg,
						 parPrefijo.FirmaTre,
						 parPrefijo.FirmaCua,
						 parPrefijo.EstadoId,
						 parEstado.EstadoDes
			FROM 	parPrefijo
						LEFT JOIN parDoc ON parPrefijo.DocId=parDoc.DocId
						LEFT JOIN segModulo ON parPrefijo.ModuloId=segModulo.ModuloId
						LEFT JOIN segAplicacion ON parPrefijo.AplicacionId=segAplicacion.AplicacionId
						LEFT JOIN parPrefijoTipo ON parPrefijo.PrefijoTipo=parPrefijoTipo.PrefijoTipoId
			  		LEFT JOIN parTipoEncabezado ON parPrefijo.TipoEncabezadoId=parTipoEncabezado.TipoEncabezadoId
						LEFT JOIN parFormatoImp ON parPrefijo.FormatoImpId=parFormatoImp.FormatoImpId
						LEFT JOIN parPrefijoCopia ON parPrefijo.PrefijoCopiaId=parPrefijoCopia.PrefijoCopiaId
						LEFT JOIN parEstado ON parPrefijo.EstadoId=parEstado.EstadoId
			ORDER BY parPrefijo.PrefijoNro
  END
  ELSE IF (@SelectFilter = 0) --All
				AND (@WhereFilter=4)--Details
	BEGIN
			SELECT parPrefijo.PrefijoId,
						 parPrefijo.DocId,
						 parDoc.DocDes,
						 parDoc.DocNem,
						 parPrefijo.ModuloId,
						 segModulo.ModuloDes,
						 parPrefijo.AplicacionId,
						 segAplicacion.AplicacionDes,
						 parPrefijo.PrefijoDes,
						 parPrefijo.PrefijoNro,
						 parPrefijo.PrefijoTipo,
						 parPrefijoTipo.PrefijoTipoDes,
						 parPrefijo.PrefijoIniGes,
						 parPrefijo.FormatoImpId,
						 parFormatoImp.FormatoImpDes,
						 parPrefijo.MensajeFor,

						 parPrefijo.PrefijoCopiaId,
						 parPrefijoCopia.PrefijoCopiaDes,
						 parPrefijo.ItemMax,
						 parPrefijo.ImprimeUsr,
						 parPrefijo.ImprimeFec,
						 parPrefijo.TipoEncabezadoId,
						 parTipoEncabezado.TipoEncabezadoDes,
						 parPrefijo.RazonSoc,

						 parPrefijo.RazonSocAbr,
						 parPrefijo.ObsUno,
						 parPrefijo.ObsDos,
						 parPrefijo.FirmaUno,
						 parPrefijo.FirmaSeg,
						 parPrefijo.FirmaTre,
						 parPrefijo.FirmaCua,
						 parPrefijo.EstadoId,
						 parEstado.EstadoDes
			FROM 	parPrefijo
						LEFT JOIN parDoc ON parPrefijo.DocId=parDoc.DocId 
						LEFT JOIN parPrefijoTipo ON parPrefijo.PrefijoTipo=parPrefijoTipo.PrefijoTipoId
			  		LEFT JOIN parTipoEncabezado ON parPrefijo.TipoEncabezadoId=parTipoEncabezado.TipoEncabezadoId
						LEFT JOIN parFormatoImp ON parPrefijo.FormatoImpId=parFormatoImp.FormatoImpId
						LEFT JOIN parPrefijoCopia ON parPrefijo.PrefijoCopiaId=parPrefijoCopia.PrefijoCopiaId
						LEFT JOIN segModulo ON parPrefijo.ModuloId=segModulo.ModuloId
						LEFT JOIN segAplicacion ON parPrefijo.AplicacionId=segAplicacion.AplicacionId
						LEFT JOIN parEstado ON parPrefijo.EstadoId=parEstado.EstadoId
		WHERE parPrefijo.PrefijoId=@PrefijoId
	END
	ELSE IF (@SelectFilter=4)--PrefijoNro
	BEGIN
		select PrefijoNro
		from parPrefijo
		where PrefijoNro=@PrefijoNro
	END
END

GO

-- ----------------------------
-- Procedure structure for parPrefijoUpdate
-- ----------------------------
DROP PROCEDURE [parPrefijoUpdate]
GO
CREATE PROCEDURE [parPrefijoUpdate]
	@UpdateFilter smallint,
			@PrefijoId INT,	
			@DocId INT,
		  @ModuloId INT,
			@AplicacionId INT,
			@PrefijoNro INT,
			@PrefijoDes VARCHAR(255),
			@PrefijoTipo INT,
			@PrefijoIniGes INT,
			@FormatoImpId INT,
			@MensajeFor VARCHAR(255),
			@PrefijoCopiaId INT,
			@ItemMax INT,
			@ImprimeUsr BIT,
			@ImprimeFec BIT,
			@TipoEncabezadoId INT,
			@RazonSoc VARCHAR(255),
			@RazonSocAbr VARCHAR(100),
			@ObsUno VARCHAR(255),
			@ObsDos VARCHAR(255),
			@FirmaUno VARCHAR(100),
			@FirmaSeg VARCHAR(100),
			@FirmaTre VARCHAR(100),
			@FirmaCua VARCHAR(100),
			@EstadoId INT
AS
BEGIN
	IF @UpdateFilter = 0	--All
	BEGIN
		DECLARE @Id int 
		SET @Id = 0

		SELECT	@Id = PrefijoId 
		FROM	parPrefijo
		WHERE	parPrefijo.PrefijoId = @PrefijoId
		IF @Id>0
		BEGIN
				IF NOT EXISTS(
						SELECT PrefijoNro
						FROM 	parPrefijo
						WHERE PrefijoNro=@PrefijoNro
							AND PrefijoId<>@PrefijoId
				)
				BEGIN
						UPDATE parPrefijo
						SET
						DocId=@DocId,
						ModuloId=@ModuloId,
						AplicacionId=@AplicacionId,
						PrefijoNro=@PrefijoNro,
						PrefijoDes=@PrefijoDes,
						PrefijoTipo=@PrefijoTipo,
						PrefijoIniGes=@PrefijoIniGes,
						FormatoImpId=@FormatoImpId,
						MensajeFor=@MensajeFor,
						PrefijoCopiaId=@PrefijoCopiaId,
						ItemMax=@ItemMax,
						ImprimeUsr=@ImprimeUsr,
						ImprimeFec=@ImprimeFec,
						TipoEncabezadoId=@TipoEncabezadoId,
						RazonSoc=@RazonSoc,
						RazonSocAbr=@RazonSocAbr,
						ObsUno=@ObsUno,
						ObsDos=@ObsDos,
						FirmaUno=@FirmaUno,
						FirmaSeg=@FirmaSeg,
						FirmaTre=@FirmaTre,
						FirmaCua=@FirmaCua,
						EstadoId=@EstadoId
						WHERE PrefijoId=@PrefijoId
				END
				ELSE
				BEGIN
					RAISERROR('Prefijo duplicado',16,1)
					RETURN
				END		
		END
	END
END

GO

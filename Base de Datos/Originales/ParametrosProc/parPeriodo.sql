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

Date: 2018-07-04 17:35:24
*/


-- ----------------------------
-- Procedure structure for parPeriodoDelete
-- ----------------------------
DROP PROCEDURE [parPeriodoDelete]
GO
CREATE PROCEDURE [parPeriodoDelete]
		@DeleteFilter smallint,
		@PeriodoId INT
AS
BEGIN
	 IF EXISTS ( 
			SELECT PeriodoId
			FROM parPeriodo
			WHERE PeriodoId=@PeriodoId
		)
		BEGIN
			IF @DeleteFilter = 0 --ALL
			BEGIN
					DELETE 
					FROM parPeriodo
					WHERE PeriodoId=@PeriodoId
			END
		END
END

GO

-- ----------------------------
-- Procedure structure for parPeriodoInsert
-- ----------------------------
DROP PROCEDURE [parPeriodoInsert]
GO
CREATE PROCEDURE [parPeriodoInsert]
			@InsertFilter smallint,
			@Id int OUT,			
			@GestionId INTEGER,
			@MesId INTEGER,			
			@PeriodoFecIni DATE,
			@PeriodoFecFin DATE,
			@EstadoId int
AS
BEGIN
	IF NOT EXISTS (SELECT MesId 
				FROM parPeriodo
				WHERE MesId=@MesId and GestionId=@GestionId)
	BEGIN
			IF @InsertFilter=0 --ALL
			BEGIN
				INSERT INTO parPeriodo(GestionId,MesId,PeriodoFecIni,PeriodoFecFin,EstadoId)
										VALUES(@GestionId,@MesId,@PeriodoFecIni,@PeriodoFecFin,@EstadoId)
				SET @Id = SCOPE_IDENTITY()
			END
  END
	ELSE 
	BEGIN
		RAISERROR('Mes duplicado para la gestión', 16, 1)
		RETURN
	END
END

GO

-- ----------------------------
-- Procedure structure for parPeriodoSelect
-- ----------------------------
DROP PROCEDURE [parPeriodoSelect]
GO
CREATE PROCEDURE [parPeriodoSelect] 
	@SQL varchar(MAX) 
AS
BEGIN
	EXEC(@SQL)
END

GO

-- ----------------------------
-- Procedure structure for parPeriodoUpdate
-- ----------------------------
DROP PROCEDURE [parPeriodoUpdate]
GO
CREATE PROCEDURE [parPeriodoUpdate]
		@UpdateFilter smallint,
		@PeriodoId INTEGER,
		@GestionId INTEGER,
		@MesId INTEGER,			
		@PeriodoFecIni DATE,
		@PeriodoFecFin DATE,
		@EstadoId INTEGER
AS
BEGIN
		DECLARE @Id int 
		SET @Id = 0

		SELECT	@Id = PeriodoId 
		FROM	parPeriodo
		WHERE	parPeriodo.PeriodoId = @PeriodoId
		
		IF (@Id > 0)
		BEGIN 
		IF @UpdateFilter = 0	--All
		BEGIN
				IF NOT EXISTS (
						SELECT MesId
						FROM parPeriodo
						WHERE GestionId = @GestionId 
							AND MesId = @MesId
							AND PeriodoId <> @PeriodoId
				)
				BEGIN 
						UPDATE parPeriodo
						SET
						GestionId=@GestionId,
						MesId=@MesId,
						PeriodoFecIni=@PeriodoFecIni,
						PeriodoFecFin=@PeriodoFecFin,
						EstadoId=@EstadoId
						WHERE PeriodoId=@PeriodoId
				END
				ELSE
				BEGIN
					RAISERROR('Periodo duplicado para la gestion',16,1)
					RETURN
				END			  
		END
		END
END

GO

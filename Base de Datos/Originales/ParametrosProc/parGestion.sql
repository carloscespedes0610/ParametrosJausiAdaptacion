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

Date: 2018-07-04 17:34:34
*/


-- ----------------------------
-- Procedure structure for parGestionDelete
-- ----------------------------
DROP PROCEDURE [parGestionDelete]
GO
CREATE PROCEDURE [parGestionDelete]
		@DeleteFilter smallint,
		@GestionId int
AS
BEGIN
	IF EXISTS (	SELECT	GestionId 
				FROM	parGestion 
				WHERE	GestionId = @GestionId) 
	BEGIN
		IF @DeleteFilter = 0 --All
		BEGIN

			IF NOT EXISTS(SELECT PeriodoId
								FROM parPeriodo
								WHERE GestionId=@GestionId)
			BEGIN			
					DELETE
					FROM   parGestion
					WHERE  GestionId = @GestionId
			END
			ELSE
			BEGIN
			RAISERROR('La gestión ya tiene periodos asignados', 16, 1)
			RETURN
  END 
		END
	END
	ELSE
	BEGIN
		RAISERROR('ID de Gestión No Encontrado', 16, 1)
		RETURN
  END 
END

GO

-- ----------------------------
-- Procedure structure for parGestionInsert
-- ----------------------------
DROP PROCEDURE [parGestionInsert]
GO
CREATE PROCEDURE [parGestionInsert]
			@InsertFilter smallint,
			@Id int OUT, 
			@GestionNro INTEGER,
			@GestionFecIni DATE,
			@GestionFecFin DATE,
			@EstadoId int
AS
BEGIN
  IF NOT EXISTS (	SELECT	GestionNro 
					FROM	parGestion 
					WHERE	GestionNro = @GestionNro) 
	BEGIN
		IF @InsertFilter = 0	--All
		BEGIN
			INSERT INTO parGestion(GestionNro, 										
										GestionFecIni,
										GestionFecFin,
										EstadoId)
								VALUES (@GestionNro, 
										@GestionFecIni, 
										@GestionFecFin,
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
-- Procedure structure for parGestionSelect
-- ----------------------------
DROP PROCEDURE [parGestionSelect]
GO

CREATE PROCEDURE [parGestionSelect] 
	@SQL varchar(MAX) 
AS
BEGIN
	EXEC(@SQL)
END

GO

-- ----------------------------
-- Procedure structure for parGestionUpdate
-- ----------------------------
DROP PROCEDURE [parGestionUpdate]
GO
CREATE PROCEDURE [parGestionUpdate]
			@UpdateFilter smallint,
			@GestionId INT, 
			@GestionNro INTEGER,
			@GestionFecIni DATE,
			@GestionFecFin DATE,
			@EstadoId int
AS 
BEGIN
	DECLARE @Id int 
	SET @Id = 0

	SELECT	@Id = GestionId 
	FROM	parGestion 
	WHERE	parGestion.GestionId = @GestionId 
	
	IF (@Id > 0)
	BEGIN
		IF @UpdateFilter = 0	--All
		BEGIN			
			IF NOT EXISTS (	SELECT	GestionNro 
							FROM	parGestion 
							WHERE	GestionNro = @GestionNro
							AND		GestionId <> @GestionId)
			BEGIN	
				UPDATE	parGestion
				SET		GestionNro = @GestionNro, 
						GestionFecIni = @GestionFecIni, 
						GestionFecFin = @GestionFecFin, 
						EstadoId = @EstadoId 
				WHERE	GestionId = @GestionId
			END
			ELSE
			BEGIN
				RAISERROR('Número de gestión Duplicado', 16, 1)
				RETURN
			END 
		END
		
		
		 
	END
	ELSE
	BEGIN
		RAISERROR('ID de Gestión No Encontrado', 16, 1)
		RETURN
    END 
END

GO

		
		
/************************************************************/
/*  STORE PROCEDURE	: parGestionSelect				*/
/*  AUTOR			: Joel Mercado          		*/
/*  MODIFICACION	: Carlos Cespedes (06/10/2018)	*/
/*  FECHA			: 05/07/2018					*/
/*  DESCRIPCION		: 						    */
/***********************************************************/
	
IF OBJECT_ID('parGestionSelect') IS NOT NULL
BEGIN 
    DROP PROC parGestionSelect 
END 
GO
CREATE PROC parGestionSelect 
	@SQL varchar(MAX) 
AS
BEGIN
	EXEC(@SQL)
END
GO

----------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------

IF OBJECT_ID('parGestionInsert') IS NOT NULL
BEGIN 
    DROP PROC parGestionInsert	 
END 
GO
CREATE PROC parGestionInsert
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

----------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------

IF OBJECT_ID('parGestionUpdate') IS NOT NULL
BEGIN 
    DROP PROC parGestionUpdate 
END 
GO
CREATE PROC parGestionUpdate
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

----------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------

IF OBJECT_ID('parGestionDelete') IS NOT NULL
BEGIN 
    DROP PROC parGestionDelete 
END 
GO
CREATE PROC parGestionDelete 
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



	
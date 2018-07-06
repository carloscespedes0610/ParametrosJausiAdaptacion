		
/************************************************************/
/*  STORE PROCEDURE	: parPeriodoSelect				*/
/*  AUTOR			: Joel Mercado          		*/
/*  FECHA			: 28/03/2018					*/
/*  MODIFICACION	: Carlos Cespedes (06/07/2018)	*/
/*  DESCRIPCION		: 						    */
/***********************************************************/
	
IF OBJECT_ID('parPeriodoSelect') IS NOT NULL
BEGIN 
    DROP PROC parPeriodoSelect 
END 
GO
CREATE PROC parPeriodoSelect 
	@SQL varchar(MAX) 
AS
BEGIN
	EXEC(@SQL)
END
GO

----------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------

IF OBJECT_ID('parPeriodoInsert') IS NOT NULL
BEGIN 
    DROP PROC parPeriodoInsert	 
END 
GO
CREATE PROC parPeriodoInsert
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
----------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------

IF OBJECT_ID('parPeriodoUpdate') IS NOT NULL
BEGIN 
    DROP PROC parPeriodoUpdate 
END 
GO
CREATE PROC parPeriodoUpdate
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

----------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------

IF OBJECT_ID('parPeriodoDelete') IS NOT NULL
BEGIN 
    DROP PROC parPeriodoDelete 
END 
GO
CREATE PROC parPeriodoDelete 
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

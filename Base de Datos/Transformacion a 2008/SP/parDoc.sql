		
/************************************************************/
/*  STORE PROCEDURE	: parDocSelect				*/
/*  AUTOR			: Joel Mercado          		*/
/*  MODIFICACION	: Carlos Cespedes (06/07/2018)	*/
/*  FECHA			: 28/03/2018					*/
/*  DESCRIPCION		: 						    */
/***********************************************************/
	
IF OBJECT_ID('parDocSelect') IS NOT NULL
BEGIN 
    DROP PROC parDocSelect 
END 
GO
CREATE PROC parDocSelect 
	@SQL varchar(MAX) 
AS
BEGIN
	EXEC(@SQL)
END
GO

----------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------

IF OBJECT_ID('parDocInsert') IS NOT NULL
BEGIN 
    DROP PROC parDocInsert	 
END 
GO
CREATE PROC parDocInsert
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
		RAISERROR('Nro de Documento Duplicado', 16, 1)
		RETURN
    END 
END

GO

----------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------

IF OBJECT_ID('parDocUpdate') IS NOT NULL
BEGIN 
    DROP PROC parDocUpdate 
END 
GO
CREATE PROC parDocUpdate
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


----------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------

IF OBJECT_ID('parDocDelete') IS NOT NULL
BEGIN 
    DROP PROC parDocDelete 
END 
GO
CREATE PROC parDocDelete 
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

	
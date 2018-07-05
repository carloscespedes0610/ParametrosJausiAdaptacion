/********************************************************************/
/*  TABLA			: parDefault       					   	        */
/*  AUTOR			: Joel Mercado									*/
/*  FECHA			: 15/12/2017									*/
/*  DESCRIPCION		: Datos por defecto                             */
/********************************************************************/

Print 'Creating table dbo.parDefault'

CREATE TABLE parDefault 
(
   --** Llave
   DefaultId        int identity(1,1) NOT NULL,  --** Id. del default

   --** Atributos
   ModuloId	        int NOT NULL,               --** ID. del Modulo(segModulo)
   UsuarioId		int NOT NULL,               --** Id. Del Usuario(segUsuario)
   DefaultCod       int NOT NULL,               --** Codigo por Defecto.
   DefaultDes       varchar(255) NOT NULL,		--** Descripcion del default
   DefaultTipo		int NOT NULL,				--** Tipo de Parametro
												--** 1=Entero;2=Decimal;
												--** 3=Caracter; 4=Fecha
												--** 5= booleam
   DefaultCar		varchar(100) NULL,			--** Default caracter
   DefaultEnt		int NULL,					--** Default Entero
   DefaultDec		decimal(18,5) NULL,			--** Default Decimal
   DefaultFec		datetime NULL,				--** Default Fecha
   DefaultBoo		bit NULL					--** Default booleano

   CONSTRAINT DefaultPK PRIMARY KEY NONCLUSTERED (DefaultId)
)

GO

/********************************************************************/
/*  TABLA			: parParametro      					   	    */
/*  AUTOR			: Joel Mercado									*/
/*  FECHA			: 15/12/2017									*/
/*  DESCRIPCION		: Parametros por aplicacion.                        */
/********************************************************************/
	 
Print 'Creating table dbo.parParametro'

CREATE TABLE parParametro 
(
   --** Llave
   ParametroId		int identity(1,1) NOT NULL,		--** Id. del parametro

   --** Atributos
   ModuloId	        int NOT NULL,					--** ID. del Modulo(segModulo)
   AplicacionId	    int NOT NULL,					--** ID. del Modulo(segModulo)
   ParametroCod     int NOT NULL,					--** Codigo 
   ParametroDes     varchar(255) NOT NULL,			--** Descripcion 
   ParametroTipo    int NOT NULL,					--** Tipo de Parametro
													--** 1=Entero;2=Decimal;
													--** 3=Caracter; 4=Fecha
													--** 5= booleam
   ParametroCar     varchar(100) NULL,				--** Parametro caracter
   ParametroEnt     int NULL,						--** Parametro Entero
   ParametroDec     decimal(18,5) NULL,				--** Parametro Decimal
   ParametroFec     datetime NULL,					--** Parametro Fecha
   ParametroBoo     bit NULL						--** Parametro booleano

   CONSTRAINT ParametroPK PRIMARY KEY NONCLUSTERED (ParametroId)
 )

 GO
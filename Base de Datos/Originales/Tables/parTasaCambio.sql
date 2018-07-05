/********************************************************************/
/*  TABLA			: parTasaCambio        					   	    */
/*  AUTOR			: Joel Mercado									*/
/*  FECHA			: 15/12/2017									*/
/*  DESCRIPCION		: Tasa de Cambio / UFV.                         */
/********************************************************************/
	 
Print 'Creating table dbo.parTasaCambio'

CREATE TABLE parTasaCambio 
(
   --** Llave
   TasaCambioId    int identity(1,1) NOT NULL,  --** Id. de la TC.

   --** Atributos
   TasaCambioFec   datetime NOT NULL,           --** Fecha de tasa de cambio/ufv
   TasaCambioVal   decimal(18,5) NOT NULL,      --** Valor de la Tasa de Cambio
   TasaCambioUfv   decimal(18,5) NOT NULL		--** Valor de Ufv

   CONSTRAINT TasaCambioPK PRIMARY KEY NONCLUSTERED (TasaCambioId)
)

GO

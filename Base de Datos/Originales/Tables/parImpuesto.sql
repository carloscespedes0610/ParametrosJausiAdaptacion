/********************************************************************/
/*  TABLA			: parImpuesto        					   	    */
/*  AUTOR			: Joel Mercado									*/
/*  FECHA			: 15/12/2017									*/
/*  DESCRIPCION		: Tasas de Impuestos                            */
/********************************************************************/
	 
Print 'Creating table dbo.parImpuesto'

CREATE TABLE parImpuesto
(
   --** Llave
   ImpuestoId      int identity(1,1) NOT NULL,  --** Id. de impuesto

   --** Atributos
   FechaIni     datetime NULL,				  --** Fecha de tasa de impuesto.
   IVA			decimal(18,5) NOT NULL,       --** % IVA.
   IT			decimal(18,5) NOT NULL,       --** % I.T.R.
   ITF			decimal(18,5) NOT NULL,       --** % I.T.F.
   IUE			decimal(18,5) NOT NULL,       --** % I.U.E.
   RET_SER		decimal(18,5) NOT NULL,       --** % Retencion I.U.E. Servicios
   RET_BIE		decimal(18,5) NOT NULL,       --** % Retencion I.U.E. Bienes
   RC_IVA		decimal(18,5) NOT NULL,       --** % RC - I.V.A.
   IVA_POL		decimal(18,5) NOT NULL        --** % RC - I.V.A. POLIZAS

   CONSTRAINT ImpuestoPK PRIMARY KEY NONCLUSTERED (ImpuestoId)
)

GO

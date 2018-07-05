/********************************************************************/
/*  TABLA			: parPeriodo        					   	    */
/*  AUTOR			: Joel Mercado									*/
/*  FECHA			: 15/12/2017									*/
/*  DESCRIPCION		: Periodo.                                      */
/********************************************************************/
	 
Print 'Creating table dbo.parPeriodo'

CREATE TABLE parPeriodo 
(
   --** Llave
   PeriodoId       int identity(1,1) NOT NULL,  --** Id. del periodo

   --** Atributos
   GestionId       int NOT NULL,               --** Gestion del periodo
   MesId		   int NOT NULL,               --** Nro. del periodo
   PeriodoFecIni   datetime NOT NULL,          --** Fecha inicial
   PeriodoFecFin   datetime NOT NULL,          --** Fecha Final
   EstadoId        int NOT NULL                --** Estado(Activo/Inactivo)

   CONSTRAINT PeriodoPK PRIMARY KEY NONCLUSTERED (PeriodoId) 
)

GO

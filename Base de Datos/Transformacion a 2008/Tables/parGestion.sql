/********************************************************************/
/*  TABLA			: parGestion        					   	    */
/*  AUTOR			: Joel Mercado									*/
/*  FECHA			: 15/12/2017									*/
/*  DESCRIPCION		: Gestion.                                      */
/********************************************************************/
	 
Print 'Creating table dbo.parGestion'

CREATE TABLE parGestion 
(
   --** Llave
   GestionId       int identity(1,1) NOT NULL,  --** Id. del periodo

   --** Atributos
   GestionNro      int NOT NULL,                --** Nro. Gestion
   GestionFecIni   datetime NOT NULL,           --** Fecha inicial
   GestionFecFin   datetime NOT NULL,           --** Fecha Final
   EstadoId        int NOT NULL                 --** Estado(Activo/Inactivo)

   CONSTRAINT GestionPK PRIMARY KEY NONCLUSTERED (GestionId) 
)

GO

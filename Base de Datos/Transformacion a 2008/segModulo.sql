/********************************************************************/
/*  TABLA			: segModulo							    	    */
/*  AUTOR			: Joel Mercado									*/
/*  FECHA			: 15/12/2017									*/
/*  DESCRIPCION		:									            */
/********************************************************************/

Print 'Creating table dbo.segModulo'
CREATE TABLE dbo.segModulo
(
   --** Llave
   ModuloId      int NOT NULL,				--** Id. Del Modulo

   --** Atributos
   ModuloCod	 varchar(3) NOT NULL,       --** Prefijo del modulo
   ModuloDes     varchar(255) NOT NULL,         --** Descripcion del modulo
   ModuloEsp     varchar(255) NULL,     --** Nombre del modulo
   EstadoId      int NOT NULL               --** Estado(Activo/Inactivo)

   CONSTRAINT ModuloPK PRIMARY KEY NONCLUSTERED(ModuloId)
)

GO

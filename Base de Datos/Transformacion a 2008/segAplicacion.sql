/********************************************************************/
/*  TABLA			: segAplicacion							   	    */
/*  AUTOR			: Joel Mercado									*/
/*  FECHA			: 15/12/2017									*/
/*  DESCRIPCION		:									            */
/********************************************************************/

Print 'Creating table dbo.segAplicacion'
CREATE TABLE segAplicacion 
(
   --** Llave
   AplicacionId     int NOT NULL,				--** Id. De la Aplicacion

   --** Atributos
   AplicacionCod	varchar(3) NOT NULL,        --** Prefijo de la aplicacion
   AplicacionDes    varchar(255) NOT NULL,		--** Nombre del Usuario
   AplicacionEsp    varchar(255) NULL,			--** Nombre de la aplicacion
   ModuloId			int NOT NULL,               --** ID. del Modulo(segModulo)
   EstadoId         int NOT NULL                --** Estado(Activo/Inactivo)

   CONSTRAINT AplicacionPK PRIMARY KEY NONCLUSTERED(AplicacionId)
 )
 
 GO

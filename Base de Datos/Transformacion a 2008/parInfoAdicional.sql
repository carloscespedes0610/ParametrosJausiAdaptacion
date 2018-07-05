/********************************************************************/
/*  TABLA			: parInfoAdicional		           	    */
/*  AUTOR			: Joel Mercado									*/
/*  FECHA			: 31/01/2018									*/
/*  DESCRIPCION		: Informacion Adicional de persona              */
/********************************************************************/

Print 'Creating table dbo.parInfoAdicional'
CREATE TABLE dbo.parInfoAdicional
(
   --** Llave
   InfoAdicionalId	    int identity(1,1) NOT NULL,  --** Id. parInfoAdicional

   --** Atributos
   TipoRelacionId       int NOT NULL,                --** Id. Tipo de relacion con la empresa                                                          --** (C=Cliente; P=Proveedor; E=Empleado)
   InfoAdicionalDes     Varchar(255) NOT NULL,        --** Descripcion Información adicional

   CONSTRAINT InfoAdicionalPK PRIMARY KEY NONCLUSTERED (InfoAdicionalId)
)

GO
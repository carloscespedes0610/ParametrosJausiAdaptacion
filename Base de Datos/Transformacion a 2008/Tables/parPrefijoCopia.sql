/********************************************************************/
/*  TABLA			: parPrefijoCopia    								*/
/*  AUTOR			: Joel Mercado									*/
/*  FECHA			: 15/12/2017									*/
/*  DESCRIPCION		: Copias de Impresion de documentos		    	            */
/********************************************************************/

Print 'Creating table dbo.parPrefijoCopia'

CREATE TABLE parPrefijoCopia 
(
   --** Llave
   PrefijoCopiaId		int NOT NULL,					--** Id. del PrefijoCopia
       
   --** Atributos
   PrefijoCopiaDes		varchar(255) NOT NULL,			--** Descripcion del PrefijoCopia
   OriginalNro			int NOT NULL,					--** Cantidad de Impresion Orifinal	   
   CopiaNro				int NOT NULL,					--** Cantidad de Impresion Copia	   

   CONSTRAINT PrefijoCopiaPK PRIMARY KEY NONCLUSTERED (PrefijoCopiaId)
 )
 
 GO

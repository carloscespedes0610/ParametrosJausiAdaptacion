/********************************************************************/
/*  TABLA			: parPrefijo    								*/
/*  AUTOR			: Joel Mercado									*/
/*  FECHA			: 15/12/2017									*/
/*  DESCRIPCION		: Prefijo de documento		    	            */
/********************************************************************/

Print 'Creating table dbo.parPrefijo'

CREATE TABLE parPrefijo 
(
   --** Llave
   PrefijoId		int identity(1,1) NOT NULL,		--** Id. del prefijo
       
   --** Atributos
   DocId			int NOT NULL,					--** Id. del documento(parDoc)
   ModuloId			int NOT NULL,					--** ID. del Modulo(segModulo)
   AplicacionId		int NOT NULL,					--** ID. de aplicacion(segModulo)
   PrefijoNro		int NOT NULL,					--** Nro. de Prefijo	   
   PrefijoDes		varchar(255) NOT NULL,			--** Descripcion del Prefijo
   PrefijoTipo		int NOT NULL,					--** Tipo de Numeracion
													--** 1=Manual,2=Automatica
   PrefijoIniGes	bit  NOT NULL,					--** Inicializa en cambio 
													--** de gestion
   FormatoImpId     int NOT NULL,					--** Formato de Impresion
   MensajeFor		varchar(255) NOT NULL,			--** Mensaje del formato
   NumeroCop		int NOT NULL,					--** Nro. de Copias
   ItemMax			int NOT NULL,					--** Nro. de Item Maximo
   ImprimeUsr		bit NOT NULL,					--** Imprime usuario (1=Si/0=No)
   ImprimeFec		bit NOT NULL,					--** Imprime Fecha y Hora (1=Si/0=No)
   TipoEncabezadoId    	int NOT NULL,				--** Bandera del encabezado del prefijo
													--** 1 = Razon social del documento
													--** 2 = Nombre de la empresa
													--** 3 = Logotipo A
													--** 4 = Logotipo B
													--** 5 = Logotipo C
													--** 6 = Logotipo D
													--** 7 = Logotipo E
													--** anterior- TipoEnc
   RazonSoc			varchar(255) NULL,				--** Razon Social p/Documento
   RazonSocAbr		varchar(100) NULL,				--** Razon Social p/documento corto 
   ObsUno			varchar(255) NULL,				--** Observacion Uno del Doc.
   ObsDos			varchar(255) NULL,				--** Observacion Dos del Doc.
   FirmaUno			varchar(100) NULL,				--** Descripcion Firma Uno
   FirmaSeg			varchar(100) NULL,				--** Descripcion Firma Dos
   FirmaTre			varchar(100) NULL,				--** Descripcion Firma Tres
   FirmaCua			varchar(100) NULL,				--** Descripcion Firma Cuatro
   NroAuto			bigint NOT NULL,				--**?? Numero de Orden(factura) eliminado en tabla
   EstadoId			int NOT NULL					--** Estado(Activo/Inactivo)

   CONSTRAINT PrefijoPK PRIMARY KEY  NONCLUSTERED (PrefijoId)
 )
 
 GO

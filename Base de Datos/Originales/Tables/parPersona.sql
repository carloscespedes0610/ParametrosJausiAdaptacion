/********************************************************************/
/*  TABLA			: parPersona		             	            */
/*  AUTOR			: Joel Mercado									*/
/*  FECHA			: 31/01/2018									*/
/*  DESCRIPCION		: Informacion de la persona                     */
/********************************************************************/

Print 'Creating table dbo.parPersona'
CREATE TABLE dbo.parPersona
(
   --** Llave
   PersonaId		    int identity(1,1) NOT NULL, --** Id. de la persona

   --** Atributos
   TipoPersonaId        int NOT NULL,               --** Id. del tipo de persona
   PersonaCod           int NOT NULL,               --** Codigo del tipo de persona
                                                    --** (Tipo * 10000 +
                                                    --** Numero persona)
                                                    --** Numero de la persona)
   TipoEntidadId        int NOT NULL,               --** Id. del tipo empresa
                                                    --** Empresa, PArticular
   RazonSocial          varchar(255) NOT NULL,      --** Razon Social
   Nit					varchar(50) NOT NULL,		--** NIT
   IdentificaId         int NOT NULL,               --** ID. del tipo de doc.
   IdentificaNro        varchar(50) NOT NULL,       --** Numero del documento
   ExpedidoId           int NOT NULL,               --** Id. del expedido
   IdentificaExt        varchar(10) NOT NULL,       --** Extension Doc. Identidad (Opcional)
   TelTrabajo           varchar(100) NOT NULL,      --** Telefono del Trabajo
   TelParticular        varchar(100) NOT NULL,      --** Telefono PArticular
   TelFax               varchar(100) NOT NULL,      --** Telefono Fax
   TelCelular           varchar(100) NOT NULL,      --** Telefono Celular
   Email                varchar(100) NOT NULL,      --** Email
   PaginaWeb            varchar(100) NOT NULL,      --** Pagina Web
   
   --** Direccion Principal
   PrincipalPais        varchar(100) NOT NULL,      --** Pais
   PrincipalDpto        varchar(100) NOT NULL,      --** Departamento
   PrincipalCiudad      varchar(100) NOT NULL,      --** Ciudad
   PrincipalDir         varchar(255) NOT NULL,      --** Calle

   --** Direccion Para entrega de mercaderia - Ventas
   EntregaPais			varchar(100),				--** Pais
   EntregaDpto			varchar(100),				--** Departamento
   EntregaCiudad		varchar(100),				--** Ciudad
   EntregaDir			varchar(255),				--** Calle

   --** Direccion del proveedor - Compras
   CompraPais			varchar(100),				--** Pais
   CompraDpto			varchar(100),				--** Departamento
   CompraCiudad			varchar(100),				--** Ciudad
   CompraDir			varchar(255),				--** Calle
   SitArancelariaId		int NOT NULL,               --** Id. Situacion Arancelaria 
													--** precios proveedor

   --** Informacion Personal
   FechaNac				datetime,                   --** Fecha de Nacimiento
   LugarNac				varchar(100),				--** Lugar Nacimiento
   OcupacionId			int NOT NULL,               --** Id. de la ocupacion
   CargoId				int NOT NULL,               --** Id. Cargo
   EmpresaTrabajo		varchar(100),               --** Empresa en que trabaja
   SexoId				int NOT NULL,               --** 0 = Masculino; 1 = Femenino
   EstadoCivilId		int NOT NULL,               --** Id. Estado Civil(Soltero, Casado, Viudo, Divorciado)
   FechaAniversario		datetime,                   --** Fecha Aniversario

   --** Otros Datos 
   CoorX				varchar(50),                --** Coordenada X de GPS
   CoorY				varchar(50),                --** Coordenada Y de GPS
   CodigoAnt			varchar(100)				--** Codigo Anterior

   EstadoId			    int NOT NULL,               --** Estado(Activo/Inactivo)
    
   CONSTRAINT PersonaPK PRIMARY KEY NONCLUSTERED (PersonaId)
)

GO
  
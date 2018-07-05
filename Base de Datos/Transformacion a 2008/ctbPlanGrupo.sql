/********************************************************************/
/*  TABLA			: ctbPlanGrupo       					   	    */
/*  AUTOR			: Joel Mercado									*/
/*  FECHA			: 15/12/2017									*/
/*  DESCRIPCION		: Grupo de Cuentas.                             */
/********************************************************************/
	 
Print 'Creating table dbo.ctbPlanGrupo'

CREATE TABLE ctbPlanGrupo 
(
   --** Llave
   PlanGrupoId			int identity(1,1) NOT NULL,		--** Id. del grupo de cuentas

   --** Atributos
   PlanGrupoCod			varchar(50) NOT NULL,			--** Codigo del grupo de cuenta
   PlanGrupoDes			varchar(255) NOT NULL,			--** Descripcion
   PlanGrupoEsp			varchar(255) NULL,				--** Especificacion
   PlanGrupoTipoId		int NOT NULL,					--** Tipo de grupo cuenta  
   PlanGrupoTipoDetId	int NOT NULL,					--** SubTipo de grupo de cuenta
   NroCuentas			int NOT NULL,					--** Cantidad de cuenta contables que contendra el detalle
   MonedaId				int NOT NULL,					--** Moneda (B=Bs.; U=Us.; E=Es.; F=UFV)
   VerificaMto			bit NOT NULL,					--** Verificacion Monto Autorizado 
														--** p/Debito Ctas. x Cobrar y 
														--** p/Debito Ctas. Ctes. Deudoras
														--** Si va_ver_mto=0  Verificacion activada
														--**    va_ver_mto=1  Verificacion desactivada
   EstadoId				int NOT NULL					--** Estado(Activo/Inactivo)
 
  CONSTRAINT PlanGrupoPK PRIMARY KEY NONCLUSTERED (PlanGrupoId)
)

GO


--** EL CODIGO ESTA CREADO DE 10 DIGITOS :
--** LOS DOS PRIMEROS DIGITOS CORRESPONDEN AL TIPO DE GRUPO CUENTA
--** TE = TESORERIA
--** EC = EXIGIBLE X COBRAR
--** EP = EXIGIBLE X PAGAR
--** LOS DOS SIGUIENTES DIGITOS CORRESPONDEN AL SUBTIPO DE GRUPO CUENTA
--** EL TERCER DIGITO CORRESPONDE A LA MONEDA(B=Bolivianos; U=Dolares;)
--** LOS CINCO RESTANTES DIGITOS CORRESPONDE AL NUMERO DEL GRUPO CUENTA.


--** TIPO DE GRUPO CUENTA			--** SUBTIPO DE GRUPO CUENTA
--** TE = Tesoreria					1  = Caja Facturacion
--**								2  = Caja General
--**								3  = Banco
--** EC = Exigible x Cobrar			10 = Creditos x Cobrar
--**								11 = Cuentas x Cobrar
--**								12 = Cuentas Corrientes Deudoras
--** EP = Exigible x Pagar			20 = Creditos x Pagar
--**                                21 = Cuentas x Pagar
--**                                22 = Cuentas Corrientes x Pagar


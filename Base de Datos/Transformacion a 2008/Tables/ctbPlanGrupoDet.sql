/********************************************************************/
/*  TABLA			: ctbPlanGrupoDet      					   	    */
/*  AUTOR			: Joel Mercado									*/
/*  FECHA			: 15/12/2017									*/
/*  DESCRIPCION		: Grupo de Cuentas Detalle.                     */
/********************************************************************/
	 
Print 'Creating table dbo.ctbPlanGrupoDet'

CREATE TABLE ctbPlanGrupoDet 
(
   --** Llave
   PlanGrupoDetId		int identity(1,1) NOT NULL,		--** Id. del detalle grupo de cuentas

   --** Atributos
   PlanGrupoId			int NOT NULL,					--** Id. del grupo de cuentas
   PlanGrupoDetDes      varchar(255),					--** Descripcion
   PlanId				int NOT NULL,					--** Id. del plan de cuentas
   PlanFlujoId          int NOT NULL,					--** Id. del plan de flujo de cuentas
   SucursalId			int NOT NULL,					--** Id. de la sucursal
   CenCosId				int NOT NULL,					--** Id. del C.C.
   Orden				int NOT NULL,					--** Orden asigando a la cuenta
   EstadoId				int NOT NULL					--** Estado(Activo/Inactivo)

   CONSTRAINT PlanGrupoDetPK PRIMARY KEY NONCLUSTERED (PlanGrupoDetId)
 )
 
 GO

 --** La asignacion numero de cuenta (PlanGrupoNro) se la realiza 
 --** dependiendo del tipo y subtipo del grupo de cuentas.

 --**    TIPO GRUPO DE CUENTA
 --**         NRO. CUENTA      DESCRIPCION CUENTA
 --**  -----------------------------------------------------------
 --**  TESORERIA
 --**             1            Cuenta contable Control
 --**                            * Registrada
 --**                            * Capitulo de activo
 --**                            * Analitica Bs./Us.
 --**                            * Habilitada
 --**                            * Moneda libro = moneda cuenta
 --**                            * Uso del sistema
 --**                            * Menor o igual a la global ultima
 --**                              cuenta del disponible
 --**  EXIGIBLE x COBRAR
 --**         CUENTAS CORRIENTES DEUDORAS
 --**             1            Cuenta contable Control
 --**                            * Registrada
 --**                            * Capitulo de activo
 --**                            * Cuenta analitica Bs./Us.
 --**                            * Habilitada
 --**                            * Moneda libro = moneda cuenta
 --**                            * Uso del sistema
 --**                            * Mayor a la global ultima
 --**                              cuenta del disponible
 --**             2            Desembolsos cuentas ctes. (flujo)
 --**             3            Recuperacion cuentas ctes.(flujo)
 --**                            * Registrada
 --**                            * Analitica
 --**                            * Habilitada
 --**         CUENTAS x COBRAR
 --**             1            Cuenta Contable Control
 --**                            * Registrada
 --**                            * Capitulo de activos
 --**                            * Analitica Bs./Us.
 --**                            * Habilitada
 --**                            * Moneda libro = moneda cuenta
 --**                            * Uso del sistema
 --**                            * Mayor a la global ultima
 --**                              cuenta del disponible
 --**             2            Cuenta Contable Descuentos p/Pronto Pago
 --**                            * Registrada
 --**                            * Capitulo de Egresos
 --**                            * Analitica con/sin Detalle
 --**                            * Habilitada
 --**                            * Mayor a la global ultima
 --**                              cuenta del disponible
 --**             3            Desembolsos        (flujo)
 --**             4            Recuperacion       (flujo)
 --**                            * Registrada
 --**                            * Habilitada
 --**                            * Analitica
 --**         CREDITOS x COBRAR
 --**             1            Credito capital           (contable)
 --**             2            Interes p/cobrar          (contable)
 --**             3            Cta. Control Liquidaciones(Contable)
 --**                            * Registrada
 --**                            * Capitulo de activo
 --**                            * Analitica Bs./Us.
 --**                            * Habilitada
 --**                            * Moneda libro = moneda cuenta
 --**                            * Uso del sistema
 --**             4            Ingreso p/Intereses       (contable)
 --**                            * Registrada
 --**                            * Analitica con/sin detalle
 --**                            * Habilitada
 --**                            * Ingresos
 --**             5            Formulario y Otros       (contable)
 --**                            * Registrada
 --**                            * Analitica con/sin detalle
 --**                            * Habilitada
 --**                            * Ingresos
 --**             6            Desembolsos capital       (flujo)
 --**             7            Recuperacion capital      (flujo)
 --**             8            Ingreso p/Intereses y Otros      (flujo)
 --**                            * Registrada
 --**                            * Analitica
 --**                            * Habilitada
 --**
 --**  EXIGIBLE x PAGAR 
 --**         CUENTAS CORRIENTES ACREEDORAS
 --**             1            Cuenta contable Control
 --**                            * Registrada
 --**                            * Capitulo de pasivos
 --**                            * Analitica Bs./Us.
 --**                            * Moneda libro = moneda cuenta
 --**                            * Uso de sistema
 --**             2            Desembolsos cuentas ctes. (flujo)
 --**             3            Pagos cuentas ctes.       (flujo)
 --**                            * Registrada
 --**                            * Analitica
 --**                            * Habilitada
 --**         CUENTAS x PAGAR
 --**             1            Cuenta contable Control
 --**                            * Registrada
 --**                            * Capitulo de pasivos
 --**                            * Analitica Bs./Us.
 --**                            * Moneda libro = moneda cuenta
 --**                            * Uso de sistema
 --**             2            Desembolsos 		     (flujo)
 --**             3            Pagos 		     (flujo)
 --**                            * Registrada
 --**                            * Analitica
 --**                            * Habilitada
 --**         CREDITOS x PAGAR
 --**             1            Capital a corto plazo     (contable)
 --**             2            Capital a largo plazo     (contable)
 --**             3            Intereses por pagar       (contable)
 --**                            * Registrada
 --**                            * Capitulo pasivos
 --**                            * Analitica Bs./Us.
 --**                            * Habilitada
 --**                            * Moneda libro = moneda cuenta
 --**                            * Uso de sistema
 --**                            * Mayor a la global ultima
 --**                              cuenta del disponible
 --**             4            Gasto por intereses         (contable)
 --**             5            Gasto p/formularios y otros (contable)
 --**                            * Registrada
 --**                            * Capitulo de egresos
 --**                            * Analitica con/sin detalle
 --**                            * Habilitada
 --**                            * Resultado
 --**             6            Desembolsos capital       (flujo)
 --**             7            Pagos de capital          (flujo)
 --**             8            Pagos de intereses        (flujo)
 --**             9            Pagos Formularios y Otros (Flujo)
 --**                            * Registrada
 --**                            * Analitica
 --**                            * Habilitada
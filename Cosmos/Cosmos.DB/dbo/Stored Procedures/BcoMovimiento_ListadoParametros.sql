

CREATE PROCEDURE [dbo].[BcoMovimiento_ListadoParametros]
@FechaInicial DateTime,
@FechaFinal DateTime,
@PpalProveedorID int
-- Parámetros para Bitácora
	,@UsuarioIDBitcora		int
	,@DescripcionBitacora	varchar(500)	= null
	,@IpAddress				varchar(40)		= null
	,@HostName				varchar(50)		= null

AS
-- Variables para manejo de Errores
DECLARE @Errores int = 0, @Mensaje nvarchar(300)
-- Variables para Bitácora          
DECLARE @TablaNombreBitacora   nvarchar(100) = 'BcoMovimiento',	
		@Operacion	nvarchar(20) = 'lIST', 
		@logMessage	varchar(Max) = '',
		@isChangeBeLogged bit

SET NOCOUNT ON 
SET XACT_ABORT ON;
BEGIN TRY
	BEGIN TRANSACTION

	SELECT	BM.BcoMovimientoID,				PS.PpalSerieClave,				BM.Folio,
			EP.Nombre + ' ' + EP.ApellidoPaterno + ' ' + EP.ApellidoMaterno AS PersonalNombre,
			BM.Fecha,						BM.Importe,						BC.Cuenta
	  FROM	BcoMovimiento BM
	  LEFT OUTER JOIN PpalSerie PS ON BM.PpalSerieID = PS.PpalSerieID
	  LEFT OUTER JOIN PpalPersonal PP ON BM.PpalPersonalID = PP.PpalPersonalID
	  LEFT OUTER JOIN EspPersona EP ON PP.EspPersonaID = EP.EspPersonaID
	  LEFT OUTER JOIN BcoCuenta BC ON BM.BcoCuentaID = BC.BcoCuentaID
	 WHERE BM.Fecha BETWEEN @FechaInicial AND @FechaFinal
	ORDER BY BM.Fecha,	PS.PpalSerieClave,  BM.Folio

	/* Procesa Bitácora */
	-- Revisa si el cambio debe ser guardado en Bitácora
	EXEC	@isChangeBeLogged	=   SistemaLogRegla_Consultar_LogBit
			@UsuarioID			=	@UsuarioIDBitcora,
			@TablaNombre		=   @TablaNombreBitacora,
			@Operacion			=	@Operacion

	-- Si el cambio debe guardarse, prepara variables de Bitácora y lo guarda
	IF @isChangeBeLogged = 1 And @@RowCount > 0
	BEGIN
		-- logMessage = Parámetros de Listado
		SET @logMessage =  Concat('FechaInicial::', @FechaInicial, ':',0, ';')
		SET @logMessage =  Concat('FechaFinal::', @FechaFinal, ':',0, ';')
		SET @logMessage =  Concat('PpalProveedorID::', @PpalProveedorID, ':',0, ';')

		-- Guarda en Bitácora
		EXEC 	 [dbo].[SistemaLog_Guardar] @TablaNombre		= @TablaNombreBitacora
												,@TablaID			= 0
												,@TablaColumna1		= ''
												,@TablaColumna2		= ''
												,@Operacion			= @Operacion
												,@UsuarioID			= @UsuarioIDBitcora
												,@Descripcion		= @DescripcionBitacora
												,@Cambios			= @logMessage
												,@IpAddress			= @IpAddress
												,@HostName			= @HostName
	END
	-- Si no hubo errores -> COMMIT
	COMMIT TRANSACTION
END TRY
-- Si hubo error los procesa y lo regresa
BEGIN CATCH
	IF (XACT_STATE()) = -1 ROLLBACK TRANSACTION;
	IF (XACT_STATE()) = 1 COMMIT TRANSACTION;
    SELECT @Errores = ERROR_NUMBER(), 
			@Mensaje = dbo.FDecodificaError(ERROR_NUMBER(), ERROR_MESSAGE(), ERROR_SEVERITY(), ERROR_STATE(), ERROR_PROCEDURE(), ERROR_LINE())
END CATCH 

SELECT  COALESCE(@Errores, 0) as Errores, 
        COALESCE(@Mensaje, '') as Mensaje,
		COALESCE(ERROR_SEVERITY(), 0) as Severidad,
		COALESCE(ERROR_STATE(), 0) as Estado,
		COALESCE(ERROR_PROCEDURE(), '') as ProcedimientoAlmacenado,
		COALESCE(ERROR_LINE(), 0) as Linea
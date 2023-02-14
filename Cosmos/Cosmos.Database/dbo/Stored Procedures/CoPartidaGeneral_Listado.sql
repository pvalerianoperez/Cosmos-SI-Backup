﻿CREATE PROCEDURE [dbo].[CoPartidaGeneral_Listado]
@TipoListado varchar(10)
-- Parámetros para Bitácora
	,@EmpresaIDSolicitudBase int
	,@UsuarioIDBitcora		int
	,@DescripcionBitacora		varchar(500)	= null
	,@IpAddress			varchar(40)		= null
	,@HostName			varchar(50)		= null
AS
-- Variables para manejo de Errores
DECLARE @Errores int = 0, @Mensaje nvarchar(500)
-- Variables para Bitácora          
DECLARE @TablaNombreIDBitacora   nvarchar(100) = 'CoPartidaGeneral',	
		@Operacion	nvarchar(20) = 'List', 
		@logMessage	varchar(Max) = '',
		@isChangeBeLogged bit

SET NOCOUNT ON 
SET XACT_ABORT ON;
BEGIN TRY
	BEGIN TRANSACTION

	/* Procesa Bitácora */
	-- Revisa si el cambio debe ser guardado en Bitácora
	EXEC	@isChangeBeLogged	=   SistemaLogRegla_Consultar_LogBit
			@UsuarioID			=	@UsuarioIDBitcora,
			@TablaNombre		=   @TablaNombreIDBitacora,
			@Operacion			=	@Operacion

	-- Si el cambio debe guardarse, prepara variables de Bitácora y lo guarda
	IF @isChangeBeLogged = 1 And @@RowCount > 0
	BEGIN
		-- logMessage = Parámetros de Listado
		SET @logMessage =  Concat('CoTipoPresupuestoID::',0, ':',0, ';')

		-- Guarda en Bitácora
		EXEC 	 [dbo].[SistemaLog_Guardar] @TablaNombre		= @TablaNombreIDBitacora
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


	IF @TipoListado = 'Minimo'
		SELECT  CoPartidaGeneralID as ID,		CoPartidaGeneralClave as Clave,				Nombre,
				NombreCorto,					CoTipoConstruccionID as PadreID
		FROM    CoPartidaGeneral
		ORDER BY CoPartidaGeneralClave
	ELSE IF @TipoListado = 'Parcial' OR @TipoListado = 'Completo'
		SELECT  CoPartidaGeneralID,			PadreID,				CoPartidaGeneralClave,				Nombre,
				NombreCorto,				PpalAreaIDInicio,		PpalConceptoEgresoIDInicio,			AplicaIVA,
				CoTipoConstruccionID
		FROM    CoPartidaGeneral
		ORDER BY CoPartidaGeneralClave

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

/**************** FIN COPY 2 *********************************************/
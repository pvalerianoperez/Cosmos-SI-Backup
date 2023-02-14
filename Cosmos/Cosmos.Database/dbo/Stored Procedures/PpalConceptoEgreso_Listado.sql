

CREATE PROCEDURE [dbo].[PpalConceptoEgreso_Listado]
@TipoListado varchar(10),
-- Parámetros para Bitácora
	@EmpresaIDSolicitudBase int
	,@UsuarioIDBitacora		int
	,@DescripcionBitacora	varchar(500)	= null
	,@IpAddress			varchar(40)		= null
	,@HostName			varchar(50)		= null

AS
-- Variables para manejo de Errores
DECLARE @Errores int = 0, @Mensaje nvarchar(500)
-- Variables para Bitácora          
DECLARE @TablaNombreBitacora   nvarchar(100) = 'PpalConceptoEgreso',	
		@Operacion	nvarchar(20) = 'Read', 
		@logMessage	varchar(Max) = '',
		@isChangeBeLogged bit

SET NOCOUNT ON 
SET XACT_ABORT ON;
BEGIN TRY
	BEGIN TRANSACTION
	/* Procesa Bitácora */
	-- Revisa si el cambio debe ser guardado en Bitácora
	EXEC	@isChangeBeLogged	=   SistemaLogRegla_Consultar_LogBit
			@UsuarioID			=	@UsuarioIDBitacora,
			@TablaNombre		=   @TablaNombreBitacora,
			@Operacion			=	@Operacion

	-- Si el cambio debe guardarse, prepara variables de Bitácora y lo guarda
	IF @isChangeBeLogged = 1 And @@RowCount > 0
	BEGIN
		-- logMessage = Parámetros de Listado
		SET @logMessage =  Concat('EmpresaID::', @EmpresaIDSolicitudBase, ':',0, ';')

		-- Guarda en Bitácora
		EXEC 	 [dbo].[SistemaLog_Guardar] @TablaNombre		= @TablaNombreBitacora
												,@TablaID			= 0
												,@TablaColumna1		= ''
												,@TablaColumna2		= ''
												,@Operacion			= @Operacion
												,@UsuarioID			= @UsuarioIDBitacora
												,@Descripcion		= @DescripcionBitacora
												,@Cambios			= @logMessage
												,@IpAddress			= @IpAddress
												,@HostName			= @HostName
	END

	IF @TipoListado = 'Minimo'
		SELECT  PpalConceptoEgresoID AS ID,					PpalConceptoEgresoClave AS Clave,
				Nombre,										NombreCorto,
				0 as PadreID
		FROM    PpalConceptoEgreso
		WHERE	EmpresaID  = @EmpresaIDSolicitudBase AND
			((SELECT administrador
			   FROM SegUsuario
			  WHERE SegUsuarioID = @UsuarioIDBitacora) = 1 OR
			(SELECT PpalConceptoEgresoID 
			   FROM PpalConceptoEgreso
			  WHERE PpalConceptoEgresoClave = (SELECT ClaveNoAsignado FROM SistemaParamCosmos)) in 
				(SELECT PpalConceptoEgresoID
				  FROM SegUsuarioConceptoEgreso
				 WHERE SegUsuarioID = @UsuarioIDBitacora) OR
			PpalConceptoEgresoID in 
				(SELECT PpalConceptoEgresoID
				  FROM SegUsuarioConceptoEgreso
				 WHERE SegUsuarioID = @UsuarioIDBitacora))		order by Nombre
	ELSE
		SELECT  PpalConceptoEgresoID,PpalConceptoEgresoClave,Nombre,NombreCorto,CompraFactura,Desglosar, EmpresaID
		FROM    PpalConceptoEgreso
		WHERE	EmpresaID  = @EmpresaIDSolicitudBase
		order by PpalConceptoEgresoClave

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
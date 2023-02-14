
CREATE PROCEDURE [dbo].[SegUsuarioEstatusDocumento_Guardar]
@SegUsuarioEstatusDocumentoID int,
@SegUsuarioID int,
@CfgEstatusDocumentoID int,
@PpalCentroCostoID int = 0 ,
@PpalAreaID int = 0,
@EmpresaID int = 0,
@PpalAlmacenID int = 0,
@PpalSucursalID int = 0,
@Monto money = 0
-- Parámetros para Bitácora
	,@UsuarioIDBitacora		int
	,@DescripcionBitacora	varchar(500)	= null
	,@IpAddress				varchar(40)		= null
	,@HostName				varchar(50)		= null

AS
-- Variables para manejo de Errores
DECLARE @Errores int = 0, @Mensaje nvarchar(300) = '', @IDAActualizar int, @ClaveNoAsignado varchar(5)
-- Variables para Bitácora
DECLARE @TablaNombreIDBitacora   nvarchar(100) = 'SegUsuarioEstatusDocumento',	
		@Operacion	nvarchar(20) = '', 
		@logMessage	varchar(Max) = '',
		@isChangeBeLogged bit
-- Variables para valores anteriores (Bitácora Update) 
DECLARE	@SegUsuarioID_ int = 0,
		@CfgEstatusDocumentoID_ int = 0,
		@PpalCentroCostoID_ int = 0 ,
		@PpalAreaID_ int = 0,
		@EmpresaID_ int = 0,
		@PpalAlmacenID_ int = 0,
		@PpalSucursalID_ int = 0,
		@Monto_ money = 0,
		@SegUsuarioEstatusDocumentoID_ int = @SegUsuarioEstatusDocumentoID

SET NOCOUNT ON 
SET XACT_ABORT ON;
BEGIN TRY
	BEGIN TRANSACTION

	SET @IDAActualizar = @SegUsuarioEstatusDocumentoID
	-- Si es UPDATE -> Lee valores anteriores de las columnas (Bitácora Update) 
	IF @IDAActualizar > 0
	BEGIN
		SELECT	@SegUsuarioID_ = IsNull(SegUsuarioID,0),
				@CfgEstatusDocumentoID_ = IsNull(CfgEstatusDocumentoID,0),
				@PpalCentroCostoID_ = IsNull(PpalCentroCostoID,0) ,
				@PpalAreaID_ = IsNull(PpalAreaID,0),
				@EmpresaID_ = IsNull(@EmpresaID,0),
				@PpalAlmacenID_ = IsNull(PpalAlmacenID,0),
				@PpalSucursalID_ = IsNull(PpalSucursalID,0),
				@Monto_ = IsNull(Monto,0),
				@SegUsuarioEstatusDocumentoID_ = IsNull(SegUsuarioEstatusDocumentoID,0)
		   FROM	SegUsuarioEstatusDocumento WHERE SegUsuarioEstatusDocumentoID = @SegUsuarioEstatusDocumentoID
		-- Si no se encontró registro a actualizar -> error
		IF @@RowCount = 0
			SELECT @Errores = 999999, @Mensaje = CONCAT('No se encontró el ID a Actualizar: ', @IDAActualizar);
		-- No se permite cambiar Clave cuando es igual a @ClaveNoAsignado
		--IF @AreaClave_ = @ClaveNoAsignado and @AreaClave <> @ClaveNoAsignado
			--SELECT @Errores = 999996, @Mensaje = CONCAT('No es permitido cambiar la clave ', @ClaveNoAsignado);
	END
	-- Si no hubo error (es INSERT o es UPDATE y existe el registro)
	IF @Errores = 0
	BEGIN
		-- Si la llave existe hace UPDATE y si no, hace INSERT
		IF @IDAActualizar > 0
		BEGIN
			UPDATE  SegUsuarioEstatusDocumento
			SET		SegUsuarioID = @SegUsuarioID,
					CfgEstatusDocumentoID = @CfgEstatusDocumentoID,
					PpalCentroCostoID = @PpalCentroCostoID,
					PpalAreaID = @PpalAreaID,
					EmpresaID = @EmpresaID,
					PpalAlmacenID = @PpalAlmacenID,
					PpalSucursalID = @PpalSucursalID,
					Monto = @Monto
			WHERE   SegUsuarioEstatusDocumentoID = @IDAActualizar
		END
		ELSE
		BEGIN        
			INSERT  INTO SegUsuarioEstatusDocumento(
					SegUsuarioID,
					CfgEstatusDocumentoID,
					PpalCentroCostoID,
					PpalAreaID,
					EmpresaID,
					PpalAlmacenID,
					PpalSucursalID,
					Monto)
			VALUES  (
					@SegUsuarioID,
					@CfgEstatusDocumentoID,
					@PpalCentroCostoID,
					@PpalAreaID,
					@EmpresaID,
					@PpalAlmacenID,
					@PpalSucursalID,
					@Monto)
        
			SET     @IDAActualizar = SCOPE_IDENTITY()
		END

		IF @@RowCount > 0
		BEGIN
			/* Procesa Bitácora */
			-- Determina si fue UPDATE o INSERT
			IF @SegUsuarioEstatusDocumentoID_ > 0  SET @Operacion = 'Update' 	
						ELSE SET @Operacion = 'Create' 

			-- Revisa si el cambio debe ser guardado en Bitácora
			EXEC	@isChangeBeLogged	=   SistemaLogRegla_Consultar_LogBit
					@UsuarioID			=	@UsuarioIDBitacora,
					@TablaNombre		=   @TablaNombreIDBitacora,
					@Operacion			=	@Operacion

			-- Si el cambio debe guardarse, prepara variables de Bitácora y lo guarda
			IF @isChangeBeLogged = 1 
			BEGIN
				-- logMessage = Cambios efectuados
				SET @logMessage = Concat('SegUsuarioID::', @SegUsuarioID_, ':', @SegUsuarioID, ';')
				SET @logMessage = Concat(@logMessage, 'CfgEstatusDocumentoID::', @CfgEstatusDocumentoID_, ':', @CfgEstatusDocumentoID, ';')
				SET @logMessage = Concat(@logMessage, 'PpalCentroCostoID::', @PpalCentroCostoID_ , ':', @PpalCentroCostoID, ';')
				SET @logMessage = Concat(@logMessage, 'PpalAreaID::', @PpalAreaID_, ':', @PpalAreaID, ';')
				SET @logMessage = Concat(@logMessage, 'EmpresaID::', @EmpresaID_, ':', @EmpresaID, ';')
				SET @logMessage = Concat(@logMessage, 'PpalAlmacenID::', @PpalAlmacenID_, ':', @PpalAlmacenID, ';')
				SET @logMessage = Concat(@logMessage, 'PpalSucursalID::', @PpalSucursalID_, ':', @PpalSucursalID, ';')
				SET @logMessage = Concat(@logMessage, 'Monto::', @Monto_, ':', @Monto, ';')
				PRINT @logMessage
				-- Guarda en Bitácora
				EXEC 	 [dbo].[SistemaLog_Guardar] @TablaNombre		= @TablaNombreIDBitacora
														,@TablaID			= @IDAActualizar
														,@TablaColumna1		= ''
														,@TablaColumna2		= ''
														,@Operacion			= @Operacion
														,@UsuarioID			= @UsuarioIDBitacora
														,@Descripcion		= @DescripcionBitacora
														,@Cambios			= @logMessage
														,@IpAddress			= @IpAddress
														,@HostName			= @HostName
			END
		END
		-- Fin de proceso sin errores -> COMMIT
		COMMIT TRANSACTION
	END
END TRY
-- Si hubo error los procesa y lo regresa
BEGIN CATCH
    SELECT @Errores = ERROR_NUMBER(), 
			@Mensaje = dbo.FDecodificaError(ERROR_NUMBER(), ERROR_MESSAGE(), ERROR_SEVERITY(), ERROR_STATE(), ERROR_PROCEDURE(), ERROR_LINE())
END CATCH 
IF (XACT_STATE()) = -1 ROLLBACK TRANSACTION;
IF (XACT_STATE()) = 1 COMMIT TRANSACTION;

SELECT  COALESCE(@Errores, 0) as Errores, 
        COALESCE(@Mensaje, '') as Mensaje,
		COALESCE(ERROR_SEVERITY(), 0) as Severidad,
		COALESCE(ERROR_STATE(), 0) as Estado,
		COALESCE(ERROR_PROCEDURE(), '') as ProcedimientoAlmacenado,
		COALESCE(ERROR_LINE(), 0) as Linea,
		@IDAActualizar as GuardarID
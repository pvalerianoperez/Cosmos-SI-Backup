-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [dbo].[InvMovimientoEncabezado_Guardar]
@InvMovimientoEncabezadoID int,
@PpalSucursalID int,
@TipoDocumentoID int,
@PpalSerieID int,
@Folio int,
@InvTipoMovimientoInventarioID int,
@PpalPersonalID int,
@Fecha int,
@Referencia varchar(50),
@Concepto varchar(100),
@CfgEstatusDocumentoID int
-- Parámetros para Bitácora
	,@UsuarioIDBitacora		int
	,@DescripcionBitacora	varchar(500)	= null
	,@IpAddress				varchar(40)		= null
	,@HostName				varchar(50)		= null
AS
-- Variables para manejo de Errores
DECLARE @Errores int = 0, @Mensaje nvarchar(500) = '', @IDAActualizar int, @ClaveNoAsignado varchar(5)
-- Variables para Bitácora
DECLARE @TablaNombreIDBitacora   nvarchar(100) = 'InvMovimientoEncabezado',	
		@Operacion	nvarchar(20) = '', 
		@logMessage	varchar(Max) = '',
		@isChangeBeLogged bit
-- Variables para valores anteriores (Bitácora Update) 
DECLARE	@InvMovimientoEncabezadoID_ int = @InvMovimientoEncabezadoID,	
		@PpalSucursalID_ int = 0,
		@TipoDocumentoID_ int = 0,
		@PpalSerieID_ int = 0,
		@Folio_ int = 0,
		@InvTipoMovimientoInventarioID_ int = 0,
		@PpalPersonalID_ int = 0,
		@Fecha_ datetime = 0,
		@Referencia_ varchar(50) = '',
		@Concepto_ varchar(100) = '',
		@CfgEstatusDocumentoID_ int = 0

SET NOCOUNT ON 
SET XACT_ABORT ON;
BEGIN TRY
	BEGIN TRANSACTION

	SET @IDAActualizar = @InvMovimientoEncabezadoID
	-- Si es UPDATE -> Lee valores anteriores de las columnas (Bitácora Update) 
	IF @IDAActualizar > 0
	BEGIN

		SELECT	@InvMovimientoEncabezadoID_ = IsNull(InvTipoMovimientoInventarioID,0),
				@PpalSucursalID_ =	ISNULL(PpalSucursalID, 0),
				@TipoDocumentoID_ = ISNULL(TipoDocumentoID, 0),
				@PpalSerieID_ = ISNULL(PpalSerieID,0),
				@Folio_ = ISNull(Folio, 0),
				@InvTipoMovimientoInventarioID_ = ISNULL(InvTipoMovimientoInventarioID, 0),
				@PpalPersonalID_ = ISNULL(PpalPersonalID, 0),
				@Fecha_ = ISNULL(Fecha, 0),
				@Referencia_ = ISNULL(Referencia, 0),
				@Concepto_ = ISNULL(Concepto, 0),
				@CfgEstatusDocumentoID_ = ISNULL(CfgEstatusDocumentoID, 0)
		   FROM	InvMovimientoEncabezado WHERE InvMovimientoEncabezadoID = @InvMovimientoEncabezadoID
		IF @@RowCount = 0
		SELECT @Errores = 999999, @Mensaje = CONCAT('No se encontró el ID a Actualizar:', ' ', @IDAActualizar);
	END
	-- Si no hubo error (es INSERT o es UPDATE y existe el registro)
	IF @Errores = 0
	BEGIN
		-- Si la llave existe hace UPDATE y si no, hace INSERT
		IF @IDAActualizar > 0
		BEGIN
			UPDATE		InvMovimientoEncabezado
			SET			PpalSucursalID = @PpalSucursalID,
						TipoDocumentoID = @TipoDocumentoID,
						PpalSerieID = @PpalSerieID,
						Folio = @Folio,
						InvTipoMovimientoInventarioID = @InvTipoMovimientoInventarioID,
						PpalPersonalID = @PpalPersonalID,
						Fecha = @Fecha,
						Referencia = @Referencia,
						Concepto = @Concepto,
						CfgEstatusDocumentoID = @CfgEstatusDocumentoID
			WHERE		InvMovimientoEncabezadoID = @IDAActualizar
		END
		ELSE
		BEGIN        
			INSERT  INTO InvMovimientoEncabezado(
						 PpalSucursalID,
						 TipoDocumentoID,
						 PpalSerieID,
						 Folio,
						 InvTipoMovimientoInventarioID,
						 PpalPersonalID,
						 Fecha,
						 Referencia,
						 Concepto,
						 CfgEstatusDocumentoID)
			VALUES  (
						@PpalSucursalID,
						@TipoDocumentoID,
						@PpalSerieID,
						@Folio,
						@InvTipoMovimientoInventarioID,
						@PpalPersonalID,
						@Fecha,
						@Referencia,
						@Concepto,
						@CfgEstatusDocumentoID)
        
			SET     @IDAActualizar = SCOPE_IDENTITY()
		END

		IF @@RowCount > 0
		BEGIN
			/* Procesa Bitácora */
			-- Determina si fue UPDATE o INSERT
			IF @InvMovimientoEncabezadoID_ > 0  SET @Operacion = 'Update' 	
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
				SET @logMessage = Concat(@logMessage, 'Folio::', @Folio_, ':', @Folio, ';')
				SET @logMessage = Concat(@logMessage, 'Fecha::', @Fecha_, ':', @Fecha, ';')
				SET @logMessage = Concat(@logMessage, 'Concepto::', @Concepto_, ':', @Concepto, ';')
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
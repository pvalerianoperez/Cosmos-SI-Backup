-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [dbo].[InvMovimientoDesglose_Guardar]
@InvMovimientoDesgloseID int,
@InvMovimientoDetalleID int,
@Renglon int,
@CmpRequisionDetalleID int,
@CmpOrdenCompraDesgloseID int,
@CmpCompraDesgloseID int,
@PpalSucursalID int,
@PpalCentroCostoID int,
@PpalAreaID int,
@PpalAlmacenID int,
@PpalConceptoEgresoID int,
@PpalCuentaContableID int,
@cantidad float,
@InvMovimientoDesgloseReferenciaID int
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
DECLARE	@InvMovimientoDesgloseID_ int = @InvMovimientoDesgloseID,
		@InvMovimientoDetalleID_ int = 0,
		@Renglon_ int = 0,
		@CmpRequisionDetalleID_ int = 0,
		@CmpOrdenCompraDesgloseID_ int = 0,
		@CmpCompraDesgloseID_ int = 0,
		@PpalSucursalID_ int = 0,
		@PpalCentroCostoID_ int = 0,
		@PpalAreaID_ int = 0,
		@PpalAlmacenID_ int = 0,
		@PpalConceptoEgresoID_ int = 0,
		@PpalCuentaContableID_ int = 0,
		@cantidad_ float = 0,
		@InvMovimientoDesgloseReferenciaID_ int = 0 

SET NOCOUNT ON 
SET XACT_ABORT ON;
BEGIN TRY
	BEGIN TRANSACTION

	SET @IDAActualizar = @InvMovimientoDesgloseID
	-- Si es UPDATE -> Lee valores anteriores de las columnas (Bitácora Update) 
	IF @IDAActualizar > 0
	BEGIN

		SELECT	@InvMovimientoDesgloseID_ = IsNull(InvMovimientoDesgloseID,0),
				@InvMovimientoDetalleID_ = IsNull(InvMovimientoDetalleID,0),
				@Renglon_ =	ISNULL(Renglon, 0),
				@CmpRequisionDetalleID_ = ISNULL(CmpRequisicionDetalleID, 0),
				@CmpOrdenCompraDesgloseID_ = ISNULL(CmpOrdenCompraDesgloseID,0),
				@CmpCompraDesgloseID_ = ISNULL(CmpCompraDesgloseID,0),
				@PpalSucursalID_ = ISNull(PpalSucursalID, 0),
				@PpalCentroCostoID_ = ISNULL(PpalCentroCostoID, 0),
				@PpalAreaID_ = ISNULL(PpalAreaID, 0),
				@PpalAlmacenID_ = ISNULL(PpalAlmacenID, 0),
				@PpalConceptoEgresoID_ = ISNULL(PpalConceptoEgresoID, 0),
				@PpalCuentaContableID_ = ISNULL(PpalCuentaContableID, 0),
				@cantidad_ = ISNULL(cantidad, 0),
				@InvMovimientodesgloseID_ = IsNull(InvMovimientoDesgloseID,0)
		   FROM	InvMovimientoDesglose WHERE InvMovimientoDesgloseID = @InvMovimientoDesgloseID
		IF @@RowCount = 0
		SELECT @Errores = 999999, @Mensaje = CONCAT('No se encontró el ID a Actualizar:', ' ', @IDAActualizar);
	END
	-- Si no hubo error (es INSERT o es UPDATE y existe el registro)
	IF @Errores = 0
	BEGIN
		-- Si la llave existe hace UPDATE y si no, hace INSERT
		IF @IDAActualizar > 0
		BEGIN
			UPDATE		InvMovimientoDesglose
			SET			InvMovimientoDetalleID = @InvMovimientoDetalleID,
						Renglon = @Renglon, 
						CmpRequisicionDetalleID = @CmpRequisionDetalleID,
						CmpOrdenCompraDesgloseID = @CmpOrdenCompraDesgloseID,
						CmpCompraDesgloseID = @CmpCompraDesgloseID,
						PpalSucursalID = @PpalSucursalID,
						PpalCentroCostoID = @PpalCentroCostoID,
						PpalAreaID = @PpalAreaID,
						PpalAlmacenID =@PpalAlmacenID,
						PpalConceptoEgresoID = @PpalConceptoEgresoID,
						PpalCuentaContableID = @PpalCuentaContableID,
						cantidad = @cantidad
			WHERE		InvMovimientoDesgloseID = @IDAActualizar
		END
		ELSE
		BEGIN        
			INSERT  INTO InvMovimientoDesglose(
						 InvMovimientoDetalleID,
						 Renglon, 
						 CmpRequisicionDetalleID,
						 CmpOrdenCompraDesgloseID,
						 CmpCompraDesgloseID,
						 PpalSucursalID,
						 PpalCentroCostoID,
						 PpalAreaID,
						 PpalAlmacenID,
						 PpalConceptoEgresoID,
						 PpalCuentaContableID,
						 cantidad)
			VALUES  (
						@InvMovimientoDetalleID,
						@Renglon,
						@CmpRequisionDetalleID,
						@CmpOrdenCompraDesgloseID,
						@CmpCompraDesgloseID,
						@PpalSucursalID,
						@PpalCentroCostoID,
						@PpalAreaID,
						@PpalAlmacenID,
						@PpalConceptoEgresoID,
						@PpalCuentaContableID,
						@cantidad)
        
			SET     @IDAActualizar = SCOPE_IDENTITY()
		END

		IF @@RowCount > 0
		BEGIN
			/* Procesa Bitácora */
			-- Determina si fue UPDATE o INSERT
			IF @InvMovimientoDesgloseID_ > 0  SET @Operacion = 'Update' 	
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
				SET @logMessage = Concat(@logMessage, 'InvMovimientoDetalleID::', @InvMovimientoDetalleID_, ':', @InvMovimientoDetalleID, ';')
				SET @logMessage = Concat(@logMessage, 'PpalSucursalID::', @PpalSucursalID_, ':', @PpalSucursalID, ';')
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
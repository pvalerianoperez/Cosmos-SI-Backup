-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [dbo].[CmpAnticipoDetalle_Guardar]
@CmpAnticipoDetalleID int,
@CmpAnticipoEncabezadoID int,
@PpalCentroCostoID int,
@PpalAreaID int,
@PpalConceptoEgresoID int,
@PpalCuentaContableID int,
@Importe float,
@Descripcion int
-- Parámetros para Bitácora
	,@UsuarioIBitacora			int
	,@DescripcionBitacora	varchar(500)	= null
	,@IpAddress				varchar(40)		= null
	,@HostName				varchar(50)		= null
AS
-- Variables para manejo de Errores
DECLARE @Errores int = 0, @Mensaje nvarchar(300) = '', @IDAActualizar int
-- Variables para Bitácora
DECLARE @TablaNombreIDBitacora   nvarchar(100) = 'CmpAnticipoDetalle',	
		@Operacion	nvarchar(20) = '', 
		@logMessage	varchar(Max) = '',
		@isChangeBeLogged bit
-- Variables para valores anteriores (Bitácora Update) 
DECLARE	@CmpAnticipoDetalleID_ int  = @CmpAnticipoDetalleID,
		@CmpAnticipoEncabezadoID_ int = 0,
		@PpalCentroCostoID_ int = 0,
		@PpalAreaID_ int = 0,
		@PpalConceptoEgresoID_ int = 0,
		@PpalCuentaContableID_ int = 0,
		@Importe_ float = 0.0,
		@Descripcion_ int = 0

SET NOCOUNT ON 
SET XACT_ABORT ON;
BEGIN TRY
	BEGIN TRANSACTION

	SET @IDAActualizar = @CmpAnticipoDetalleID
	-- Si es UPDATE -> Lee valores anteriores de las columnas (Bitácora Update) 
	IF @IDAActualizar > 0
	BEGIN
		SELECT	@CmpAnticipoEncabezadoID_ = IsNull(CmpAnticipoEncabezadoID,0),
				@CmpAnticipoEncabezadoID_  = IsNull(CmpAnticipoEncabezadoID,0),
				@PpalCentroCostoID_ = IsNull(PpalCentroCostoID,0),
				@PpalAreaID_ = IsNull(PpalAreaID, 0),
				@PpalConceptoEgresoID_ = IsNull(PpalConceptoEgresoID,0),
				@PpalCuentaContableID_ = ISNull(PpalCuentaContableID, -0),
				@Importe_ = IsNull(Importe, 0.0),
				@Descripcion_ = ISNULL(Descripcion, 0)
		   FROM	CmpAnticipoDetalle WHERE CmpAnticipoDetalleID = @IDAActualizar
		IF @@RowCount = 0
		SELECT @Errores = 999999, @Mensaje = CONCAT('No se encontró el ID a Actualizar:', ' ', @IDAActualizar);
	END
	-- Si no hubo error (es INSERT o es UPDATE y existe el registro)
	IF @Errores = 0
	BEGIN
		-- Si la llave existe hace UPDATE y si no, hace INSERT
		IF @IDAActualizar > 0
/************* FIN COPY 1  *********************/
		BEGIN
			UPDATE	CmpAnticipoDetalle
			SET		CmpAnticipoEncabezadoID = @CmpAnticipoEncabezadoID,
					PpalCentroCostoID = @PpalCentroCostoID,
					PpalAreaID = @PpalAreaID,
					PpalConceptoEgresoID = @PpalConceptoEgresoID,
					PpalCuentaContableID = @PpalCuentaContableID,
					Importe = @Importe,
					Descripcion = @Descripcion
			WHERE	CmpAnticipoDetalleID = @IDAActualizar
		END
		ELSE
		BEGIN        
			INSERT  INTO CmpAnticipoDetalle(
					CmpAnticipoEncabezadoID,
					PpalCentroCostoID,
					PpalAreaID,
					PpalConceptoEgresoID,
					PpalCuentaContableID,
					Importe,
					Descripcion)
			VALUES  (
				    @CmpAnticipoEncabezadoID,
				    @PpalCentroCostoID,
				    @PpalAreaID,
				    @PpalConceptoEgresoID,
				    @PpalCuentaContableID,
				    @Importe,
				    @Descripcion)
        
			SET     @IDAActualizar = SCOPE_IDENTITY()
		END

		IF @@RowCount > 0
		BEGIN
			/* Procesa Bitácora */
			-- Determina si fue UPDATE o INSERT
			IF @CmpAnticipoDetalleID_ > 0  SET @Operacion = 'Update' 	
						ELSE SET @Operacion = 'Create' 

			-- Revisa si el cambio debe ser guardado en Bitácora
			EXEC	@isChangeBeLogged	=   SistemaLogRegla_Consultar_LogBit
					@UsuarioID			=	@UsuarioIBitacora,
					@TablaNombre		=   @TablaNombreIDBitacora,
					@Operacion			=	@Operacion

			-- Si el cambio debe guardarse, prepara variables de Bitácora y lo guarda
			IF @isChangeBeLogged = 1 
			BEGIN
				-- logMessage = Cambios efectuados
				SET @logMessage = Concat('CmpAnticipoEncabezadoID::', @CmpAnticipoEncabezadoID_, ':', @CmpAnticipoEncabezadoID, ';')
				SET @logMessage = Concat(@logMessage, 'PpalAreaID::', @PpalAreaID_, ':', @PpalAreaID, ';')
				SET @logMessage = Concat(@logMessage, 'Importe::', @Importe_, ':', @Importe, ';')
				SET @logMessage = Concat(@logMessage, 'Descripcion::', @Descripcion_, ':', @Descripcion, ';')
				
				PRINT @logMessage
				-- Guarda en Bitácora
				EXEC 	 [dbo].[SistemaLog_Guardar] @TablaNombre		= @TablaNombreIDBitacora
														,@TablaID			= @IDAActualizar
														,@TablaColumna1		= ''
														,@TablaColumna2		= ''
														,@Operacion			= @Operacion
														,@UsuarioID			= @UsuarioIBitacora
														,@Descripcion		= @Descripcion
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
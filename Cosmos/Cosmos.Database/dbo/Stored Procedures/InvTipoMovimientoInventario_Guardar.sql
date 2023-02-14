-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [dbo].[InvTipoMovimientoInventario_Guardar]
@InvTipoMovimientoInventarioID int,
@InvTipoMovimientoInventarioClave varchar(10),
@Nombre varchar(50),
@NombreCorto varchar(20),
@EntradaSalida char(1)
-- Parámetros para Bitácora
	,@UsuarioIDBitacora		int
	,@DescripcionBitacora	varchar(500)	= null
	,@IpAddress				varchar(40)		= null
	,@HostName				varchar(50)		= null
AS
-- Variables para manejo de Errores
DECLARE @Errores int = 0, @Mensaje nvarchar(500) = '', @IDAActualizar int, @ClaveNoAsignado varchar(5)
-- Variables para Bitácora
DECLARE @TablaNombreIDBitacora   nvarchar(100) = 'InvTipoMOvimientoInventario',	
		@Operacion	nvarchar(20) = '', 
		@logMessage	varchar(Max) = '',
		@isChangeBeLogged bit
-- Variables para valores anteriores (Bitácora Update) 
DECLARE	@InvTipoMovimientoInventarioID_ int = @InvTipoMovimientoInventarioID,
		@InvTipoMovimientoInventarioClave_ varchar(10) = @InvTipoMovimientoInventarioClave,
		@Nombre_ varchar(50) = @Nombre,
		@NombreCorto_ varchar(20) = @NombreCorto,
		@EntradaSalida_ char(1) = @EntradaSalida

SET NOCOUNT ON 
SET XACT_ABORT ON;
BEGIN TRY
	BEGIN TRANSACTION

	SET @IDAActualizar = @InvTipoMovimientoInventarioID
	-- Si es UPDATE -> Lee valores anteriores de las columnas (Bitácora Update) 
	IF @IDAActualizar > 0
	BEGIN

		SELECT	@InvTipoMovimientoInventarioID_ = IsNull(InvTipoMovimientoInventarioID,0),
				@InvTipoMovimientoInventarioClave_ = IsNull(InvTipoMovimientoInventarioClave,''),
				@Nombre_ = IsNull(Nombre,''),
				@NombreCorto_ = IsNull(NombreCorto,''),
				@EntradaSalida_ = IsNull(EntradaSalida,0)
				
		   FROM	InvTipoMovimientoInventario WHERE InvTipoMovimientoInventarioID = @InvTipoMovimientoInventarioID
		IF @@RowCount = 0
		SELECT @Errores = 999999, @Mensaje = CONCAT('No se encontró el ID a Actualizar:', ' ', @IDAActualizar);
	END
	-- Si no hubo error (es INSERT o es UPDATE y existe el registro)
	IF @Errores = 0
	BEGIN
		-- Si la llave existe hace UPDATE y si no, hace INSERT
		IF @IDAActualizar > 0
		BEGIN
			UPDATE	 InvTipoMovimientoInventario
			SET      InvTipoMovimientoInventarioClave = @InvTipoMovimientoInventarioClave,
					 Nombre = @Nombre,
					 NombreCorto = @NombreCorto,
					 EntradaSalida = @EntradaSalida
			WHERE	 InvTipoMovimientoInventarioID = @IDAActualizar
		END
		ELSE
		BEGIN        
			INSERT  INTO InvTipoMovimientoInventario(
						 InvTipoMovimientoInventarioClave,
						Nombre,
						NombreCorto,
						EntradaSalida)
			VALUES  (
						@InvTipoMovimientoInventarioClave,
						@Nombre,
						@NombreCorto,
						@EntradaSalida)
        
			SET     @IDAActualizar = SCOPE_IDENTITY()
		END

		IF @@RowCount > 0
		BEGIN
			/* Procesa Bitácora */
			-- Determina si fue UPDATE o INSERT
			IF @InvTipoMovimientoInventarioID_ > 0  SET @Operacion = 'Update' 	
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
				SET @logMessage = Concat('InvTipoMovimientoInventarioClave::', @InvTipoMovimientoInventarioClave_, ':', @InvTipoMovimientoInventarioClave, ';')
				SET @logMessage = Concat(@logMessage, 'Nombre::', @Nombre_, ':', @Nombre, ';')
				SET @logMessage = Concat(@logMessage, 'NombreCorto::', @NombreCorto_, ':', @NombreCorto, ';')
				SET @logMessage = Concat(@logMessage, 'EntradaSalida::', @EntradaSalida_, ':', @EntradaSalida_, ';')
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
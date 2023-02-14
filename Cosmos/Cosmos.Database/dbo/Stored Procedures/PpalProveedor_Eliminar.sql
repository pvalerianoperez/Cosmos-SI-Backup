CREATE PROCEDURE [dbo].[PpalProveedor_Eliminar]
@PpalProveedorID int
-- Parámetros para Bitácora
	,@UsuarioIDBitacora		int
	,@DescripcionBitacora	varchar(500)	= null
	,@IpAddress			varchar(40)		= null
	,@HostName			varchar(50)		= null
AS
-- Variables para manejo de Errores
DECLARE @Errores int = 0, @Mensaje nvarchar(300), @IDABorrar int, @EliminarPersonaID int , @ComparteProveedor char(1),@Unico int
SELECT @EliminarPersonaID = EspPersonaID FROM PpalProveedor WHERE PpalProveedorID = @PpalProveedorID
-- Variables para Bitácora
DECLARE @TablaNombreIDBitacora   nvarchar(100) = 'PpalProveedor',	
		@Operacion	nvarchar(20) = 'Delete', 
		@logMessage	varchar(Max) = '',
		@isChangeBeLogged bit

SET NOCOUNT ON 
SET XACT_ABORT ON;
BEGIN TRY
	BEGIN TRANSACTION

	SET @IDABorrar = @PpalProveedorID
	BEGIN
		select @ComparteProveedor = ComparteProveedor from CfgParamConfigUsuarioCosmos
		IF @ComparteProveedor = 'G'
			BEGIN  				
				DELETE
				FROM    PpalProveedorEmpresaSucursal
				WHERE   PpalProveedorID = @PpalProveedorID 
			END
		IF @ComparteProveedor = 'E'
			BEGIN    
				SELECT EmpresaID FROM  PpalProveedorEmpresaSucursal WHERE PpalProveedorID = @PpalProveedorID GROUP BY EmpresaID
				IF  @@RowCount < 2
				BEGIN
					DELETE
					FROM    PpalProveedorEmpresaSucursal
					WHERE   PpalProveedorID = @PpalProveedorID 
				END
			END
		IF @ComparteProveedor = 'S'
			BEGIN    
				SELECT EmpresaID FROM  PpalProveedorEmpresaSucursal WHERE PpalProveedorID = @PpalProveedorID GROUP BY EmpresaID					
				IF @@RowCount = 1
				BEGIN
					DELETE
					FROM    PpalProveedorEmpresaSucursal
					WHERE   PpalProveedorID = @PpalProveedorID 
				END
			END
		DELETE 
		FROM    PpalProveedor
		WHERE   PpalProveedorID = @PpalProveedorID
		-- Si no se encontró registro a eliminar -> error
		IF @@RowCount = 0
		BEGIN
			SELECT @Errores = 999998, @Mensaje = CONCAT('No se encontró el ID a Eliminar:', ' ', @PpalProveedorID)
			ROLLBACK TRANSACTION
		END
		ELSE
		BEGIN
    		/* Procesa Bitácora */
			-- Revisa si el borrado debe ser guardado en Bitácora
			EXEC	@isChangeBeLogged	=   SistemaLogRegla_Consultar_LogBit
					@UsuarioID			=	@UsuarioIDBitacora,
					@TablaNombre		=   @TablaNombreIDBitacora,
					@Operacion			=	@Operacion

			-- Si el borrado debe guardarse, prepara variables de Bitácora y lo guarda
			IF @isChangeBeLogged = 1
			BEGIN
				-- LogMessage = Parámetro para borrado
				SET @logMessage = Concat('PpalProveedorID::', @PpalProveedorID, ':', 0, ';')

				-- Guarda en Bitácora
				EXEC 	 [dbo].[SistemaLog_Guardar] @TablaNombre		= @TablaNombreIDBitacora
														,@TablaID			= @PpalProveedorID
														,@TablaColumna1		= ''
														,@TablaColumna2		= ''
														,@Operacion			= @Operacion
														,@UsuarioID			= @UsuarioIDBitacora
														,@Descripcion		= @DescripcionBitacora
														,@Cambios			= @logMessage
														,@IpAddress			= @IpAddress
														,@HostName			= @HostName
			END
			COMMIT TRANSACTION
		END
	END
	-- Fin de proceso sin errores -> COMMIT
END TRY
-- Si hubo error los procesa y lo regresa
BEGIN CATCH
	IF (XACT_STATE()) = -1 ROLLBACK TRANSACTION;
	IF (XACT_STATE()) = 1 COMMIT TRANSACTION;
    SELECT @Errores = ERROR_NUMBER(), 
			@Mensaje = dbo.FDecodificaError(ERROR_NUMBER(), ERROR_MESSAGE(), ERROR_SEVERITY(), ERROR_STATE(), ERROR_PROCEDURE(), ERROR_LINE())
END CATCH 
--EXEC [PpalPersona_Eliminar]
--@ModificacionUsuarioID = null,
--@PersonaID = @EliminarPersonaID

SELECT  COALESCE(@Errores, 0) as Errores, 
        COALESCE(@Mensaje, '') as Mensaje,
		COALESCE(ERROR_SEVERITY(), 0) as Severidad,
		COALESCE(ERROR_STATE(), 0) as Estado,
		COALESCE(ERROR_PROCEDURE(), '') as ProcedimientoAlmacenado,
		COALESCE(ERROR_LINE(), 0) as Linea,
		@IDABorrar as EliminarID
SET NOCOUNT OFF
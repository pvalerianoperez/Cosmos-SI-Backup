CREATE PROCEDURE [dbo].[PpalProveedorUltimoCodigo_Listado]
@TipoListado varchar(10) = ''
-- Parámetros para Bitácora
	,@EmpresaIDSolicitudBase int = null
	,@UsuarioIDBitacora		int
	,@DescripcionBitacora	varchar(500)	= null
	,@IpAddress			varchar(40)		= null
	,@HostName			varchar(50)		= null
AS
-- Variables para manejo de Errores
DECLARE @Errores int = 0, @Mensaje nvarchar(500), @ComparteProveedor char(1)
-- Variables para Bitácora          
DECLARE @TablaNombreIDBitacora   nvarchar(100) = 'PpalProveedor',	
		@Operacion	nvarchar(20) = 'List', 
		@logMessage	varchar(Max) = '',
		@isChangeBeLogged bit
-- 
DECLARE @PpalProveedorClave varchar(20),
		@PpalProveedorDigitos int

SET NOCOUNT ON 
SET XACT_ABORT ON;
BEGIN TRY
	BEGIN TRANSACTION

	/* Procesa Bitácora */
	-- Revisa si el cambio debe ser guardado en Bitácora
	EXEC	@isChangeBeLogged	=   SistemaLogRegla_Consultar_LogBit
			@UsuarioID			=	@UsuarioIDBitacora,
			@TablaNombre		=   @TablaNombreIDBitacora,
			@Operacion			=	@Operacion

	-- Si el cambio debe guardarse, prepara variables de Bitácora y lo guarda
	IF @isChangeBeLogged = 1 And @@RowCount > 0
	BEGIN
		-- logMessage = Parámetros de Listado
		SET @logMessage =  Concat('EmpresaID::', @EmpresaIDSolicitudBase, ':',0, ';')

		-- Guarda en Bitácora
		EXEC 	 [dbo].[SistemaLog_Guardar] @TablaNombre		= @TablaNombreIDBitacora
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


	select @ComparteProveedor = ComparteProveedor from CfgParamConfigUsuarioCosmos
	BEGIN
	IF @ComparteProveedor = 'G'
		BEGIN
			IF @TipoListado = 'Minimo'
				IF (SELECT ProveedorClaveAutomatico  FROM CfgParamConfigUsuarioCosmos) = 'S'
				BEGIN
					SELECT @PpalProveedorClave = (SELECT MAX(PpalProveedorClave) FROM PpalProveedor PP
										inner join PpalProveedorEmpresaSucursal PPES on PP.PpalProveedorID = PPES.PpalProveedorID
											AND (PPES.EmpresaID = @EmpresaIDSolicitudBase or PPES.EmpresaID IS NULL))
					SELECT @PpalProveedorDigitos = (SELECT ProveedorClaveDigitos FROM CfgParamConfigUsuarioCosmos)
					SET @PpalProveedorClave = right('00000000000000000000' + cast(cast(@PpalProveedorClave as decimal) + 1 as varchar), @PpalProveedorDigitos)
					SELECT  0 AS ID,						@PpalProveedorClave AS Clave,				'' AS Nombre,			
							'' AS NombreCorto,				0 as PadreID
				END
				ELSE
					SELECT  0 AS ID,						'' AS Clave,				'' AS Nombre,			
							'' AS NombreCorto,				0 as PadreID
			ELSE	
					SELECT  0 AS ID,						'' AS Clave,				'' AS Nombre,			
							'' AS NombreCorto,				0 as PadreID
		END	
	IF @ComparteProveedor = 'E'
		BEGIN        
			IF @TipoListado = 'Minimo'
				IF (SELECT ProveedorClaveAutomatico  FROM CfgParamConfigUsuarioCosmos) = 'S'
				BEGIN
					SELECT @PpalProveedorClave = (SELECT MAX(PpalProveedorClave) FROM PpalProveedor PP
										inner join PpalProveedorEmpresaSucursal PPES on PP.PpalProveedorID = PPES.PpalProveedorID
											AND (PPES.EmpresaID = @EmpresaIDSolicitudBase or PPES.EmpresaID IS NULL))
					SELECT @PpalProveedorDigitos = (SELECT ProveedorClaveDigitos FROM CfgParamConfigUsuarioCosmos)
					SET @PpalProveedorClave = right('00000000000000000000' + cast(cast(@PpalProveedorClave as decimal) + 1 as varchar), @PpalProveedorDigitos)
					SELECT  0 AS ID,						@PpalProveedorClave AS Clave,				'' AS Nombre,			
							'' AS NombreCorto,				0 as PadreID
				END
				ELSE
					SELECT  0 AS ID,						'' AS Clave,				'' AS Nombre,			
							'' AS NombreCorto,				0 as PadreID
			ELSE	
					SELECT  0 AS ID,						'' AS Clave,				'' AS Nombre,			
							'' AS NombreCorto,				0 as PadreID
		END
	IF @ComparteProveedor = 'S'
		BEGIN
			IF @TipoListado = 'Minimo'
				IF (SELECT ProveedorClaveAutomatico  FROM CfgParamConfigUsuarioCosmos) = 'S'
				BEGIN
					SELECT @PpalProveedorClave = (SELECT MAX(PpalProveedorClave) FROM PpalProveedor PP
							inner join PpalProveedorEmpresaSucursal PPES on PP.PpalProveedorID = PPES.PpalProveedorID
														AND (PPES.EmpresaID = @EmpresaIDSolicitudBase or PPES.EmpresaID IS NULL)
							where PP.PpalProveedorID in (select PpalProveedorID from PpalProveedorEmpresaSucursal
										where EmpresaID is NULL) or
							PP.PpalProveedorID in (select PpalProveedorID from PpalProveedorEmpresaSucursal
										where EmpresaID = @EmpresaIDSolicitudBase and PpalSucursalID is NULL))					
					SELECT @PpalProveedorDigitos = (SELECT ProveedorClaveDigitos FROM CfgParamConfigUsuarioCosmos)
					SET @PpalProveedorClave = right('00000000000000000000' + cast(cast(@PpalProveedorClave as decimal) + 1 as varchar), @PpalProveedorDigitos)
					SELECT  0 AS ID,						@PpalProveedorClave AS Clave,				'' AS Nombre,			
							'' AS NombreCorto,				0 as PadreID
				END
				ELSE
					SELECT  0 AS ID,						'' AS Clave,				'' AS Nombre,			
							'' AS NombreCorto,				0 as PadreID
			ELSE	
					SELECT  0 AS ID,						'' AS Clave,				'' AS Nombre,			
							'' AS NombreCorto,				0 as PadreID


		END
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
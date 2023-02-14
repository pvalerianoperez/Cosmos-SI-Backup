CREATE PROCEDURE [dbo].[CfgPeriodoOperativo_Guardar]
@PeriodoOperativoID INT,
@EjercicioOperativoID INT,
@PeriodoClave VARCHAR(6),
@Nombre VARCHAR(20),
@NombreCorto VARCHAR(6),
@PeriodoOrden INT,
@FechaInicial DATE,
@FechaFinal DATE,
@FechaEjercePresupuesto Date
-- Parámetros para Bitácora
	,@UsuarioIDBitacora		int
	,@DescripcionBitacora	varchar(500)	= null
	,@IpAddress				varchar(40)		= null
	,@HostName				varchar(50)		= null

AS
-- Variables para manejo de Errores
DECLARE @Errores int = 0, @Mensaje nvarchar(300) = '', @IDAActualizar int
-- Variables para Bitácora
DECLARE @TablaNombreIDBitacora   nvarchar(100) = 'CfgPeriodoOperativo',	
		@Operacion	nvarchar(20) = '', 
		@logMessage	varchar(Max) = '',
		@isChangeBeLogged bit
-- Variables para valores anteriores (Bitácora Update) 
DECLARE	@PeriodoOperativoID_ INT = @PeriodoOperativoID,
		@EjercicioOperativoID_ INT = 0,
		@PeriodoClave_ VARCHAR(6) = '',
		@Nombre_ VARCHAR(20) = '',
		@NombreCorto_ VARCHAR(6) = '',
		@PeriodoOrden_ INT = 0,
		@FechaInicial_ DATE,
		@FechaFinal_ DATE

SET NOCOUNT ON 
SET XACT_ABORT ON;
BEGIN TRY
	BEGIN TRANSACTION

	SET @IDAActualizar = @PeriodoOperativoID
	-- Si es UPDATE -> Lee valores anteriores de las columnas (Bitácora Update) 
	IF @IDAActualizar > 0
	BEGIN
		SELECT	@EjercicioOperativoID_ =	IsNull(CfgEjercicioOperativoID, 0),
				@PeriodoClave_ =			IsNull(CfgPeriodoClave, ''),
				@Nombre_ =					IsNull(Nombre,''),
				@NombreCorto_ =				IsNull(NombreCorto,''),
				@PeriodoOrden_ =			IsNull(PeriodoOrden,''),
				@FechaInicial_ =			IsNull(FechaInicial, sysdatetime()),
				@FechaFinal_ =				IsNull(FechaFinal, sysdatetime())
		   FROM	CfgPeriodoOperativo WHERE CfgPeriodoOperativoID = @IDAActualizar
		IF @@RowCount = 0
		SELECT @Errores = 999999, @Mensaje = CONCAT('No se encontró el ID a Actualizar:', ' ', @IDAActualizar);
	END
	-- Si no hubo error (es INSERT o es UPDATE y existe el registro)
	IF @Errores = 0
	BEGIN
		-- Si la llave existe hace UPDATE y si no, hace INSERT
		IF @IDAActualizar > 0

		BEGIN
			UPDATE  CfgPeriodoOperativo
			SET     CfgEjercicioOperativoID = @EjercicioOperativoID,
					CfgPeriodoClave = @PeriodoClave,
					Nombre = @Nombre,
					NombreCorto = @NombreCorto,
					PeriodoOrden = @PeriodoOrden,
					FechaInicial = @FechaInicial,
					FechaFinal = @FechaFinal
			WHERE   CfgPeriodoOperativoID = @IDAActualizar
		END
		ELSE
		BEGIN        
			INSERT  INTO CfgPeriodoOperativo(
					CfgEjercicioOperativoID,
					CfgPeriodoClave,
					Nombre,
					NombreCorto,
					PeriodoOrden,
					FechaInicial,
					FechaFinal)
			VALUES  (
					@EjercicioOperativoID,
					@PeriodoClave,
					@Nombre,
					@NombreCorto,
					@PeriodoOrden,
					@FechaInicial,
					@FechaFinal)
        
			SET     @IDAActualizar = SCOPE_IDENTITY()
		END

		IF @@RowCount > 0
		BEGIN
			/* Procesa Bitácora */
			-- Determina si fue UPDATE o INSERT
			IF @EjercicioOperativoID_ > 0  SET @Operacion = 'Update' 	
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
				SET @logMessage = Concat('BancoClave::', @PeriodoClave_, ':', @PeriodoClave, ';')
				SET @logMessage = Concat(@logMessage, 'Nombre::', @Nombre_, ':', @Nombre, ';')
				SET @logMessage = Concat(@logMessage, 'NombreCorto::', @NombreCorto_, ':', @NombreCorto, ';')
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


CREATE PROCEDURE [dbo].[EspDomicilio_Consultar]
@EspDomicilioID int
-- Parámetros para Bitácora
	,@UsuarioIDBitacora		int
	,@DescripcionBitacora	varchar(500)	= null
	,@IpAddress				varchar(40)		= null
	,@HostName				varchar(50)		= null

AS
-- Variables para manejo de Errores
DECLARE @Errores int = 0, @Mensaje nvarchar(300), @IDAConsultar int
-- Variables para Bitácora
DECLARE @TablaNombreIDBitacora   nvarchar(100) = 'EspDomicilio',	
		@Operacion	nvarchar(20) = 'Read', 
		@logMessage	varchar(Max) = '',
		@isChangeBeLogged bit

-- Variables para valores de columnas
DECLARE	@EspDomicilioID_ int = @EspDomicilioID,
		@Calle_ varchar(50) = '',
		@NumeroExterior_ varchar(20) = '',
		@NumeroInterior_ varchar(20) = '',
		@EntreCalle1_ varchar(40) = '',
		@EntreCalle2_ varchar(40) = '',
		@CodigoPostal_ int = 0,
		@EspColoniaID_ int = 0,
		@Coordenadas_ varchar(40) = '',
		@Observaciones_ varchar(100) = ''
SET NOCOUNT ON 
SET XACT_ABORT ON;
BEGIN TRY
	BEGIN TRANSACTION

	SET @IDAConsultar = @EspDomicilioID
	SELECT  EspDomicilioID = @EspDomicilioID_,				Calle =			@Calle_,			NumeroExterior =	@NumeroExterior_,
			NumeroInterior = @NumeroInterior_,				EntreCalle1 =	@EntreCalle1_,		EntreCalle2 =		@EntreCalle2_,
			CodigoPostal =	 @CodigoPostal_,				EspColoniaID =	@EspColoniaID_,		Coordenadas =		@Coordenadas_,
			Observaciones =	 @Observaciones_,				c.EspCiudadID,						c.EspMunicipioID, 
			m.EspEstadoID,										e.EspPaisID, 
			Calle + ' ' + NumeroExterior + ' ' +  c.Nombre + ' ' + e.Nombre as DomicilioCompleto
	FROM    EspDomicilio d, EspCiudad c, EspMunicipio m, EspEstado e
	WHERE   EspDomicilioID = @EspDomicilioID and d.EspCiudadID = c.EspCiudadID and c.EspMunicipioID = m.EspMunicipioID 
			and m.EspEstadoID = e.EspEstadoID

	-- Si no se encontró registro a Consultar -> error
	IF @@RowCount = 0
		SELECT @Errores = 999997, @Mensaje = CONCAT('No se encontró el ID a Consultar:', ' ', @IDAConsultar)
	ELSE
	BEGIN
		/* Procesa Bitácora */
		-- Revisa si la consulta debe ser guardado en Bitácora
		EXEC	@isChangeBeLogged	=   SistemaLogRegla_Consultar_LogBit
				@UsuarioID			=	@UsuarioIDBitacora,
				@TablaNombre		=   @TablaNombreIDBitacora,
				@Operacion			=	@Operacion

		-- Si la consulta debe guardarse, prepara variables de Bitácora y lo guarda
		IF @isChangeBeLogged = 1 
		BEGIN
			-- LogMessage = Parámetros de Consulta
			SET @logMessage = Concat('EspDomicilioID::', @EspDomicilioID, ':', 0, ';')
	
			-- Guarda en Bitácora
			EXEC 	 [dbo].[SistemaLog_Guardar] @TablaNombre		= @TablaNombreIDBitacora
													,@TablaID			= @IDAConsultar
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
	-- Si no hubo errores -> COMMIT
	COMMIT TRANSACTION
END TRY
-- Si hubo error lo procesa y lo regresa
BEGIN CATCH
	IF (XACT_STATE()) = -1 ROLLBACK TRANSACTION;
	IF (XACT_STATE()) = 1 COMMIT TRANSACTION;
    SELECT @Errores = ERROR_NUMBER(), 
			@Mensaje = dbo.FDecodificaError(ERROR_NUMBER(), ERROR_MESSAGE(), ERROR_SEVERITY(), ERROR_STATE(), ERROR_PROCEDURE(), ERROR_LINE())
END CATCH 

IF @Errores = 0
	SELECT  @IDAConsultar	 as EspDomicilioID, 		@Calle_			as Calle,				@NumeroExterior_ as NumeroExterior,
			@NumeroInterior_ as NumeroInterior,			@EntreCalle1_	as EntreCalle1,			@EntreCalle2_ as EntreCalle2,
			@CodigoPostal_	 as CodigoPostal,			@EspColoniaID_	as EspColoniaID,		@Coordenadas_ as Coordinadas, 
			@Observaciones_	 as Observaciones
			
ELSE
	SELECT  COALESCE(@Errores, 0) as Errores, 
			COALESCE(@Mensaje, '') as Mensaje,
			COALESCE(ERROR_SEVERITY(), 0) as Severidad,
			COALESCE(ERROR_STATE(), 0) as Estado,
			COALESCE(ERROR_PROCEDURE(), '') as ProcedimientoAlmacenado,
			COALESCE(ERROR_LINE(), 0) as Linea,
		    @IDAConsultar as ConsultarID
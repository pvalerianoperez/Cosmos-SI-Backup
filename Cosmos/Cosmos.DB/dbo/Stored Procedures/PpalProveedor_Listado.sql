CREATE PROCEDURE [dbo].[PpalProveedor_Listado]
@TipoListado varchar(10) = ''
-- Parámetros para Bitácora
	,@EmpresaIDSolicitudBase int = null
	,@UsuarioIDBitacora		int
	,@DescripcionBitacora	varchar(500)	= null
	,@IpAddress				varchar(40)		= null
	,@HostName				varchar(50)		= null
AS
-- Variables para manejo de Errores
DECLARE @Errores int = 0, @Mensaje nvarchar(500), @ComparteProveedor char(1)
-- Variables para Bitácora          
DECLARE @TablaNombreIDBitacora   nvarchar(100) = 'PpalProveedor',	
		@Operacion	nvarchar(20) = 'List', 
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
				SELECT  PP.PpalProveedorID AS ID,		PPES.PpalProveedorClave as Clave, 
						CASE WHEN FisicaMoral = 'F' THEN EP.Nombre + ' ' + EP.ApellidoPaterno + ' ' + EP.ApellidoMaterno
													ELSE EP.NombreComercial END AS Nombre,  
						EP.NombreCorto as NombreCorto,			0 as PadreID,				EP.RFC as Extra3
				FROM    PpalProveedor PP
				inner join EspPersona EP on PP.EspPersonaID = EP.EspPersonaID 
				inner join PpalProveedorEmpresaSucursal PPES on PP.PpalProveedorID = PPES.PpalProveedorID
											AND (PPES.EmpresaID = @EmpresaIDSolicitudBase or PPES.EmpresaID IS NULL)
				ORDER BY Nombre
			ELSE IF @TipoListado = 'Parcial'
				SELECT  PP.PpalProveedorID,					PP.EspPersonaID,			PP.AuxGiroEmpresaID, 
						PP.CmpTipoProveedorID,				PP.AuxGiroEmpresaID,		PP.AuxMedioContactoID,
						PP.AuxVinculoID,					PP.AplicaRetenciones,		EP.FisicaMoral,
						EP.NombreComercial,
						EP.RazonSocial,						EP.Nombre,					EP.ApellidoPaterno,
						EP.ApellidoMaterno,					EP.CURP,					EP.SistemaSexoID,
						EP.FechaNacimiento,					EP.EspCiudadNacimientoID,		EP.AuxEstadoCivilID,
						EP.CasadoCivil,						EP.CasadoIglesia,			EP.Iniciales,
						EP.Sobrenombre,						EP.NombreCorto,
						AGE.Nombre AS GiroEmpresaNombre,	EP.RFC,						PPES.PpalProveedorClave,
						CASE EP.FisicaMoral WHEN 'F' THEN EP.Nombre + ' ' + EP.ApellidoPaterno + ' ' + EP.ApellidoMaterno
								ELSE EP.NombreComercial END AS NombreCompleto,
						PPES.PpalSucursalID,				PPES.EmpresaID
				FROM    PpalProveedor PP	
				inner join EspPersona EP on PP.EspPersonaID = EP.EspPersonaID 
				inner join AuxGiroEmpresa AGE on PP.AuxGiroEmpresaID =  AGE.AuxGiroEmpresaID
				inner join PpalProveedorEmpresaSucursal PPES on PP.PpalProveedorID = PPES.PpalProveedorID
			ELSE
				SELECT  PP.PpalProveedorID,PP.EspPersonaID,PP.CmpTipoProveedorID,PP.AuxGiroEmpresaID,PP.AuxMedioContactoID,PP.AuxVinculoID,PP.AplicaRetenciones,
						EP.RazonSocial, EP.NombreComercial, EP.RFC, EP.NombreCorto, EP.FisicaMoral, AGE.Nombre as GiroEmpresaNombre,
						EP.Nombre, EP.ApellidoPaterno, EP.ApellidoMaterno, EP.CURP, EP.SistemaSexoID AS SexoID,
						CASE EP.FisicaMoral WHEN 'F' THEN EP.Nombre + ' ' + EP.ApellidoPaterno + ' ' + EP.ApellidoMaterno
								ELSE EP.NombreComercial END AS NombreCompleto,
						PPES.PpalProveedorClave
				FROM    PpalProveedor PP	
				inner join EspPersona EP on PP.EspPersonaID = EP.EspPersonaID 
				inner join AuxGiroEmpresa AGE on PP.AuxGiroEmpresaID =  AGE.AuxGiroEmpresaID
				inner join PpalProveedorEmpresaSucursal PPES on PP.PpalProveedorID = PPES.PpalProveedorID
		END	
	IF @ComparteProveedor = 'E'
		BEGIN        
			IF @TipoListado = 'Minimo'
				SELECT  PP.PpalProveedorID AS ID,		PPES.PpalProveedorClave as Clave, 
						CASE WHEN FisicaMoral = 'F' THEN EP.Nombre + ' ' + EP.ApellidoPaterno + ' ' + EP.ApellidoMaterno
													ELSE EP.NombreComercial END AS Nombre,  
						EP.NombreCorto as NombreCorto,			0 as PadreID,				EP.RFC as Extra3
				FROM PpalProveedor PP
				inner join EspPersona EP on PP.EspPersonaID = EP.EspPersonaID 
				inner join PpalProveedorEmpresaSucursal PPES on PP.PpalProveedorID = PPES.PpalProveedorID
											AND (PPES.EmpresaID = @EmpresaIDSolicitudBase or PPES.EmpresaID IS NULL)
				WHERE PP.PpalProveedorID in (SELECT PpalProveedorID FROM PpalProveedorEmpresaSucursal
							WHERE EmpresaID is NULL) or
				(SELECT Administrador FROM SegUsuario WHERE SegUsuarioID = @UsuarioIDBitacora) = 1 or
				(SELECT SegUsuarioSucursalID FROM SegUsuarioSucursal WHERE SegUsuarioID = @UsuarioIDBitacora and PpalSucursalID is Null) > 0 or
				PP.PpalProveedorID in (SELECT Max(PPES.PpalProveedorID) FROM SegUsuarioSucursal SUS, PpalProveedorEmpresaSucursal PPES, PpalSucursal PS1, PpalSucursal PS2
						WHERE SUS.PpalSucursalID = PS1.PpalSucursalID and PPES.PpalSucursalID = PS2.PpalSucursalID and
								PS1.EmpresaID = PS2.EmpresaID and PS1.EmpresaID = @EmpresaIDSolicitudBase and
							SUS.SegUsuarioID = @UsuarioIDBitacora)
			ELSE IF @TipoListado = 'Parcial'
				SELECT  PP.PpalProveedorID,					PP.EspPersonaID,			PP.AuxGiroEmpresaID, 
						PP.CmpTipoProveedorID,				PP.AuxGiroEmpresaID,		PP.AuxMedioContactoID,
						PP.AuxVinculoID,					PP.AplicaRetenciones,		EP.FisicaMoral,
						EP.NombreComercial,
						EP.RazonSocial,						EP.Nombre,					EP.ApellidoPaterno,
						EP.ApellidoMaterno,					EP.CURP,					EP.SistemaSexoID,
						EP.FechaNacimiento,					EP.EspCiudadNacimientoID,		EP.AuxEstadoCivilID,
						EP.CasadoCivil,						EP.CasadoIglesia,			EP.Iniciales,
						EP.Sobrenombre,						EP.NombreCorto,
						AGE.Nombre AS GiroEmpresaNombre,	EP.RFC,						PPES.PpalProveedorClave,
						CASE EP.FisicaMoral WHEN 'F' THEN EP.Nombre + ' ' + EP.ApellidoPaterno + ' ' + EP.ApellidoMaterno
								ELSE EP.NombreComercial END AS NombreCompleto,
						PPES.PpalSucursalID,				PPES.EmpresaID
				FROM PpalProveedor PP
				inner join EspPersona EP on PP.EspPersonaID = EP.EspPersonaID 
				inner join AuxGiroEmpresa AGE on PP.AuxGiroEmpresaID =  AGE.AuxGiroEmpresaID
				inner join PpalProveedorEmpresaSucursal PPES on PP.PpalProveedorID = PPES.PpalProveedorID
				WHERE PP.PpalProveedorID in (SELECT PpalProveedorID FROM PpalProveedorEmpresaSucursal
							WHERE EmpresaID is NULL) or
				(SELECT Administrador FROM SegUsuario WHERE SegUsuarioID = @UsuarioIDBitacora) = 1 or
				(SELECT SegUsuarioSucursalID FROM SegUsuarioSucursal WHERE SegUsuarioID = @UsuarioIDBitacora and PpalSucursalID is Null) > 0 or
				PP.PpalProveedorID in (SELECT Max(PPES.PpalProveedorID) FROM SegUsuarioSucursal SUS, PpalProveedorEmpresaSucursal PPES, PpalSucursal PS1, PpalSucursal PS2
						WHERE SUS.PpalSucursalID = PS1.PpalSucursalID and PPES.PpalSucursalID = PS2.PpalSucursalID and
								PS1.EmpresaID = PS2.EmpresaID and PS1.EmpresaID = @EmpresaIDSolicitudBase and
							SUS.SegUsuarioID = @UsuarioIDBitacora)
			ELSE
				SELECT * FROM PpalProveedor PP
				WHERE PP.PpalProveedorID in (SELECT PpalProveedorID FROM PpalProveedorEmpresaSucursal
							WHERE EmpresaID is NULL) or
				(SELECT Administrador FROM SegUsuario WHERE SegUsuarioID = @UsuarioIDBitacora) = 1 or
				(SELECT SegUsuarioSucursalID FROM SegUsuarioSucursal WHERE SegUsuarioID = @UsuarioIDBitacora and PpalSucursalID is Null) > 0 or
				PP.PpalProveedorID in (SELECT Max(PPES.PpalProveedorID) FROM SegUsuarioSucursal SUS, PpalProveedorEmpresaSucursal PPES, PpalSucursal PS1, PpalSucursal PS2
						WHERE SUS.PpalSucursalID = PS1.PpalSucursalID and PPES.PpalSucursalID = PS2.PpalSucursalID and
								PS1.EmpresaID = PS2.EmpresaID and PS1.EmpresaID = @EmpresaIDSolicitudBase and
							SUS.SegUsuarioID = @UsuarioIDBitacora) 
		END
		IF @ComparteProveedor = 'S'
		BEGIN
			IF @TipoListado = 'Minimo'
				SELECT  PP.PpalProveedorID AS ID,		PPES.PpalProveedorClave as Clave, 
						CASE WHEN FisicaMoral = 'F' THEN EP.Nombre + ' ' + EP.ApellidoPaterno + ' ' + EP.ApellidoMaterno
													ELSE EP.NombreComercial END AS Nombre,  
						EP.NombreCorto as NombreCorto,			0 as PadreID,				EP.RFC as Extra3
				from PpalProveedor PP
				inner join EspPersona EP on PP.EspPersonaID = EP.EspPersonaID 
				inner join PpalProveedorEmpresaSucursal PPES on PP.PpalProveedorID = PPES.PpalProveedorID
											AND (PPES.EmpresaID = @EmpresaIDSolicitudBase or PPES.EmpresaID IS NULL)
				where PP.PpalProveedorID in (select PpalProveedorID from PpalProveedorEmpresaSucursal
							where EmpresaID is NULL) or
				PP.PpalProveedorID in (select PpalProveedorID from PpalProveedorEmpresaSucursal
							where EmpresaID = @EmpresaIDSolicitudBase and PpalSucursalID is NULL) and
				(Select Max(SegUsuarioSucursalID) from SegUsuarioSucursal where SegUsuarioID = @UsuarioIDBitacora) > 0 or
				(Select administrador from SegUsuario where SegUsuarioID = @UsuarioIDBitacora) = 1 or
				(Select SegUsuarioSucursalID from SegUsuarioSucursal where SegUsuarioID = @UsuarioIDBitacora and PpalSucursalID is Null) > 0 or
				PP.PpalProveedorID in (Select Max(PPES.PpalProveedorID) from SegUsuarioSucursal SUS, PpalProveedorEmpresaSucursal PPES
						where SUS.PpalSucursalID = PPES.PpalSucursalID and
							SUS.SegUsuarioID = @UsuarioIDBitacora)
			ELSE
				SELECT * from PpalProveedor PP
				where PP.PpalProveedorID in (select PpalProveedorID from PpalProveedorEmpresaSucursal
							where EmpresaID is NULL) or
				PP.PpalProveedorID in (select PpalProveedorID from PpalProveedorEmpresaSucursal
							where EmpresaID = @EmpresaIDSolicitudBase and PpalSucursalID is NULL) and
				(Select Max(SegUsuarioSucursalID) from SegUsuarioSucursal where SegUsuarioID = @UsuarioIDBitacora) > 0 or
				(Select administrador from SegUsuario where SegUsuarioID = @UsuarioIDBitacora) = 1 or
				(Select SegUsuarioSucursalID from SegUsuarioSucursal where SegUsuarioID = @UsuarioIDBitacora and PpalSucursalID is Null) > 0 or
				PP.PpalProveedorID in (Select Max(PPES.PpalProveedorID) from SegUsuarioSucursal SUS, PpalProveedorEmpresaSucursal PPES
						where SUS.PpalSucursalID = PPES.PpalSucursalID and
							SUS.SegUsuarioID = @UsuarioIDBitacora) 
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


CREATE PROCEDURE [dbo].[PpalProveedorEmpresaSucursal_Consultar]
@PpalProveedorEmpresaSucursalID int
-- Parámetros para Bitácora
	,@UsuarioIDBitacora		int
	,@DescripcionBitacora	varchar(500)	= null
	,@IpAddress				varchar(40)		= null
	,@HostName				varchar(50)		= null

AS


	SELECT  PpalProveedorEmpresaSucursalID,PpalSucursalID,PpalProveedorID,PpalProveedorClave,Activo,EmpresaID
	FROM    PpalProveedorEmpresaSucursal
	WHERE   PpalProveedorEmpresaSucursalID = @PpalProveedorEmpresaSucursalID
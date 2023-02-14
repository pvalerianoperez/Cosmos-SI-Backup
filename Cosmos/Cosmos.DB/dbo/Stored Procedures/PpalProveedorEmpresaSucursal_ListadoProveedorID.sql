

CREATE PROCEDURE [dbo].[PpalProveedorEmpresaSucursal_ListadoProveedorID]
@PpalProveedorID INT
as

	SELECT  PpalProveedorEmpresaSucursalID,pes.PpalSucursalID,PpalProveedorID,PpalProveedorClave,Activo,
			s.PpalSucursalClave, s.Nombre as NombreSucursal,E.Nombre as EmpresaNombre
	FROM    PpalProveedorEmpresaSucursal pes
			inner join PpalSucursal s on pes.PpalSucursalID = s.PpalSucursalID 
			inner join SistemaEmpresa E on s.EmpresaID = E.EmpresaID
	WHERE   PpalProveedorID = @PpalProveedorID
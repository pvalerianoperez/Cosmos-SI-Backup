


/*select * from persona
select * from proveedor*/
CREATE VIEW [dbo].[vProveedor]
AS
SELECT        PpalProveedorID, EspPersonaID, CmpTipoProveedorID, AuxGiroEmpresaID, AuxMedioContactoID, AuxVinculoID
FROM            dbo.PpalProveedor
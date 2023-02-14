

CREATE PROCEDURE [dbo].[PpalProveedor_ConsultarComplemento]
@PpalProveedorID int
AS
select d.* from EspDomicilio d
inner join PpalProveedorDomicilio pd on d.EspDomicilioID = pd.EspDomicilioID
inner join PpalProveedor p on pd.PpalProveedorID = p.PpalProveedorID
where p.PpalProveedorID = @PpalProveedorID
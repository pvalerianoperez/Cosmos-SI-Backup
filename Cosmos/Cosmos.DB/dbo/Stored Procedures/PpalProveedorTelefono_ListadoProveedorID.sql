
CREATE PROCEDURE [dbo].[PpalProveedorTelefono_ListadoProveedorID]
@PpalProveedorID int
AS


SELECT	pt.PpalProveedorTelefonoID,pt.PpalProveedorID,pt.CfgUsoTelefonoID,ut.Nombre as CfgUsoTelefonoNombre,pt.Predeterminado,pt.Comentarios, 
		pt.EspTelefonoID,t.CfgTipoTelefonoID,tt.Nombre as CfgTipoTelefonoNombre,t.SistemaEstatusTelefonoID,t.Comentario,
		t.ClaveTelefonicaPais, t.NumeroTelefonico as NumeroTelefonico,pt.Extension,
		(select concat('(',t.ClaveTelefonicaPais,') ',t.NumeroTelefonico,' / ',pt.Extension)) as TelefonoCompleto,
		p.EspPaisID as PaisID,p.Nombre as PaisNombre
FROM	PpalProveedorTelefono pt
	inner join EspTelefono t on pt.EspTelefonoID = t.EspTelefonoID
	inner join CfgUsoTelefono  ut on pt.CfgUsoTelefonoID = ut.CfgUsoTelefonoID
	inner join CfgTipoTelefono tt on t.CfgTipoTelefonoID = tt.CfgTipoTelefonoID
	inner join EspPais p on p.ClaveTelefonicaPais = t.ClaveTelefonicaPais
WHERE	pt.PpalProveedorID = @PpalProveedorID
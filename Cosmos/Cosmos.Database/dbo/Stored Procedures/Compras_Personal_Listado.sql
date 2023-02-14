

CREATE PROCEDURE [dbo].[Compras_Personal_Listado]
@EmpresaID int
AS

SELECT  a.PersonalID,a.PersonaID,a.PersonalClave,a.EmpresaID,a.PuestoID,a.ReportaAPersonalID,a.AreaID,a.CentroCostoID,a.HorarioPersonalID,a.EstatusPersonalID,
		b.*		
FROM    Personal a
		INNER JOIN vPersona b ON a.PersonaID = b.PersonaID
WHERE	a.EmpresaID = @EmpresaID
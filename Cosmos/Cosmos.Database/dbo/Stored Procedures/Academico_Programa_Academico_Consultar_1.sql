

create procedure [dbo].[Academico_Programa_Academico_Consultar]

	@ProgramaAcademicoID as int

as

	select * 
	from   AcProgramaAcademico
	where  ProgramaAcademicoID = @ProgramaAcademicoID

return 0
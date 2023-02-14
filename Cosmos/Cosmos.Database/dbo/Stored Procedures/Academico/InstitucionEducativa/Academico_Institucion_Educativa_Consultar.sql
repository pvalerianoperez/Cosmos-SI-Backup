

create procedure [dbo].[Academico_Institucion_Educativa_Consultar]

	@InstitucionEducativaID as int

as

	select * 
	from   AcInstitucionEducativa
	where  InstitucionEducativaID = @InstitucionEducativaID

return 0

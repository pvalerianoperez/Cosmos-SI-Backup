CREATE PROCEDURE [dbo].[Academico_Programa_Academico_Listado]

AS
	select     
		 	 [ProgramaAcademicoID] 
			,[ProgramaAcademicoClave]
			,[Nombre] 
			,[NombreCorto]  
			,[ExtraTexto1]  
			,[ExtraTexto2]   
			,[ExtraTexto3]
			,[ExtraFecha1] 
			,[ExtraFecha2]
	from   AcProgramaAcademico

return 0
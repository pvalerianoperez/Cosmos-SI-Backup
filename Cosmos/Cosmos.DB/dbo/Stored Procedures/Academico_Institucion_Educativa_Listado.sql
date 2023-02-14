CREATE PROCEDURE [dbo].[Academico_Institucion_Educativa_Listado]

AS
	select     
		 	 [InstitucionEducativaID] 
			,[InstitucionEducativaClave]
			,[Nombre] 
			,[NombreCorto]  
			,[ExtraTexto1]  
			,[ExtraTexto2]   
			,[ExtraTexto3]
			,[ExtraFecha1] 
			,[ExtraFecha2] 
			,[ExtraDecimal1]
			,[ExtraDecimal2]
			,[ExtraDecimal3]
	from   AcInstitucionEducativa

return 0
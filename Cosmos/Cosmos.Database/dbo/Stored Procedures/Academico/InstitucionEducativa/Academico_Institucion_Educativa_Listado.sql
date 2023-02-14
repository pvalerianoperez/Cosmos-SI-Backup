CREATE PROCEDURE [dbo].[Academico_Institucion_Educativa_Listado]

As
	Select     
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
	From   AcInstitucionEducativa

return 0

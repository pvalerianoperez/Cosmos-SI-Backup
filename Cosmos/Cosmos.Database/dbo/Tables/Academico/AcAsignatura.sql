CREATE TABLE [dbo].[AcAsignatura]
(
	[AsignaturaID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Nombre] VARCHAR(80) NOT NULL, 
    CONSTRAINT [AK_AcAsignatura_Nombre] UNIQUE ([Nombre])
)
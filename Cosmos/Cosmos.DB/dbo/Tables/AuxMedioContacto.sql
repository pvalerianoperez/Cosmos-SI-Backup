CREATE TABLE [dbo].[AuxMedioContacto] (
    [AuxMedioContactoID]    INT          IDENTITY (1, 1) NOT NULL,
    [AuxMedioContactoClave] VARCHAR (5)  NOT NULL,
    [Nombre]                VARCHAR (30) NOT NULL,
    [NombreCorto]           VARCHAR (10) NULL,
    CONSTRAINT [PK_Auxmedios_contacto] PRIMARY KEY CLUSTERED ([AuxMedioContactoID] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_MedioContacto_MedioContactoClave]
    ON [dbo].[AuxMedioContacto]([AuxMedioContactoClave] ASC);


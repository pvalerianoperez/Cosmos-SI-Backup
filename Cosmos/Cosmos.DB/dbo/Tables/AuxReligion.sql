CREATE TABLE [dbo].[AuxReligion] (
    [AuxReligionID]    INT          IDENTITY (1, 1) NOT NULL,
    [AuxReligionClave] VARCHAR (5)  NOT NULL,
    [Nombre]           VARCHAR (50) NULL,
    [NombreCorto]      VARCHAR (12) NULL,
    CONSTRAINT [PK_AuxReligionID] PRIMARY KEY CLUSTERED ([AuxReligionID] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_AuxReligion_AuxReligionClave]
    ON [dbo].[AuxReligion]([AuxReligionClave] ASC);


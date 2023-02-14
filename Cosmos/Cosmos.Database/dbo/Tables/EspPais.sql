CREATE TABLE [dbo].[EspPais] (
    [EspPaisID]           INT          IDENTITY (1, 1) NOT NULL,
    [EspPaisClave]        VARCHAR (6)  NOT NULL,
    [Nombre]              VARCHAR (50) NOT NULL,
    [NombreCorto]         VARCHAR (15) NOT NULL,
    [CodigoAlfa2]         VARCHAR (2)  NOT NULL,
    [CodigoAlfa3]         VARCHAR (3)  NOT NULL,
    [ClaveTelefonicaPais] VARCHAR (15) NOT NULL,
    CONSTRAINT [PK_EspPais] PRIMARY KEY CLUSTERED ([EspPaisID] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Pais_PaisClave]
    ON [dbo].[EspPais]([EspPaisClave] ASC);


CREATE TABLE [dbo].[AuxVinculo] (
    [AuxVinculoID]    INT          IDENTITY (1, 1) NOT NULL,
    [AuxVinculoClave] VARCHAR (5)  NOT NULL,
    [Nombre]          VARCHAR (40) NOT NULL,
    [NombreCorto]     VARCHAR (15) NOT NULL,
    CONSTRAINT [PK_AuxVinculoID] PRIMARY KEY CLUSTERED ([AuxVinculoID] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Vinculo]
    ON [dbo].[AuxVinculo]([AuxVinculoClave] ASC);


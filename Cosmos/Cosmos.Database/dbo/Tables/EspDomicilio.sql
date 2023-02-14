CREATE TABLE [dbo].[EspDomicilio] (
    [EspDomicilioID] INT           IDENTITY (1, 1) NOT NULL,
    [Calle]          VARCHAR (50)  NOT NULL,
    [NumeroExterior] VARCHAR (20)  NOT NULL,
    [NumeroInterior] VARCHAR (20)  NOT NULL,
    [EntreCalle1]    VARCHAR (40)  NOT NULL,
    [EntreCalle2]    VARCHAR (40)  NOT NULL,
    [CodigoPostal]   INT           NOT NULL,
    [Coordenadas]    VARCHAR (40)  NOT NULL,
    [EspCiudadID]    INT           NOT NULL,
    [EspColoniaID]   INT           NOT NULL,
    [Observaciones]  VARCHAR (100) NOT NULL,
    CONSTRAINT [PK_EspDomicilio] PRIMARY KEY CLUSTERED ([EspDomicilioID] ASC),
    CONSTRAINT [FK__EspDomicilio__EspColonia] FOREIGN KEY ([EspColoniaID]) REFERENCES [dbo].[EspColonia] ([EspColoniaID]),
    CONSTRAINT [FK_Domicilio_EspCiudad] FOREIGN KEY ([EspCiudadID]) REFERENCES [dbo].[EspCiudad] ([EspCiudadID])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Domicilio_ColoniaID_Calle_NumeroExterior_NumeroInterior]
    ON [dbo].[EspDomicilio]([EspColoniaID] ASC, [Calle] ASC, [NumeroExterior] ASC, [NumeroInterior] ASC);


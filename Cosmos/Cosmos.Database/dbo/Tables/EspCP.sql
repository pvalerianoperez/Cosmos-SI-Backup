CREATE TABLE [dbo].[EspCP] (
    [EspCP]       INT NOT NULL,
    [EspCiudadID] INT NOT NULL,
    CONSTRAINT [PK_EspCP] PRIMARY KEY CLUSTERED ([EspCP] ASC),
    CONSTRAINT [FK_EspCP_EspCiudad] FOREIGN KEY ([EspCiudadID]) REFERENCES [dbo].[EspCiudad] ([EspCiudadID])
);


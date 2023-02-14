CREATE TABLE [dbo].[CfgTipoMail] (
    [CfgTipoMailID]        INT          IDENTITY (1, 1) NOT NULL,
    [CfgTipoMailClave]     VARCHAR (10) NOT NULL,
    [Nombre]               VARCHAR (40) NOT NULL,
    [NombreCorto]          VARCHAR (15) NOT NULL,
    [Estatus]              BIT          NOT NULL,
    [CfgSistemaTipoMailID] INT          NOT NULL,
    CONSTRAINT [PK_CfgTipoMail] PRIMARY KEY CLUSTERED ([CfgTipoMailID] ASC),
    CONSTRAINT [FK_CfgTipoMail_SistemaTipoMail] FOREIGN KEY ([CfgSistemaTipoMailID]) REFERENCES [dbo].[SistemaTipoMail] ([SistemaTipoMailID])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_TipoMail_TipoMailClave]
    ON [dbo].[CfgTipoMail]([CfgTipoMailClave] ASC);


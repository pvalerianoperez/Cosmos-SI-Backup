CREATE TABLE [dbo].[PpalContactoPersonalMail] (
    [PpalContactoPersonalMailID] INT           IDENTITY (1, 1) NOT NULL,
    [PpalContactoPersonalID]     INT           NOT NULL,
    [Email]                      VARCHAR (100) NOT NULL,
    [Predeterminado]             BIT           NOT NULL,
    [Comentarios]                VARCHAR (100) NOT NULL,
    [CfgTipoMailID]              INT           NOT NULL,
    CONSTRAINT [PK_PpalContactoPersonalMailID] PRIMARY KEY CLUSTERED ([PpalContactoPersonalMailID] ASC),
    CONSTRAINT [FK_PpalContactoPersonalMail_CfgTipoMail] FOREIGN KEY ([CfgTipoMailID]) REFERENCES [dbo].[CfgTipoMail] ([CfgTipoMailID]),
    CONSTRAINT [FK_PpalContactoPersonalMail_PpalContactoPersonal] FOREIGN KEY ([PpalContactoPersonalID]) REFERENCES [dbo].[PpalContactoPersonal] ([PpalContactoPersonalID]) ON DELETE CASCADE
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_PpalContactoPersonalMail_PpalContactoPersonalID_Email]
    ON [dbo].[PpalContactoPersonalMail]([PpalContactoPersonalMailID] ASC, [Email] ASC);


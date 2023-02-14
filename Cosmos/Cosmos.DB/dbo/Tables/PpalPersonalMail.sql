CREATE TABLE [dbo].[PpalPersonalMail] (
    [PpalPersonalMailID] INT           IDENTITY (1, 1) NOT NULL,
    [PpalPersonalID]     INT           NOT NULL,
    [Email]              VARCHAR (100) NOT NULL,
    [CfgTipoMailID]      INT           NOT NULL,
    [Predeterminado]     BIT           NOT NULL,
    [Comentarios]        VARCHAR (100) NOT NULL,
    CONSTRAINT [PK_PpalPersonalMailID] PRIMARY KEY CLUSTERED ([PpalPersonalMailID] ASC),
    CONSTRAINT [FK_PpalPersonalMail_CfgTipoMail] FOREIGN KEY ([CfgTipoMailID]) REFERENCES [dbo].[CfgTipoMail] ([CfgTipoMailID]),
    CONSTRAINT [FK_PpalPersonalMail_PpalPersonal] FOREIGN KEY ([PpalPersonalID]) REFERENCES [dbo].[PpalPersonal] ([PpalPersonalID])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_PpalPersonalMail_PpalPersonalID_Email]
    ON [dbo].[PpalPersonalMail]([PpalPersonalID] ASC, [Email] ASC);


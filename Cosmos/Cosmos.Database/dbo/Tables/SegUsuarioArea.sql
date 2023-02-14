CREATE TABLE [dbo].[SegUsuarioArea] (
    [SegUsuarioAreaID] INT IDENTITY (1, 1) NOT NULL,
    [SegUsuarioID]     INT NOT NULL,
    [PpalAreaID]       INT NOT NULL,
    CONSTRAINT [PK_SegUsuarioArea] PRIMARY KEY CLUSTERED ([SegUsuarioAreaID] ASC),
    CONSTRAINT [FK_SegUsuarioArea_PpalArea] FOREIGN KEY ([PpalAreaID]) REFERENCES [dbo].[PpalArea] ([PpalAreaID]),
    CONSTRAINT [FK_SegUsuarioArea_SegUsuario] FOREIGN KEY ([SegUsuarioID]) REFERENCES [dbo].[SegUsuario] ([SegUsuarioID]) ON DELETE CASCADE
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_SegUsuarioArea_SegUsuarioID_PpalAreaID]
    ON [dbo].[SegUsuarioArea]([SegUsuarioID] ASC, [PpalAreaID] ASC);


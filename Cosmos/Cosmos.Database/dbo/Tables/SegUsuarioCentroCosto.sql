CREATE TABLE [dbo].[SegUsuarioCentroCosto] (
    [SegUsuarioCentroCostoID] INT IDENTITY (1, 1) NOT NULL,
    [SegUsuarioID]            INT NOT NULL,
    [PpalCentroCostoID]       INT NOT NULL,
    CONSTRAINT [PK_SegUsuarioCentroCosto] PRIMARY KEY CLUSTERED ([SegUsuarioCentroCostoID] ASC),
    CONSTRAINT [FK_SegUsuarioCentroCosto_PpalCentroCosto] FOREIGN KEY ([PpalCentroCostoID]) REFERENCES [dbo].[PpalCentroCosto] ([PpalCentroCostoID]),
    CONSTRAINT [FK_SegUsuarioCentroCosto_SegUsuario] FOREIGN KEY ([SegUsuarioID]) REFERENCES [dbo].[SegUsuario] ([SegUsuarioID]) ON DELETE CASCADE
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_SegUsuarioCentroCosto_SegUsuarioID_PpalCentroCostoID]
    ON [dbo].[SegUsuarioCentroCosto]([SegUsuarioID] ASC, [PpalCentroCostoID] ASC);


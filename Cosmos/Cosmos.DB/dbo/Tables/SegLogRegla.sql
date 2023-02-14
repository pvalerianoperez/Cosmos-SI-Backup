CREATE TABLE [dbo].[SegLogRegla] (
    [SegLogReglaID] INT          IDENTITY (1, 1) NOT NULL,
    [SegUsuarioID]  INT          DEFAULT ((0)) NULL,
    [TablaNombre]   VARCHAR (50) NOT NULL,
    [C]             TINYINT      CONSTRAINT [DF_SistemaLogRegla_C] DEFAULT ((0)) NOT NULL,
    [R]             TINYINT      CONSTRAINT [DF_SistemaLogRegla_R] DEFAULT ((0)) NOT NULL,
    [U]             TINYINT      CONSTRAINT [DF_SistemaLogRegla_U] DEFAULT ((0)) NOT NULL,
    [D]             TINYINT      CONSTRAINT [DF_SistemaLogRegla_D] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_SegLogRegla] PRIMARY KEY CLUSTERED ([SegLogReglaID] ASC),
    CONSTRAINT [FK_SegLogRegla_SegUsuarioID] FOREIGN KEY ([SegUsuarioID]) REFERENCES [dbo].[SegUsuario] ([SegUsuarioID]) ON DELETE SET NULL
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_SistemaLogRegla_TablaNombre_UsuarioID]
    ON [dbo].[SegLogRegla]([TablaNombre] ASC, [SegUsuarioID] ASC);


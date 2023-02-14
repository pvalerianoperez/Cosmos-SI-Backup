CREATE TABLE [dbo].[SistemaLogRegla] (
    [SistemaLogReglaID] INT          IDENTITY (1, 1) NOT NULL,
    [UserID]            INT          DEFAULT ((0)) NOT NULL,
    [TablaNombre]       VARCHAR (50) NOT NULL,
    [C]                 BIT          DEFAULT ((0)) NOT NULL,
    [R]                 BIT          DEFAULT ((0)) NOT NULL,
    [U]                 BIT          DEFAULT ((1)) NOT NULL,
    [D]                 BIT          DEFAULT ((1)) NOT NULL,
    PRIMARY KEY CLUSTERED ([SistemaLogReglaID] ASC),
    CONSTRAINT [AK_SistemaLogRegla_TablaNombre_UserID] UNIQUE NONCLUSTERED ([TablaNombre] ASC, [UserID] ASC)
);


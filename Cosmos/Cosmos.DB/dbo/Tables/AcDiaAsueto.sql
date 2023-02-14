CREATE TABLE [dbo].[AcDiaAsueto] (
    [DiaAsuetoID]    INT           IDENTITY (1, 1) NOT NULL,
    [DiaAsuetoClave] VARCHAR (6)   NULL,
    [Nombre]         VARCHAR (80)  NOT NULL,
    [NombreCorto]    VARCHAR (15)  NULL,
    [CicloID]        INT           NOT NULL,
    [Descripcion]    VARCHAR (150) NULL,
    [Fecha]          DATE          NOT NULL,
    CONSTRAINT [PK_AcDiaAsueto] PRIMARY KEY CLUSTERED ([DiaAsuetoID] ASC),
    CONSTRAINT [FK_AcDiaAsueto_AcCiclo] FOREIGN KEY ([CicloID]) REFERENCES [dbo].[AcCiclo] ([CicloID]),
    CONSTRAINT [AK_AcDiaAsueto_CicloID_Fecha] UNIQUE NONCLUSTERED ([CicloID] ASC, [Fecha] ASC),
    CONSTRAINT [AK_AcDiaAsueto_DiaAsuetoClave] UNIQUE NONCLUSTERED ([DiaAsuetoClave] ASC),
    CONSTRAINT [AK_AcDiaAsueto_Nombre] UNIQUE NONCLUSTERED ([Nombre] ASC),
    CONSTRAINT [AK_AcDiaAsueto_NombreCorto] UNIQUE NONCLUSTERED ([NombreCorto] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IXFK_AcDiaAsueto_AcCiclo]
    ON [dbo].[AcDiaAsueto]([CicloID] ASC);


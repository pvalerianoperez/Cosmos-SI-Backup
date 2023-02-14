CREATE TABLE [dbo].[AcDiaAsueto] (
    [DiaAsuetoID]    INT           NOT NULL IDENTITY,
    [DiaAsuetoClave] VARCHAR (6)   NULL,
    [Nombre]         VARCHAR (80)  NOT NULL,
    [NombreCorto]    VARCHAR (15)  NULL,
    [CicloID]   INT           NOT NULL,
    [Descripcion]    VARCHAR (150) NULL,
    [Fecha]          DATE          NOT NULL,
    CONSTRAINT [PK_AcDiaAsueto] PRIMARY KEY CLUSTERED ([DiaAsuetoID] ASC),
    CONSTRAINT [FK_AcDiaAsueto_AcCiclo] FOREIGN KEY ([CicloID]) REFERENCES [dbo].[AcCiclo] ([CicloID]), 
    CONSTRAINT [AK_AcDiaAsueto_DiaAsuetoClave] UNIQUE ([DiaAsuetoClave]), 
    CONSTRAINT [AK_AcDiaAsueto_Nombre] UNIQUE ([Nombre]),
    CONSTRAINT [AK_AcDiaAsueto_NombreCorto] UNIQUE ([NombreCorto]), 
    CONSTRAINT [AK_AcDiaAsueto_CicloID_Fecha] UNIQUE ([CicloID],[Fecha])
);


GO
CREATE NONCLUSTERED INDEX [IXFK_AcDiaAsueto_AcCiclo]
    ON [dbo].[AcDiaAsueto]([CicloID] ASC);


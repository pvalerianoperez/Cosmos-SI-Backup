CREATE TABLE [dbo].[AcAdmisionEstatus] (
    [EstatusID]    INT           IDENTITY (1, 1) NOT NULL,
    [EstatusClave] VARCHAR (6)   NOT NULL,
    [Nombre]       VARCHAR (80)  NOT NULL,
    [NombreCorto]  VARCHAR (15)  NOT NULL,
    [Descripcion]  VARCHAR (150) NULL,
    [Admitido]     BIT           NOT NULL,
    [Entrevistado] BIT           NOT NULL,
    [Suspendido]   BIT           NOT NULL,
    [No_Admitido]  BIT           NULL,
    PRIMARY KEY CLUSTERED ([EstatusID] ASC)
);


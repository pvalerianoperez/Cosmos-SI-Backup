CREATE TABLE [dbo].[SistemaParamCosmos] (
    [SistemaParamCosmosID]   INT           IDENTITY (1, 1) NOT NULL,
    [ClaveNoAsignado]        VARCHAR (4)   NOT NULL,
    [TituloMensajeRespuesta] VARCHAR (100) CONSTRAINT [DF_ParamCosmos_TituloMensajeRespuesta] DEFAULT ('') NOT NULL,
    CONSTRAINT [PK_SistemaParamCosmos] PRIMARY KEY CLUSTERED ([SistemaParamCosmosID] ASC)
);


CREATE TABLE [dbo].[SistemaConfiguracion] (
    [ConfiguracionID]     INT           IDENTITY (1, 1) NOT NULL,
    [Nombre]              NVARCHAR (50) NOT NULL,
    [MaximoIntentosLogin] TINYINT       NULL,
    [Activa]              BIT           NOT NULL,
    CONSTRAINT [PK_SistemaConfiguracion] PRIMARY KEY CLUSTERED ([ConfiguracionID] ASC)
);


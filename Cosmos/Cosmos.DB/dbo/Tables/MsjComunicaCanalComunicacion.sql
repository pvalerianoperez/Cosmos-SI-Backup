CREATE TABLE [dbo].[MsjComunicaCanalComunicacion] (
    [CanalComunicacionID]    INT           IDENTITY (1, 1) NOT NULL,
    [CanalComunicacionClave] VARCHAR (6)   NOT NULL,
    [Nombre]                 NVARCHAR (50) NOT NULL,
    [NombreCorto]            NVARCHAR (15) NOT NULL,
    [Activo]                 BIT           NOT NULL,
    PRIMARY KEY CLUSTERED ([CanalComunicacionID] ASC),
    CONSTRAINT [AK_MsjComunicaCanalComunicacion_CanalComunicacionClave] UNIQUE NONCLUSTERED ([CanalComunicacionClave] ASC),
    CONSTRAINT [AK_MsjComunicaCanalComunicacion_Nombre] UNIQUE NONCLUSTERED ([Nombre] ASC),
    CONSTRAINT [AK_MsjComunicaCanalComunicacion_NombreCorto] UNIQUE NONCLUSTERED ([NombreCorto] ASC)
);


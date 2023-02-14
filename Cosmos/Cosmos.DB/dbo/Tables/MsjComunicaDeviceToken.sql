CREATE TABLE [dbo].[MsjComunicaDeviceToken] (
    [DeviceTokenID] INT            IDENTITY (1, 1) NOT NULL,
    [DeviceToken]   NVARCHAR (256) NOT NULL,
    [OS]            VARCHAR (50)   NOT NULL,
    [VersionOS]     NVARCHAR (50)  NULL,
    [VersionApp]    NVARCHAR (50)  NULL,
    [Descripcion]   VARCHAR (500)  NOT NULL,
    [FechaRegistro] DATETIME       NOT NULL,
    PRIMARY KEY CLUSTERED ([DeviceTokenID] ASC),
    CONSTRAINT [AK_MsjComunicaDeviceToken_DeviceToken] UNIQUE NONCLUSTERED ([DeviceTokenID] ASC)
);


CREATE TABLE [dbo].[MsjComunicaDeviceToken]
(
	[DeviceTokenID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [DeviceToken] NVARCHAR(256) NOT NULL,
    [OS] VARCHAR(50) NOT NULL, 
    [VersionOS] NVARCHAR(50) NULL, 
    [VersionApp] NVARCHAR(50) NULL, 
    [Descripcion] VARCHAR(500) NOT NULL, 
    [FechaRegistro] DATETIME NOT NULL, 
    CONSTRAINT [AK_MsjComunicaDeviceToken_DeviceToken] UNIQUE ([DeviceTokenID]), 
)

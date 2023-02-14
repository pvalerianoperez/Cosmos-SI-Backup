CREATE TABLE [dbo].[AcAdmisionProspecto] (
    [ProspectoID]     INT           NOT NULL,
    [Nombre]          NVARCHAR (35) NULL,
    [ApellidoPaterno] NVARCHAR (30) NULL,
    [ApellidoMaterno] NVARCHAR (30) NULL,
    PRIMARY KEY CLUSTERED ([ProspectoID] ASC)
);


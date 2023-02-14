CREATE TABLE [dbo].[AcInstitucionEducativa] (
    [InstitucionEducativaID]    INT             IDENTITY (1, 1) NOT NULL,
    [InstitucionEducativaClave] VARCHAR (6)     NOT NULL,
    [Nombre]           VARCHAR (80)    NOT NULL,
    [NombreCorto]      VARCHAR (15)    NOT NULL,
    [ExtraTexto1]      VARCHAR (500)   NULL,
    [ExtraTexto2]      VARCHAR (500)   NULL,
    [ExtraTexto3]      VARCHAR (500)   NULL,
    [ExtraFecha1]      DATETIME        NULL,
    [ExtraFecha2]      DATETIME        NULL,
    [ExtraDecimal1]    DECIMAL (18, 6) NULL,
    [ExtraDecimal2]    DECIMAL (18, 6) NULL,
    [ExtraDecimal3]    DECIMAL (18, 6) NULL,
    CONSTRAINT [PK_AcInstitucionEducativa] PRIMARY KEY CLUSTERED ([InstitucionEducativaID] ASC),
    CONSTRAINT [AK_AcInstitucionEducativa_InstitucionEducativaClave] UNIQUE ([InstitucionEducativaClave]),
    CONSTRAINT [AK_AcInstitucionEducativa_Nombre] UNIQUE ([Nombre]),
    CONSTRAINT [AK_AcInstitucionEducativa_NombreCorto] UNIQUE ([NombreCorto]),
);


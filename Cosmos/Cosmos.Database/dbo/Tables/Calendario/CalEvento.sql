CREATE TABLE [dbo].[CalEvento]
(
	[EventoID]				INT NOT NULL PRIMARY KEY IDENTITY,
    [EventoTipoID]			INT            NOT NULL,
    [FechaInicio]			SMALLDATETIME  NULL,
    [FechaFinal]			SMALLDATETIME  NULL,
    [TodoElDia]				BIT            NULL,
    [Tema]					NVARCHAR (50)  NULL,
    [Locacion]				NVARCHAR (50)  NULL,
    [Descripcion]			NVARCHAR (MAX) NULL,
    [StatusID]				INT            NOT NULL,
    [EtiquetaID]			INT            NULL,
    [RecursoID]				INT            NULL,
    [RecursoIDs]			NVARCHAR (MAX) NULL,
    [RecordatorioInfo]		NVARCHAR (MAX) NULL,
    [RecurrenciaInfo]		NVARCHAR (MAX) NULL,
    [CampoPersonalizado1]	NVARCHAR (MAX) NULL,
    [CampoPersonalizado2]	NVARCHAR (MAX) NULL,
    [CampoPersonalizado3]	NVARCHAR (MAX) NULL,
    [CampoPersonalizado4]	NVARCHAR (MAX) NULL,
    [CampoPersonalizado5]	NVARCHAR (MAX) NULL, 
    CONSTRAINT [FK_CalEvento_CalEventoTipo]   FOREIGN KEY ([EventoTipoID]) REFERENCES [CalEventoTipo]([EventoTipoID]),
    CONSTRAINT [FK_CalEvento_CalEventoStatus] FOREIGN KEY ([StatusID])     REFERENCES [CalEventoStatus]([EventoStatusID])
)

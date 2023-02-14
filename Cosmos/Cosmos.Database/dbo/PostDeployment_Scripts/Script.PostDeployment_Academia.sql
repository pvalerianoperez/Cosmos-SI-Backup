/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/



If Not Exists(Select TipoDocumentoID FROM AcTipoDocumento WHERE TipoDocumentoID = 1)
Begin

	Exec Init_Academico_TipoDocumento
	
End


If Not Exists(Select DocumentoID FROM AcDocumento WHERE DocumentoID = 1)
Begin

	Exec Init_Academico_Documento

End


If Not Exists(Select EstatusID FROM AcAdmisionEstatus WHERE EstatusID = 1)
Begin

	Exec Init_Academico_Admision_Estatus

End


If Not Exists(Select ZonaID FROM AcAdmisionZona WHERE ZonaID = 1)
Begin

	Exec Init_Academico_Admision_Zona

End


If Not Exists(Select IdiomaID FROM AcAdmisionIdioma WHERE IdiomaID = 1)
Begin

	Exec Init_Academico_Admision_Idioma

End


If Not Exists(Select MotivoBajaID FROM AcAdmisionMotivoBaja WHERE MotivoBajaID = 1)
Begin

	Exec Init_Academico_Admision_MotivoBaja

End


If Not Exists(Select MotivoInteresID FROM AcAdmisionMotivoInteres WHERE MotivoInteresID = 1)
Begin

	Exec Init_Academico_Admision_MotivoInteres

End


If Not Exists(Select EscolaridadID FROM AcAdmisionEscolaridad WHERE EscolaridadID = 1)
Begin

	Exec Init_Academico_Admision_Escolaridad

End

If Not Exists(Select MotivoCancelacionServicioID FROM AcAdmisionMotivoCancelacionServicio WHERE MotivoCancelacionServicioID = 1)
Begin

	Exec Init_Academico_Admision_MotivoCancelacionServicio

End


If Not Exists(Select TipoObservacionID FROM AcAdmisionTipoObservacion WHERE TipoObservacionID = 1)
Begin

	Exec Init_Academico_Admision_TipoObservacion

End


If Not Exists(Select ParentescoID FROM AcAdmisionParentesco WHERE ParentescoID = 1)
Begin

	Exec Init_Academico_Admision_Parentesco

End


If Not Exists(Select ReligionID FROM AcAdmisionReligion WHERE ReligionID = 1)
Begin

	Exec Init_Academico_Admision_Religion

End


If Not Exists(Select TipoRepresentanteFamiliaID FROM AcAdmisionTipoRepresentanteFamilia WHERE TipoRepresentanteFamiliaID = 1)
Begin

	Exec Init_Academico_Admision_TipoRepresentanteFamilia

End


If Not Exists(Select VinculoID FROM AcAdmisionVinculo WHERE VinculoID = 1)
Begin

	Exec Init_Academico_Admision_Vinculo

End


If Not Exists(Select RazonNoViableID FROM AcAdmisionRazonNoViable WHERE RazonNoViableID = 1)
Begin

	Exec Init_Academico_Admision_RazonNoViable
	
End


If Not Exists(Select EventoStatusID FROM CalEventoStatus WHERE EventoStatusID = 1)
Begin

	Delete From CalEventoStatus
	DBCC CHECKIDENT ('CalEventoStatus', RESEED, 0);
	
	Insert Into CalEventoStatus(EventoStatusClave, Nombre, NombreCorto) Values ('Normal', 'Normal', 'Normal')

End



If Not Exists(Select EventoTipoID FROM CalEventoTipo WHERE EventoTipoID = 1)
Begin

	Delete From CalEventoTipo
	DBCC CHECKIDENT ('CalEventoTipo', RESEED, 0);
	
	Insert Into CalEventoTipo(EventoTipoClave, Nombre, NombreCorto) Values ('Inst', 'Institucional', 'Institucional')

End


If Not Exists(Select CalendarioTipoID FROM CalCalendarioTipo WHERE CalendarioTipoID = 1)
Begin

	Delete From CalCalendarioTipo
	DBCC CHECKIDENT ('CalCalendarioTipo', RESEED, 0);
	
	Insert Into CalCalendarioTipo(CalendarioTipoClave, Nombre, NombreCorto) Values ('Per', 'Personal', 'Personal')

End



If Not Exists(Select SistemaLogReglaID FROM SistemaLogRegla WHERE SistemaLogReglaID = 1)
Begin

	Delete From SistemaLogRegla
	DBCC CHECKIDENT ('SistemaLogRegla', RESEED, 0);

	Insert Into SistemaLogRegla(UsuarioID, TablaNombre, C, R, U, D) Values (0, '*', 0, 0, 0, 0)
	Insert Into SistemaLogRegla(UsuarioID, TablaNombre, C, R, U, D) Values (0, 'SistemaLogRegla', 1, 0, 1, 1)
	Insert Into SistemaLogRegla(UsuarioID, TablaNombre, C, R, U, D) Values (0, 'TestTable', 1, 0, 1, 1)

End



If Not Exists(Select PermisoConversacionID FROM MsjChatPermisoConversacion WHERE PermisoConversacionID = 1)
Begin

	Delete From MsjChatPermisoConversacion
	DBCC CHECKIDENT ('MsjChatPermisoConversacion', RESEED, 0);

	Insert Into MsjChatPermisoConversacion(PermisoConversacionNombre) Values ('Read&Write')
	Insert Into MsjChatPermisoConversacion(PermisoConversacionNombre) Values ('ReadOnly')

End

If Not Exists(Select TipoMensajeID FROM MsjChatTipoMensaje WHERE TipoMensajeID = 1)
Begin

	Delete From MsjChatTipoMensaje
	DBCC CHECKIDENT ('MsjChatTipoMensaje', RESEED, 0);

	Insert Into MsjChatTipoMensaje(TipoNombre) Values ('Texto')
	Insert Into MsjChatTipoMensaje(TipoNombre) Values ('Imagen')
	Insert Into MsjChatTipoMensaje(TipoNombre) Values ('Video')

End


-- Area Formacion
If Not Exists(Select AreaFormacionID FROM AcAreaFormacion WHERE AreaFormacionID = 1)
Begin

    --[AreaFormacionID]    INT          NOT NULL IDENTITY,
    --[AreaFormacionClave] VARCHAR (6)  NULL,
    --[Nombre]             VARCHAR (80) NOT NULL,
    --[NombreCorto]        VARCHAR (15) NULL,

	Delete From AcAreaFormacion
	DBCC CHECKIDENT ('AcAreaFormacion', RESEED, 0);
	
	Insert into AcAreaFormacion(AreaFormacionClave,Nombre,NombreCorto) Values ('bc','básica común','bc')
	Insert into AcAreaFormacion(AreaFormacionClave,Nombre,NombreCorto) Values ('bco','básica común obligatoria','bco')
	Insert into AcAreaFormacion(AreaFormacionClave,Nombre,NombreCorto) Values ('bpo','básica particular obligatoria','bpo')
	Insert into AcAreaFormacion(AreaFormacionClave,Nombre,NombreCorto) Values ('bps','básica particular selectiva','bps')
	Insert into AcAreaFormacion(AreaFormacionClave,Nombre,NombreCorto) Values ('eo','especializante obligatoria','eo')
	Insert into AcAreaFormacion(AreaFormacionClave,Nombre,NombreCorto) Values ('es','especializante selectiva','es')
	Insert into AcAreaFormacion(AreaFormacionClave,Nombre,NombreCorto) Values ('oa','optativa abierta','oa')
	Insert into AcAreaFormacion(AreaFormacionClave,Nombre,NombreCorto) Values ('e','especializante','e')
	Insert into AcAreaFormacion(AreaFormacionClave,Nombre,NombreCorto) Values ('p','propedeútica','p')
	Insert into AcAreaFormacion(AreaFormacionClave,Nombre,NombreCorto) Values ('pt','para el trabajo','pt')
	Insert into AcAreaFormacion(AreaFormacionClave,Nombre,NombreCorto) Values ('h','humana','h')
	Insert into AcAreaFormacion(AreaFormacionClave,Nombre,NombreCorto) Values ('ex','ExtraCurricular','ex')

End

-- Asignatura
If Not Exists(Select AsignaturaID FROM AcAsignatura WHERE AsignaturaID = 1)
Begin

	--[AsignaturaID] INT NOT NULL PRIMARY KEY IDENTITY, 
 --   [Nombre] VARCHAR(80) NOT NULL, 

	Delete From AcAsignatura
	DBCC CHECKIDENT ('AcAsignatura', RESEED, 0);
	
	Insert into AcAsignatura(Nombre) Values ('Taller de Lectura y Redacción I')
	Insert into AcAsignatura(Nombre) Values ('Matemáticas I')
	Insert into AcAsignatura(Nombre) Values ('Química I')
	Insert into AcAsignatura(Nombre) Values ('Informática I')
	Insert into AcAsignatura(Nombre) Values ('Introducción a las Ciencias Sociales')
	Insert into AcAsignatura(Nombre) Values ('Aprendizaje Autogestivo')
	Insert into AcAsignatura(Nombre) Values ('Taller de Lectura y Redacción II')
	Insert into AcAsignatura(Nombre) Values ('Matemáticas II')
	Insert into AcAsignatura(Nombre) Values ('Química II')
	Insert into AcAsignatura(Nombre) Values ('Informática II')
	Insert into AcAsignatura(Nombre) Values ('Historia de México I')
	Insert into AcAsignatura(Nombre) Values ('Desarrollo Humano')
	Insert into AcAsignatura(Nombre) Values ('Literatura I')
	Insert into AcAsignatura(Nombre) Values ('Matemáticas III')
	Insert into AcAsignatura(Nombre) Values ('Biología I')
	Insert into AcAsignatura(Nombre) Values ('Física I')
	Insert into AcAsignatura(Nombre) Values ('Historia de México II')
	Insert into AcAsignatura(Nombre) Values ('Formación Empresarial I')
	Insert into AcAsignatura(Nombre) Values ('Literatura II')
	Insert into AcAsignatura(Nombre) Values ('Matemáticas IV')
	Insert into AcAsignatura(Nombre) Values ('Biología II')
	Insert into AcAsignatura(Nombre) Values ('Física II')
	Insert into AcAsignatura(Nombre) Values ('Estructura Socioeconómica de México')
	Insert into AcAsignatura(Nombre) Values ('Formación Empresarial II')
	Insert into AcAsignatura(Nombre) Values ('Historia Universal Contemporánea')
	Insert into AcAsignatura(Nombre) Values ('Geografía')
	Insert into AcAsignatura(Nombre) Values ('Filosofía')
	Insert into AcAsignatura(Nombre) Values ('Ecología y Medio Ambiente')
	Insert into AcAsignatura(Nombre) Values ('Metodología de la Investigación')
	Insert into AcAsignatura(Nombre) Values ('Calidad e Innovación Tecnológica')
	Insert into AcAsignatura(Nombre) Values ('Contabilidad I')
	Insert into AcAsignatura(Nombre) Values ('Contabilidad II')
	Insert into AcAsignatura(Nombre) Values ('Inglés I')
	Insert into AcAsignatura(Nombre) Values ('Inglés II')
	Insert into AcAsignatura(Nombre) Values ('Inglés III')
	Insert into AcAsignatura(Nombre) Values ('Inglés IV')
	Insert into AcAsignatura(Nombre) Values ('Economía I')
	Insert into AcAsignatura(Nombre) Values ('Matemáticas Financieras I')
	Insert into AcAsignatura(Nombre) Values ('Administración')
	Insert into AcAsignatura(Nombre) Values ('Economía II')
	Insert into AcAsignatura(Nombre) Values ('Matemáticas Financieras II')
	Insert into AcAsignatura(Nombre) Values ('Curso Propedéutico')If Not Exists(Select CalendarioID FROM AcCalendario WHERE CalendarioID = 1)
	Insert into AcAsignatura(Nombre) Values ('Etica I')
	Insert into AcAsignatura(Nombre) Values ('Etica II')

End



--¨Planteles
If Not Exists(Select PlantelID FROM AcPlantel WHERE PlantelID = 1)
Begin

	Delete From AcPlantel
	DBCC CHECKIDENT ('AcPlantel', RESEED, 0);
	
	Insert Into AcPlantel(PlantelClave, Nombre, NombreCorto, SucursalID) Values ('001','Plantel01','P1',1);
	Insert Into AcPlantel(PlantelClave, Nombre, NombreCorto, SucursalID) Values ('002','Plantel02','P2',2);

End

-- Calendarios
If Not Exists(Select CalendarioID FROM AcCalendario WHERE CalendarioID = 1)
Begin

	--[CalendarioID]         INT           NOT NULL IDENTITY,
 --   [CalendarioClave]      VARCHAR (6)   NULL,
 --   [Nombre]               VARCHAR (80)  NOT NULL,
 --   [NombreCorto]          VARCHAR (15)  NULL,
 --   [Descripcion]          VARCHAR (100) NULL,
 --   [FechaInicio]          DATETIME      NOT NULL,
 --   [FechaFinal]           DATETIME      NOT NULL,
 --   [CalendarioIDAnterior] INT           DEFAULT (-1) NOT NULL,

	Delete From AcCalendario
	DBCC CHECKIDENT ('AcCalendario', RESEED, 0);
	
	Insert Into AcCalendario(CalendarioClave, Nombre, NombreCorto, Descripcion, FechaInicio, FechaFinal) Values ('C01','2019-2020','2019','Descripcion1','2019-08-01', '2020-07-30');
	Insert Into AcCalendario(CalendarioClave, Nombre, NombreCorto, Descripcion, FechaInicio, FechaFinal) Values ('C02','2020-2021','2020','Descripcion2','2020-08-01', '2021-07-30');

End

-- CicloTipoID
If Not Exists(Select CicloTipoID FROM AcCicloTipo WHERE CicloTipoID = 1)
Begin

    --[CicloTipoID]    INT          NOT NULL IDENTITY,
    --[CicloTipoClave] VARCHAR (6)  NULL,
    --[Nombre]         VARCHAR (80) NOT NULL,
    --[NombreCorto]    VARCHAR (15) NULL,

	Delete From AcCicloTipo
	DBCC CHECKIDENT ('AcCicloTipo', RESEED, 0);
	
	Insert Into AcCicloTipo(CicloTipoClave, Nombre, NombreCorto) Values ('CT01','Semanal','Semanal');
	Insert Into AcCicloTipo(CicloTipoClave, Nombre, NombreCorto) Values ('CT02','Quincenal','Quincenal');
	Insert Into AcCicloTipo(CicloTipoClave, Nombre, NombreCorto) Values ('CT03','Mensual','Mensual');
	Insert Into AcCicloTipo(CicloTipoClave, Nombre, NombreCorto) Values ('CT04','BiMensual','BiMensual');
	Insert Into AcCicloTipo(CicloTipoClave, Nombre, NombreCorto) Values ('CT05','TriMestral','TriMestral');
	Insert Into AcCicloTipo(CicloTipoClave, Nombre, NombreCorto) Values ('CT06','CuatriMestral','CuatriMestral');
	Insert Into AcCicloTipo(CicloTipoClave, Nombre, NombreCorto) Values ('CT07','Semestral','Semestral');
	Insert Into AcCicloTipo(CicloTipoClave, Nombre, NombreCorto) Values ('CT08','Anual','Anual');
	Insert Into AcCicloTipo(CicloTipoClave, Nombre, NombreCorto) Values ('CT09','BiAnual','BiAnual');
	Insert Into AcCicloTipo(CicloTipoClave, Nombre, NombreCorto) Values ('CT10','Lustro','Lustro');
	Insert Into AcCicloTipo(CicloTipoClave, Nombre, NombreCorto) Values ('CT11','Decada','Decada');

End

-- Ciclos
If Not Exists(Select CicloID FROM AcCiclo WHERE CicloID = 1)
Begin

    --[CicloID]         INT           NOT NULL IDENTITY,
    --[CicloClave]      VARCHAR (6)   NULL,
    --[Nombre]          VARCHAR (80)  NOT NULL,
    --[NombreCorto]     VARCHAR (15)  NULL,
    --[Descripcion]     VARCHAR (150) NULL,
    --[CalendarioID]    INT           NOT NULL,
    --[FechaInicio]     DATETIME      NOT NULL,
    --[FechaFinal]      DATETIME      NOT NULL,
    --[CicloIDAnterior] INT           NOT NULL,
    --[CicloTipoID]     INT           NOT NULL,

	Delete From AcCiclo
	DBCC CHECKIDENT ('AcCiclo', RESEED, 0);
	
	Insert Into AcCiclo(CicloClave, Nombre, NombreCorto, Descripcion, CalendarioID, FechaInicio, FechaFinal, CicloIDAnterior, CicloTipoID) Values ('C01','Ciclo1','C1','Descripcion1',1, '2019-08-01', '2020-07-30', NULL, 8);
	Insert Into AcCiclo(CicloClave, Nombre, NombreCorto, Descripcion, CalendarioID, FechaInicio, FechaFinal, CicloIDAnterior, CicloTipoID) Values ('C02','Ciclo2','C2','Descripcion2',1, '2019-08-01', '2020-03-30', NULL, 7);
	Insert Into AcCiclo(CicloClave, Nombre, NombreCorto, Descripcion, CalendarioID, FechaInicio, FechaFinal, CicloIDAnterior, CicloTipoID) Values ('C03','Ciclo3','C3','Descripcion3',1, '2019-04-01', '2020-07-30', 2, 7);
	Insert Into AcCiclo(CicloClave, Nombre, NombreCorto, Descripcion, CalendarioID, FechaInicio, FechaFinal, CicloIDAnterior, CicloTipoID) Values ('C04','Ciclo4','C4','Descripcion4',1, '2019-08-01', '2019-10-30', NULL, 5);
	Insert Into AcCiclo(CicloClave, Nombre, NombreCorto, Descripcion, CalendarioID, FechaInicio, FechaFinal, CicloIDAnterior, CicloTipoID) Values ('C05','Ciclo5','C5','Descripcion5',1, '2019-11-01', '2020-01-30', 4, 5);
	Insert Into AcCiclo(CicloClave, Nombre, NombreCorto, Descripcion, CalendarioID, FechaInicio, FechaFinal, CicloIDAnterior, CicloTipoID) Values ('C06','Ciclo6','C6','Descripcion6',1, '2019-02-01', '2020-04-30', 5, 5);
	Insert Into AcCiclo(CicloClave, Nombre, NombreCorto, Descripcion, CalendarioID, FechaInicio, FechaFinal, CicloIDAnterior, CicloTipoID) Values ('C07','Ciclo7','C7','Descripcion7',1, '2019-05-01', '2020-07-30', 5, 5);

End

-- NivelEducativo
If Not Exists(Select NivelEducativoID FROM AcNivelEducativo WHERE NivelEducativoID = 1)
Begin

    --[NivelEducativoID]    INT          NOT NULL IDENTITY,
    --[NivelEducativoClave] VARCHAR (6)  NULL,
    --[Nombre]              VARCHAR (80) NOT NULL,
    --[NombreCorto]         VARCHAR (15) NULL,


	Delete From AcSeccion
	DBCC CHECKIDENT ('AcNivelEducativo', RESEED, 0);
	
	Insert Into AcNivelEducativo(NivelEducativoClave, Nombre, NombreCorto) Values ('N01','Inicial','Inicial');
	Insert Into AcNivelEducativo(NivelEducativoClave, Nombre, NombreCorto) Values ('N02','PreEscolar','PreEscolar');
	Insert Into AcNivelEducativo(NivelEducativoClave, Nombre, NombreCorto) Values ('N03','Primaria','Primaria');
	Insert Into AcNivelEducativo(NivelEducativoClave, Nombre, NombreCorto) Values ('N04','Secundaria','Secundaria');
	Insert Into AcNivelEducativo(NivelEducativoClave, Nombre, NombreCorto) Values ('N05','Media Superior','Media Superior');
	Insert Into AcNivelEducativo(NivelEducativoClave, Nombre, NombreCorto) Values ('N06','Superior','Superior');
	Insert Into AcNivelEducativo(NivelEducativoClave, Nombre, NombreCorto) Values ('N07','Formacion para el Trabajo', 'FormaTrabajo');
	Insert Into AcNivelEducativo(NivelEducativoClave, Nombre, NombreCorto) Values ('N08','Otro Nivel Educativo','Otro');
	Insert Into AcNivelEducativo(NivelEducativoClave, Nombre, NombreCorto) Values ('N09','Educacion Continua','Edu Continua');

End

-- Secciones
If Not Exists(Select SeccionID FROM AcSeccion WHERE SeccionID = 1)
Begin

    --[SeccionID]        INT           NOT NULL IDENTITY,
    --[SeccionClave]     VARCHAR (6)   NULL,
    --[Nombre]           VARCHAR (80)  NOT NULL,
    --[NombreCorto]      VARCHAR (15)  NULL,
    --[Descripcion]      VARCHAR (150) NULL,
    --[NivelEducativoID] INT           NOT NULL,


	Delete From AcSeccion
	DBCC CHECKIDENT ('AcSeccion', RESEED, 0);
	
	Insert Into AcSeccion(SeccionClave, Nombre, NombreCorto, Descripcion, NivelEducativoID) Values ('C01','Guardería','Guarde','Descripcion1',1);
	Insert Into AcSeccion(SeccionClave, Nombre, NombreCorto, Descripcion, NivelEducativoID) Values ('C02','PreMaternal','PreMa','Descripcion2',1);
	Insert Into AcSeccion(SeccionClave, Nombre, NombreCorto, Descripcion, NivelEducativoID) Values ('C03','Maternal','Maternal','Descripcion3',1);
	Insert Into AcSeccion(SeccionClave, Nombre, NombreCorto, Descripcion, NivelEducativoID) Values ('C04','Kinder','Kinder','Descripcion4',2);
	Insert Into AcSeccion(SeccionClave, Nombre, NombreCorto, Descripcion, NivelEducativoID) Values ('C05','Primaria','Primaria','Descripcion5',3);
	Insert Into AcSeccion(SeccionClave, Nombre, NombreCorto, Descripcion, NivelEducativoID) Values ('C06','Secundaria','Secundaria','Descripcion6',4);
	Insert Into AcSeccion(SeccionClave, Nombre, NombreCorto, Descripcion, NivelEducativoID) Values ('C07','Bachillerato','Prepa','Descripcion7',5);
	Insert Into AcSeccion(SeccionClave, Nombre, NombreCorto, Descripcion, NivelEducativoID) Values ('C08','Derecho','Derecho','Descripcion8',6);
	Insert Into AcSeccion(SeccionClave, Nombre, NombreCorto, Descripcion, NivelEducativoID) Values ('C09','Contabilidad','Conta','Descripcion9',6);
	Insert Into AcSeccion(SeccionClave, Nombre, NombreCorto, Descripcion, NivelEducativoID) Values ('C10','Informática','Informatica','Descripcion10',6);

End

-- DiaAsueto
If Not Exists(Select DiaAsuetoID FROM AcDiaAsueto WHERE DiaAsuetoID = 1)
Begin

	--[DiaAsuetoID]    INT           NOT NULL IDENTITY,
 --   [DiaAsuetoClave] VARCHAR (6)   NULL,
 --   [Nombre]         VARCHAR (80)  NOT NULL,
 --   [NombreCorto]    VARCHAR (15)  NULL,
 --   [CicloID]   INT           NOT NULL,
 --   [Descripcion]    VARCHAR (150) NULL,
 --   [Fecha]          DATE          NOT NULL,


	Delete From AcDiaAsueto
	DBCC CHECKIDENT ('AcDiaAsueto', RESEED, 0);
	
	Insert into AcDiaAsueto(DiaAsuetoClave,Nombre,NombreCorto,CicloID,Descripcion,Fecha) Values ('DM','DiaMuerto','DM',1,'Descripcion','2019-11-03')


End

-- InstitucionEducativa
If Not Exists(Select InstitucionEducativaID FROM AcInstitucionEducativa WHERE InstitucionEducativaID = 1)
Begin

	--[InstitucionEducativaID]    INT             IDENTITY (1, 1) NOT NULL,
	--[InstitucionEducativaClave] VARCHAR (6)     NOT NULL,
	--[Nombre]           VARCHAR (80)    NOT NULL,
	--[NombreCorto]      VARCHAR (15)    NOT NULL,
	--[ExtraTexto1]      VARCHAR (500)   NULL,
	--[ExtraTexto2]      VARCHAR (500)   NULL,
	--[ExtraTexto3]      VARCHAR (500)   NULL,
	--[ExtraFecha1]      DATETIME        NULL,
	--[ExtraFecha2]      DATETIME        NULL,
	--[ExtraDecimal1]    DECIMAL (18, 6) NULL,
	--[ExtraDecimal2]    DECIMAL (18, 6) NULL,
	--[ExtraDecimal3]    DECIMAL (18, 6) NULL,


	Delete From AcInstitucionEducativa
	DBCC CHECKIDENT ('AcInstitucionEducativa', RESEED, 0);
	
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R0001D','VILLA REAL','14PPR0001D')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R0007Y','ALBERT CAMUS','14PPR0007Y')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R0010L','INSTITUTO DE LA VERA CRUZ','14PPR0010L')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R0017E','COMUNIDAD EDUCATIVA IDEO','14PPR0017E')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R0025N','CENTRO EDUCACIONAL TLAQUEPAQUE II','14PPR0025N')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R0028K','MEXICO IRLANDES','14PPR0028K')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R0038R','CENTRO ESCOLAR TORREBLANCA','14PPR0038R')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R0041E','SAN RAFAEL DEL PARQUE','14PPR0041E')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R0047Z','GOMEZ FARIAS','14PPR0047Z')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R0052K','INSTITUTO VERDE VALLE','14PPR0052K')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R0056G','NUEVO MILENIO','14PPR0056G')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R0067M','SAN JUAN BOSCO','14PPR0067M')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R0088Z','TRABAJO Y HOGAR DE JALISCO','14PPR0088Z')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R0092L','DANTE ALIGHIERI','14PPR0092L')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R0096H','LOPEZ DE LEGAZPI','14PPR0096H')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R0100D','FATIMA','14PPR0100D')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R0121Q','COLEGIO INTERNACIONAL VANCOUVER','14PPR0121Q')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R0122P','COLEGIO OXFORD','14PPR0122P')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R0127K','LEONARDO DA VINCI','14PPR0127K')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R0142C','PRIMERO DE MAYO','14PPR0142C')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R0143B','ROSA DE LIMA','14PPR0143B')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R0149W','LA SALLE','14PPR0149W')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R0166M','FRANCISCO LARROYO','14PPR0166M')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R0171Y','INSTITUTO DE EDUCACION CREATIVA','14PPR0171Y')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R0186Z','JAIME SABINES','14PPR0186Z')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R0202A','OSWALDO HUIZAR SANTACRUZ','14PPR0202A')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R0203Z','COLEGIO REAL GUADALAJARA','14PPR0203Z')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R0222O','COLEGIO MELANIE KLEIN','14PPR0222O')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R0228I','VASCO DE QUIROGA','14PPR0228I')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R0236R','COLEGIO ANDRES MANJON','14PPR0236R')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R0238P','THOMAS ALVA EDISON','14PPR0238P')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R0245Z','LIBERTAD','14PPR0245Z')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R0256E','COLEGIO BILBAO MONTESSORI','14PPR0256E')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R0257D','OCCIDENTAL','14PPR0257D')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R0258C','NUEVA GALICIA','14PPR0258C')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R0266L','NIÑA OBRERA','14PPR0266L')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R0268J','MOTOLINIA','14PPR0268J')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R0282C','MEDRANO','14PPR0282C')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R0284A','MATEL','14PPR0284A')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R0285Z','MEDRANO','14PPR0285Z')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R0286Z','MARTINEZ NEGRETE','14PPR0286Z')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R0293I','TERRANOVA','14PPR0293I')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R0298D','CALASANZ','14PPR0298D')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R0301A','BORROMEO','14PPR0301A')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R0302Z','ANA FREUD','14PPR0302Z')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R0302Z','ANA FREUD','14PPR0302Z')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R0303Z','LUIS SILVA','14PPR0303Z')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R0304Y','PEDRO CHANEL','14PPR0304Y')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R0317B','LOURDES','14PPR0317B')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R0318A','ASIS','14PPR0318A')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R0323M','ANTONIO CASO','14PPR0323M')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R0331V','COLEGIO AMERICA','14PPR0331V')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R0332U','PATRIA','14PPR0332U')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R0337P','EDUCACION CULTURA Y APRENDIZAJE','14PPR0337P')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R0341B','AGUSTIN DE LA ROSA','14PPR0341B')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R0350J','TEPEYAC','14PPR0350J')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R0357C','COLEGIO VALLARTA','14PPR0357C')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R0364M','ADOLFO LOPEZ MATEOS','14PPR0364M')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R0382B','REVOLUCION','14PPR0382B')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R0386Y','REPUBLICA MEXICANA','14PPR0386Y')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R0388W','REFORMA','14PPR0388W')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R0392I','INSTITUTO MEXICO INGLES','14PPR0392I')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R0396E','RAFAEL GUIZAR','14PPR0396E')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R0403Y','PABLO PICASSO','14PPR0403Y')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R0414D','JUAN JACOBO ROUSSEAU','14PPR0414D')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R0415C','HONORE DE BALZAC','14PPR0415C')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R0433S','INSTITUTO COLON','14PPR0433S')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R0441A','GUADALUPE','14PPR0441A')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R0442Z','HANS CHRISTIAN ANDERSEN','14PPR0442Z')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R0443Z','JEAN PIAGET','14PPR0443Z')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R0445X','GOMEZ DE MENDIOLA','14PPR0445X')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R0450I','FRAY ANTONIO DE SEGOVIA','14PPR0450I')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R0452G','FRAY ANTONIO ALCALDE','14PPR0452G')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R0454E','MARGARET MEAD','14PPR0454E')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R0455D','IN CALLI','14PPR0455D')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R0456C','FELICITAS DE LA CRUZ','14PPR0456C')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R0458A','GOMEZ DE MENDIOLA','14PPR0458A')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R0461O','ESPERANZA','14PPR0461O')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R0463M','COLEGIO ENRIQUE DE OSSO','14PPR0463M')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R0466J','DANTE ALIGHIERI COLINAS','14PPR0466J')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R0492H','JOSE SANCHEZ DEL RIO','14PPR0492H')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R0493G','JUAN PABLO II','14PPR0493G')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R0494F','GUADALAJARA','14PPR0494F')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R0506U','MARTIN LUTHER KING','14PPR0506U')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R0507T','MA ESTHER ZUNO DE ECHEVERRIA','14PPR0507T')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R0514C','LUIS BARRAGAN','14PPR0514C')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R0515B','COLEGIO ESPAÐOL DE GUADALAJARA','14PPR0515B')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R0522L','THOMAS ALVA EDISON','14PPR0522L')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R0533R','COLEGIO IMPULSO','14PPR0533R')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R0539L','LUDWING VAN BEETHOVEN','14PPR0539L')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R0549S','FEDERICO FROEBEL','14PPR0549S')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R0555C','MARIO BENEDETTI','14PPR0555C')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R0556B','JOSE VASCONCELOS','14PPR0556B')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R0560O','LEONARDO DA VINCI','14PPR0560O')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R0571U','CENTRO ESCOLAR GUADALAJARA','14PPR0571U')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R0571U','CENTRO ESCOLAR GUADALAJARA','14PPR0571U')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R0572T','SOR JUANA INES DE LA CRUZ','14PPR0572T')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R0600Z','PALMARES','14PPR0600Z')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R0606T','COLEGIO VICTOR NEUMANN LARA','14PPR0606T')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R0613C','HELENE LUBIESKA DE LENVAL','14PPR0613C')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R0620M','JOSEFA ORTIZ DE DOMINGUEZ','14PPR0620M')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R0621L','COLEGIO DE OCCIDENTE','14PPR0621L')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R0631S','JEAN PIAGET','14PPR0631S')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R0882X','OLIMPICA','14PPR0882X')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R0883W','AMERICA','14PPR0883W')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R0884V','FRANCISCO JAVIER CLAVIJERO','14PPR0884V')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R0906Q','VASCO DE QUIROGA','14PPR0906Q')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R0909N','DE LA LUZ','14PPR0909N')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R0928B','COLEGIO NIÐOS HEROES','14PPR0928B')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R1042K','LA PAZ','14PPR1042K')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R1056N','DOMINGO DE ALZOLA','14PPR1056N')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R1062Y','LICEO DEL VALLE','14PPR1062Y')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R1106E','TOMAS DE AQUINO','14PPR1106E')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R1106E','TOMAS DE AQUINO','14PPR1106E')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R1149C','SANTA MONICA','14PPR1149C')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R1150S','COLEGIO AMERICANO DE GUADALAJARA','14PPR1150S')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R1156M','INDEPENDENCIA','14PPR1156M')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R1157L','ANAHUAC GARIBALDI','14PPR1157L')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R1172D','TERESA DE AVILA','14PPR1172D')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R1217J','JARDINES ALCALDE','14PPR1217J')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R1220X','INSURGENTES','14PPR1220X')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R1250R','INSTITUTO PATRIA','14PPR1250R')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R1255M','JALISCO','14PPR1255M')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R1256L','FRAY PEDRO DE GANTE','14PPR1256L')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R1282J','MAYAS','14PPR1282J')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R1285G','INSTITUTO AMERICA JARDINES DEL COUNTRY','14PPR1285G')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R1408Z','INSTITUTO IGNACIO ALLENDE','14PPR1408Z')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R1412M','MARTIN DE CORUÐA','14PPR1412M')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R1420V','APRENDER A SER','14PPR1420V')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R1421U','DOCE DE OCTUBRE','14PPR1421U')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R1443F','INSTITUTO DEL REFUGIO','14PPR1443F')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R1446C','ALFREDO R PLASCENCIA','14PPR1446C')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R1449Z','MADRID DE GUADALAJARA','14PPR1449Z')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R1453M','ENRIQUE C REBSAMEN','14PPR1453M')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R1454L','COLEGIO IBEROAMERICANO','14PPR1454L')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R1456J','FRANCIS BACON','14PPR1456J')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R1457I','MARTIN LUTHER KING','14PPR1457I')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R1459G','CENTRO ESCOLAR HENRICH PESTALOZZI','14PPR1459G')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R1460W','MARIA CARRILLO DIAZ','14PPR1460W')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R1471B','AGUSTIN YAÐEZ','14PPR1471B')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R1476X','IGNACIO DIAZ MORALES','14PPR1476X')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R1479U','ROOSEVELT SCHOOL','14PPR1479U')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R1480J','LICEO DEL COUNTRY AURELIO ORTEGA','14PPR1480J')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R1485E','RUDYARD KIPLING','14PPR1485E')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R1490Q','INSTITUTO ALPES SAN JAVIER','14PPR1490Q')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R1493N','COZUMEL DE GUADALAJARA','14PPR1493N')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R1500G','BERTRAND RUSSELL','14PPR1500G')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R1508Z','COLEGIO WINSTON CHURCHILL','14PPR1508Z')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R1531Z','ALFRED BINET','14PPR1531Z')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R1536V','NUEVO JARDIN AMERICANO','14PPR1536V')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R1543E','JUAN DE LA BARRERA','14PPR1543E')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R1545C','COLEGIO OVIDIO DECROLY','14PPR1545C')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R1563S','MONTESSORI ALBATROS','14PPR1563S')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R1564R','COLEGIO XITLALIN','14PPR1564R')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R1568N','CENTRO ESCOLAR EL CASTILLO','14PPR1568N')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R1569M','PILCALLI','14PPR1569M')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R1570B','MA TERESA CALDERON VELAZCO','14PPR1570B')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R1597I','JEAN PIAGET','14PPR1597I')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R1602D','NUEVO MEXICO','14PPR1602D')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R1603C','LICEO CHAPALITA','14PPR1603C')
	Insert into AcInstitucionEducativa(InstitucionEducativaClave,Nombre,NombreCorto) Values('R1613J','COLEGIO LAS AMERICAS','14PPR1613J')

End



-- AcPeriodoEvaluacion
If Not Exists(Select PeriodoEvaluacionID FROM AcPeriodoEvaluacion WHERE PeriodoEvaluacionID = 1)
Begin

    --[PeriodoEvaluacionID]         INT          NOT NULL IDENTITY,
    --[PeriodoEvaluacionClave]      VARCHAR (6)  NULL,
    --[Nombre]                      VARCHAR (80) NOT NULL,
    --[NombreCorto]                 VARCHAR (15) NULL,
    --[Descripcion]				  VARCHAR (150) NULL,
    --[PeriodoEvaluacionIDAnterior] INT          NULL,
    --[FechaInicio]                 DATETIME     NOT NULL,
    --[FechaFinal]                  DATETIME     NOT NULL,
    --[CicloID]                     INT          NOT NULL,

	Delete From AcPeriodoEvaluacion
	DBCC CHECKIDENT ('AcPeriodoEvaluacion', RESEED, 0);

	Insert into AcPeriodoEvaluacion(PeriodoEvaluacionClave,Nombre,NombreCorto,PeriodoEvaluacionIDAnterior,FechaInicio,FechaFinal,CicloID) Values ('1er19','1er Bimestre','1er Bimestre',Null,'2019-10-01','2019-10-11',1)
	Insert into AcPeriodoEvaluacion(PeriodoEvaluacionClave,Nombre,NombreCorto,PeriodoEvaluacionIDAnterior,FechaInicio,FechaFinal,CicloID) Values ('2do19','2do Bimestre','2do Bimestre',1,'2019-11-01','2019-11-11',1)
	Insert into AcPeriodoEvaluacion(PeriodoEvaluacionClave,Nombre,NombreCorto,PeriodoEvaluacionIDAnterior,FechaInicio,FechaFinal,CicloID) Values ('3er19','3er Bimestre','3er Bimestre',2,'2019-12-01','2019-12-11',1)
	Insert into AcPeriodoEvaluacion(PeriodoEvaluacionClave,Nombre,NombreCorto,PeriodoEvaluacionIDAnterior,FechaInicio,FechaFinal,CicloID) Values ('4to19','4to Bimestre','4to Bimestre',3,'2020-01-01','2020-01-11',1)


End

-- AcPeriodoVacacional
If Not Exists(Select PeriodoVacacionalID FROM AcPeriodoVacacional WHERE PeriodoVacacionalID = 1)
Begin

    --[PeriodoVacacionalID]    INT          NOT NULL IDENTITY,
    --[PeriodoVacacionalClave] VARCHAR (6)  NULL,
    --[Nombre]                 VARCHAR (80) NOT NULL,
    --[NombreCorto]            VARCHAR (15) NULL,
    --[Descripcion]            VARCHAR (150) NULL,
    --[CicloID]				 INT          NOT NULL,
    --[FechaInicio]            DATETIME     NOT NULL,
    --[FechaFinal]             DATETIME     NOT NULL,

	Delete From AcPeriodoVacacional
	DBCC CHECKIDENT ('AcPeriodoVacacional', RESEED, 0);

	Insert into AcPeriodoVacacional(PeriodoVacacionalClave,Nombre,NombreCorto,Descripcion,CicloID,FechaInicio,FechaFinal) Values('Uno','SemanaSanta','SemanaSanta','Descripcion',1,'2020-03-10','2020-03-25')

End

-- AcPlanEstudio
If Not Exists(Select PlanEstudioID FROM AcPlanEstudio WHERE PlanEstudioID = 1)
Begin

	--[PlanEstudioID]                 INT          NOT NULL IDENTITY,
	--[PlanEstudioClave]              VARCHAR (6)  NULL,
	--[Nombre]                        VARCHAR (80) NOT NULL,
	--[NombreCorto]                   VARCHAR (15) NULL,
	--[Descripcion]                   VARCHAR (150) NULL,
	--[SeccionID]                     INT          NOT NULL,
	--[CalificacionMinimaAprobatoria] DECIMAL(5, 2)          NULL,
	--[CreditosParaAcreditar]         INT          NULL,

	Delete From AcPlanEstudio
	DBCC CHECKIDENT ('AcPlanEstudio', RESEED, 0);

	Insert into AcPlanEstudio(PlanEstudioClave,Nombre,NombreCorto,Descripcion,SeccionID,CalificacionMinimaAprobatoria,CreditosParaAcreditar) Values('Guarde','Guarde','Guarde','Guarde',1,6,-1)
	Insert into AcPlanEstudio(PlanEstudioClave,Nombre,NombreCorto,Descripcion,SeccionID,CalificacionMinimaAprobatoria,CreditosParaAcreditar) Values('PreMat','PreMat','PreMat','PreMat',2,6,-1)
	Insert into AcPlanEstudio(PlanEstudioClave,Nombre,NombreCorto,Descripcion,SeccionID,CalificacionMinimaAprobatoria,CreditosParaAcreditar) Values('Matern','Matern','Matern','Matern',3,6,-1)
	Insert into AcPlanEstudio(PlanEstudioClave,Nombre,NombreCorto,Descripcion,SeccionID,CalificacionMinimaAprobatoria,CreditosParaAcreditar) Values('Kinder','Kinder','Kinder','Kinder',4,6,-1)
	Insert into AcPlanEstudio(PlanEstudioClave,Nombre,NombreCorto,Descripcion,SeccionID,CalificacionMinimaAprobatoria,CreditosParaAcreditar) Values('Primar','Primar','Primar','Primar',5,6,-1)
	Insert into AcPlanEstudio(PlanEstudioClave,Nombre,NombreCorto,Descripcion,SeccionID,CalificacionMinimaAprobatoria,CreditosParaAcreditar) Values('Secund','Secun','Secun','Secun',6,6,-1)
	Insert into AcPlanEstudio(PlanEstudioClave,Nombre,NombreCorto,Descripcion,SeccionID,CalificacionMinimaAprobatoria,CreditosParaAcreditar) Values('2018','2018','2018','Bachillerato 2018',7,6,-1)
	Insert into AcPlanEstudio(PlanEstudioClave,Nombre,NombreCorto,Descripcion,SeccionID,CalificacionMinimaAprobatoria,CreditosParaAcreditar) Values('Derech','Derecho','Derecho','Derecho',8,6,-1)
	Insert into AcPlanEstudio(PlanEstudioClave,Nombre,NombreCorto,Descripcion,SeccionID,CalificacionMinimaAprobatoria,CreditosParaAcreditar) Values('Contab','Contabilidad','Contabilidad','Contabilidad',9,6,-1)
	Insert into AcPlanEstudio(PlanEstudioClave,Nombre,NombreCorto,Descripcion,SeccionID,CalificacionMinimaAprobatoria,CreditosParaAcreditar) Values('Inform','Informatica','Informatica','Informatica',10,6,-1)



End

 -- AcTurno
If Not Exists(Select TurnoID FROM AcTurno WHERE TurnoID = 1)
Begin

    --[TurnoID]     INT           NOT NULL IDENTITY,
    --[TurnoClave]  VARCHAR (6)   NULL,
    --[Nombre]      VARCHAR (80)  NULL,
    --[NombreCorto] VARCHAR (15)  NULL,
    --[HoraInicio]  SMALLINT NULL,
    --[HoraFinal]   SMALLINT  NULL, 

	Delete From AcTurno
	DBCC CHECKIDENT ('AcTurno', RESEED, 0);

	Insert into AcTurno(TurnoClave,Nombre,NombreCorto,HoraInicio,HoraFinal) Values ('T01','Matutino','Matutino',440,840)
	Insert into AcTurno(TurnoClave,Nombre,NombreCorto,HoraInicio,HoraFinal) Values ('T02','Vespertino','Vespertino',840,1200)
	Insert into AcTurno(TurnoClave,Nombre,NombreCorto,HoraInicio,HoraFinal) Values ('T03','Nocturno','Nocturno',1200,1320)
	Insert into AcTurno(TurnoClave,Nombre,NombreCorto,HoraInicio,HoraFinal) Values ('T04','Discontinuo','Discontinuo',-1,-1)
	Insert into AcTurno(TurnoClave,Nombre,NombreCorto,HoraInicio,HoraFinal) Values ('T05','Continuo','Continuo',-1,-1)
	Insert into AcTurno(TurnoClave,Nombre,NombreCorto,HoraInicio,HoraFinal) Values ('T06','No Aplica','No Aplica',-1,-1)
	Insert into AcTurno(TurnoClave,Nombre,NombreCorto,HoraInicio,HoraFinal) Values ('T07','Sabatino','Sabatino',480,840)

End

 -- AcRvoe
If Not Exists(Select RvoeID FROM AcRvoe WHERE RvoeID = 1)
Begin

    --[RvoeClave]       VARCHAR (6)  NULL,
    --[Nombre]          VARCHAR (80) NULL,
    --[NombreCorto]     VARCHAR (15) NULL,
    --[Registro]            VARCHAR (50) NULL,
    --[FechaExpedicion] DATETIME     NULL,

	Delete From AcRvoe
	DBCC CHECKIDENT ('AcRvoe', RESEED, 0);

	Insert into AcRvoe(RvoeClave,Nombre,NombreCorto,Registro,FechaExpedicion) Values ('R01','R01','R01','ESLI20011414','2019-01-01')
	Insert into AcRvoe(RvoeClave,Nombre,NombreCorto,Registro,FechaExpedicion) Values ('R02','R02','R02','ESLI20121455','2019-01-01')
	Insert into AcRvoe(RvoeClave,Nombre,NombreCorto,Registro,FechaExpedicion) Values ('R03','R03','R03','ESLI20011412','2019-01-01')
	Insert into AcRvoe(RvoeClave,Nombre,NombreCorto,Registro,FechaExpedicion) Values ('R04','R04','R04','ESLI20011419','2019-01-01')
	Insert into AcRvoe(RvoeClave,Nombre,NombreCorto,Registro,FechaExpedicion) Values ('R05','R05','R05','ESLI20121454','2019-01-01')
	Insert into AcRvoe(RvoeClave,Nombre,NombreCorto,Registro,FechaExpedicion) Values ('R06','R06','R06','ESLI20011415','2019-01-01')
	Insert into AcRvoe(RvoeClave,Nombre,NombreCorto,Registro,FechaExpedicion) Values ('R07','R07','R07','ESLI20011410','2019-01-01')
	Insert into AcRvoe(RvoeClave,Nombre,NombreCorto,Registro,FechaExpedicion) Values ('R08','R08','R08','ESLI20011409','2019-01-01')
	Insert into AcRvoe(RvoeClave,Nombre,NombreCorto,Registro,FechaExpedicion) Values ('R09','R09','R09','ESLI20011413','2019-01-01')


End



 -- AcProgramaEstudioTipo
If Not Exists(Select ProgramaEstudioTipoID FROM AcProgramaEstudioTipo WHERE ProgramaEstudioTipoID = 1)
Begin

    --[ProgramaEstudioTipoID]    INT          NOT NULL IDENTITY,
    --[ProgramaEstudioTipoClave] VARCHAR (6) NULL,
    --[Nombre]                   VARCHAR (80) NOT NULL,
    --[NombreCorto]              VARCHAR (15) NULL,

	Delete From AcProgramaEstudioTipo
	DBCC CHECKIDENT ('AcProgramaEstudioTipo', RESEED, 0);

	Insert into AcProgramaEstudioTipo(ProgramaEstudioTipoClave,Nombre,NombreCorto) Values('Curso','Curso','Curso')
	Insert into AcProgramaEstudioTipo(ProgramaEstudioTipoClave,Nombre,NombreCorto) Values('Taller','Taller','Taller')
	Insert into AcProgramaEstudioTipo(ProgramaEstudioTipoClave,Nombre,NombreCorto) Values('Practi','Practica','Practica')
	Insert into AcProgramaEstudioTipo(ProgramaEstudioTipoClave,Nombre,NombreCorto) Values('CursoT','Curso-Taller','Curso-Taller')
	Insert into AcProgramaEstudioTipo(ProgramaEstudioTipoClave,Nombre,NombreCorto) Values('Semina','Seminario','Seminario')
	Insert into AcProgramaEstudioTipo(ProgramaEstudioTipoClave,Nombre,NombreCorto) Values('Labora','Laboratorio','Laboratorio')
	Insert into AcProgramaEstudioTipo(ProgramaEstudioTipoClave,Nombre,NombreCorto) Values('CursoS','Curso-Seminario','Curso-Seminario')
	Insert into AcProgramaEstudioTipo(ProgramaEstudioTipoClave,Nombre,NombreCorto) Values('CursoL','Curso-Laboratorio','Curso-Laboratorio')
	Insert into AcProgramaEstudioTipo(ProgramaEstudioTipoClave,Nombre,NombreCorto) Values('CursoP','Curso-Practica','Curso-Practica')
	Insert into AcProgramaEstudioTipo(ProgramaEstudioTipoClave,Nombre,NombreCorto) Values('CursoN','Curso-N','Curso-N')


End



 -- AcProgramaEstudio
If Not Exists(Select ProgramaEstudioID FROM AcProgramaEstudio WHERE ProgramaEstudioID = 1)
Begin

    --[ProgramaEstudioID]     INT         NOT NULL IDENTITY,
    --[PlanEstudioID]         INT         NOT NULL,
    --[AsignaturaID]          INT         NOT NULL,
    --[Clave]                 VARCHAR (6) NULL,
    --[ProgramaEstudioTipoID] INT         NOT NULL,
    --[AreaFormacionID]       INT         NOT NULL,
    --[HorasTeoria]           INT         NULL,
    --[HorasPractica]         INT         NULL,
    --[HorasTotales]          INT         NULL,
    --[Creditos]              INT         NULL,
    --[DuracionSemanas]       INT         NULL,
    --[Grado] INT NULL, 

	Delete From AcProgramaEstudio
	DBCC CHECKIDENT ('AcProgramaEstudio', RESEED, 0);

	Insert into AcProgramaEstudio(PlanEstudioID, AsignaturaID, Clave, ProgramaEstudioTipoID, AreaFormacionID) Values (7,1,'B1',1,1)
	Insert into AcProgramaEstudio(PlanEstudioID, AsignaturaID, Clave, ProgramaEstudioTipoID, AreaFormacionID) Values (7,2,'B2',1,1)
	Insert into AcProgramaEstudio(PlanEstudioID, AsignaturaID, Clave, ProgramaEstudioTipoID, AreaFormacionID) Values (7,3,'B3',1,1)
	Insert into AcProgramaEstudio(PlanEstudioID, AsignaturaID, Clave, ProgramaEstudioTipoID, AreaFormacionID) Values (7,4,'B4',1,1)
	Insert into AcProgramaEstudio(PlanEstudioID, AsignaturaID, Clave, ProgramaEstudioTipoID, AreaFormacionID) Values (7,5,'B5',1,1)
	Insert into AcProgramaEstudio(PlanEstudioID, AsignaturaID, Clave, ProgramaEstudioTipoID, AreaFormacionID) Values (7,6,'B6',1,1)
	Insert into AcProgramaEstudio(PlanEstudioID, AsignaturaID, Clave, ProgramaEstudioTipoID, AreaFormacionID) Values (7,7,'B7',1,1)
	Insert into AcProgramaEstudio(PlanEstudioID, AsignaturaID, Clave, ProgramaEstudioTipoID, AreaFormacionID) Values (7,8,'B8',1,1)
	Insert into AcProgramaEstudio(PlanEstudioID, AsignaturaID, Clave, ProgramaEstudioTipoID, AreaFormacionID) Values (7,9,'B9',1,1)
	Insert into AcProgramaEstudio(PlanEstudioID, AsignaturaID, Clave, ProgramaEstudioTipoID, AreaFormacionID) Values (7,10,'B10',1,1)
	Insert into AcProgramaEstudio(PlanEstudioID, AsignaturaID, Clave, ProgramaEstudioTipoID, AreaFormacionID) Values (7,11,'B11',1,1)
	Insert into AcProgramaEstudio(PlanEstudioID, AsignaturaID, Clave, ProgramaEstudioTipoID, AreaFormacionID) Values (7,12,'B12',1,1)
	Insert into AcProgramaEstudio(PlanEstudioID, AsignaturaID, Clave, ProgramaEstudioTipoID, AreaFormacionID) Values (7,13,'B13',1,1)
	Insert into AcProgramaEstudio(PlanEstudioID, AsignaturaID, Clave, ProgramaEstudioTipoID, AreaFormacionID) Values (7,14,'B14',1,1)
	Insert into AcProgramaEstudio(PlanEstudioID, AsignaturaID, Clave, ProgramaEstudioTipoID, AreaFormacionID) Values (7,15,'B15',1,1)
	Insert into AcProgramaEstudio(PlanEstudioID, AsignaturaID, Clave, ProgramaEstudioTipoID, AreaFormacionID) Values (7,16,'B16',1,1)
	Insert into AcProgramaEstudio(PlanEstudioID, AsignaturaID, Clave, ProgramaEstudioTipoID, AreaFormacionID) Values (7,17,'B17',1,1)
	Insert into AcProgramaEstudio(PlanEstudioID, AsignaturaID, Clave, ProgramaEstudioTipoID, AreaFormacionID) Values (7,18,'B18',1,1)
	Insert into AcProgramaEstudio(PlanEstudioID, AsignaturaID, Clave, ProgramaEstudioTipoID, AreaFormacionID) Values (7,19,'B19',1,1)
	Insert into AcProgramaEstudio(PlanEstudioID, AsignaturaID, Clave, ProgramaEstudioTipoID, AreaFormacionID) Values (7,20,'B20',1,1)
	Insert into AcProgramaEstudio(PlanEstudioID, AsignaturaID, Clave, ProgramaEstudioTipoID, AreaFormacionID) Values (7,21,'B21',1,1)
	Insert into AcProgramaEstudio(PlanEstudioID, AsignaturaID, Clave, ProgramaEstudioTipoID, AreaFormacionID) Values (7,22,'B22',1,1)
	Insert into AcProgramaEstudio(PlanEstudioID, AsignaturaID, Clave, ProgramaEstudioTipoID, AreaFormacionID) Values (7,23,'B23',1,1)
	Insert into AcProgramaEstudio(PlanEstudioID, AsignaturaID, Clave, ProgramaEstudioTipoID, AreaFormacionID) Values (7,24,'B24',1,1)
	Insert into AcProgramaEstudio(PlanEstudioID, AsignaturaID, Clave, ProgramaEstudioTipoID, AreaFormacionID) Values (7,25,'B25',1,1)
	Insert into AcProgramaEstudio(PlanEstudioID, AsignaturaID, Clave, ProgramaEstudioTipoID, AreaFormacionID) Values (7,26,'B26',1,1)
	Insert into AcProgramaEstudio(PlanEstudioID, AsignaturaID, Clave, ProgramaEstudioTipoID, AreaFormacionID) Values (7,27,'B27',1,1)
	Insert into AcProgramaEstudio(PlanEstudioID, AsignaturaID, Clave, ProgramaEstudioTipoID, AreaFormacionID) Values (7,28,'B28',1,1)
	Insert into AcProgramaEstudio(PlanEstudioID, AsignaturaID, Clave, ProgramaEstudioTipoID, AreaFormacionID) Values (7,29,'B29',1,1)
	Insert into AcProgramaEstudio(PlanEstudioID, AsignaturaID, Clave, ProgramaEstudioTipoID, AreaFormacionID) Values (7,30,'B30',1,1)
	Insert into AcProgramaEstudio(PlanEstudioID, AsignaturaID, Clave, ProgramaEstudioTipoID, AreaFormacionID) Values (7,31,'B31',1,1)
	Insert into AcProgramaEstudio(PlanEstudioID, AsignaturaID, Clave, ProgramaEstudioTipoID, AreaFormacionID) Values (7,32,'B32',1,1)
	Insert into AcProgramaEstudio(PlanEstudioID, AsignaturaID, Clave, ProgramaEstudioTipoID, AreaFormacionID) Values (7,33,'B33',1,1)
	Insert into AcProgramaEstudio(PlanEstudioID, AsignaturaID, Clave, ProgramaEstudioTipoID, AreaFormacionID) Values (7,34,'B34',1,1)
	Insert into AcProgramaEstudio(PlanEstudioID, AsignaturaID, Clave, ProgramaEstudioTipoID, AreaFormacionID) Values (7,35,'B35',1,1)
	Insert into AcProgramaEstudio(PlanEstudioID, AsignaturaID, Clave, ProgramaEstudioTipoID, AreaFormacionID) Values (7,36,'B36',1,1)
	Insert into AcProgramaEstudio(PlanEstudioID, AsignaturaID, Clave, ProgramaEstudioTipoID, AreaFormacionID) Values (7,37,'B37',1,1)
	Insert into AcProgramaEstudio(PlanEstudioID, AsignaturaID, Clave, ProgramaEstudioTipoID, AreaFormacionID) Values (7,38,'B38',1,1)
	Insert into AcProgramaEstudio(PlanEstudioID, AsignaturaID, Clave, ProgramaEstudioTipoID, AreaFormacionID) Values (7,39,'B39',1,1)
	Insert into AcProgramaEstudio(PlanEstudioID, AsignaturaID, Clave, ProgramaEstudioTipoID, AreaFormacionID) Values (7,40,'B40',1,1)
	Insert into AcProgramaEstudio(PlanEstudioID, AsignaturaID, Clave, ProgramaEstudioTipoID, AreaFormacionID) Values (7,41,'B41',1,1)
	Insert into AcProgramaEstudio(PlanEstudioID, AsignaturaID, Clave, ProgramaEstudioTipoID, AreaFormacionID) Values (7,42,'B42',1,1)
	Insert into AcProgramaEstudio(PlanEstudioID, AsignaturaID, Clave, ProgramaEstudioTipoID, AreaFormacionID) Values (7,43,'B43',1,1)
	Insert into AcProgramaEstudio(PlanEstudioID, AsignaturaID, Clave, ProgramaEstudioTipoID, AreaFormacionID) Values (7,44,'B44',1,1)



End


 -- AcOfertaAcademica
If Not Exists(Select OfertaAcademicaID FROM AcOfertaAcademica WHERE OfertaAcademicaID = 1)
Begin

	--[OfertaAcademicaID] INT NOT NULL PRIMARY KEY IDENTITY, 
 --   [CicloID] INT NOT NULL, 
 --   [PlantelID] INT NOT NULL, 
 --   [SeccionID] INT NOT NULL, 

	Delete From AcOfertaAcademica
	DBCC CHECKIDENT ('AcOfertaAcademica', RESEED, 0);

	Insert into AcOfertaAcademica(CicloID,PlantelID,SeccionID) Values (1,1,1)
	Insert into AcOfertaAcademica(CicloID,PlantelID,SeccionID) Values (1,1,2)
	Insert into AcOfertaAcademica(CicloID,PlantelID,SeccionID) Values (1,1,3)
	Insert into AcOfertaAcademica(CicloID,PlantelID,SeccionID) Values (1,1,4)
	Insert into AcOfertaAcademica(CicloID,PlantelID,SeccionID) Values (1,1,5)
	Insert into AcOfertaAcademica(CicloID,PlantelID,SeccionID) Values (1,1,6)
	Insert into AcOfertaAcademica(CicloID,PlantelID,SeccionID) Values (2,1,7)
	Insert into AcOfertaAcademica(CicloID,PlantelID,SeccionID) Values (3,1,7)

End


 -- AcOfertaAcademicaPlanEstudioTurno
If Not Exists(Select OfertaAcademicaPlanEstudioTurnoID FROM AcOfertaAcademicaPlanEstudioTurno WHERE OfertaAcademicaPlanEstudioTurnoID = 1)
Begin

	--[OfertaAcademicaPlanEstudioTurnoID] INT NOT NULL PRIMARY KEY IDENTITY, 
 --   [OfertaAcademicaID] INT NOT NULL, 
 --   [PlanEstudioID] INT NOT NULL, 
 --   [TurnoID] INT NOT NULL, 
 --   [RvoeID] INT NOT NULL, 

	Delete From AcOfertaAcademicaPlanEstudioTurno
	DBCC CHECKIDENT ('AcOfertaAcademicaPlanEstudioTurno', RESEED, 0);

	Insert into AcOfertaAcademicaPlanEstudioTurno(OfertaAcademicaID,PlanEstudioID,TurnoID,RvoeID) Values (7,7,1,1)
	Insert into AcOfertaAcademicaPlanEstudioTurno(OfertaAcademicaID,PlanEstudioID,TurnoID,RvoeID) Values (8,7,1,1)


End




USE premium_web
GO
IF OBJECT_ID('segformulario') IS NOT NULL
BEGIN
    DROP TABLE segformulario;
    PRINT 'Tabla eliminada correctamente.';
END
Go
CREATE TABLE [dbo].[segformulario](
	[codigo] [varchar](4) NOT NULL,
	[nombre] [varchar](100) NULL,
	[descripcion] [varchar](100) NULL,
	[codmodulo] [char](2) NOT NULL,
 CONSTRAINT [PK_segformulario] PRIMARY KEY CLUSTERED 
(
	[codigo] ASC,
	[codmodulo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


SET ANSI_PADDING ON
GO
IF OBJECT_ID('segmenu') IS NOT NULL
BEGIN
    DROP TABLE segmenu;
    PRINT 'Tabla eliminada correctamente.';
END
Go
CREATE TABLE [dbo].[segmenu](
	[codigo] [varchar](20) NOT NULL,
	[etiqueta] [varchar](100) NULL,
	[nivel1] [char](2) NULL,
	[nivel2] [char](2) NULL,
	[nivel3] [char](2) NULL,
	[comando] [varchar](50) NULL,
	[codigoFormulario] [varchar](50) NULL,
	[nombreIcono] [varchar](30) NULL,
	[codmodulo] [varchar](2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[codigo] ASC,
	[codmodulo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
IF OBJECT_ID('segmodulo') IS NOT NULL
BEGIN
    DROP TABLE segmodulo;
    PRINT 'Tabla eliminada correctamente.';
END
Go

CREATE TABLE [dbo].[segmodulo](
	[Codigo] [char](2) NOT NULL,
	[Nombre] [varchar](100) NULL,
 CONSTRAINT [PK_segmodulo] PRIMARY KEY NONCLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
IF OBJECT_ID('segperfil') IS NOT NULL
BEGIN
    DROP TABLE segperfil;
    PRINT 'Tabla eliminada correctamente.';
END
Go
CREATE TABLE [dbo].[segperfil](
	[codigo] [varchar](20) NOT NULL,
	[nombre] [varchar](20) NULL,
	[descripcion] [varchar](100) NULL,
 CONSTRAINT [PK_segperfil] PRIMARY KEY CLUSTERED 
(
	[codigo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
IF OBJECT_ID('segmenuxperfil') IS NOT NULL
BEGIN
    DROP TABLE segmenuxperfil;
    PRINT 'Tabla eliminada correctamente.';
END
Go

CREATE TABLE [dbo].[segmenuxperfil](
	[codigoPerfil] [varchar](20) NOT NULL,
	[codigoMenu] [varchar](20) NOT NULL,
	[opcxmenu] [varchar](20) NULL,
	[codmodulo] [varchar](2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[codigoMenu] ASC,
	[codigoPerfil] ASC,
	[codmodulo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

IF OBJECT_ID('Segusuario') IS NOT NULL
BEGIN
    DROP TABLE Segusuario;
    PRINT 'Tabla eliminada correctamente.';
END
Go


CREATE TABLE [dbo].[Segusuario](
	[Codigo] [varchar](20) NOT NULL,
	[NombreUsuario] [varchar](50) NULL,
	[ClaveUsuario] [varchar](20) NULL,
	[CodigoPerfil] [varchar](50) NULL,
	[CodigoEmpresa] [varchar](2) NULL,
 CONSTRAINT [PK_Segusuario] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

IF OBJECT_ID('segOpciones') IS NOT NULL
BEGIN
    DROP TABLE segOpciones;
    PRINT 'Tabla eliminada correctamente.';
END
Go

CREATE TABLE [dbo].[segOpciones](
	[codigoOpc] [varchar](3) NOT NULL,
	[nombreOpc] [varchar](100) NULL,
	[posicionOpc] [char](3) NULL,
 CONSTRAINT [PK_segOpciones] PRIMARY KEY NONCLUSTERED 
(
	[codigoOpc] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

IF OBJECT_ID('segOpcxFormulario') IS NOT NULL
BEGIN
    DROP TABLE segOpcxFormulario;
    PRINT 'Tabla eliminada correctamente.';
END
Go

CREATE TABLE [dbo].[segOpcxFormulario](
	[codigoFormulario] [varchar](4) NOT NULL,
	[codigoOpc] [varchar](3) NOT NULL,
	[codmodulo] [char](2) NOT NULL,
 CONSTRAINT [PK_segOpcxFormulario] PRIMARY KEY CLUSTERED 
(
	[codigoFormulario] ASC,
	[codigoOpc] ASC,
	[codmodulo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


IF OBJECT_ID('segmodulosxempresa') IS NOT NULL
BEGIN
    DROP TABLE segmodulosxempresa;
    PRINT 'Tabla eliminada correctamente.';
END
Go

CREATE TABLE [dbo].[segmodulosxempresa](
	[codigoEmpresa] [varchar](2) NOT NULL,
	[codigoModulo] [varchar](50) NOT NULL,
 CONSTRAINT [PK_segmodulosxempresa] PRIMARY KEY CLUSTERED 
(
	[codigoEmpresa] ASC,
	[codigoModulo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO



select * from segformulario
insert into segformulario values('0001', 'banco', 'banco compoenten', '01')
insert into segformulario values('0002', 'cuentas_bancarias', 'cuentas bancarias componente', '01')
insert into segformulario values('0003', 'usuario', 'usuario componente', '01')
insert into segformulario values('0004', 'numero_cuenta', 'numero cuenta componente', '01')
select * from segmenu
insert into segmenu values('0001', 'Bancos', '01', '00','00', '','','','01')
insert into segmenu values('0002', 'banco', '01', '01','00', '','0001','pi pi-fw pi-building','01')
insert into segmenu values('0003', 'cuenta bancaria', '01', '02','00', '','0002','pi pi-fw pi-credit-card','01')
insert into segmenu values('0004', 'numero cuenta', '01', '03','00', '','0004','pi pi-fw pi-credit-card','01')
insert into segmenu values('0005', 'Seguridad', '02', '00','00', '','','','01')
insert into segmenu values('0006', 'usuario', '02', '01','00', '','0003','pi pi-fw pi-user','01')


select * from segmodulo
insert  into segmodulo values('01', 'Caja banco')
select * from segperfil
insert into segperfil values ('01', 'Administrador Genera', 'Perfil de administrador')
insert into segperfil values ('02', 'Asistente General', 'Perfil de planillero global')
insert into segperfil values ('03', 'Administrador', 'Perfil de administrador de cliente')
insert into segperfil values ('04', 'Asistente', 'Perfil de planillero cliente')

select * from Segusuario
insert into Segusuario values('administrador', 'administrador', 'administrador', '01','01')
select * from segmenuxperfil
insert into segmenuxperfil values ('03', '0001', '11111111111111111111', '01')
insert into segmenuxperfil values ('03', '0002', '11111111111111111111', '01')
insert into segmenuxperfil values ('03', '0003', '11111111111111111111', '01')
insert into segmenuxperfil values ('03', '0004', '11111111111111111111', '01')
insert into segmenuxperfil values ('03', '0005', '11111111111111111111', '01')
insert into segmenuxperfil values ('03', '0006', '11111111111111111111', '01')

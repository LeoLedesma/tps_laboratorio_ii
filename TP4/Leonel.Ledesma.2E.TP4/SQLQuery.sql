USE [master]
GO
/****** Object:  Database [LedesmaLeonel2ETP4]    Script Date: 19/06/2022 13:14:56 ******/
CREATE DATABASE [LedesmaLeonel2ETP4]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'LedesmaLeonel2ETP4', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\LedesmaLeonel2ETP4.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'LedesmaLeonel2ETP4_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\LedesmaLeonel2ETP4_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [LedesmaLeonel2ETP4] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [LedesmaLeonel2ETP4].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [LedesmaLeonel2ETP4] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [LedesmaLeonel2ETP4] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [LedesmaLeonel2ETP4] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [LedesmaLeonel2ETP4] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [LedesmaLeonel2ETP4] SET ARITHABORT OFF 
GO
ALTER DATABASE [LedesmaLeonel2ETP4] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [LedesmaLeonel2ETP4] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [LedesmaLeonel2ETP4] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [LedesmaLeonel2ETP4] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [LedesmaLeonel2ETP4] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [LedesmaLeonel2ETP4] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [LedesmaLeonel2ETP4] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [LedesmaLeonel2ETP4] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [LedesmaLeonel2ETP4] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [LedesmaLeonel2ETP4] SET  ENABLE_BROKER 
GO
ALTER DATABASE [LedesmaLeonel2ETP4] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [LedesmaLeonel2ETP4] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [LedesmaLeonel2ETP4] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [LedesmaLeonel2ETP4] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [LedesmaLeonel2ETP4] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [LedesmaLeonel2ETP4] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [LedesmaLeonel2ETP4] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [LedesmaLeonel2ETP4] SET RECOVERY FULL 
GO
ALTER DATABASE [LedesmaLeonel2ETP4] SET  MULTI_USER 
GO
ALTER DATABASE [LedesmaLeonel2ETP4] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [LedesmaLeonel2ETP4] SET DB_CHAINING OFF 
GO
ALTER DATABASE [LedesmaLeonel2ETP4] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [LedesmaLeonel2ETP4] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [LedesmaLeonel2ETP4] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [LedesmaLeonel2ETP4] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'LedesmaLeonel2ETP4', N'ON'
GO
ALTER DATABASE [LedesmaLeonel2ETP4] SET QUERY_STORE = OFF
GO
USE [LedesmaLeonel2ETP4]
GO
/****** Object:  Table [dbo].[centroMedico]    Script Date: 19/06/2022 13:14:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[centroMedico](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[duracionTurno] [int] NOT NULL,
	[idDiasDeAtencion] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[diasDeAtencion]    Script Date: 19/06/2022 13:14:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[diasDeAtencion](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idLunes] [int] NOT NULL,
	[idMartes] [int] NOT NULL,
	[idMiercoles] [int] NOT NULL,
	[idJueves] [int] NOT NULL,
	[idViernes] [int] NOT NULL,
	[idSabado] [int] NOT NULL,
	[idDomingo] [int] NOT NULL,
 CONSTRAINT [PK__diasDeAt__3213E83FC4B4FE24] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[especialidadesCentro]    Script Date: 19/06/2022 13:14:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[especialidadesCentro](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](20) NOT NULL,
	[isActive] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[especialidadesProfesionales]    Script Date: 19/06/2022 13:14:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[especialidadesProfesionales](
	[idEspecialidadesCentro] [int] NOT NULL,
	[idProfesional] [int] NOT NULL,
	[isActive] [bit] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[horarioDeAtencion]    Script Date: 19/06/2022 13:14:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[horarioDeAtencion](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[atiende] [bit] NOT NULL,
	[esPorDefecto] [bit] NOT NULL,
	[desde] [varchar](10) NULL,
	[hasta] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[pacientes]    Script Date: 19/06/2022 13:14:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[pacientes](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](20) NOT NULL,
	[apellido] [varchar](20) NOT NULL,
	[fechaNacimiento] [date] NOT NULL,
	[indiceGenero] [int] NOT NULL,
	[indiceNacionalidad] [int] NOT NULL,
	[documento] [varchar](9) NOT NULL,
	[telefono] [varchar](20) NOT NULL,
	[telefonoContacto] [varchar](20) NULL,
	[obraSocial] [varchar](30) NULL,
	[numeroAfiliado] [varchar](20) NULL,
	[isActive] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[profesionales]    Script Date: 19/06/2022 13:14:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[profesionales](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](20) NOT NULL,
	[apellido] [varchar](20) NOT NULL,
	[fechaNacimiento] [date] NOT NULL,
	[indiceGenero] [int] NOT NULL,
	[indiceNacionalidad] [int] NOT NULL,
	[documento] [varchar](9) NOT NULL,
	[telefono] [varchar](20) NOT NULL,
	[matricula] [varchar](20) NOT NULL,
	[idDiasDeAtencion] [int] NOT NULL,
	[isActive] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[turnos]    Script Date: 19/06/2022 13:14:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[turnos](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[fecha] [datetime] NOT NULL,
	[idPaciente] [int] NOT NULL,
	[idProfesional] [int] NOT NULL,
	[idEspecialidad] [int] NOT NULL,
	[pacienteAsistio] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[centroMedico]  WITH CHECK ADD  CONSTRAINT [FK__centroMed__idDia__3C69FB99] FOREIGN KEY([idDiasDeAtencion])
REFERENCES [dbo].[diasDeAtencion] ([id])
GO
ALTER TABLE [dbo].[centroMedico] CHECK CONSTRAINT [FK__centroMed__idDia__3C69FB99]
GO
ALTER TABLE [dbo].[diasDeAtencion]  WITH CHECK ADD FOREIGN KEY([idDomingo])
REFERENCES [dbo].[horarioDeAtencion] ([id])
GO
ALTER TABLE [dbo].[diasDeAtencion]  WITH CHECK ADD FOREIGN KEY([idJueves])
REFERENCES [dbo].[horarioDeAtencion] ([id])
GO
ALTER TABLE [dbo].[diasDeAtencion]  WITH CHECK ADD FOREIGN KEY([idLunes])
REFERENCES [dbo].[horarioDeAtencion] ([id])
GO
ALTER TABLE [dbo].[diasDeAtencion]  WITH CHECK ADD FOREIGN KEY([idMartes])
REFERENCES [dbo].[horarioDeAtencion] ([id])
GO
ALTER TABLE [dbo].[diasDeAtencion]  WITH CHECK ADD FOREIGN KEY([idMiercoles])
REFERENCES [dbo].[horarioDeAtencion] ([id])
GO
ALTER TABLE [dbo].[diasDeAtencion]  WITH CHECK ADD FOREIGN KEY([idSabado])
REFERENCES [dbo].[horarioDeAtencion] ([id])
GO
ALTER TABLE [dbo].[diasDeAtencion]  WITH CHECK ADD FOREIGN KEY([idViernes])
REFERENCES [dbo].[horarioDeAtencion] ([id])
GO
ALTER TABLE [dbo].[especialidadesProfesionales]  WITH CHECK ADD FOREIGN KEY([idEspecialidadesCentro])
REFERENCES [dbo].[especialidadesCentro] ([id])
GO
ALTER TABLE [dbo].[especialidadesProfesionales]  WITH CHECK ADD FOREIGN KEY([idProfesional])
REFERENCES [dbo].[profesionales] ([id])
GO
ALTER TABLE [dbo].[profesionales]  WITH CHECK ADD  CONSTRAINT [FK__profesion__idDia__32E0915F] FOREIGN KEY([idDiasDeAtencion])
REFERENCES [dbo].[diasDeAtencion] ([id])
GO
ALTER TABLE [dbo].[profesionales] CHECK CONSTRAINT [FK__profesion__idDia__32E0915F]
GO
ALTER TABLE [dbo].[turnos]  WITH CHECK ADD FOREIGN KEY([idEspecialidad])
REFERENCES [dbo].[especialidadesCentro] ([id])
GO
ALTER TABLE [dbo].[turnos]  WITH CHECK ADD FOREIGN KEY([idProfesional])
REFERENCES [dbo].[profesionales] ([id])
GO
ALTER TABLE [dbo].[turnos]  WITH CHECK ADD FOREIGN KEY([idPaciente])
REFERENCES [dbo].[pacientes] ([id])
GO
USE [master]
GO
ALTER DATABASE [LedesmaLeonel2ETP4] SET  READ_WRITE 
GO

use LedesmaLeonel2ETP4

INSERT INTO [horarioDeAtencion] (atiende, esPorDefecto, desde, hasta) VALUES (1, 0, '08:00', '20:00')
INSERT INTO horarioDeAtencion (atiende, esPorDefecto, desde, hasta) VALUES (1, 0, '08:00', '20:00')
INSERT INTO horarioDeAtencion (atiende, esPorDefecto, desde, hasta) VALUES (1, 0, '08:00', '20:00')
INSERT INTO horarioDeAtencion (atiende, esPorDefecto, desde, hasta) VALUES (1, 0, '08:00', '20:00')
INSERT INTO horarioDeAtencion (atiende, esPorDefecto, desde, hasta) VALUES (1, 0, '08:00', '20:00')
INSERT INTO horarioDeAtencion (atiende, esPorDefecto, desde, hasta) VALUES (1, 0, '08:00', '13:30')
INSERT INTO horarioDeAtencion (atiende, esPorDefecto, desde, hasta) VALUES (1, 0, '08:00', '13:30')
INSERT INTO diasDeAtencion(idLunes, idMartes, idMiercoles, idJueves, idViernes, idSabado, idDomingo) VALUES (1, 2, 3, 4, 5, 6, 7)
INSERT INTO centroMedico (nombre, duracionTurno, idDiasDeAtencion) VALUES ('Centro Medico', 30, 1)
INSERT INTO especialidadesCentro (nombre, isActive) VALUES ('Odontologia', 1)
INSERT INTO especialidadesCentro (nombre, isActive) VALUES ('Cirugia', 1)
INSERT INTO especialidadesCentro (nombre, isActive) VALUES ('Medicina Familiar', 1)
INSERT INTO horarioDeAtencion (atiende, esPorDefecto, desde, hasta) VALUES (0, 1, '00:00', '00:00')
INSERT INTO horarioDeAtencion (atiende, esPorDefecto, desde, hasta) VALUES (0, 1, '00:00', '00:00')
INSERT INTO horarioDeAtencion (atiende, esPorDefecto, desde, hasta) VALUES (0, 1, '00:00', '00:00')
INSERT INTO horarioDeAtencion (atiende, esPorDefecto, desde, hasta) VALUES (0, 1, '00:00', '00:00')
INSERT INTO horarioDeAtencion (atiende, esPorDefecto, desde, hasta) VALUES (0, 1, '00:00', '00:00')
INSERT INTO horarioDeAtencion (atiende, esPorDefecto, desde, hasta) VALUES (0, 1, '00:00', '00:00')
INSERT INTO horarioDeAtencion (atiende, esPorDefecto, desde, hasta) VALUES (0, 1, '00:00', '00:00')
INSERT INTO diasDeAtencion(idLunes, idMartes, idMiercoles, idJueves, idViernes, idSabado, idDomingo) VALUES (8, 9, 10, 11, 12, 13, 14)
INSERT INTO profesionales (nombre, apellido, fechaNacimiento, indiceGenero, indiceNacionalidad, documento, telefono, matricula, idDiasDeAtencion, isActive) VALUES ('juan', 'dominguez', '14/12/1969 0:00:00', 1, 0, '18548584', '1154858596', '45484585', 2, 1)
INSERT INTO especialidadesProfesionales (idProfesional, idEspecialidadesCentro, isActive) VALUES (1, 2, 1)
INSERT INTO especialidadesProfesionales (idProfesional, idEspecialidadesCentro, isActive) VALUES (1, 3, 1)
INSERT INTO horarioDeAtencion (atiende, esPorDefecto, desde, hasta) VALUES (0, 1, '00:00', '00:00')
INSERT INTO horarioDeAtencion (atiende, esPorDefecto, desde, hasta) VALUES (0, 1, '00:00', '00:00')
INSERT INTO horarioDeAtencion (atiende, esPorDefecto, desde, hasta) VALUES (0, 1, '00:00', '00:00')
INSERT INTO horarioDeAtencion (atiende, esPorDefecto, desde, hasta) VALUES (0, 1, '00:00', '00:00')
INSERT INTO horarioDeAtencion (atiende, esPorDefecto, desde, hasta) VALUES (0, 1, '00:00', '00:00')
INSERT INTO horarioDeAtencion (atiende, esPorDefecto, desde, hasta) VALUES (0, 1, '00:00', '00:00')
INSERT INTO horarioDeAtencion (atiende, esPorDefecto, desde, hasta) VALUES (0, 1, '00:00', '00:00')
INSERT INTO diasDeAtencion(idLunes, idMartes, idMiercoles, idJueves, idViernes, idSabado, idDomingo) VALUES (15, 16, 17, 18, 19, 20, 21)
INSERT INTO profesionales (nombre, apellido, fechaNacimiento, indiceGenero, indiceNacionalidad, documento, telefono, matricula, idDiasDeAtencion, isActive) VALUES ('micaela', 'romano', '24/12/1968 0:00:00', 0, 0, '254785969', '154748585', '458584', 3, 1)
INSERT INTO especialidadesProfesionales (idProfesional, idEspecialidadesCentro, isActive) VALUES (2, 3, 1)
INSERT INTO pacientes (nombre, apellido, fechaNacimiento, indiceGenero, indiceNacionalidad, documento, telefono, telefonoContacto, obraSocial, numeroAfiliado, isActive) VALUES ('juan', 'perez', '10/02/2000 0:00:00', 1, 0, '42396381', '1131396060', '1131396060', 'OSPA', '', 1)
INSERT INTO pacientes (nombre, apellido, fechaNacimiento, indiceGenero, indiceNacionalidad, documento, telefono, telefonoContacto, obraSocial, numeroAfiliado, isActive) VALUES ('b�rang�re', 'kemm', '26/11/2019 0:00:00', 0, 0, '11378109', '6949612459', '6949612459', 'O.S.T.C.A.R.A.', '9204', 1)
INSERT INTO pacientes (nombre, apellido, fechaNacimiento, indiceGenero, indiceNacionalidad, documento, telefono, telefonoContacto, obraSocial, numeroAfiliado, isActive) VALUES ('na�va', 'dominguez', '03/05/1995 0:00:00', 2, 0, '17422541', '2813430955', '2813430955', 'OSSEG', '8089', 1)
INSERT INTO pacientes (nombre, apellido, fechaNacimiento, indiceGenero, indiceNacionalidad, documento, telefono, telefonoContacto, obraSocial, numeroAfiliado, isActive) VALUES ('ga�tane', 'schruyer', '02/03/1971 0:00:00', 2, 0, '29405800', '4824284522', '4824284522', 'OSSACRAOSJERA', '4271', 1)
INSERT INTO pacientes (nombre, apellido, fechaNacimiento, indiceGenero, indiceNacionalidad, documento, telefono, telefonoContacto, obraSocial, numeroAfiliado, isActive) VALUES ('est�ve', 'waison', '11/01/1999 0:00:00', 0, 0, '16676634', '4253287067', '4253287067', 'OSSACRAOSJERA', '5229', 1)
INSERT INTO pacientes (nombre, apellido, fechaNacimiento, indiceGenero, indiceNacionalidad, documento, telefono, telefonoContacto, obraSocial, numeroAfiliado, isActive) VALUES ('zh�', 'cartan', '20/02/1985 0:00:00', 0, 0, '34709116', '1179522239', '1179522239', 'OSME', '5806', 1)
INSERT INTO pacientes (nombre, apellido, fechaNacimiento, indiceGenero, indiceNacionalidad, documento, telefono, telefonoContacto, obraSocial, numeroAfiliado, isActive) VALUES ('ma�ly', 'passe', '19/03/1952 0:00:00', 0, 0, '38435838', '5179817668', '5179817668', 'OSPA', '6335', 1)
INSERT INTO pacientes (nombre, apellido, fechaNacimiento, indiceGenero, indiceNacionalidad, documento, telefono, telefonoContacto, obraSocial, numeroAfiliado, isActive) VALUES ('r�jane', 'cartmael', '10/05/1984 0:00:00', 1, 0, '40850561', '4996937453', '4996937453', 'OSAMMVC', '8745', 1)
INSERT INTO pacientes (nombre, apellido, fechaNacimiento, indiceGenero, indiceNacionalidad, documento, telefono, telefonoContacto, obraSocial, numeroAfiliado, isActive) VALUES ('torbj�rn', 'veitch', '09/05/2011 0:00:00', 3, 0, '48355419', '6019827635', '6019827635', 'FEDECAMARAS', '4702', 1)
INSERT INTO pacientes (nombre, apellido, fechaNacimiento, indiceGenero, indiceNacionalidad, documento, telefono, telefonoContacto, obraSocial, numeroAfiliado, isActive) VALUES ('lo�c', 'battersby', '03/09/1997 0:00:00', 1, 0, '31027911', '2579314480', '2579314480', 'OSPA', '4380', 1)
INSERT INTO pacientes (nombre, apellido, fechaNacimiento, indiceGenero, indiceNacionalidad, documento, telefono, telefonoContacto, obraSocial, numeroAfiliado, isActive) VALUES ('aur�lie', 'killner', '11/11/1978 0:00:00', 3, 0, '31657259', '3638006242', '3638006242', 'OSME', '9371', 1)
INSERT INTO pacientes (nombre, apellido, fechaNacimiento, indiceGenero, indiceNacionalidad, documento, telefono, telefonoContacto, obraSocial, numeroAfiliado, isActive) VALUES ('no�lla', 'mease', '23/05/1974 0:00:00', 3, 0, '37965098', '1714997116', '1714997116', 'OSPA', '6470', 1)
INSERT INTO pacientes (nombre, apellido, fechaNacimiento, indiceGenero, indiceNacionalidad, documento, telefono, telefonoContacto, obraSocial, numeroAfiliado, isActive) VALUES ('h�l�ne', 'lidgate', '21/02/2014 0:00:00', 1, 0, '13936554', '6667318276', '6667318276', 'OSFE', '9712', 1)
INSERT INTO pacientes (nombre, apellido, fechaNacimiento, indiceGenero, indiceNacionalidad, documento, telefono, telefonoContacto, obraSocial, numeroAfiliado, isActive) VALUES ('doroth�e', 'couttes', '29/12/2014 0:00:00', 3, 0, '43863443', '1566493781', '1566493781', 'OSME', '9775', 1)
INSERT INTO pacientes (nombre, apellido, fechaNacimiento, indiceGenero, indiceNacionalidad, documento, telefono, telefonoContacto, obraSocial, numeroAfiliado, isActive) VALUES ('mil�na', 'gingel', '31/12/1998 0:00:00', 3, 0, '18663414', '3552147810', '3552147810', 'OSTAMMA', '4236', 1)
INSERT INTO pacientes (nombre, apellido, fechaNacimiento, indiceGenero, indiceNacionalidad, documento, telefono, telefonoContacto, obraSocial, numeroAfiliado, isActive) VALUES ('t�ng', 'ranvoise', '20/06/1975 0:00:00', 0, 0, '18014022', '2967028488', '2967028488', 'OSPOCE', '7043', 1)
INSERT INTO pacientes (nombre, apellido, fechaNacimiento, indiceGenero, indiceNacionalidad, documento, telefono, telefonoContacto, obraSocial, numeroAfiliado, isActive) VALUES ('rach�le', 'cosson', '15/09/1954 0:00:00', 0, 0, '13447196', '9727080578', '9727080578', 'OSPESCA', '9181', 1)
INSERT INTO pacientes (nombre, apellido, fechaNacimiento, indiceGenero, indiceNacionalidad, documento, telefono, telefonoContacto, obraSocial, numeroAfiliado, isActive) VALUES ('st�phanie', 'pirnie', '18/11/1993 0:00:00', 1, 0, '30469840', '6289210712', '6289210712', 'OSMISS', '5838', 1)
INSERT INTO pacientes (nombre, apellido, fechaNacimiento, indiceGenero, indiceNacionalidad, documento, telefono, telefonoContacto, obraSocial, numeroAfiliado, isActive) VALUES ('c�lestine', 'morratt', '14/10/1978 0:00:00', 1, 0, '49241854', '1489307284', '1489307284', 'OSSACRAOSJERA', '6945', 1)
INSERT INTO pacientes (nombre, apellido, fechaNacimiento, indiceGenero, indiceNacionalidad, documento, telefono, telefonoContacto, obraSocial, numeroAfiliado, isActive) VALUES ('ru�', 'mclanachan', '23/05/2010 0:00:00', 0, 0, '42117797', '7991473851', '7991473851', 'OSTAMMA', '5972', 1)
INSERT INTO pacientes (nombre, apellido, fechaNacimiento, indiceGenero, indiceNacionalidad, documento, telefono, telefonoContacto, obraSocial, numeroAfiliado, isActive) VALUES ('kallist�', 'carding', '07/09/1989 0:00:00', 1, 0, '22767653', '4703772933', '4703772933', 'OSSEG', '5584', 1)
INSERT INTO pacientes (nombre, apellido, fechaNacimiento, indiceGenero, indiceNacionalidad, documento, telefono, telefonoContacto, obraSocial, numeroAfiliado, isActive) VALUES ('ma�t�', 'galton', '30/08/1996 0:00:00', 0, 0, '39948704', '1448563769', '1448563769', 'OSAMMVC', '8094', 1)
INSERT INTO pacientes (nombre, apellido, fechaNacimiento, indiceGenero, indiceNacionalidad, documento, telefono, telefonoContacto, obraSocial, numeroAfiliado, isActive) VALUES ('b�rje', 'kayser', '16/11/1945 0:00:00', 0, 0, '45988718', '7625729540', '7625729540', 'OSALARA', '9403', 1)
INSERT INTO pacientes (nombre, apellido, fechaNacimiento, indiceGenero, indiceNacionalidad, documento, telefono, telefonoContacto, obraSocial, numeroAfiliado, isActive) VALUES ('m�lanie', 'waldie', '23/07/1993 0:00:00', 0, 0, '14906792', '4998630810', '4998630810', 'OSSACRAOSJERA', '6595', 1)
INSERT INTO pacientes (nombre, apellido, fechaNacimiento, indiceGenero, indiceNacionalidad, documento, telefono, telefonoContacto, obraSocial, numeroAfiliado, isActive) VALUES ('illustr�e', 'viste', '01/01/1951 0:00:00', 3, 0, '12402245', '7422928388', '7422928388', 'OSPOCE', '5540', 1)
INSERT INTO pacientes (nombre, apellido, fechaNacimiento, indiceGenero, indiceNacionalidad, documento, telefono, telefonoContacto, obraSocial, numeroAfiliado, isActive) VALUES ('lo�s', 'von nassau', '20/04/1979 0:00:00', 0, 0, '21477183', '1164852536', '1164852536', 'OSPOCE', '7379', 1)
INSERT INTO pacientes (nombre, apellido, fechaNacimiento, indiceGenero, indiceNacionalidad, documento, telefono, telefonoContacto, obraSocial, numeroAfiliado, isActive) VALUES ('r�becca', 'casajuana', '15/02/1966 0:00:00', 1, 0, '42355807', '6078137825', '6078137825', 'OSPOCE', '6843', 1)
INSERT INTO pacientes (nombre, apellido, fechaNacimiento, indiceGenero, indiceNacionalidad, documento, telefono, telefonoContacto, obraSocial, numeroAfiliado, isActive) VALUES ('cr��z', 'whitechurch', '26/10/1957 0:00:00', 3, 0, '14238955', '6189219041', '6189219041', 'OSALARA', '7737', 1)
INSERT INTO pacientes (nombre, apellido, fechaNacimiento, indiceGenero, indiceNacionalidad, documento, telefono, telefonoContacto, obraSocial, numeroAfiliado, isActive) VALUES ('l�ng', 'newey', '29/01/1983 0:00:00', 2, 0, '34599737', '1886320238', '1886320238', 'OSPA', '9364', 1)
INSERT INTO pacientes (nombre, apellido, fechaNacimiento, indiceGenero, indiceNacionalidad, documento, telefono, telefonoContacto, obraSocial, numeroAfiliado, isActive) VALUES ('l�andre', 'worssam', '09/12/1982 0:00:00', 2, 0, '28412924', '7102043328', '7102043328', 'OSFE', '7743', 1)
INSERT INTO pacientes (nombre, apellido, fechaNacimiento, indiceGenero, indiceNacionalidad, documento, telefono, telefonoContacto, obraSocial, numeroAfiliado, isActive) VALUES ('ma�ly', 'klewi', '15/08/1950 0:00:00', 1, 0, '42209499', '9422490082', '9422490082', 'OSPA', '8044', 1)
INSERT INTO pacientes (nombre, apellido, fechaNacimiento, indiceGenero, indiceNacionalidad, documento, telefono, telefonoContacto, obraSocial, numeroAfiliado, isActive) VALUES ('m�diamass', 'luggar', '22/03/1974 0:00:00', 1, 0, '29087873', '3552392590', '3552392590', 'OSME', '6132', 1)
INSERT INTO pacientes (nombre, apellido, fechaNacimiento, indiceGenero, indiceNacionalidad, documento, telefono, telefonoContacto, obraSocial, numeroAfiliado, isActive) VALUES ('illustr�e', 'grinston', '07/07/1995 0:00:00', 0, 0, '33118214', '5583842367', '5583842367', 'O.S.T.C.A.R.A.', '7646', 1)
INSERT INTO pacientes (nombre, apellido, fechaNacimiento, indiceGenero, indiceNacionalidad, documento, telefono, telefonoContacto, obraSocial, numeroAfiliado, isActive) VALUES ('fr�d�rique', 'labat', '18/12/1968 0:00:00', 2, 0, '35800281', '6374603381', '6374603381', 'OSMISS', '8374', 1)
INSERT INTO pacientes (nombre, apellido, fechaNacimiento, indiceGenero, indiceNacionalidad, documento, telefono, telefonoContacto, obraSocial, numeroAfiliado, isActive) VALUES ('marie-�ve', 'macclenan', '05/01/1975 0:00:00', 1, 0, '17464886', '6184246405', '6184246405', 'OSALARA', '6612', 1)
INSERT INTO pacientes (nombre, apellido, fechaNacimiento, indiceGenero, indiceNacionalidad, documento, telefono, telefonoContacto, obraSocial, numeroAfiliado, isActive) VALUES ('r�becca', 'crich', '03/04/1949 0:00:00', 3, 0, '33646230', '4052612007', '4052612007', 'OSPROTURA', '6745', 1)
INSERT INTO pacientes (nombre, apellido, fechaNacimiento, indiceGenero, indiceNacionalidad, documento, telefono, telefonoContacto, obraSocial, numeroAfiliado, isActive) VALUES ('�ke', 'arger', '26/05/1963 0:00:00', 2, 0, '28097472', '4829645308', '4829645308', 'OSMISS', '4311', 1)
INSERT INTO pacientes (nombre, apellido, fechaNacimiento, indiceGenero, indiceNacionalidad, documento, telefono, telefonoContacto, obraSocial, numeroAfiliado, isActive) VALUES ('fran�oise', 'imbrey', '02/07/1963 0:00:00', 2, 0, '17790625', '2904661740', '2904661740', 'O.S.T.C.A.R.A.', '8626', 1)
INSERT INTO pacientes (nombre, apellido, fechaNacimiento, indiceGenero, indiceNacionalidad, documento, telefono, telefonoContacto, obraSocial, numeroAfiliado, isActive) VALUES ('laur�ne', 'farryann', '13/12/1955 0:00:00', 2, 0, '33277488', '3028040568', '3028040568', 'OSPROTURA', '8979', 1)
INSERT INTO pacientes (nombre, apellido, fechaNacimiento, indiceGenero, indiceNacionalidad, documento, telefono, telefonoContacto, obraSocial, numeroAfiliado, isActive) VALUES ('laur�lie', 'clavey', '16/10/1973 0:00:00', 0, 0, '47116503', '7629164371', '7629164371', 'OSME', '6097', 1)
INSERT INTO pacientes (nombre, apellido, fechaNacimiento, indiceGenero, indiceNacionalidad, documento, telefono, telefonoContacto, obraSocial, numeroAfiliado, isActive) VALUES ('edm�e', 'possel', '16/11/1986 0:00:00', 0, 0, '31708252', '6082900787', '6082900787', 'OSSACRAOSJERA', '9700', 1)
INSERT INTO pacientes (nombre, apellido, fechaNacimiento, indiceGenero, indiceNacionalidad, documento, telefono, telefonoContacto, obraSocial, numeroAfiliado, isActive) VALUES ('l�i', 'barkly', '03/10/1977 0:00:00', 2, 0, '32657928', '7722398672', '7722398672', 'OSSACRAOSJERA', '7032', 1)
INSERT INTO pacientes (nombre, apellido, fechaNacimiento, indiceGenero, indiceNacionalidad, documento, telefono, telefonoContacto, obraSocial, numeroAfiliado, isActive) VALUES ('t�ng', 'mebius', '02/01/1974 0:00:00', 2, 0, '30757346', '1847070996', '1847070996', 'OSSACRAOSJERA', '7567', 1)
INSERT INTO pacientes (nombre, apellido, fechaNacimiento, indiceGenero, indiceNacionalidad, documento, telefono, telefonoContacto, obraSocial, numeroAfiliado, isActive) VALUES ('na�lle', 'pumphreys', '18/04/2012 0:00:00', 2, 0, '14565800', '3123366017', '3123366017', 'OSPROTURA', '4286', 1)
INSERT INTO pacientes (nombre, apellido, fechaNacimiento, indiceGenero, indiceNacionalidad, documento, telefono, telefonoContacto, obraSocial, numeroAfiliado, isActive) VALUES ('y�', 'kobelt', '08/06/1956 0:00:00', 2, 0, '46998519', '3446791391', '3446791391', 'OSPROTURA', '8945', 1)
INSERT INTO pacientes (nombre, apellido, fechaNacimiento, indiceGenero, indiceNacionalidad, documento, telefono, telefonoContacto, obraSocial, numeroAfiliado, isActive) VALUES ('ku�', 'catcherside', '18/09/2007 0:00:00', 2, 0, '14700979', '4692641035', '4692641035', 'OSPA', '9122', 1)
INSERT INTO pacientes (nombre, apellido, fechaNacimiento, indiceGenero, indiceNacionalidad, documento, telefono, telefonoContacto, obraSocial, numeroAfiliado, isActive) VALUES ('�sa', 'petheridge', '02/05/1948 0:00:00', 3, 0, '15844973', '2807879309', '2807879309', 'FEDECAMARAS', '5305', 1)
INSERT INTO pacientes (nombre, apellido, fechaNacimiento, indiceGenero, indiceNacionalidad, documento, telefono, telefonoContacto, obraSocial, numeroAfiliado, isActive) VALUES ('�sa', 'salzberg', '20/05/2017 0:00:00', 2, 0, '42639098', '3675805682', '3675805682', 'O.S.T.C.A.R.A.', '8691', 1)
INSERT INTO pacientes (nombre, apellido, fechaNacimiento, indiceGenero, indiceNacionalidad, documento, telefono, telefonoContacto, obraSocial, numeroAfiliado, isActive) VALUES ('chlo�', 'pettko', '18/07/1992 0:00:00', 1, 0, '10781202', '4457008210', '4457008210', 'OSMISS', '4784', 1)
INSERT INTO pacientes (nombre, apellido, fechaNacimiento, indiceGenero, indiceNacionalidad, documento, telefono, telefonoContacto, obraSocial, numeroAfiliado, isActive) VALUES ('r�serv�s', 'costigan', '23/06/1945 0:00:00', 3, 0, '49645615', '7696751475', '7696751475', 'OSPOCE', '7333', 1)
INSERT INTO pacientes (nombre, apellido, fechaNacimiento, indiceGenero, indiceNacionalidad, documento, telefono, telefonoContacto, obraSocial, numeroAfiliado, isActive) VALUES ('annot�e', 'casier', '25/08/2012 0:00:00', 2, 0, '19310852', '9293056036', '9293056036', 'OSPOCE', '8667', 1)
INSERT INTO pacientes (nombre, apellido, fechaNacimiento, indiceGenero, indiceNacionalidad, documento, telefono, telefonoContacto, obraSocial, numeroAfiliado, isActive) VALUES ('illustr�e', 'ruilton', '31/10/1999 0:00:00', 2, 0, '45165505', '1212491210', '1212491210', 'OSLERA', '8616', 1)
INSERT INTO pacientes (nombre, apellido, fechaNacimiento, indiceGenero, indiceNacionalidad, documento, telefono, telefonoContacto, obraSocial, numeroAfiliado, isActive) VALUES ('m�ryl', 'jeannaud', '09/12/1947 0:00:00', 3, 0, '30607238', '2974228178', '2974228178', 'OSAMMVC', '6421', 1)
INSERT INTO pacientes (nombre, apellido, fechaNacimiento, indiceGenero, indiceNacionalidad, documento, telefono, telefonoContacto, obraSocial, numeroAfiliado, isActive) VALUES ('gis�le', 'canto', '09/03/1984 0:00:00', 0, 0, '39433077', '7322931640', '7322931640', 'OSPOCE', '8824', 1)
INSERT INTO pacientes (nombre, apellido, fechaNacimiento, indiceGenero, indiceNacionalidad, documento, telefono, telefonoContacto, obraSocial, numeroAfiliado, isActive) VALUES ('andr�a', 'gilberthorpe', '28/04/2012 0:00:00', 0, 0, '25066666', '4762451692', '4762451692', 'OSPESCA', '6893', 1)
INSERT INTO pacientes (nombre, apellido, fechaNacimiento, indiceGenero, indiceNacionalidad, documento, telefono, telefonoContacto, obraSocial, numeroAfiliado, isActive) VALUES ('val�rie', 'dcosta', '01/04/1979 0:00:00', 0, 0, '47507872', '4892376042', '4892376042', 'O.S.T.C.A.R.A.', '9496', 1)
INSERT INTO pacientes (nombre, apellido, fechaNacimiento, indiceGenero, indiceNacionalidad, documento, telefono, telefonoContacto, obraSocial, numeroAfiliado, isActive) VALUES ('t�n', 'jelks', '07/01/2014 0:00:00', 0, 0, '33606935', '8259670551', '8259670551', 'OSPA', '4723', 1)
INSERT INTO pacientes (nombre, apellido, fechaNacimiento, indiceGenero, indiceNacionalidad, documento, telefono, telefonoContacto, obraSocial, numeroAfiliado, isActive) VALUES ('d�', 'linder', '19/05/1974 0:00:00', 2, 0, '38692723', '6817986520', '6817986520', 'OSAMMVC', '4258', 1)
INSERT INTO pacientes (nombre, apellido, fechaNacimiento, indiceGenero, indiceNacionalidad, documento, telefono, telefonoContacto, obraSocial, numeroAfiliado, isActive) VALUES ('ma�line', 'dutnall', '21/11/1955 0:00:00', 1, 0, '34837548', '5522966205', '5522966205', 'OSLERA', '7613', 1)
INSERT INTO pacientes (nombre, apellido, fechaNacimiento, indiceGenero, indiceNacionalidad, documento, telefono, telefonoContacto, obraSocial, numeroAfiliado, isActive) VALUES ('v�rane', 'jiles', '18/07/2011 0:00:00', 3, 0, '22063480', '5806944866', '5806944866', 'OSLERA', '7625', 1)
INSERT INTO pacientes (nombre, apellido, fechaNacimiento, indiceGenero, indiceNacionalidad, documento, telefono, telefonoContacto, obraSocial, numeroAfiliado, isActive) VALUES ('lucr�ce', 'sandever', '05/03/2005 0:00:00', 3, 0, '45561019', '2998199611', '2998199611', 'OSPOCE', '8244', 1)
INSERT INTO pacientes (nombre, apellido, fechaNacimiento, indiceGenero, indiceNacionalidad, documento, telefono, telefonoContacto, obraSocial, numeroAfiliado, isActive) VALUES ('laur�na', 'kirsche', '27/12/1995 0:00:00', 0, 0, '30038097', '7689659382', '7689659382', 'FEDECAMARAS', '6588', 1)
INSERT INTO pacientes (nombre, apellido, fechaNacimiento, indiceGenero, indiceNacionalidad, documento, telefono, telefonoContacto, obraSocial, numeroAfiliado, isActive) VALUES ('m�thode', 'aplin', '26/07/2000 0:00:00', 3, 0, '30436977', '3698282882', '3698282882', 'OSPA', '4939', 1)
INSERT INTO pacientes (nombre, apellido, fechaNacimiento, indiceGenero, indiceNacionalidad, documento, telefono, telefonoContacto, obraSocial, numeroAfiliado, isActive) VALUES ('ma�lla', 'crannage', '30/11/1953 0:00:00', 2, 0, '48960160', '6714916343', '6714916343', 'OSPA', '6409', 1)
INSERT INTO pacientes (nombre, apellido, fechaNacimiento, indiceGenero, indiceNacionalidad, documento, telefono, telefonoContacto, obraSocial, numeroAfiliado, isActive) VALUES ('b�rang�re', 'carnock', '16/12/1954 0:00:00', 3, 0, '10441714', '8606078021', '8606078021', 'FEDECAMARAS', '5342', 1)
INSERT INTO pacientes (nombre, apellido, fechaNacimiento, indiceGenero, indiceNacionalidad, documento, telefono, telefonoContacto, obraSocial, numeroAfiliado, isActive) VALUES ('st�phanie', 'peattie', '12/06/1945 0:00:00', 0, 0, '17986140', '1223505951', '1223505951', 'OSPROTURA', '5760', 1)
INSERT INTO pacientes (nombre, apellido, fechaNacimiento, indiceGenero, indiceNacionalidad, documento, telefono, telefonoContacto, obraSocial, numeroAfiliado, isActive) VALUES ('gis�le', 'macalroy', '29/11/1988 0:00:00', 0, 0, '30662210', '9686707873', '9686707873', 'OSALARA', '7684', 1)
INSERT INTO pacientes (nombre, apellido, fechaNacimiento, indiceGenero, indiceNacionalidad, documento, telefono, telefonoContacto, obraSocial, numeroAfiliado, isActive) VALUES ('lor�ne', 'gehringer', '12/08/2001 0:00:00', 2, 0, '19871189', '9504591566', '9504591566', 'FEDECAMARAS', '5777', 1)
INSERT INTO pacientes (nombre, apellido, fechaNacimiento, indiceGenero, indiceNacionalidad, documento, telefono, telefonoContacto, obraSocial, numeroAfiliado, isActive) VALUES ('s�verine', 'baltrushaitis', '08/05/1964 0:00:00', 2, 0, '34070776', '8212231666', '8212231666', 'OSPESCA', '5224', 1)
INSERT INTO pacientes (nombre, apellido, fechaNacimiento, indiceGenero, indiceNacionalidad, documento, telefono, telefonoContacto, obraSocial, numeroAfiliado, isActive) VALUES ('ma�lle', 'robjant', '13/03/2002 0:00:00', 1, 0, '34887386', '3589995405', '3589995405', 'OSSACRAOSJERA', '4843', 1)
INSERT INTO pacientes (nombre, apellido, fechaNacimiento, indiceGenero, indiceNacionalidad, documento, telefono, telefonoContacto, obraSocial, numeroAfiliado, isActive) VALUES ('l�onie', 'hymor', '08/08/1965 0:00:00', 0, 0, '29097590', '1831886623', '1831886623', 'OSSEG', '7993', 1)
INSERT INTO pacientes (nombre, apellido, fechaNacimiento, indiceGenero, indiceNacionalidad, documento, telefono, telefonoContacto, obraSocial, numeroAfiliado, isActive) VALUES ('k�vina', 'drinkall', '19/10/1974 0:00:00', 0, 0, '11208492', '2302025072', '2302025072', 'OSPOCE', '6435', 1)
INSERT INTO pacientes (nombre, apellido, fechaNacimiento, indiceGenero, indiceNacionalidad, documento, telefono, telefonoContacto, obraSocial, numeroAfiliado, isActive) VALUES ('l�a', 'dabels', '08/03/1956 0:00:00', 2, 0, '11250647', '2557320046', '2557320046', 'OSLERA', '4869', 1)
INSERT INTO pacientes (nombre, apellido, fechaNacimiento, indiceGenero, indiceNacionalidad, documento, telefono, telefonoContacto, obraSocial, numeroAfiliado, isActive) VALUES ('salom�', 'forgan', '10/12/1967 0:00:00', 0, 0, '27713296', '7141290051', '7141290051', 'OSSEG', '6709', 1)
INSERT INTO pacientes (nombre, apellido, fechaNacimiento, indiceGenero, indiceNacionalidad, documento, telefono, telefonoContacto, obraSocial, numeroAfiliado, isActive) VALUES ('lo�ca', 'mcaster', '28/02/1996 0:00:00', 3, 0, '20272596', '3473006991', '3473006991', 'FEDECAMARAS', '5158', 1)
INSERT INTO pacientes (nombre, apellido, fechaNacimiento, indiceGenero, indiceNacionalidad, documento, telefono, telefonoContacto, obraSocial, numeroAfiliado, isActive) VALUES ('ma�ly', 'fromant', '02/02/2008 0:00:00', 0, 0, '30309913', '1898041154', '1898041154', 'OSTAMMA', '8094', 1)
INSERT INTO pacientes (nombre, apellido, fechaNacimiento, indiceGenero, indiceNacionalidad, documento, telefono, telefonoContacto, obraSocial, numeroAfiliado, isActive) VALUES ('agn�s', 'godfroy', '06/01/1963 0:00:00', 3, 0, '19742065', '4023773310', '4023773310', 'OSSACRAOSJERA', '6491', 1)
INSERT INTO pacientes (nombre, apellido, fechaNacimiento, indiceGenero, indiceNacionalidad, documento, telefono, telefonoContacto, obraSocial, numeroAfiliado, isActive) VALUES ('doroth�e', 'errett', '24/08/1998 0:00:00', 3, 0, '29912340', '4288839856', '4288839856', 'OSSACRAOSJERA', '9648', 1)
INSERT INTO pacientes (nombre, apellido, fechaNacimiento, indiceGenero, indiceNacionalidad, documento, telefono, telefonoContacto, obraSocial, numeroAfiliado, isActive) VALUES ('ma�t�', 'snowdon', '15/08/1948 0:00:00', 0, 0, '26550971', '5834553555', '5834553555', 'OSMISS', '9279', 1)
INSERT INTO pacientes (nombre, apellido, fechaNacimiento, indiceGenero, indiceNacionalidad, documento, telefono, telefonoContacto, obraSocial, numeroAfiliado, isActive) VALUES ('s�verine', 'borham', '30/06/1958 0:00:00', 3, 0, '38061921', '9889657138', '9889657138', 'OSALARA', '9274', 1)
INSERT INTO pacientes (nombre, apellido, fechaNacimiento, indiceGenero, indiceNacionalidad, documento, telefono, telefonoContacto, obraSocial, numeroAfiliado, isActive) VALUES ('in�s', 'obey', '31/05/2003 0:00:00', 0, 0, '26074191', '3231339221', '3231339221', 'OSSACRAOSJERA', '9376', 1)
INSERT INTO pacientes (nombre, apellido, fechaNacimiento, indiceGenero, indiceNacionalidad, documento, telefono, telefonoContacto, obraSocial, numeroAfiliado, isActive) VALUES ('�ke', 'mitchel', '26/10/1985 0:00:00', 0, 0, '27096386', '2895026620', '2895026620', 'OSALARA', '9073', 1)
INSERT INTO pacientes (nombre, apellido, fechaNacimiento, indiceGenero, indiceNacionalidad, documento, telefono, telefonoContacto, obraSocial, numeroAfiliado, isActive) VALUES ('ad�lie', 'veeler', '24/07/1972 0:00:00', 1, 0, '24852677', '7833301097', '7833301097', 'OSSEG', '7101', 1)
INSERT INTO pacientes (nombre, apellido, fechaNacimiento, indiceGenero, indiceNacionalidad, documento, telefono, telefonoContacto, obraSocial, numeroAfiliado, isActive) VALUES ('ru�', 'kellet', '03/09/1956 0:00:00', 2, 0, '13844205', '7816308386', '7816308386', 'OSPROTURA', '4789', 1)
INSERT INTO pacientes (nombre, apellido, fechaNacimiento, indiceGenero, indiceNacionalidad, documento, telefono, telefonoContacto, obraSocial, numeroAfiliado, isActive) VALUES ('m�lys', 'denrico', '17/09/1942 0:00:00', 0, 0, '28545622', '3633565024', '3633565024', 'OSALARA', '9983', 1)
INSERT INTO pacientes (nombre, apellido, fechaNacimiento, indiceGenero, indiceNacionalidad, documento, telefono, telefonoContacto, obraSocial, numeroAfiliado, isActive) VALUES ('b�reng�re', 'mellanby', '27/05/1961 0:00:00', 2, 0, '46235061', '2942803027', '2942803027', 'OSSEG', '7382', 1)
INSERT INTO pacientes (nombre, apellido, fechaNacimiento, indiceGenero, indiceNacionalidad, documento, telefono, telefonoContacto, obraSocial, numeroAfiliado, isActive) VALUES ('p�lagie', 'welds', '20/03/1953 0:00:00', 3, 0, '35095829', '9117991723', '9117991723', 'OSLERA', '7826', 1)
INSERT INTO pacientes (nombre, apellido, fechaNacimiento, indiceGenero, indiceNacionalidad, documento, telefono, telefonoContacto, obraSocial, numeroAfiliado, isActive) VALUES ('marl�ne', 'trenchard', '20/01/2015 0:00:00', 2, 0, '38919930', '8363572093', '8363572093', 'OSME', '8930', 1)
INSERT INTO pacientes (nombre, apellido, fechaNacimiento, indiceGenero, indiceNacionalidad, documento, telefono, telefonoContacto, obraSocial, numeroAfiliado, isActive) VALUES ('ma�lis', 'mckeaney', '28/05/1997 0:00:00', 0, 0, '27390283', '8679095537', '8679095537', 'OSSACRAOSJERA', '7467', 1)
INSERT INTO pacientes (nombre, apellido, fechaNacimiento, indiceGenero, indiceNacionalidad, documento, telefono, telefonoContacto, obraSocial, numeroAfiliado, isActive) VALUES ('ang�lique', 'duley', '07/11/1987 0:00:00', 0, 0, '43327616', '8903931894', '8903931894', 'OSME', '7657', 1)
INSERT INTO pacientes (nombre, apellido, fechaNacimiento, indiceGenero, indiceNacionalidad, documento, telefono, telefonoContacto, obraSocial, numeroAfiliado, isActive) VALUES ('ang�lique', 'blundan', '24/04/2017 0:00:00', 2, 0, '16918971', '9428921803', '9428921803', 'OSALARA', '4877', 1)
INSERT INTO pacientes (nombre, apellido, fechaNacimiento, indiceGenero, indiceNacionalidad, documento, telefono, telefonoContacto, obraSocial, numeroAfiliado, isActive) VALUES ('�sa', 'gauford', '24/05/1964 0:00:00', 2, 0, '36559293', '1455236930', '1455236930', 'OSPROTURA', '6012', 1)
INSERT INTO pacientes (nombre, apellido, fechaNacimiento, indiceGenero, indiceNacionalidad, documento, telefono, telefonoContacto, obraSocial, numeroAfiliado, isActive) VALUES ('oph�lie', 'farebrother', '09/08/1986 0:00:00', 1, 0, '38514397', '3985655812', '3985655812', 'OSPROTURA', '9157', 1)
INSERT INTO pacientes (nombre, apellido, fechaNacimiento, indiceGenero, indiceNacionalidad, documento, telefono, telefonoContacto, obraSocial, numeroAfiliado, isActive) VALUES ('marief ran�oise', 'greenroad', '13/03/1993 0:00:00', 0, 0, '43818174', '2432574170', '2432574170', 'OSSEG', '5291', 1)
INSERT INTO turnos (idPaciente, idProfesional, idEspecialidad, fecha, pacienteAsistio) VALUES (4, 1, 1, '20/06/2022 14:00:00', 0)
INSERT INTO horarioDeAtencion (atiende, esPorDefecto, desde, hasta) VALUES (1, 0, '08:00', '20:00')
INSERT INTO horarioDeAtencion (atiende, esPorDefecto, desde, hasta) VALUES (1, 0, '08:00', '20:00')
INSERT INTO horarioDeAtencion (atiende, esPorDefecto, desde, hasta) VALUES (1, 0, '08:00', '20:00')
INSERT INTO horarioDeAtencion (atiende, esPorDefecto, desde, hasta) VALUES (1, 0, '08:00', '20:00')
INSERT INTO horarioDeAtencion (atiende, esPorDefecto, desde, hasta) VALUES (1, 0, '08:00', '20:00')
INSERT INTO horarioDeAtencion (atiende, esPorDefecto, desde, hasta) VALUES (1, 0, '08:00', '13:30')
INSERT INTO horarioDeAtencion (atiende, esPorDefecto, desde, hasta) VALUES (1, 0, '08:00', '13:30')
INSERT INTO diasDeAtencion(idLunes, idMartes, idMiercoles, idJueves, idViernes, idSabado, idDomingo) VALUES (1, 2, 3, 4, 5, 6, 7)
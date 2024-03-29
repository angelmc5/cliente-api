USE [master]
GO
/****** Object:  Database [AppApi]    Script Date: 6/2/2024 23:27:40 ******/
CREATE DATABASE [AppApi]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'AppApi', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\AppApi.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'AppApi_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\AppApi_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [AppApi] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AppApi].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [AppApi] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [AppApi] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [AppApi] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [AppApi] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [AppApi] SET ARITHABORT OFF 
GO
ALTER DATABASE [AppApi] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [AppApi] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [AppApi] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [AppApi] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [AppApi] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [AppApi] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [AppApi] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [AppApi] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [AppApi] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [AppApi] SET  ENABLE_BROKER 
GO
ALTER DATABASE [AppApi] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [AppApi] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [AppApi] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [AppApi] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [AppApi] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [AppApi] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [AppApi] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [AppApi] SET RECOVERY FULL 
GO
ALTER DATABASE [AppApi] SET  MULTI_USER 
GO
ALTER DATABASE [AppApi] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [AppApi] SET DB_CHAINING OFF 
GO
ALTER DATABASE [AppApi] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [AppApi] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [AppApi] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [AppApi] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'AppApi', N'ON'
GO
ALTER DATABASE [AppApi] SET QUERY_STORE = ON
GO
ALTER DATABASE [AppApi] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [AppApi]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 6/2/2024 23:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cuenta]    Script Date: 6/2/2024 23:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cuenta](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Numero] [nvarchar](max) NOT NULL,
	[Tipo] [nvarchar](max) NOT NULL,
	[Saldo] [real] NOT NULL,
	[Estado] [bit] NOT NULL,
	[ClienteId] [int] NOT NULL,
 CONSTRAINT [PK_Cuenta] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Movimiento]    Script Date: 6/2/2024 23:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movimiento](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Fecha] [datetime2](7) NOT NULL,
	[TipoMovimiento] [int] NOT NULL,
	[Valor] [real] NOT NULL,
	[Saldo] [real] NOT NULL,
	[cuentaId] [int] NOT NULL,
 CONSTRAINT [PK_Movimiento] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Persona]    Script Date: 6/2/2024 23:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Persona](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](max) NOT NULL,
	[Genero] [nvarchar](max) NOT NULL,
	[Edad] [int] NOT NULL,
	[Identificacion] [nvarchar](max) NOT NULL,
	[Direccion] [nvarchar](max) NOT NULL,
	[Telefono] [nvarchar](max) NOT NULL,
	[Discriminator] [nvarchar](8) NOT NULL,
	[Contrasena] [nvarchar](max) NULL,
	[Estado] [bit] NULL,
 CONSTRAINT [PK_Persona] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240204043025_CrearCliente', N'8.0.1')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240205020507_CrearCuentaMovimiento', N'8.0.1')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240206005438_CrearMovimientos', N'8.0.1')
GO
SET IDENTITY_INSERT [dbo].[Cuenta] ON 

INSERT [dbo].[Cuenta] ([Id], [Numero], [Tipo], [Saldo], [Estado], [ClienteId]) VALUES (1, N'10101020', N'Ahorros', 200, 1, 1)
INSERT [dbo].[Cuenta] ([Id], [Numero], [Tipo], [Saldo], [Estado], [ClienteId]) VALUES (2, N'10101010', N'Ahorros', 20, 1, 1)
INSERT [dbo].[Cuenta] ([Id], [Numero], [Tipo], [Saldo], [Estado], [ClienteId]) VALUES (3, N'478758', N'Ahorros', 1425, 1, 4)
INSERT [dbo].[Cuenta] ([Id], [Numero], [Tipo], [Saldo], [Estado], [ClienteId]) VALUES (4, N'225487', N'Corriente', 700, 1, 5)
INSERT [dbo].[Cuenta] ([Id], [Numero], [Tipo], [Saldo], [Estado], [ClienteId]) VALUES (5, N'495878', N'Ahorros', 150, 1, 6)
INSERT [dbo].[Cuenta] ([Id], [Numero], [Tipo], [Saldo], [Estado], [ClienteId]) VALUES (6, N'496825', N'Ahorros', 0, 1, 5)
INSERT [dbo].[Cuenta] ([Id], [Numero], [Tipo], [Saldo], [Estado], [ClienteId]) VALUES (7, N'585545', N'Corriente', 1000, 1, 4)
SET IDENTITY_INSERT [dbo].[Cuenta] OFF
GO
SET IDENTITY_INSERT [dbo].[Movimiento] ON 

INSERT [dbo].[Movimiento] ([Id], [Fecha], [TipoMovimiento], [Valor], [Saldo], [cuentaId]) VALUES (5, CAST(N'2024-02-05T20:46:21.2660770' AS DateTime2), 0, 10, 190, 1)
INSERT [dbo].[Movimiento] ([Id], [Fecha], [TipoMovimiento], [Valor], [Saldo], [cuentaId]) VALUES (6, CAST(N'2024-02-05T20:47:19.0246017' AS DateTime2), 0, 10, 200, 1)
INSERT [dbo].[Movimiento] ([Id], [Fecha], [TipoMovimiento], [Valor], [Saldo], [cuentaId]) VALUES (7, CAST(N'2024-02-05T20:47:46.0775285' AS DateTime2), 1, -10, 210, 1)
INSERT [dbo].[Movimiento] ([Id], [Fecha], [TipoMovimiento], [Valor], [Saldo], [cuentaId]) VALUES (8, CAST(N'2024-02-05T20:48:17.9014813' AS DateTime2), 0, 10, 0, 2)
INSERT [dbo].[Movimiento] ([Id], [Fecha], [TipoMovimiento], [Valor], [Saldo], [cuentaId]) VALUES (9, CAST(N'2024-02-06T01:45:54.5696465' AS DateTime2), 0, 10, 10, 2)
INSERT [dbo].[Movimiento] ([Id], [Fecha], [TipoMovimiento], [Valor], [Saldo], [cuentaId]) VALUES (11, CAST(N'2024-02-06T14:53:58.9770224' AS DateTime2), 1, -575, 2000, 3)
INSERT [dbo].[Movimiento] ([Id], [Fecha], [TipoMovimiento], [Valor], [Saldo], [cuentaId]) VALUES (12, CAST(N'2024-02-06T15:03:48.1512620' AS DateTime2), 0, 600, 100, 4)
INSERT [dbo].[Movimiento] ([Id], [Fecha], [TipoMovimiento], [Valor], [Saldo], [cuentaId]) VALUES (13, CAST(N'2024-02-06T15:05:21.2029956' AS DateTime2), 0, 150, 0, 5)
INSERT [dbo].[Movimiento] ([Id], [Fecha], [TipoMovimiento], [Valor], [Saldo], [cuentaId]) VALUES (14, CAST(N'2024-02-06T15:07:52.2732705' AS DateTime2), 1, -540, 540, 6)
SET IDENTITY_INSERT [dbo].[Movimiento] OFF
GO
SET IDENTITY_INSERT [dbo].[Persona] ON 

INSERT [dbo].[Persona] ([Id], [Nombre], [Genero], [Edad], [Identificacion], [Direccion], [Telefono], [Discriminator], [Contrasena], [Estado]) VALUES (1, N'Angel Morocho', N'M', 44, N'0705337889', N'El Batan n34-41 y Eloy Alfaro', N'0982668859', N'Cliente', N'test123456', 1)
INSERT [dbo].[Persona] ([Id], [Nombre], [Genero], [Edad], [Identificacion], [Direccion], [Telefono], [Discriminator], [Contrasena], [Estado]) VALUES (2, N'Carmen Cuenca', N'F', 45, N'0705447889', N'NA', N'0983337746', N'Cliente', N'test1', 1)
INSERT [dbo].[Persona] ([Id], [Nombre], [Genero], [Edad], [Identificacion], [Direccion], [Telefono], [Discriminator], [Contrasena], [Estado]) VALUES (3, N'Jose Mejia', N'M', 30, N'07053378890001', N'Shiris y Suecia', N'0983336737', N'Cliente', N'test123', 1)
INSERT [dbo].[Persona] ([Id], [Nombre], [Genero], [Edad], [Identificacion], [Direccion], [Telefono], [Discriminator], [Contrasena], [Estado]) VALUES (4, N'Jose Lema', N'M', 30, N'0705337881', N'Otavalo sn y principal', N'098254785', N'Cliente', N'1234', 1)
INSERT [dbo].[Persona] ([Id], [Nombre], [Genero], [Edad], [Identificacion], [Direccion], [Telefono], [Discriminator], [Contrasena], [Estado]) VALUES (5, N'Marianela Montalvo', N'F', 20, N'0705223661', N'Amazonas y NNUU', N'097548965', N'Cliente', N'5678', 1)
INSERT [dbo].[Persona] ([Id], [Nombre], [Genero], [Edad], [Identificacion], [Direccion], [Telefono], [Discriminator], [Contrasena], [Estado]) VALUES (6, N'Juan Osorio', N'M', 20, N'0543212332', N'13 junio y Equinoccial', N'098874587', N'Cliente', N'1245', 1)
SET IDENTITY_INSERT [dbo].[Persona] OFF
GO
/****** Object:  Index [IX_Movimiento_cuentaId]    Script Date: 6/2/2024 23:27:40 ******/
CREATE NONCLUSTERED INDEX [IX_Movimiento_cuentaId] ON [dbo].[Movimiento]
(
	[cuentaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Movimiento]  WITH CHECK ADD  CONSTRAINT [FK_Movimiento_Cuenta_cuentaId] FOREIGN KEY([cuentaId])
REFERENCES [dbo].[Cuenta] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Movimiento] CHECK CONSTRAINT [FK_Movimiento_Cuenta_cuentaId]
GO
USE [master]
GO
ALTER DATABASE [AppApi] SET  READ_WRITE 
GO

CREATE DATABASE BaseDatos;

USE [BaseDatos]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 11/30/2022 5:11:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NombrePersona] [varchar](50) NULL,
	[GeneroPersona] [varchar](50) NULL,
	[DireccionPersona] [varchar](50) NULL,
	[EdadPersona] [int] NULL,
	[EstadoCliente] [varchar](5) NULL,
	[IdentificacionPersona] [varchar](50) NULL,
	[TelefonoPersona] [varchar](50) NULL,
	[PassCliente] [varchar](50) NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cuentas]    Script Date: 11/30/2022 5:11:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cuentas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NumeroCuenta] [varchar](50) NULL,
	[TipoCuenta] [varchar](50) NULL,
	[SaldoInicial] [int] NULL,
	[EstadoCuenta] [varchar](5) NULL,
	[ClienteId] [int] NOT NULL,
 CONSTRAINT [PK_Cuentas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Movimientos]    Script Date: 11/30/2022 5:11:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movimientos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FechaMovimiento] [date] NULL,
	[TipoMovimiento] [varchar](50) NULL,
	[ValorMovimiento] [int] NULL,
	[SaldoMovimiento] [int] NULL,
	[NumeroCuenta] [nvarchar](50) NULL,
	[TipoCuenta] [nvarchar](50) NULL,
	[SaldoInicial] [int] NULL,
	[EstadoCuenta] [nvarchar](5) NULL,
 CONSTRAINT [PK_Movimientos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

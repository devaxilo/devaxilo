USE [Devaxilo]
GO
/****** Object:  Table [dbo].[KetQuaXoSoMienBac]    Script Date: 01/07/2018 21:14:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KetQuaXoSoMienBac](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[G0] [nvarchar](10) NULL,
	[G1] [nvarchar](10) NULL,
	[G21] [nvarchar](10) NULL,
	[G22] [nvarchar](10) NULL,
	[G31] [nvarchar](10) NULL,
	[G32] [nvarchar](10) NULL,
	[G33] [nvarchar](10) NULL,
	[G34] [nvarchar](10) NULL,
	[G35] [nvarchar](10) NULL,
	[G36] [nvarchar](10) NULL,
	[G41] [nvarchar](10) NULL,
	[G42] [nvarchar](10) NULL,
	[G43] [nvarchar](10) NULL,
	[G44] [nvarchar](10) NULL,
	[G51] [nvarchar](10) NULL,
	[G52] [nvarchar](10) NULL,
	[G53] [nvarchar](10) NULL,
	[G54] [nvarchar](10) NULL,
	[G55] [nvarchar](10) NULL,
	[G56] [nvarchar](10) NULL,
	[G61] [nvarchar](10) NULL,
	[G62] [nvarchar](10) NULL,
	[G63] [nvarchar](10) NULL,
	[G71] [nvarchar](10) NULL,
	[G72] [nvarchar](10) NULL,
	[G73] [nvarchar](10) NULL,
	[G74] [nvarchar](10) NULL,
	[LoCuoi] [nvarchar](100) NULL,
	[De] [nvarchar](10) NULL,
 CONSTRAINT [PK_KetQuaXoSoMienBac] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[KetQuaXoSoMienBac] ON
INSERT [dbo].[KetQuaXoSoMienBac] ([Id], [CreatedDate], [G0], [G1], [G21], [G22], [G31], [G32], [G33], [G34], [G35], [G36], [G41], [G42], [G43], [G44], [G51], [G52], [G53], [G54], [G55], [G56], [G61], [G62], [G63], [G71], [G72], [G73], [G74], [LoCuoi], [De]) VALUES (1, CAST(0x0000A86100000000 AS DateTime), N'13957', N'71291', N'43584', N'94421', N'56877', N'88880', N'15970', N'56482', N'53768', N'52763', N'0280', N'7793', N'5600', N'8222', N'7849', N'8392', N'2153', N'7150', N'9946', N'1763', N'689', N'904', N'820', N'42', N'29', N'08', N'78', N'57|91|84|21|77|80|70|82|68|63|80|93|00|22|49|92|53|50|46|63|89|04|20|42|29|08|78|', N'57')
SET IDENTITY_INSERT [dbo].[KetQuaXoSoMienBac] OFF
/****** Object:  Table [dbo].[AccountLogin]    Script Date: 01/07/2018 21:14:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccountLogin](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AccId] [int] NOT NULL,
	[HashLoginCode] [nvarchar](100) NOT NULL,
	[ExpiredAt] [datetime] NOT NULL,
 CONSTRAINT [PK_AccountLogin] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 01/07/2018 21:14:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Account](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UUID] [uniqueidentifier] NOT NULL,
	[FullName] [nvarchar](100) NULL,
	[Email] [varchar](100) NOT NULL,
	[HashPassword] [nvarchar](50) NULL,
	[CreatedAt] [datetime] NOT NULL,
	[Status] [tinyint] NOT NULL,
	[EnableTransferAuthen] [bit] NOT NULL,
	[ActivateCode] [nvarchar](50) NULL,
	[NickName] [nvarchar](20) NULL,
	[Phone] [nvarchar](20) NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO

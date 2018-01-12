USE [Devaxilo]
GO
/****** Object:  Table [dbo].[ManageWalletInfo]    Script Date: 01/11/2018 22:47:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ManageWalletInfo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[HashInfo] [nvarchar](500) NULL,
	[DataType] [int] NULL,
 CONSTRAINT [PK_ManageWalletInfo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KetQuaXoSoMienBac]    Script Date: 01/11/2018 22:47:16 ******/
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
INSERT [dbo].[KetQuaXoSoMienBac] ([Id], [CreatedDate], [G0], [G1], [G21], [G22], [G31], [G32], [G33], [G34], [G35], [G36], [G41], [G42], [G43], [G44], [G51], [G52], [G53], [G54], [G55], [G56], [G61], [G62], [G63], [G71], [G72], [G73], [G74], [LoCuoi], [De]) VALUES (2, CAST(0x0000A86200000000 AS DateTime), N'79708', N'95955', N'13054', N'85850', N'70232', N'52809', N'50542', N'00493', N'24973', N'06079', N'7310', N'8360', N'7553', N'4681', N'2390', N'1907', N'6737', N'5248', N'9032', N'3108', N'117', N'693', N'213', N'85', N'63', N'53', N'36', N'08|55|54|50|32|09|42|93|73|79|10|60|53|81|90|07|37|48|32|08|17|93|13|85|63|53|36|', N'08')
INSERT [dbo].[KetQuaXoSoMienBac] ([Id], [CreatedDate], [G0], [G1], [G21], [G22], [G31], [G32], [G33], [G34], [G35], [G36], [G41], [G42], [G43], [G44], [G51], [G52], [G53], [G54], [G55], [G56], [G61], [G62], [G63], [G71], [G72], [G73], [G74], [LoCuoi], [De]) VALUES (3, CAST(0x0000A86500000000 AS DateTime), N'88149', N'20508', N'61872', N'45785', N'71055', N'20120', N'24052', N'34290', N'85185', N'24538', N'0120', N'1273', N'4303', N'6274', N'7176', N'9839', N'5585', N'9311', N'3314', N'1977', N'306', N'647', N'616', N'26', N'07', N'93', N'86', N'49|08|72|85|55|20|52|90|85|38|20|73|03|74|76|39|85|11|14|77|06|47|16|26|07|93|86|', N'49')
SET IDENTITY_INSERT [dbo].[KetQuaXoSoMienBac] OFF
/****** Object:  Table [dbo].[AccountLogin]    Script Date: 01/11/2018 22:47:16 ******/
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
/****** Object:  Table [dbo].[Account]    Script Date: 01/11/2018 22:47:16 ******/
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
	[HashPassword] [nvarchar](100) NULL,
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

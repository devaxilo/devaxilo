SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[AccountBalance](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AccId] [int] NOT NULL,
	[Balance] [money] NOT NULL,
	[HoldBalance] [money] NOT NULL,
	[Status] [tinyint] NOT NULL,
 CONSTRAINT [PK_AccountBalance] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[LotteryTransaction](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UUID] [uniqueidentifier] NOT NULL,
	[UserId] [int] NOT NULL,
	[ParentId] [int] NULL,
	[Amount] [money] NOT NULL,
	[LotteryNumber] [tinyint] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[FinishedAt] [datetime] NULL,
	[LotteryType] [tinyint] NOT NULL,
	[WalletType] [tinyint] NOT NULL,
	[TransactionType] [tinyint] NOT NULL,
	[Status] [tinyint] NOT NULL,
 CONSTRAINT [PK_LotteryTransaction] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
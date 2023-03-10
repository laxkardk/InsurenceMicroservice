USE [CustomerPolicyDB]
GO
/****** Object:  Table [dbo].[CustomerPolicy]    Script Date: 2/20/2023 4:32:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerPolicy](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[PolicyId] [numeric](18, 0) NOT NULL,
	[Duration] [nvarchar](50) NULL,
	[isActive] [bit] NOT NULL,
	[Bonus] [numeric](18, 0) NULL,
	[MaturityDate] [datetime] NULL,
	[PolicyDescription] [nvarchar](max) NULL,
	[PolicyType] [nvarchar](50) NULL,
	[PolicyAmount] [numeric](18, 0) NOT NULL,
	[MaturityAmount] [numeric](18, 0) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[CustomerPolicy] ADD  DEFAULT ((1)) FOR [isActive]
GO

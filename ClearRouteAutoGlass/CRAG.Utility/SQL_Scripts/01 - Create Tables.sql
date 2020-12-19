USE [CRAG]
GO

ALTER TABLE [dbo].[Brands] DROP CONSTRAINT [DF_Brands_LastUpdateDate]
GO

ALTER TABLE [dbo].[Brands] DROP CONSTRAINT [DF_Brands_CreationDate]
GO

ALTER TABLE [dbo].[Brands] DROP CONSTRAINT [DF_Brands_UpdatedBy]
GO

ALTER TABLE [dbo].[Brands] DROP CONSTRAINT [DF_Brands_CreatedBy]
GO

/****** Object:  Table [dbo].[Brands]    Script Date: 12/18/2020 9:22:53 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Brands]') AND type in (N'U'))
DROP TABLE [dbo].[Brands]
GO

/****** Object:  Table [dbo].[Brands]    Script Date: 12/18/2020 9:22:53 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Brands](
	[BrandId] [int] IDENTITY(1,1) NOT NULL,
	[BrandName] [nvarchar](50) NULL,
	[CreatedBy] [varchar](100) NULL,
	[UpdatedBy] [varchar](100) NULL,
	[CreationDate] [datetime] NOT NULL,
	[LastUpdateDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Brands] PRIMARY KEY CLUSTERED 
(
	[BrandId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Brands] ADD  CONSTRAINT [DF_Brands_CreatedBy]  DEFAULT ('Anonymous') FOR [CreatedBy]
GO

ALTER TABLE [dbo].[Brands] ADD  CONSTRAINT [DF_Brands_UpdatedBy]  DEFAULT ('Anonymous') FOR [UpdatedBy]
GO

ALTER TABLE [dbo].[Brands] ADD  CONSTRAINT [DF_Brands_CreationDate]  DEFAULT (getdate()) FOR [CreationDate]
GO

ALTER TABLE [dbo].[Brands] ADD  CONSTRAINT [DF_Brands_LastUpdateDate]  DEFAULT (getdate()) FOR [LastUpdateDate]
GO



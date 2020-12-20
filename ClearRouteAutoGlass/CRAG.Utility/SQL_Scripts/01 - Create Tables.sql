USE [CRAG]
GO

--- Entity :  WorkOrderStatuses
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[WorkOrderStatuses]') AND type in (N'U'))
BEGIN
  ALTER TABLE [dbo].[WorkOrderStatuses] DROP CONSTRAINT [DF_WorkOrderStatuses_LastUpdateDate]
  ALTER TABLE [dbo].[WorkOrderStatuses] DROP CONSTRAINT [DF_WorkOrderStatuses_CreationDate]
  ALTER TABLE [dbo].[WorkOrderStatuses] DROP CONSTRAINT [DF_WorkOrderStatuses_UpdatedBy]
  ALTER TABLE [dbo].[WorkOrderStatuses] DROP CONSTRAINT [DF_WorkOrderStatuses_CreatedBy]
END
GO
DROP TABLE IF EXISTS [dbo].[WorkOrderStatuses]
GO
CREATE TABLE dbo.WorkOrderStatuses
(
	[WorkOrderStatusId]      INT IDENTITY(1,1)   NOT NULL,
	[WorkOrderStatusName]    VARCHAR     (50)    NOT NULL,
	[CreatedBy]        VARCHAR     (100)   NOT NULL,
	[UpdatedBy]        VARCHAR     (100)   NOT NULL,
	[CreationDate]     DATETIME            NOT NULL,
	[LastUpdateDate]   DATETIME            NOT NULL,
 CONSTRAINT [PK_WorkOrderStatuses] PRIMARY KEY CLUSTERED 
(
	[WorkOrderStatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[WorkOrderStatuses] ADD  CONSTRAINT [DF_WorkOrderStatuses_CreatedBy]  DEFAULT ('Anonymous') FOR [CreatedBy]
GO
ALTER TABLE [dbo].[WorkOrderStatuses] ADD  CONSTRAINT [DF_WorkOrderStatuses_UpdatedBy]  DEFAULT ('Anonymous') FOR [UpdatedBy]
GO
ALTER TABLE [dbo].[WorkOrderStatuses] ADD  CONSTRAINT [DF_WorkOrderStatuses_CreationDate]  DEFAULT (getdate()) FOR [CreationDate]
GO
ALTER TABLE [dbo].[WorkOrderStatuses] ADD  CONSTRAINT [DF_WorkOrderStatuses_LastUpdateDate]  DEFAULT (getdate()) FOR [LastUpdateDate]
GO

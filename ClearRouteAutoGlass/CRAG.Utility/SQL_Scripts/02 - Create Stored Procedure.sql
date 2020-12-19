USE [CRAG]
GO

----  Entity : Brands ( Drops Stored Procedure  )  
DROP PROCEDURE IF EXISTS [dbo].[Brands_AddNew]
GO
DROP PROCEDURE IF EXISTS [dbo].[Brands_Delete]
GO
DROP PROCEDURE IF EXISTS [dbo].[Brands_GetAll]
GO
DROP PROCEDURE IF EXISTS [dbo].[Brands_Update]
GO

DROP PROCEDURE IF EXISTS [dbo].[Brands_GetById]
GO


----  Entity : Brands ( Create Stored Procedure  ) 
CREATE PROCEDURE  [dbo].[Brands_AddNew]
   @BrandName   nvarchar(150)
  ,@user        varchar(150)
AS 
  INSERT INTO dbo.Brands
    ( BrandName 
	 ,CreatedBy 
	 ,UpdatedBy)
  VALUES
    ( @BrandName
	 ,@user
	 ,@user)

  --  Returns the inserted Id
  RETURN CAST(scope_identity() AS int)
GO

CREATE PROCEDURE  [dbo].[Brands_Delete]
   @Id   INT
AS 

--  Deletes the 
DELETE  [dbo].[Brands] WHERE [BrandId] = @Id  

SELECT @@ROWCOUNT
GO

CREATE PROCEDURE [dbo].[Brands_GetAll]
AS 

SELECT [BrandId]
      ,[BrandName]
      ,[CreatedBy]
      ,[UpdatedBy]
      ,[CreationDate]
      ,[LastUpdateDate]
  FROM [Brands]
GO

CREATE PROCEDURE  [dbo].[Brands_Update]
   @BarandID    nvarchar(20)
  ,@BrandName nvarchar(150)
  ,@user        varchar(150)
AS 


UPDATE  [dbo].[Brands]
SET  
    [BrandName]  = @BrandName
   ,UpdatedBy    = @user
   ,CreationDate = GETDATE()
WHERE
   [BrandId] = @BarandID 
return @BarandID
GO

CREATE PROCEDURE  [dbo].[Brands_GetById]
   @BarandID    nvarchar(20)
AS 
SELECT 
       [BrandId]
      ,[BrandName]
      ,[CreatedBy]
      ,[UpdatedBy]
      ,[CreationDate]
      ,[LastUpdateDate]
FROM 
   [dbo].[Brands]
WHERE
   [BrandId] = @BarandID
GO
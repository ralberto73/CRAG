USE CRAG
GO

----  Entity : Brands ( Drops Stored Procedure  )  
DROP PROCEDURE IF EXISTS dbo.Brands_AddNew
GO
DROP PROCEDURE IF EXISTS dbo.Brands_Delete
GO
DROP PROCEDURE IF EXISTS dbo.Brands_GetAll
GO
DROP PROCEDURE IF EXISTS dbo.Brands_Update
GO

DROP PROCEDURE IF EXISTS dbo.Brands_GetById
GO


----  Entity : Brands ( Create Stored Procedure  ) 

CREATE PROCEDURE  dbo.Brands_AddNew
   @BrandName   NVARCHAR(50)
  ,@user        VARCHAR(100)
AS 
  INSERT INTO dbo.Brands
    ( BrandName 
	 ,CreatedBy 
	 ,UpdatedBy)
  VALUES
    ( @BrandName
	 ,@user
	 ,@user)

  SELECT  CAST(scope_identity() AS int)
GO

CREATE PROCEDURE  dbo.Brands_Delete
   @id  INT
AS 
  DELETE  dbo.Brands WHERE BrandId = @id 
  SELECT @@ROWCOUNT
GO

CREATE PROCEDURE dbo.Brands_GetAll
AS 
    SELECT 
		BrandId
	   ,BrandName
	   ,CreatedBy
	   ,UpdatedBy
	   ,CreationDate
	   ,LastUpdateDate
	FROM 
		Brands
GO

CREATE PROCEDURE  dbo.Brands_Update
   @id         INT
  ,@BrandName  NVARCHAR(50)
  ,@user       VARCHAR(100)
AS 
  UPDATE  dbo.Brands
  SET  
	 BrandName  = @BrandName
	,UpdatedBy  = @user
	   ,CreationDate = GETDATE()
  WHERE
	   BrandId = @Id

  SELECT CAST( @@ROWCOUNT AS int)
GO

CREATE PROCEDURE  dbo.Brands_GetById
   @id   INT
AS 
SELECT 
       BrandId
      ,BrandName
      ,CreatedBy
      ,UpdatedBy
      ,CreationDate
      ,LastUpdateDate
FROM 
   dbo.Brands
WHERE
   BrandId = @Id
GO

USE CRAG
GO

----  Entity : Insurances ( Drops Stored Procedure  )  
DROP PROCEDURE IF EXISTS dbo.Insurances_AddNew
GO
DROP PROCEDURE IF EXISTS dbo.Insurances_Delete
GO
DROP PROCEDURE IF EXISTS dbo.Insurances_GetAll
GO
DROP PROCEDURE IF EXISTS dbo.Insurances_Update
GO

DROP PROCEDURE IF EXISTS dbo.Insurances_GetById
GO


----  Entity : Insurances ( Create Stored Procedure  ) 

CREATE PROCEDURE  dbo.Insurances_AddNew
   @InsuranceName   NVARCHAR(50)
  ,@user        VARCHAR(100)
AS 
  INSERT INTO dbo.Insurances
    ( InsuranceName 
	 ,CreatedBy 
	 ,UpdatedBy)
  VALUES
    ( @InsuranceName
	 ,@user
	 ,@user)

  SELECT  CAST(scope_identity() AS int)
GO

CREATE PROCEDURE  dbo.Insurances_Delete
   @id  INT
AS 
  DELETE  dbo.Insurances WHERE InsuranceId = @id 
  SELECT @@ROWCOUNT
GO

CREATE PROCEDURE dbo.Insurances_GetAll
AS 
    SELECT 
		InsuranceId
	   ,InsuranceName
	   ,CreatedBy
	   ,UpdatedBy
	   ,CreationDate
	   ,LastUpdateDate
	FROM 
		Insurances
GO

CREATE PROCEDURE  dbo.Insurances_Update
   @id         INT
  ,@InsuranceName  NVARCHAR(50)
  ,@user       VARCHAR(100)
AS 
  UPDATE  dbo.Insurances
  SET  
	 InsuranceName  = @InsuranceName
	,UpdatedBy  = @user
	   ,CreationDate = GETDATE()
  WHERE
	   InsuranceId = @Id

  SELECT CAST( @@ROWCOUNT AS int)
GO

CREATE PROCEDURE  dbo.Insurances_GetById
   @id   INT
AS 
SELECT 
       InsuranceId
      ,InsuranceName
      ,CreatedBy
      ,UpdatedBy
      ,CreationDate
      ,LastUpdateDate
FROM 
   dbo.Insurances
WHERE
   InsuranceId = @Id
GO


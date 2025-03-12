USE [OrderSystem]
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertUpdate_MenuMaster]    Script Date: 03-05-2023 09:46:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER  PROCEDURE [dbo].[sp_InsertUpdate_MenuMaster] (
			@Id int,
			@Name varchar(128),
			@Icon varchar(256),
			@IsActive bit,
			@Path varchar(128),
			@UserId int
			)
AS
  BEGIN
	IF NOT EXISTS (Select Id FROM MenuMaster m WHERE m.Id=@Id)
		BEGIN
           INSERT INTO [dbo].[MenuMaster]
           (
			[Name]
           ,[Icon]
           ,[IsActive]
           ,[Path]
           ,[CreatedDate]
           ,[CreatedBy]
           )
     VALUES
           (
		   @Name,
		   @Icon,
		   @IsActive,
		   @Path,
		   GETDATE(),
		   @UserId
		   )
		  end;
	else IF EXISTS (Select Id FROM MenuMaster m WHERE m.Id=@Id)
	begin
		UPDATE MenuMaster
            SET	   	
				   Name = @Name,
				   Icon = @Icon,
                   IsActive = @IsActive,
				   Path = @Path,
				   UpdatedDate = GETDATE(),
				   UpdatedBy = @UserId 
            WHERE  Id = @Id
	end
 END;

 --select * from MenuMaster
 --exec sp_InsertUpdate_MenuMaster 0,'Rishit',start,1,errt,0
 
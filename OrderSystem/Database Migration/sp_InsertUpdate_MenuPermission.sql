USE [OrderSystem]
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertUpdate_MenuPermission]    Script Date: 02-05-2023 15:12:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_InsertUpdate_MenuPermission] (
			@PermissionId int,
			@MenuId int,
			@UserId int
			)
AS
  BEGIN
	IF NOT EXISTS (Select PermissionId FROM MenuPermission m WHERE m.PermissionId=@PermissionId)
		BEGIN
           INSERT INTO [dbo].[MenuPermission]

           (
		   [MenuId]
           ,[UserId]
           ,[CreatedDate]
           ,[CreatedBy]
           )
     VALUES
           (
		   @MenuId,
		   @UserId,
		   GETDATE(),
		   @UserId
		   )
		  end;
	else IF EXISTS (Select @PermissionId FROM MenuPermission m WHERE m.PermissionId=@PermissionId)
	begin
		UPDATE MenuPermission
            SET	   	
				   MenuId = @MenuId,
                   UserId = @UserId,
				   UpdatedDate = GETDATE(),
				   UpdatedBy = @UserId 
            WHERE  PermissionId = @PermissionId
	end
 END;

 
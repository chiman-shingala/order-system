Create or ALTER procedure [dbo].[sp_InsertUpdate_UserWiseItemMaster]
@CompanyId int,
@UserId int,
@ItemId int,
@Enable bit,
@Rate numeric(8,2)
as
begin
IF NOT EXISTS (Select UserId FROM UserWiseItemMaster c WHERE c.[CompanyId]=@CompanyId and c.UserId = @UserId and c.ItemId =@ItemId )
		begin
		INSERT INTO [dbo].[UserWiseItemMaster]
		           ([CompanyId]
		           ,[UserId]
		           ,[ItemId]
		           ,[Enable]
		           ,[Rate]
		           ,[CreatedDate]
		           ,[CreatedBy])
		 values  
		 (
		 @CompanyId,
		 @UserId,
		 @ItemId,
		 @Enable,
		 @Rate,
		 GETDATE(),
		 @UserId)
		 end;
 else IF EXISTS (Select UserId FROM UserWiseItemMaster c WHERE c.[CompanyId]=@CompanyId and c.UserId = @UserId and c.ItemId =@ItemId )
		begin
				UPDATE UserWiseItemMaster
		            SET    
		                   CompanyId = @CompanyId,
						   UserId = @UserId,
						   ItemId = @ItemId,
						   Enable = @Enable,
						   Rate = @Rate,
						   UpdatedDate = GETDATE(),
						   UpdatedBy = @UserId
		            WHERE  UserId = @UserId
		end
 end;
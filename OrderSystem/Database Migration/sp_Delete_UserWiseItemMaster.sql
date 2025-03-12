Create or ALTER Procedure [dbo].[sp_Delete_UserWiseItemMaster](
@CompanyId int,
@UserId int,
@ItemId int)
as
begin
	Delete from UserWiseItemMaster where CompanyId = @CompanyId and UserId = @UserId and ItemId = @ItemId
end;
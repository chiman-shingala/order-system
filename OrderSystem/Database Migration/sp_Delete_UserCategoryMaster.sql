CREATE OR ALTER   procedure [dbo].[sp_Delete_UserCategoryMaster]
@UserCategoryId int
as
begin
delete from UserCategoryMaster where UserCategoryId = @UserCategoryId
end;


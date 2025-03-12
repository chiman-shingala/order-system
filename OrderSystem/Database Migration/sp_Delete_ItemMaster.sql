CREATE OR ALTER   procedure [dbo].[sp_Delete_ItemMaster]
@ItemId int
as
begin
delete from ItemMaster where ItemId = @ItemId
end;
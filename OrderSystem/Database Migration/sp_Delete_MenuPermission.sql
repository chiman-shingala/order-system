CREATE OR ALTER procedure [dbo].[sp_Delete_MenuPermission]
@PermissionId int
as
Begin
	Delete MenuPermission where PermissionId = @PermissionId
end;


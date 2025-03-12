CREATE   Procedure [dbo].[sp_Get_MenuPermission] 
As 
Begin
select * from MenuMaster m
inner join MenuPermission mp on mp.MenuId = m.Id
End

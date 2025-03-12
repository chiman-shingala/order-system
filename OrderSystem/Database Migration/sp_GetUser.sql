Create   procedure [dbo].[sp_GetUser]
as
begin
SET NOCOUNT ON;
    BEGIN
        SELECT UserName FROM UserMaster;
    END
    
end;



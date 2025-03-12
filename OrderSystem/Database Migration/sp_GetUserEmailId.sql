--exec sp_GetUserEmailId 3 
CREATE OR ALTER   procedure [dbo].[sp_GetUserEmailId]
@CompanyId int
as
begin
SET NOCOUNT ON;
    BEGIN
        SELECT Email FROM UserMaster where CompanyId = @CompanyId;
    END
    
end;

alter procedure sp_ActiveInactiveCompany(
@CompanyId int,
@IsActive bit,
@UserId int
)
as
begin
 UPDATE CompanyMaster
            SET    IsActive = @IsActive,
				   UpdatedDate = GETDATE(),
				   UpdatedBy = @UserId
            WHERE  CompanyId = @CompanyId
end;

--exec sp_ActiveInactiveCompany 1,1,1
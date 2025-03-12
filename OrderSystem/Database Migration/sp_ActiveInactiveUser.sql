alter procedure sp_ActiveInactiveUser(
@UserId int,
@IsActive bit,
@UpdatedBy int
)
as
begin
 UPDATE UserMaster
            SET    IsActive = @IsActive,
				   UpdatedDate = GETDATE(),
				   UpdatedBy = @UpdatedBy
            WHERE  UserId = @UserId
end;

-- exec sp_ActiveInactiveUser 3,1,1
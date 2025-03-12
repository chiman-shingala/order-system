Create or alter procedure [dbo].[sp_OrderMaster_OrderReceived]
@UserId int,
@CompanyId int,
@AcYear int,
@TrnNo int,
@IsOrderReceived bit
as
begin
IF EXISTS (
            SELECT 1
            FROM OrderMaster
           WHERE  CompanyId = @CompanyId and 
				   AcYear = @AcYear and
				   TrnNo = @TrnNo 
                AND IsOrderDispatched = 1
        )
    BEGIN
        UPDATE OrderMaster
            SET    
                   IsOrderReceived = @IsOrderReceived,
				   UpdatedBy = @UserId,
				   UpdatedDate =GETDATE()
            WHERE  CompanyId = @CompanyId and 
				   AcYear = @AcYear and
				   TrnNo = @TrnNo
			
    END
	else 
	begin
	return -1
	end
	IF NOT EXISTS (
            SELECT 1
            FROM OrderMaster
           WHERE  CompanyId = @CompanyId and 
				   AcYear = @AcYear and
				   TrnNo = @TrnNo 
                AND IsOrderReceived = 0
        )
    BEGIN
        UPDATE OrderDetails
        SET IsOrderReceived = 1
        WHERE  CompanyId = @CompanyId and 
				   AcYear = @AcYear and
				   TrnNo = @TrnNo 
    END
	else
	BEGIN
        UPDATE OrderDetails
        SET IsOrderReceived = 0
        WHERE  CompanyId = @CompanyId and 
				   AcYear = @AcYear and
				   TrnNo = @TrnNo 
    END

	
end



-- exec [sp_OrderMaster_OrderReceived] 3,2,2024,13,0
CREATE OR ALTER procedure [dbo].[sp_OrderMaster_OrderReturned]
@UserId int,
@CompanyId int,
@AcYear int,
@TrnNo int,
@IsOrderReturned bit
as
begin
IF EXISTS (
            SELECT 1
            FROM OrderMaster
           WHERE  CompanyId = @CompanyId and 
				   AcYear = @AcYear and
				   TrnNo = @TrnNo 
                AND IsOrderReceived = 1
        )	
    BEGIN
        UPDATE OrderMaster
            SET    
                   IsOrderReturned = @IsOrderReturned,
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
                AND isnull(IsOrderReturned ,0) = 0
        )
    BEGIN
        UPDATE OrderDetails
        SET IsOrderReturned = 1
        WHERE  CompanyId = @CompanyId and 
				   AcYear = @AcYear and
				   TrnNo = @TrnNo 
    END
	else
	BEGIN
        UPDATE OrderDetails
        SET IsOrderReturned = 0
        WHERE  CompanyId = @CompanyId and 
				   AcYear = @AcYear and
				   TrnNo = @TrnNo 
    END
end

--exec sp_OrderMaster_OrderReturn 2,2,2024,2,1

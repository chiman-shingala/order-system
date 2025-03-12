USE [OrderSystem]
GO
/****** Object:  StoredProcedure [dbo].[sp_OrderDetail_OrderReceived]    Script Date: 02-08-2023 14:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE OR ALTER Procedure [dbo].[sp_OrderDetail_OrderReturned]
    @UserId int,
    @CompanyId int,
    @AcYear int,
    @TrnNo int,
    @SeqNo int,
    @IsOrderReturned bit
as
begin
    IF EXISTS
    (
        SELECT 1
        FROM OrderDetails
        WHERE CompanyId = @CompanyId
              and AcYear = @AcYear
              and TrnNo = @TrnNo
              and SeqNo = @SeqNo
              AND IsOrderReceived = 1
    )
    BEGIN
        UPDATE OrderDetails
        SET IsOrderReturned = @IsOrderReturned,
            UpdatedBy = @UserId,
            UpdatedDate = GETDATE()
        WHERE CompanyId = @CompanyId
              and AcYear = @AcYear
              and TrnNo = @TrnNo
              and SeqNo = @SeqNo
    end
    else
    begin
        return -1
    end
	 IF NOT EXISTS
        (
            SELECT 1
            FROM OrderDetails
            WHERE CompanyId = @CompanyId
                  and AcYear = @AcYear
                  and TrnNo = @TrnNo
                  AND isnull(IsOrderReturned,0) = 0
        )
        BEGIN
            UPDATE OrderMaster
            SET IsOrderReturned = 1
            WHERE CompanyId = @CompanyId
                  and AcYear = @AcYear
                  and TrnNo = @TrnNo
        END
        else
        begin
            UPDATE OrderMaster
            SET IsOrderReturned = 0
            WHERE CompanyId = @CompanyId
                  and AcYear = @AcYear
                  and TrnNo = @TrnNo
        end
end



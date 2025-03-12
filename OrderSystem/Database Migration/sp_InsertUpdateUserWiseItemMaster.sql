CREATE OR ALTER PROCEDURE [dbo].[sp_InsertUpdateUserWiseItemMaster]
    @jsonData NVARCHAR(MAX)
AS
BEGIN
    SET NOCOUNT ON;

    -- Declare a table variable to hold the parsed JSON data
    DECLARE @UserWiseItemMasterTable TABLE
    (
        CompanyId INT,
        UserId INT,
        ItemId INT,
		Rate numeric(8,2),
        Enable BIT
    );

    -- Parse JSON data into the table variable
    INSERT INTO @UserWiseItemMasterTable (CompanyId, UserId, ItemId,Rate, Enable)
    SELECT 
        JSON_VALUE(value, '$.CompanyId') AS CompanyId,
        JSON_VALUE(value, '$.UserId') AS UserId,
        JSON_VALUE(value, '$.ItemId') AS ItemId,
		JSON_VALUE(value, '$.Rate') AS Rate,
        JSON_VALUE(value, '$.Enable') AS Enable
    FROM OPENJSON(@jsonData);

    -- Update existing records
    UPDATE target
    SET 
		target.Rate = source.Rate,
        target.Enable = source.Enable,
        target.UpdatedDate = GETDATE(),
        target.UpdatedBy = source.UserId
    FROM [dbo].[UserWiseItemMaster] AS target
    INNER JOIN @UserWiseItemMasterTable AS source
    ON target.CompanyId = source.CompanyId
       AND target.UserId = source.UserId
       AND target.ItemId = source.ItemId;

    -- Insert new records
    MERGE INTO [dbo].[UserWiseItemMaster] AS target
    USING @UserWiseItemMasterTable AS source
    ON target.CompanyId = source.CompanyId
       AND target.UserId = source.UserId
      AND target.ItemId = source.ItemId
    WHEN NOT MATCHED THEN
        INSERT (CompanyId, UserId, ItemId,Rate, Enable, CreatedDate, CreatedBy)
        VALUES (source.CompanyId, source.UserId,source.ItemId,source.Rate, source.Enable, GETDATE(), source.UserId);

END;

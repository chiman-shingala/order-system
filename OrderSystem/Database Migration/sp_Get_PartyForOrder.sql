USE [OrderSystem]
GO
/****** Object:  StoredProcedure [dbo].[sp_Get_ItemForOrder]    Script Date: 06-07-2023 14:17:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER PROCEDURE [dbo].[sp_Get_PartyForOrder]
(
    @CompanyId INT = 0,
    @UserId INT = 0
)
AS
BEGIN
    declare @UserCategoryid int
    select @UserCategoryid = c.UserCategoryId
    from UserMaster u
        inner join UserCategoryMaster c
            on c.UserCategoryId = u.UserCategoryId
    where u.UserId = @UserId

    SELECT p.PartyCode,
           p.PartyName,
           ag.AGRName,
           p.Add1 + SPACE(1) + p.Add2 + SPACE(1) + p.Add3 As Address,
           p.Mobile,
           P.Phone,
           p.Email,
           ISNULL(u.Enable, 0) AS Enable
    FROM PartyMast p
        LEFT JOIN UserWisePartyMaster u
            ON p.PartyCode = u.PartyCode
               AND (
                       u.UserId = @UserId
                       OR @UserId = 0
                   )
        left join AGrpMast ag
            on ag.AGRCode = p.AGRCode
    WHERE
        p.CompanyId = @CompanyId
	   and 1 = case when @UserCategoryId =  1 then 1 
			when @UserCategoryid  in (1,2) then 1
	        else case when @UserCategoryid not in (1,2) and u.Enable = 1 then  1 else 0 end end

END;

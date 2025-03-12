CREATE OR ALTER PROCEDURE sp_Get_PartyCode
AS
  BEGIN 
	SELECT Concat( 'P', ISNULL((RIGHT('000' + Cast(Max(Cast(Substring(partycode, 2, Len(partycode) - 1) AS INT)) + 1 AS VARCHAR(2)), 4)) ,'0001') ) AS PartyCode
    FROM   PartyMast
    WHERE  partycode LIKE 'P%'
	;END

-- exec sp_Get_PartyCode


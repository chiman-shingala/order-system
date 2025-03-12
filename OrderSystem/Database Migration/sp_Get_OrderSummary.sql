alter procedure [dbo].[sp_Get_OrderSummary](
@CompanyId varchar(512) = null,
@ItemId varchar(512) = null,
@FromOrderDate date = null,
@ToOrderDate date = null,
@AcYear int = 0,
@FromRate numeric(8,2) = 0,
@ToRate numeric(8,2) = 0,
@FromAmount numeric(8,2) = 0,
@ToAmount numeric(8,2) = 0,
@FromTrnNo int = 0,
@ToTrnNo int= 0,
@FromSeqNo int = 0,
@ToSeqNo int = 0,
@FromPcs numeric(8,2) = 0,
@ToPcs numeric(8,2) = 0
)
as
begin
select c.CompanyName ,i.ItemName , sum(o.Pcs) as TotalPcs ,(sum(o.Amount)/sum(o.Pcs)) as AvgRate, sum(o.Amount) as Amount
from OrderDetails o inner join ItemMaster i on i.ItemId = o.ItemId
inner join CompanyMaster c on c.CompanyId = i.CompanyId
where((','+ @CompanyId +',' like '%,'+ convert( varchar(16),o.CompanyId ) + ',%') or @CompanyId is null)
		and	((','+ @ItemId +',' like '%,'+ convert( varchar(16),o.ItemId ) + ',%') or @ItemId is null)
		and (@FromOrderDate is null or o.TrnDate >=@FromOrderDate)
		and (@ToOrderDate is null or o.TrnDate <=@ToOrderDate)
		and (o.AcYear = @AcYear or @AcYear = 0)
		and (@FromRate = 0 or o.Rate >=@FromRate)
		and (@ToRate = 0 or o.Rate <=@ToRate)
		and (@FromAmount = 0 or o.Amount >=@FromAmount)
		and (@ToAmount = 0 or o.Amount <=@ToAmount)
		and (@FromTrnNo = 0 or o.TrnNo >=@FromTrnNo)
		and (@ToTrnNo = 0 or o.TrnNo <=@ToTrnNo)
		and (@FromSeqNo = 0 or o.SeqNo >=@FromSeqNo)
		and (@ToSeqNo = 0 or o.SeqNo <=@ToSeqNo)
		and (@FromPcs = 0 or o.Pcs >=@FromPcs)
		and (@ToPcs = 0 or o.Pcs <=@ToPcs)
group by o.ItemId,o.CompanyId,c.CompanyName,i.ItemName
end;

--select * from OrderDetails
--select * from ItemMaster
--select * from CompanyMaster
--exec sp_Get_OrderSummary null,null,null,null,0,0,0,0,0,0,0,0,0,0,0
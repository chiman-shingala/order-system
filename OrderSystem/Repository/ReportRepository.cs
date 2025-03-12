using OrderSystem.FilterClass;
using OrderSystem.Repository.Interface;
using OrderSystem.UserModel;

namespace OrderSystem.Repository
{
    public class ReportRepository : IReportRepository
    {
        private readonly IDRepository _dbRepository;

        public ReportRepository(IDRepository dbRepository)
        {
            _dbRepository = dbRepository;
        }

        public async Task<List<GetOrderSummary>> GetOrdersummaryAsync(OrderDetailFilter user)
        {
            return await _dbRepository.GetAll<GetOrderSummary>("sp_Get_OrderSummary",
            new
            {
                CompanyId = user.CompanyIdCsv,
                ItemId = user.ItemIdCsv,
                user.FromOrderDate,
                user.ToOrderDate,
                user.AcYear,
                user.FromRate,
                user.ToRate,
                user.FromAmount,
                user.ToAmount,
                user.FromTrnNo,
                user.ToTrnNo,
                user.FromSeqNo,
                user.ToSeqNo
            });
        }
        public async Task<List<GetDailyOrder>> GetDailyOrderSummaryAsync(TranscationDateDto dateDto)
        {
            return await _dbRepository.GetAll<GetDailyOrder>("sp_Get_DailyOrderSummary",dateDto);
        }
    }
}

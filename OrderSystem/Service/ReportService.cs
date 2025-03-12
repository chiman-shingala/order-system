using OrderSystem.FilterClass;
using OrderSystem.Repository.Interface;
using OrderSystem.Service.Interface;
using OrderSystem.UserModel;

namespace OrderSystem.Service
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository _reportRepository;

        public ReportService(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }

        public async Task<List<GetOrderSummary>> GetOrderSummaryAsync(OrderDetailFilter user)
        {
            return await _reportRepository.GetOrdersummaryAsync(user);
        }
        public async Task<List<GetDailyOrder>> GetDailyOrderSummaryAsync(TranscationDateDto dateDto)
        {
            return await _reportRepository.GetDailyOrderSummaryAsync(dateDto);
        }
    }
}

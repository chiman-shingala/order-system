using OrderSystem.FilterClass;
using OrderSystem.UserModel;

namespace OrderSystem.Service.Interface
{
    public interface IReportService
    {
        Task<List<GetOrderSummary>> GetOrderSummaryAsync(OrderDetailFilter user);
        Task<List<GetDailyOrder>> GetDailyOrderSummaryAsync(TranscationDateDto dateDto);
    }
}

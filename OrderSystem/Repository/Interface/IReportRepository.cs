using OrderSystem.FilterClass;
using OrderSystem.UserModel;

namespace OrderSystem.Repository.Interface
{
    public interface IReportRepository
    {
        Task<List<GetOrderSummary>> GetOrdersummaryAsync(OrderDetailFilter user);
        Task<List<GetDailyOrder>> GetDailyOrderSummaryAsync(TranscationDateDto dateDto);
    }
}

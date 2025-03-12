using OrderSystem.FilterClass;
using OrderSystem.UserModel;

namespace OrderSystem.Repository.Interface
{
    public interface IOrderDetailRepository
    {
        Task<List<OrderDetailGetFilter>> GetOrderDetailAsync(OrderDetailFilter user);
        Task<int> AddOrderDetailAsync(OrderDetailsDto user);
        Task<int> UpdateOrderDetailAsync(OrderDetailsDto user);
        Task<int> DeleteOrderDetailAsync(OrderDetailDeleteFilter user);
        Task<List<TransectionNoDto>> GetTransactionNoAsync(GetTransectionNoFilter number);
        Task<InserOrderGetFilter> AddOrderDetail(string order);
        Task<List<GetOrderDetailsFromTrnNo>> GetOrderDetailsFromTrnNoAsync(OrderDetailsFromTrnNoParaFilter filter);
        Task<int> OrderConfirmedAsync(OrderConfirmedDto order);
        Task<int> OrderDetailOrderConfirmedAsync(OrderDetailOrderConfirmedPara order);
        Task<int> OrderMasterOrderDispatchedAsync(OrderMasterOrderDispatchedPara order);
        Task<int> OrderDetailOrderDispatchedAsync(OrderDetailOrderDispatchedPara order);
        Task<int> OrderDetailOrderReceivedAsync(OrderDetailOrderReceivedPara order);
        Task<int> OrderMasterOrderReceivedAsync(OrderMasterOrderReceivedPara order);        
        Task<List<OrderMasterGetFilter>> GetOrderMasterDetailsAsync(OrderMasterFilter filter);
        Task<List<GetTotalOrder>> GetTotalOrderAsync(TotalOrderDto total);
        Task<int> OrderMasterOrderReturnAsync(OrderMasterOrderReturnPara order);
        Task<int> OrderDetailOrderReturnAsync(OrderDetailOrderReturnPara order);
    }
}

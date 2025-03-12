using OrderSystem.FilterClass;
using OrderSystem.Models;
using OrderSystem.UserModel;

namespace OrderSystem.Service.Interface
{
    public interface IOrderdetailService
    {
        Task<List<OrderDetailGetFilter>> GetOrderDetailAsync(OrderDetailFilter user);
        Task<List<OrderDetail>> AddOrderDetailAsync(OrderDetailsDto user);
        Task<List<OrderDetail>> UpdateOrderDetailAsync(OrderDetailsDto user);
        Task<int> DeleteOrderDetailAsync(OrderDetailDeleteFilter filter);
        Task<List<TransectionNoDto>> GetTransactionNoAsync(GetTransectionNoFilter user);
        Task<InserOrderGetFilter> AddOrderDetail(List<OrderDetailsDto> order);
        Task<List<GetOrderDetailsFromTrnNo>> GetOrderDetailsFromTrnNoAsync(OrderDetailsFromTrnNoParaFilter user);
        Task<int> OrderConfirmedAsync(OrderConfirmedDto order);
        Task<int> OrderDetailOrderConfirmedAsync(OrderDetailOrderConfirmedPara order);
        Task<int> OrderMasterOrderDispatchedAsync(OrderMasterOrderDispatchedPara order);
        Task<int> OrderDetailOrderDispatchedAsync(OrderDetailOrderDispatchedPara order);
        Task<int> OrderDetailOrderReceivedAsync(OrderDetailOrderReceivedPara order);        
        Task<int> OrderMasterOrderReceivedAsync(OrderMasterOrderReceivedPara order);
        Task<List<OrderMasterGetFilter>> GetOrderMasterDeatilsAsync(OrderMasterFilter filter);
        Task<List<GetTotalOrder>> GetTotalOrderAsync(TotalOrderDto total);
        Task<int> OrderMasterOrderReturnAsync(OrderMasterOrderReturnPara order);
        Task<int> OrderDetailOrderReturnAsync(OrderDetailOrderReturnPara order);
    }
}

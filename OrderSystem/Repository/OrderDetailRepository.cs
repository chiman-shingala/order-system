using OrderSystem.FilterClass;
using OrderSystem.Repository.Interface;
using OrderSystem.UserModel;
namespace OrderSystem.Repository
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly IDRepository _dbRepository;
        public OrderDetailRepository(IDRepository dbRepository)
        {
            _dbRepository = dbRepository;
        }
        public async Task<List<OrderDetailGetFilter>> GetOrderDetailAsync(OrderDetailFilter user)
        {
            return await _dbRepository.GetAll<OrderDetailGetFilter>("sp_Get_OrderDetails", 
            new { CompanyId = user.CompanyIdCsv,
                    ItemId = user.ItemIdCsv,
                user.FromOrderDate, user.ToOrderDate,
                user.AcYear,
                user.FromRate, user.ToRate,
                user.FromAmount, user.ToAmount,
                user.FromTrnNo, user.ToTrnNo, 
                user.FromSeqNo, user.ToSeqNo });
        }
        public async Task<int> AddOrderDetailAsync(OrderDetailsDto user)
        {
            return await _dbRepository.ExecuteAsyncQuery("sp_InsertUpdate_OrderDetail",user);
        }
        public async Task<int> UpdateOrderDetailAsync(OrderDetailsDto user)
        {
            return await _dbRepository.ExecuteAsyncQuery("sp_InsertUpdate_OrderDetail",user);
        }
        public async Task<int> DeleteOrderDetailAsync(OrderDetailDeleteFilter user)
        {
            return await _dbRepository.ExecuteAsyncQuery("sp_Delete_OrderDetails",user);
        }
        public async Task<List<TransectionNoDto>> GetTransactionNoAsync(GetTransectionNoFilter number)
        {
            return await _dbRepository.GetAll<TransectionNoDto>("sp_Get_TransactionNo", number);
        }
        public async Task<InserOrderGetFilter> AddOrderDetail(string order)
        {
             return await _dbRepository.ExecuteAsyncQueryWithJson<InserOrderGetFilter>("sp_Get_InsertOrder", order); 
        }
        public async Task<List<GetOrderDetailsFromTrnNo>> GetOrderDetailsFromTrnNoAsync(OrderDetailsFromTrnNoParaFilter filter)
        {
            return await _dbRepository.GetAll<GetOrderDetailsFromTrnNo>("sp_Get_OrderDetailsFromTrnNo", filter);
        }
        public async Task<int> OrderConfirmedAsync(OrderConfirmedDto order)
        {
            return await _dbRepository.ExecuteAsyncQuery("sp_OrderMaster_OrderConfirmed", order);
        }
        public async Task<int> OrderDetailOrderConfirmedAsync(OrderDetailOrderConfirmedPara order)
        {
            return await _dbRepository.ExecuteAsyncQuery("sp_OrderDetail_OrderConfirmed", order);
        }
        public async Task<int> OrderMasterOrderDispatchedAsync(OrderMasterOrderDispatchedPara order)
        {
            return await _dbRepository.ExecuteAsyncQuery("sp_OrderMaster_OrderDispatched", order);
        }
        public async Task<int> OrderDetailOrderDispatchedAsync(OrderDetailOrderDispatchedPara order)
        {
            return await _dbRepository.ExecuteAsyncQuery("sp_OrderDetail_OrderDispatched", order);
        }
        public async Task<int> OrderDetailOrderReceivedAsync(OrderDetailOrderReceivedPara order)
        {
            return await _dbRepository.ExecuteAsyncQuery("sp_OrderDetail_OrderReceived", order);
        }       
        public async Task<int> OrderMasterOrderReceivedAsync(OrderMasterOrderReceivedPara order)
        {
            return await _dbRepository.ExecuteAsyncQuery("sp_OrderMaster_OrderReceived", order);
        }
        public async Task<List<OrderMasterGetFilter>> GetOrderMasterDetailsAsync(OrderMasterFilter filter)
        {
            return await _dbRepository.GetAll<OrderMasterGetFilter>("sp_Get_OrderMasterDetails",
            new
            {
                CompanyId = filter.CompanyIdCsv,
                filter.UserId,
                filter.FromOrderDate,
                filter.ToOrderDate,
                filter.AcYear,
                filter.InvoiceNo,
                filter.FromRate,
                filter.ToRate,
                filter.FromAmount,
                filter.ToAmount,
                filter.FromTrnNo,
                filter.ToTrnNo,
                filter.FromPcs,
                filter.ToPcs,
                PartyCode = filter.PartyCodeCsv
            });
        }
        public async Task<List<GetTotalOrder>> GetTotalOrderAsync(TotalOrderDto total)
        {
            return await _dbRepository.GetAll<GetTotalOrder>("sp_Get_TotalOrders", total);
        }
        public async Task<int> OrderMasterOrderReturnAsync(OrderMasterOrderReturnPara order)
        {
            return await _dbRepository.ExecuteAsyncQuery("sp_OrderMaster_OrderReturned", order);
        }
        public async Task<int> OrderDetailOrderReturnAsync(OrderDetailOrderReturnPara order)
        {
            return await _dbRepository.ExecuteAsyncQuery("sp_OrderDetail_OrderReturned", order);
        }
    }
}

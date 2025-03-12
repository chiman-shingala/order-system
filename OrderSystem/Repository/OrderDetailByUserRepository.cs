using OrderSystem.FilterClass;
using OrderSystem.Repository.Interface;
using OrderSystem.UserModel;

namespace OrderSystem.Repository
{
    public class OrderDetailByUserRepository : IOrderDetailByUserRepository
    {
        private readonly IDRepository _dbRepository;

        public OrderDetailByUserRepository(IDRepository dbRepository)
        {
            _dbRepository = dbRepository;
        }
        public async Task<List<OrderDetailByUserDto>> GetAllOrderDeatilsAsync(OrderDetails order)
        {
            return await _dbRepository.GetAll<OrderDetailByUserDto>("sp_Get_OrderDetailsByUsers", 
                new 
                {
                    order.UserId,
                    CompanyId = order.CompanyIdCsv,
                    ItemId = order.ItemIdCsv,
                    order.FromOrderDate,
                    order.ToOrderDate,
                    order.AcYear,
                    order.InvoiceNo,
                    order.FromRate,
                    order.ToRate,
                    order.FromAmount,
                    order.ToAmount,
                    order.FromTrnNo,
                    order.ToTrnNo,
                    order.FromPcs,
                    order.ToPcs,
                    PartyCode = order.PartyCodeCsv
                });
        }
    }
}

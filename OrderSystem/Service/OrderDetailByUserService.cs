using OrderSystem.FilterClass;
using OrderSystem.Repository.Interface;
using OrderSystem.Service.Interface;
using OrderSystem.UserModel;

namespace OrderSystem.Service
{
    public class OrderDetailByUserService : IOrderDetailByUserService
    {
        private readonly IOrderDetailByUserRepository _repository;

        public OrderDetailByUserService(IOrderDetailByUserRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<OrderDetailByUserDto>> GetAllOrderDeatilsAsync(OrderDetails order)
        {
            return await _repository.GetAllOrderDeatilsAsync(order);
        }
    }
}

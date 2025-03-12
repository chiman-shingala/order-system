using OrderSystem.FilterClass;
using OrderSystem.UserModel;

namespace OrderSystem.Repository.Interface
{
    public interface IOrderDetailByUserRepository
    {
        Task<List<OrderDetailByUserDto>> GetAllOrderDeatilsAsync(OrderDetails order);
    }
}

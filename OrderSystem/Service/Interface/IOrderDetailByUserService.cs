using OrderSystem.FilterClass;
using OrderSystem.UserModel;

namespace OrderSystem.Service.Interface
{
    public interface IOrderDetailByUserService
    {
        Task<List<OrderDetailByUserDto>> GetAllOrderDeatilsAsync(OrderDetails order);
    }
}

using OrderSystem.FilterClass;
using OrderSystem.Models;
using OrderSystem.UserModel;

namespace OrderSystem.Repository.Interface
{
    public interface IPaymentRepository
    {
        Task<int> OrderPaymentAsync(PaymentDto payment);
        Task<List<PaymentDetailPara>> GetPaymentDetailsAsync(PaymentDetailDto payment);
    }
}

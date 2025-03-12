using OrderSystem.FilterClass;
using OrderSystem.Models;
using OrderSystem.UserModel;

namespace OrderSystem.Service.Interface
{
    public interface IPaymentService
    {
        Task<List<OrderPayment>> OrderPaymentAsync(PaymentDto payment);
        Task<List<PaymentDetailPara>> GetPaymentDetailsAsync(PaymentDetailDto payment);
    }
}

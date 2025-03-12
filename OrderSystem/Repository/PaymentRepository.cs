using OrderSystem.FilterClass;
using OrderSystem.Models;
using OrderSystem.Repository.Interface;
using OrderSystem.UserModel;

namespace OrderSystem.Repository
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly IDRepository _dbRepository;

        public PaymentRepository(IDRepository dbRepository) 
        {
            _dbRepository = dbRepository;
        }
        public async Task<int> OrderPaymentAsync(PaymentDto payment)
        {
            return await _dbRepository.ExecuteAsyncQuery("sp_Payment", payment); 
        }
        public async Task<List<PaymentDetailPara>> GetPaymentDetailsAsync(PaymentDetailDto payment)
        {
            return await _dbRepository.GetAll<PaymentDetailPara>("sp_Get_PaymentDetails", payment);
        }
    }
}

using AutoMapper;
using OrderSystem.FilterClass;
using OrderSystem.Models;
using OrderSystem.Repository.Interface;
using OrderSystem.Service.Interface;
using OrderSystem.UserModel;

namespace OrderSystem.Service
{
    public class PaymentService :IPaymentService
    {
        private readonly IPaymentRepository _repository;
        private readonly IMapper _mapper;

        public PaymentService(IPaymentRepository repository,IMapper mapper) 
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<OrderPayment>> OrderPaymentAsync(PaymentDto payment)
        {
            var record = await _repository.OrderPaymentAsync(payment);
            return _mapper.Map<List<OrderPayment>>(record);
        }
        public async Task<List<PaymentDetailPara>> GetPaymentDetailsAsync(PaymentDetailDto payment)
        {
            return await _repository.GetPaymentDetailsAsync(payment);
        }
    }
}

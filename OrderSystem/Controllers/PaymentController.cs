using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderSystem.Constants;
using OrderSystem.Models;
using OrderSystem.Service.Interface;
using OrderSystem.UserModel;
using System.Net;

namespace OrderSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _service;

        public PaymentController(IPaymentService service)
        {
            _service = service;
        }
        [HttpPost("addPayment")]
        public async Task<IActionResult> OrderPaymentAsync([FromBody] PaymentDto payment)
        {
            if (payment == null)
            {
                return new JsonResult(new ApiResponse(false, HttpStatusCode.BadRequest, null, CommonConstants.FAIL));
            }
            else
            {
                var response = await _service.OrderPaymentAsync(payment);
                return new JsonResult(new ApiResponse(true, HttpStatusCode.OK, response, CommonConstants.SUCCESS));
            }
        }
        [HttpGet("getPaymentDetail")]
        public async Task<IActionResult> GetPaymentDetailsAsync([FromQuery] PaymentDetailDto payment)
        {
            return new JsonResult(new ApiResponse(true, HttpStatusCode.OK, await _service.GetPaymentDetailsAsync(payment), CommonConstants.SUCCESS));
        }
    }
}

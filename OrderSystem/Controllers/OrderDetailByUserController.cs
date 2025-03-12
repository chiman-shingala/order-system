using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrderSystem.Constants;
using OrderSystem.FilterClass;
using OrderSystem.Models;
using OrderSystem.Service.Interface;
using System.Net;

namespace OrderSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderDetailByUserController : ControllerBase
    {
        private readonly IOrderDetailByUserService _services;

        public OrderDetailByUserController(IOrderDetailByUserService services)
        {
            _services = services;
        }
        [HttpGet("oderDetailByUser")]
        public async Task<IActionResult> GetAllOrderDeatilsAsync([FromQuery] OrderDetails order)
        {
            return new JsonResult(new ApiResponse(true, HttpStatusCode.OK, await _services.GetAllOrderDeatilsAsync(order), CommonConstants.SUCCESS));
        }
    }
}

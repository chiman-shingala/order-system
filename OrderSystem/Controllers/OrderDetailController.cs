using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrderSystem.Constants;
using OrderSystem.FilterClass;
using OrderSystem.Models;
using OrderSystem.Service.Interface;
using OrderSystem.UserModel;
using System.ComponentModel.Design;
using System.Net;

namespace OrderSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderDetailController : ControllerBase
    {
        private readonly IOrderdetailService _service;

        public OrderDetailController(IOrderdetailService service)
        {
            _service = service;
        }

        [HttpGet("getOrderDetails")]
        public async Task<IActionResult> GetAllOrderDetailAsync([FromQuery] OrderDetailFilter filter)
        {
            return new JsonResult(new ApiResponse(true, HttpStatusCode.OK, await _service.GetOrderDetailAsync(filter), CommonConstants.SUCCESS));
        }
        [HttpPost("addOrderDetail")]
        public async Task<IActionResult> AddOrderDetailAsync([FromBody] OrderDetailsDto user)
        {
            if (user == null)
            {
                return new JsonResult(new ApiResponse(false, HttpStatusCode.BadRequest, null, CommonConstants.FAIL));
            }
            else
            {
                var response = await _service.AddOrderDetailAsync(user);
                return new JsonResult(new ApiResponse(true, HttpStatusCode.OK, response, CommonConstants.SUCCESS));
            }
        }
        [HttpPut("UpdateOrderDetail")]
        public async Task<IActionResult> UpdateOrderDetailAsync([FromBody] OrderDetailsDto user)
        {
            if (user == null)
            {
                return new JsonResult(new ApiResponse(false, HttpStatusCode.BadRequest, null, CommonConstants.FAIL));
            }
            else
            {
                var response = await _service.UpdateOrderDetailAsync(user);
                return new JsonResult(new ApiResponse(true, HttpStatusCode.OK, response, CommonConstants.SUCCESS));
            }
        }
        [HttpDelete("deleteOrderDetail")]
        public async Task<IActionResult> DeleteUserAsync([FromQuery] OrderDetailDeleteFilter filter)
        {
            if (filter == null)
            {
                return new JsonResult(new ApiResponse(false, HttpStatusCode.BadRequest, null, CommonConstants.FAIL));
            }
            else
            {
                var response = await _service.DeleteOrderDetailAsync(filter);
                return new JsonResult(new ApiResponse(true, HttpStatusCode.OK, response, CommonConstants.SUCCESS));
            }
        }
        [HttpGet("getTransactionNo")]
        public async Task<IActionResult> GetTransectionNoAsync([FromQuery] GetTransectionNoFilter number)
        {
            return new JsonResult(new ApiResponse(true, HttpStatusCode.OK, await _service.GetTransactionNoAsync(number), CommonConstants.SUCCESS));
        }

        [HttpPost("insertOrder")]
        public async Task<IActionResult> AddOrder([FromBody] List<OrderDetailsDto> order)
        {
            var response = await _service.AddOrderDetail(order);
            return Ok(response);
        }
        [HttpGet("getOrderDetailsFromTrnNo")]
        public async Task<IActionResult> GetOrderDetailsFromTrnNoAsync([FromQuery] OrderDetailsFromTrnNoParaFilter filter)
        {
            return new JsonResult(new ApiResponse(true, HttpStatusCode.OK, await _service.GetOrderDetailsFromTrnNoAsync(filter), CommonConstants.SUCCESS));
        }
        [HttpPost("orderMasterOrderConfirmed")]
        public async Task<IActionResult> OrderConfirmedAsync([FromBody] OrderConfirmedDto order)
        {
            var response = await _service.OrderConfirmedAsync(order);
            if (response == -1)
            {
                return new JsonResult(new ApiResponse(false, HttpStatusCode.BadRequest, null, "You cannot unconfirm after order dispatched."));
            }
            return new JsonResult(new ApiResponse(true, HttpStatusCode.OK, response, CommonConstants.SUCCESS));
        }
        [HttpPost("orderDetailOrderConfirmed")]
        public async Task<IActionResult> OrderDetailOrderConfirmedAsync([FromBody] OrderDetailOrderConfirmedPara order)
        {
            var response = await _service.OrderDetailOrderConfirmedAsync(order);
            if (response == -1)
            {
                return new JsonResult(new ApiResponse(false, HttpStatusCode.BadRequest, null, "You cannot unconfirm after order dispatched."));
            }
            return new JsonResult(new ApiResponse(true, HttpStatusCode.OK,response, CommonConstants.SUCCESS));
        }
        [HttpPost("orderMasterOrderDispatched")]
        public async Task<IActionResult> OrderMasterOrderDispatchedAsync([FromBody] OrderMasterOrderDispatchedPara order)
        {
            var response =  await _service.OrderMasterOrderDispatchedAsync(order);
            if (response == -1)
            {
                return new JsonResult(new ApiResponse(false, HttpStatusCode.BadRequest, null, "Order cannot dispatch before order confirmation."));
            }
            return new JsonResult(new ApiResponse(true, HttpStatusCode.OK, response, CommonConstants.SUCCESS));
        }
        [HttpPost("orderDetailOrderDispatched")]
        public async Task<IActionResult> OrderDetailOrderDispatchedAsync([FromBody] OrderDetailOrderDispatchedPara order)
        {
            var response = await _service.OrderDetailOrderDispatchedAsync(order);
            if (response == -1)
            {
                return new JsonResult(new ApiResponse(false, HttpStatusCode.BadRequest, null, "Order cannot dispatch before order confirmation."));
            }
            return new JsonResult(new ApiResponse(true, HttpStatusCode.OK, response, CommonConstants.SUCCESS));
        }
        [HttpPost("orderDetailOrderReceived")]
        public async Task<IActionResult> OrderDetailOrderReceivedAsync([FromBody] OrderDetailOrderReceivedPara order)
        {
            var response = await _service.OrderDetailOrderReceivedAsync(order);
            if (response == -1)
            {
                return new JsonResult(new ApiResponse(false, HttpStatusCode.BadRequest, null, "Order cannot receive before order dispatch."));
            }
            return new JsonResult(new ApiResponse(true, HttpStatusCode.OK, response, CommonConstants.SUCCESS));
        }
        [HttpPost("orderMasterOrderReceived")]
        public async Task<IActionResult> OrderMasterOrderReceivedAsync([FromBody] OrderMasterOrderReceivedPara order)
        {
            var response = await _service.OrderMasterOrderReceivedAsync(order);
            if (response == -1)
            {
                return new JsonResult(new ApiResponse(false, HttpStatusCode.BadRequest, null, "Order cannot receive before order dispatch."));
            }
            return new JsonResult(new ApiResponse(true, HttpStatusCode.OK, response, CommonConstants.SUCCESS));
        }

        [HttpGet("getOrderMasterDetails")]
        public async Task<IActionResult> GetOrderMasterDeatilsAsync([FromQuery] OrderMasterFilter filter)
        {
            return new JsonResult(new ApiResponse(true, HttpStatusCode.OK, await _service.GetOrderMasterDeatilsAsync(filter), CommonConstants.SUCCESS));
        }
        [HttpGet("getTotalOrders")]
        public async Task<IActionResult> GetTotalOrderAsync([FromQuery] TotalOrderDto total)
        {
            return new JsonResult(new ApiResponse(true, HttpStatusCode.OK, await _service.GetTotalOrderAsync(total), CommonConstants.SUCCESS));
        }
        [HttpPost("orderDetailOrderReturn")]
        public async Task<IActionResult> OrderDetailOrderReturnAsync([FromBody] OrderDetailOrderReturnPara order)
        {
            var response = await _service.OrderDetailOrderReturnAsync(order);
            if (response == -1)
            {
                return new JsonResult(new ApiResponse(false, HttpStatusCode.BadRequest, null, "Order cannot return before order receive."));
            }
            return new JsonResult(new ApiResponse(true, HttpStatusCode.OK, response, CommonConstants.SUCCESS));
        }
        [HttpPost("orderMasterOrderReturn")]
        public async Task<IActionResult> OrderMasterOrderReturnAsync([FromBody] OrderMasterOrderReturnPara order)
        {
            var response = await _service.OrderMasterOrderReturnAsync(order);
            if (response == -1)
            {
                return new JsonResult(new ApiResponse(false, HttpStatusCode.BadRequest, null, "Order cannot return before order receive."));
            }
            return new JsonResult(new ApiResponse(true, HttpStatusCode.OK, response, CommonConstants.SUCCESS));
        }
    }
}

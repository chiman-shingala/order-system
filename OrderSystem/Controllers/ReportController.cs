using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderSystem.Constants;
using OrderSystem.FilterClass;
using OrderSystem.Models;
using OrderSystem.Service.Interface;
using OrderSystem.UserModel;
using System.Net;

namespace OrderSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }
        [HttpGet("getOrderSummary")]
        public async Task<IActionResult> GetAllOrderDetailAsync([FromQuery] OrderDetailFilter filter)
        {
            return new JsonResult(new ApiResponse(true, HttpStatusCode.OK, await _reportService.GetOrderSummaryAsync(filter), CommonConstants.SUCCESS));
        }
        [HttpGet("getDailyOrderSummary")]
        public async Task<IActionResult> GetDailyOrderSummaryAsync([FromQuery] TranscationDateDto dateDto)
        {
            var response = await _reportService.GetDailyOrderSummaryAsync(dateDto);
            return new JsonResult(new ApiResponse(true, HttpStatusCode.OK, response, CommonConstants.SUCCESS));

        }
    }
}

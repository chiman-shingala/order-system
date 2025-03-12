using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderSystem.Constants;
using OrderSystem.FilterClass;
using OrderSystem.Global;
using OrderSystem.Models;
using OrderSystem.Service.Interface;
using System.Net;

namespace OrderSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GlobalSearchController : ControllerBase
    {
        private readonly IGlobalSearchService _services;

        public GlobalSearchController(IGlobalSearchService services)
        {
            _services = services;
        }
        [HttpGet("global")]
        public async Task<IActionResult> GetGlobalSearchAsync([FromQuery] GlobalSearchFilter global)
        {
            return new JsonResult(new ApiResponse(true, HttpStatusCode.OK, await _services.GetGlobalSearchAsync(global), CommonConstants.SUCCESS));
        }
    }
}

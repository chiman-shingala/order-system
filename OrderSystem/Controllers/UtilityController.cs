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
    public class UtilityController : ControllerBase
    {
        private readonly IUtilityService _utilityService;
        public UtilityController(IUtilityService utilityService)
        {
            _utilityService = utilityService;
        }

        [HttpPut("setCompanyActiveInactive")]
        public async Task<IActionResult> setCompanyActiveInactive([FromQuery] ActiveInactiveCompanyFilter user)
        {
            if (user == null)
            {
                return new JsonResult(new ApiResponse(false, HttpStatusCode.BadRequest, null, CommonConstants.FAIL));
            }
            else
            {
                var response = await _utilityService.SetCompanyActiveInactiveAsync(user);
                return new JsonResult(new ApiResponse(true, HttpStatusCode.OK, response, CommonConstants.SUCCESS));
            }
        }
        [HttpPut("setUserActiveInactive")]
        public async Task<IActionResult> setUserActiveInactive([FromQuery] ActiveInactiveUserFilter user)
        {
            if (user == null)
            {
                return new JsonResult(new ApiResponse(false, HttpStatusCode.BadRequest, null, CommonConstants.FAIL));
            }
            else
            {
                var response = await _utilityService.SetUserActiveInactiveAsync(user);
                return new JsonResult(new ApiResponse(true, HttpStatusCode.OK, response, CommonConstants.SUCCESS));
            }
        }
    }
}

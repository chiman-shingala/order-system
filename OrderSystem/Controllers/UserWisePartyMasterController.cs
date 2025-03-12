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
    public class UserWisePartyMasterController : ControllerBase
    {
        private readonly IUserWisePartyMasterService _service;
        public UserWisePartyMasterController(IUserWisePartyMasterService service)
        {
            _service = service;
        }

        [HttpPost("addUserWiseParty")]
        public async Task<IActionResult> AddUserWiseParty([FromBody] AddUserWisePartyMasterPara party)
        {
            if (party == null)
            {
                return new JsonResult(new ApiResponse(false, HttpStatusCode.BadRequest, null, CommonConstants.FAIL));
            }
            else
            {
                var response = await _service.AddUserWisePartyMasterAsync(party);
                return new JsonResult(new ApiResponse(true, HttpStatusCode.OK, response, CommonConstants.SUCCESS));
            }
        }
        [HttpPost("updateUserWisePartyMaster")]
        public async Task<IActionResult> UpdateUserWisepartyMaster([FromBody] List<UpdateUserWisePartyMasterPara> order)
        {
            var response = await _service.UpdateUserWisepartyMaster(order);
            return Ok(response);
        }
        [HttpGet("getUserWisePartyMaster")]
        public async Task<IActionResult> GetUserPartyMasterAsync([FromQuery] GetUserWiseItemParameterFilter user)
        {
            return new JsonResult(new ApiResponse(true, HttpStatusCode.OK, await _service.GetPartyMasterAsync(user), CommonConstants.SUCCESS));
        }
        [HttpGet("getPartyForOrder")]
        public async Task<IActionResult> GetPartyOrderAsync([FromQuery] GetUserWiseItemParameterFilter user)
        {
            return new JsonResult(new ApiResponse(true, HttpStatusCode.OK, await _service.GetPartyOrderAsync(user), CommonConstants.SUCCESS));
        }
    }
}

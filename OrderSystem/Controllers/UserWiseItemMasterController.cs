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
    public class UserWiseItemMasterController : ControllerBase
    {
        private readonly IUserWiseItemMasterService _service;

        public UserWiseItemMasterController(IUserWiseItemMasterService service)
        {
            _service = service;
        }
        [HttpGet("getUserWiseItemMaster")]
        public async Task<IActionResult> GetAllUserAsync([FromQuery]GetUserWiseItemParameterFilter user)
        {
            return new JsonResult(new ApiResponse(true, HttpStatusCode.OK, await _service.GetUserwiseItemAsync(user), CommonConstants.SUCCESS));
        }
        [HttpGet("getItemForOrderAsync")]
        public async Task<IActionResult> GetItemForOrderAsync([FromQuery] GetUserWiseItemParameterFilter getUser)
        {
            return new JsonResult(new ApiResponse(true, HttpStatusCode.OK, await _service.GetItemForOrderAsync(getUser), CommonConstants.SUCCESS));
        }
        [HttpPost("addUserWiseItem")]
        public async Task<IActionResult> AddUserWiseItem([FromBody] List<UserWiseItemMasterDto> user)
        {
            if (user == null)
            {
                return new JsonResult(new ApiResponse(false, HttpStatusCode.BadRequest, null, CommonConstants.FAIL));
            }
            else
            {
                var response = await _service.AddUserWiseItemMasterAsync(user);
                return Ok(response);
            }
        }
        [HttpPut("updateUserWiseItem")]
        public async Task<IActionResult> UpdateUserWiseItem([FromBody] List<UserWiseItemMasterDto> user)
        {
            if (user == null)
            {
                return new JsonResult(new ApiResponse(false, HttpStatusCode.BadRequest, null, CommonConstants.FAIL));
            }
            else
            {
                var response = await _service.UpdateUserWiseItemMasterAsync(user);
                return Ok(response);
            }
        }
        [HttpDelete("deleteUserWiseItem")]
        public async Task<IActionResult> DeleteUserWiseItemAsync([FromQuery] int CompanyId, int UserId, int ItemId)
        {
            if (UserId == 0)
            {
                return new JsonResult(new ApiResponse(false, HttpStatusCode.BadRequest, null, CommonConstants.FAIL));
            }
            else
            {
                var response = await _service.DeleteUserWiseItemAsync(CompanyId,UserId, ItemId);
                return new JsonResult(new ApiResponse(true, HttpStatusCode.OK, response, CommonConstants.SUCCESS));
            }
        }
    }
}

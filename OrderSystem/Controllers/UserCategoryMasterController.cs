using Microsoft.AspNetCore.Authorization;
using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderSystem.Constants;
using OrderSystem.Models;
using System.Net;
using OrderSystem.Service.Interface;
using OrderSystem.UserModel;

namespace OrderSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserCategoryMasterController : ControllerBase
    {
        private readonly IUserCategoryMasterService _services;

        public UserCategoryMasterController(IUserCategoryMasterService services)
        {
            _services = services;
        }
        [HttpGet("UserCategory")]
        public async Task<IActionResult> GetAllUserCategoryAsync()
        {
            return new JsonResult(new ApiResponse(true, HttpStatusCode.OK, await _services.GetAllUserCategoryAsync(), CommonConstants.SUCCESS));
        }

        [HttpPost("addUserCategory")]
        public async Task<IActionResult> AddUserCategoryAsync(UserCategoryMasterDto categoryMaster)
        {
            if (categoryMaster == null)
            {
                return new JsonResult(new ApiResponse(false, HttpStatusCode.BadRequest, null, CommonConstants.FAIL));
            }
            else
            {
                var response = await _services.AddUserCategoryAsync(categoryMaster);
                return new JsonResult(new ApiResponse(false, HttpStatusCode.OK, response, CommonConstants.SUCCESS));
            }
        }
        [HttpPut("updateUserCategory")]
        public async Task<IActionResult> UpdateUserCategoryAsync(UserCategoryMasterDto categoryMaster)
        {
            if (categoryMaster == null)
            {
                return new JsonResult(new ApiResponse(false, HttpStatusCode.BadRequest, null, CommonConstants.FAIL));
            }
            else
            {
                var response = await _services.UpdateUserCategoryAsync(categoryMaster);
                return new JsonResult(new ApiResponse(false, HttpStatusCode.OK, response, CommonConstants.SUCCESS));
            }
        }

        [HttpDelete("deleteUserCategory")]
        public async Task<IActionResult> DeleteUserCategoryAsync([FromQuery] int UserCategoryId)
        {
            if (UserCategoryId == 0)
            {
                return new JsonResult(new ApiResponse(false, HttpStatusCode.BadRequest, null, CommonConstants.FAIL));
            }
            else
            {
                var response = await _services.DeleteUserCategoryAsync(UserCategoryId);
                return new JsonResult(new ApiResponse(false, HttpStatusCode.OK, response, CommonConstants.SUCCESS));
            }
        }
    }
}

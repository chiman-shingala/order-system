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
    public class MenuMasterController : ControllerBase
    {
        private readonly IMenuMasterService _services;
        public MenuMasterController(IMenuMasterService services)
        {
            _services = services;
        }
        [HttpGet("Menu")]
        public async Task<IActionResult> GetAllMenuMasterAsync()
        {
            return new JsonResult(new ApiResponse(true, HttpStatusCode.OK, await _services.GetAllMenuMasterAsync(), CommonConstants.SUCCESS));
        }

        [HttpGet("GetMenu")]
        public async Task<IActionResult> GetMenuMasterRole(int UserId)
        {
            UserDto user = new UserDto();
            user.UserId = UserId;
            return new JsonResult(new ApiResponse(true, HttpStatusCode.OK, await _services.GetMenuMasterRole(user), CommonConstants.SUCCESS));
        }

        [HttpPost("addMenu")]
        public async Task<IActionResult> AddMenuMasterAsync([FromBody] MenuMasterDto menu)
        {
            if (menu == null)
            {
                return new JsonResult(new ApiResponse(false, HttpStatusCode.BadRequest, null, CommonConstants.FAIL));
            }
            else
            {
                var response = await _services.AddMenuMasterAsync(menu);
                return new JsonResult(new ApiResponse(true, HttpStatusCode.OK, response, CommonConstants.SUCCESS));
            }
        }
        [HttpPut("updateMenu")]
        public async Task<IActionResult> UpdateCompany([FromBody] MenuMasterDto menu)
        {
            if (menu == null)
            {
                return new JsonResult(new ApiResponse(false, HttpStatusCode.BadRequest, null, CommonConstants.FAIL));
            }
            else
            {
                var response = await _services.UpdateMenuMasterAsync(menu);
                return new JsonResult(new ApiResponse(true, HttpStatusCode.OK, response, CommonConstants.SUCCESS));
            }
        }
        [HttpDelete("deleteMenuMaster")]
        public async Task<IActionResult> DeleteMenuMasterAsync([FromQuery] int Id)
        {
            if (Id == 0)
            {
                return new JsonResult(new ApiResponse(false, HttpStatusCode.BadRequest, null, CommonConstants.FAIL));
            }
            else
            {
                var response = await _services.DeleteMenuMasterAsync(Id);
                return new JsonResult(new ApiResponse(true, HttpStatusCode.OK, response, CommonConstants.SUCCESS));
            }
        }
    }
}

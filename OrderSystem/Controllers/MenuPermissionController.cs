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
    public class MenuPermissionController : ControllerBase
    {
        private readonly IMenuPermissionService _services;

        public MenuPermissionController(IMenuPermissionService services)
        {
            _services = services;
        }
        [HttpGet("menuPermission")]
        public async Task<IActionResult> GetAllMenuPermissionAsync()
        {
            return new JsonResult(new ApiResponse(true, HttpStatusCode.OK, await _services.GetAllMenuPermissionAsync(), CommonConstants.SUCCESS));
        }
        [HttpPost("addMenuPermission")]
        public async Task<IActionResult> AddMenuPermissionAsync([FromBody] MenuPermissionDto menuPermission)
        {
            if (menuPermission == null)
            {
                return new JsonResult(new ApiResponse(false, HttpStatusCode.BadRequest, null, CommonConstants.FAIL));
            }
            else
            {
                var response = await _services.AddMenuPermissionAsync(menuPermission);
                return new JsonResult(new ApiResponse(true, HttpStatusCode.OK, response, CommonConstants.SUCCESS));
            }
        }
        [HttpPut("updateMenuPermission")]
        public async Task<IActionResult> UpdateCompany([FromBody] MenuPermissionDto menuPermission)
        {
            if (menuPermission == null)
            {
                return new JsonResult(new ApiResponse(false, HttpStatusCode.BadRequest, null, CommonConstants.FAIL));
            }
            else
            {
                var response = await _services.AddMenuPermissionAsync(menuPermission);
                return new JsonResult(new ApiResponse(true, HttpStatusCode.OK, response, CommonConstants.SUCCESS));
            }
        }
        [HttpDelete("deleteMenuPermission")]
        public async Task<IActionResult> DeleteMenuPermissionAsync([FromQuery] int PermissionId)
        {
            if (PermissionId == 0)
            {
                return new JsonResult(new ApiResponse(false, HttpStatusCode.BadRequest, null, CommonConstants.FAIL));
            }
            else
            {
                var response = await _services.DeleteMenuPermissionAsync(PermissionId);
                return new JsonResult(new ApiResponse(true, HttpStatusCode.OK, response, CommonConstants.SUCCESS));
            }
        }
    }
}

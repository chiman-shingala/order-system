using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;
using OrderSystem.Constants;
using OrderSystem.FilterClass;
using OrderSystem.Global;
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
    public class ItemMasterController : ControllerBase
    {
        private readonly IItemMasterService _services;
        public ItemMasterController(IItemMasterService services)
        {
            _services = services;
        }

        [HttpGet("item")]
        public async Task<IActionResult> GetAllUserAsync(int CompanyId,int UserId)
        {

            int userId = GlobalVariables.UserId;
            return new JsonResult(new ApiResponse(true, HttpStatusCode.OK, await _services.GetAllItemAsync(CompanyId, UserId), CommonConstants.SUCCESS));
        }
        [AllowAnonymous]
        [HttpGet("itemByCompanyId")]
        public async Task<IActionResult> GetItemsByCompanyId(int CompanyId)
        {
            return new JsonResult(new ApiResponse(true, HttpStatusCode.OK, await _services.GetItemsByCompanyId(CompanyId), CommonConstants.SUCCESS));
        }
        [HttpPost("addItem")]
        public async Task<IActionResult> AddItemAsync([FromForm]  ItemMasterDto item, IFormFile file)
        {
            if (item == null)
            {
                return new JsonResult(new ApiResponse(false, HttpStatusCode.BadRequest, null, CommonConstants.FAIL));
            }
            else
            {
                var response = await _services.AddItemAsync(item,file);
                return new JsonResult(new ApiResponse(true, HttpStatusCode.OK, response, CommonConstants.SUCCESS));
            }
        }
        [HttpPut("updateItem")]
        public async Task<IActionResult> UpdateItemAsync([FromForm] ItemMasterDto item, IFormFile file = null , string OldImageName = null)
        {
            if (item == null)
            {
                return new JsonResult(new ApiResponse(false, HttpStatusCode.BadRequest, null, CommonConstants.FAIL));
            }
            else
            {
                var response = await _services.UpdateItemAsync(item,file, OldImageName);
                return new JsonResult(new ApiResponse(true, HttpStatusCode.OK, response, CommonConstants.SUCCESS));
            }
        }

        [HttpDelete("deleteItem")]
        public async Task<IActionResult> DeleteItemAsync([FromQuery] int ItemId,string OldImageName)
        {
            if (ItemId == 0)
            {
                return new JsonResult(new ApiResponse(false, HttpStatusCode.BadRequest, null, CommonConstants.FAIL));
            }
            else
            {
                var response = await _services.DeleteItemAsync(ItemId, OldImageName);
                if (response == -1)
                {
                    return new JsonResult(new ApiResponse(false, HttpStatusCode.BadRequest, null, "Cannot delete the Item because it has references in Order tables"));
                }
                return new JsonResult(new ApiResponse(true, HttpStatusCode.OK, response, CommonConstants.SUCCESS));
            }
        }
        [HttpGet("topItems")]
        public async Task<IActionResult> GetTopItemAsync([FromQuery] ItemDto user)
        {
            return new JsonResult(new ApiResponse(true, HttpStatusCode.OK, await _services.GetTopItemAsync(user), CommonConstants.SUCCESS));

        }
    }
}

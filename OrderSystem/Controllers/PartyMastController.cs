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
    public class PartyMastController : ControllerBase
    {
        private readonly IPartyMastService _service;

        public PartyMastController(IPartyMastService service)
        {
            _service = service;
        }
        [HttpGet("getPartyMastDetails")]
        public async Task<IActionResult> GetPartyMastDetailAsync([FromQuery] PartyMastFilter party)
        {
            return new JsonResult(new ApiResponse(true, HttpStatusCode.OK, await _service.GetPartyMastDetailAsync(party), CommonConstants.SUCCESS));
        }
        [HttpPost("addpartyMastDetail")]
        public async Task<IActionResult> AddPartyMastDetailAsync([FromBody] PartyMastDto party)
        {
            if (party == null)
            {
                return new JsonResult(new ApiResponse(false, HttpStatusCode.BadRequest, null, CommonConstants.FAIL));
            }
            else
            {
                var response = await _service.AddPartyMastDetailAsync(party);
                return new JsonResult(new ApiResponse(true, HttpStatusCode.OK, response, CommonConstants.SUCCESS));
            }
        }
        [HttpDelete("deletePartyMastDetail")]
        public async Task<IActionResult> DeletePartyMastAsync([FromQuery] PartyMasterParam party)
        {
            if (party == null)
            {
                return new JsonResult(new ApiResponse(false, HttpStatusCode.BadRequest, null, CommonConstants.FAIL));
            }
            else
            {
                var response = await _service.DeletePartyMastAsync(party);
                return new JsonResult(new ApiResponse(true, HttpStatusCode.OK, response, CommonConstants.SUCCESS));
            }
        }

        [HttpGet("getAgrpMasterDetails")]
        public async Task<IActionResult> GetAgrpMasterAsync()
        {
            return new JsonResult(new ApiResponse(true, HttpStatusCode.OK, await _service.GetAgrpMasterAsync(), CommonConstants.SUCCESS));
        }
        [HttpGet("getPartyCode")]
        public async Task<IActionResult> GetPartyCodeAsync()
        {
            return new JsonResult(new ApiResponse(true, HttpStatusCode.OK, await _service.GetPartyCodeAsync(), CommonConstants.SUCCESS));
        }
        [HttpGet("getAllParty")]
        public async Task<IActionResult> GetAllPartyAsync([FromQuery] GetAllPartyPara user)
        {
            return new JsonResult(new ApiResponse(true, HttpStatusCode.OK, await _service.GetAllPartyAsync(user), CommonConstants.SUCCESS));
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderSystem.Constants;
using OrderSystem.Models;
using OrderSystem.Service.Interface;
using OrderSystem.UserModel;
using System.Net;
using System.Security.Claims;

namespace OrderSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CompanyMasterController : ControllerBase
    {
        private readonly ICompanyMasterService _services;
        public CompanyMasterController(ICompanyMasterService services)
        {
            _services = services;
        }
        [HttpGet("company")]
        public async Task<IActionResult> GetAllCompanyMasterAsync()
        {
            return new JsonResult(new ApiResponse(true, HttpStatusCode.OK, await _services.GetAllCompanyMasterAsync(), CommonConstants.SUCCESS));
        }
        [HttpPost("addCompany")]
        public async Task<IActionResult> AddNewCompany([FromBody] CompanyMasterDto company)
        {
            if (company == null)
            {
                return new JsonResult(new ApiResponse(false, HttpStatusCode.BadRequest, null, CommonConstants.FAIL));
            }
            else
            {
                var response = await _services.AddNewCompanyAsync(company);
                return new JsonResult(new ApiResponse(true, HttpStatusCode.OK, response, CommonConstants.SUCCESS));
            }
        }
        [HttpPut("updateCompany")]
        public async Task<IActionResult> UpdateCompany([FromBody] CompanyMasterDto company)
        {
            if (company == null)
            {
                return new JsonResult(new ApiResponse(false, HttpStatusCode.BadRequest, null, CommonConstants.FAIL));
            }
            else
            {
                var response = await _services.UpdateCompanyAsync(company);
                return new JsonResult(new ApiResponse(true, HttpStatusCode.OK, response, CommonConstants.SUCCESS));
            }
        }
        [HttpDelete("deleteCompany")]
        public async Task<IActionResult> DeleteCompany(int CompanyId)
        {
            if (CompanyId == 0)
            {
                return new JsonResult(new ApiResponse(false, HttpStatusCode.BadRequest, null, CommonConstants.FAIL));
            }
            else
            {
                var response = await _services.DeleteCompanyAsync(CompanyId);
                if (response == -1)
                {
                    return new JsonResult(new ApiResponse(false, HttpStatusCode.BadRequest, null, "Cannot delete the company because it has references in other tables"));
                }
                return new JsonResult(new ApiResponse(true, HttpStatusCode.OK, response, CommonConstants.SUCCESS));

            }
        }
    }
}
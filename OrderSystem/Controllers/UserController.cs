using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using OrderSystem.Models;
using OrderSystem.UserModel;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Net;
using OrderSystem.Constants;
using OrderSystem.Service.Interface;
using OrderSystem.Global;
using OrderSystem.FilterClass;

namespace OrderSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _services;
        private readonly IConfiguration _configuration;
        public UserController(IUserService services, IConfiguration configuration)
        {
            _services = services;
            _configuration = configuration;
        }

        [HttpGet("user")]
        public async Task<IActionResult> GetAllUserAsync(int CompanyId,int UserCategoryId)
        {
            return new JsonResult(new ApiResponse(true, HttpStatusCode.OK, await _services.GetAllUserAsync(CompanyId,UserCategoryId), CommonConstants.SUCCESS));
        }
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(Login user)
        {
            if (user != null && user.Email != null && user.Password != null)
            {
                var userData = await _services.GetUserAsync(user);
                var aa1 = await _services.GetUserWithAcYear();
                var loginUser = aa1.Find(x => x.Email.ToLower() == user.Email.ToLower() && x.Password == user.Password);
                var jwt = _configuration.GetSection("Jwt").Get<Jwt>();
                if (userData.Count > 0)
                {
                    var claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub,jwt.Subject),
                        new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat,DateTime.UtcNow.ToString()),
                    };
                    var Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.Key));
                    var signIn = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);
                    DateTime dateTime = DateTime.Now.AddHours(1);
                    var tokenGen = new JwtSecurityToken(
                        jwt.Issuer,
                        jwt.Audience,
                        claims,
                        expires: dateTime,
                        signingCredentials: signIn
                        );

                    var data = new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(tokenGen),
                        userId = loginUser.UserId,
                        companyId = loginUser.CompanyId,
                        usercategoryId = loginUser.UserCategoryId,
                        acYear = loginUser.AcYear,
                        email = loginUser.Email.ToLower(),
                        firstname = loginUser.FirstName,
                        lastname = loginUser.LastName,
                        issueTime = DateTime.Now,
                        expires = dateTime
                    };

                    GlobalVariables.UserId = loginUser.UserId;

                    return new JsonResult(new ApiResponse(true, HttpStatusCode.OK, data, "Login Success"));
                }
                else
                {
                    return new JsonResult(new ApiResponse(false, HttpStatusCode.NotFound, null, "Invalid Credentials"));
                }
            }
            else
            {
                return new JsonResult(new ApiResponse(false, HttpStatusCode.BadRequest, null, "Invalid Credentials"));
            }
        }
        [HttpPost("addUser")]
        public async Task<IActionResult> AddUserAsync([FromBody] UserMasterDto user)
        {
            if (user == null)
            {
                return new JsonResult(new ApiResponse(false, HttpStatusCode.BadRequest, null, CommonConstants.FAIL));
            }

            var existingUsers = await _services.GetUserEmailIdAsync(user.CompanyId);

            var emailExists = existingUsers.Any(u => u.Email == user.Email);

            if (emailExists)
            {
                return new JsonResult(new ApiResponse(false, HttpStatusCode.BadRequest, null, "User already exists"));
            }
            var response = await _services.AddUserAsync(user);
            return new JsonResult(new ApiResponse(true, HttpStatusCode.OK, response, CommonConstants.SUCCESS));

        }

        [HttpPut("updateUser")]
        public async Task<IActionResult> UpdateUserAsync([FromBody] UserMasterDto user)
        {
            if (user == null)
            {
                return new JsonResult(new ApiResponse(false, HttpStatusCode.BadRequest, null, CommonConstants.FAIL));
            }
            else
            {

                var response = await _services.UpdateUserAsync(user);
                return new JsonResult(new ApiResponse(true, HttpStatusCode.OK, response, CommonConstants.SUCCESS));


            }
        }
        [HttpDelete("deleteUser")]
        public async Task<IActionResult> DeleteUserAsync([FromQuery] int UserId)
        {
            if (UserId == 0)
            {
                return new JsonResult(new ApiResponse(false, HttpStatusCode.BadRequest, null, CommonConstants.FAIL));
            }
            else
            {

                var response = await _services.DeleteUserAsync(UserId);
                return new JsonResult(new ApiResponse(true, HttpStatusCode.OK, response, CommonConstants.SUCCESS));

            }
        }
        [AllowAnonymous]
        [HttpPut("ChangeUserPassword")]
        public async Task<IActionResult> ChangeUserPasswordAsync([FromBody] ChangePasswordDto change)
        {
            if (change == null)
            {
                return new JsonResult(new ApiResponse(false, HttpStatusCode.BadRequest, null, CommonConstants.FAIL));
            }
            else
            {
                var response = await _services.ChangeUserPasswordAsync(change);
                if (response == -1)
                {
                    return new JsonResult(new ApiResponse(false, HttpStatusCode.BadRequest, response, "Invalid Credential"));
                }
                if (response == 0)
                {
                    return new JsonResult(new ApiResponse(false, HttpStatusCode.BadRequest, response, "Old and New password must be different"));
                }
                return new JsonResult(new ApiResponse(true, HttpStatusCode.OK, response, CommonConstants.SUCCESS));
            }
        }
        [HttpGet("topUser")]
        public async Task<IActionResult> GetTopUserAsync([FromQuery] TopUserParam user)
        {
            return new JsonResult(new ApiResponse(true, HttpStatusCode.OK, await _services.GetTopUserAsync(user), CommonConstants.SUCCESS));
        }
    }
}


using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Daily.Planner.with.God.Application.Dtos;
using Daily.Planner.with.God.Application.Interfaces;
using Daily.Planner.with.God.Common;
using Daily.Planner.with.God.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Daily.Planner.with.God.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;

        public LoginController(IUserService userService , IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }

        [HttpPost("login")]
        public async Task<ActionResult<ResponseMessage<UserInfoDto>>> Login([FromBody] LoginRequestDto loginRequest)
        {
            try
            {
                var user = await _userService.GetUserByUsernameAsync(loginRequest.Username);
                

                if (user == null)
                {
                    return Unauthorized();
                }

                var originPassword = EncryptionHelper.DecryptString(user.Password);
                if (originPassword != loginRequest.Password)
                {
                    return Unauthorized();
                }
                
                var token = GenerateJwtToken(user);

                var userInfo = new UserInfoDto
                {
                    Id = user.Id,
                    Username = user.Username,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    ConfigurationId = user.ConfigurationId,
                    Token = token
                };

                return Ok(userInfo);
            }
            catch (Exception)
            {
                return BadRequest();
                throw;
            }
            
        }

        [HttpGet]
        public string encriptPassword(string password)
        {
            return EncryptionHelper.EncryptString(password);
        }

        private string GenerateJwtToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                    new Claim(JwtRegisteredClaimNames.Sub, user.Username),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

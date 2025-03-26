using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Daily.Planner.with.God.Application.Dtos;
using Daily.Planner.with.God.Application.Interfaces;
using Daily.Planner.with.God.Application.Services;
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
        private readonly IConfigurationService _configurationService;
        private readonly ICardService _cardService;

        public LoginController(IUserService userService , IConfiguration configuration, IConfigurationService configurationService, ICardService cardService)
        {
            _userService = userService;
            _configuration = configuration;
            _configurationService = configurationService;
            _cardService = cardService;
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
                    Token = token,
                    IsMale = user.IsMale,
                    HasLead = !string.IsNullOrEmpty(user.LeadId?.ToString()),
                    ConfigurationName = string.Empty,
                };

                var configData = await _configurationService.GetConfigurationAsync(user.ConfigurationId);

                if (configData.Success) 
                { 
                    userInfo.ConfigurationName = configData.Data.Name; 
                    userInfo.ShowFavorites = configData.Data.ShowFavorites;
                    userInfo.ShowPetitions = configData.Data.ShowPetitions;

                    if (configData.Data.ShowFavorites) 
                    {
                        var cards = await _cardService.GetCardsAsync(user.Id);
                        List<CardInfoDto> cardsDto = new List<CardInfoDto>();
                        userInfo.TotalCardsCreated = cards.Data.Where(c => c.UserId == c.OriginalUserId).ToList().Count;
                        userInfo.TotalCardsReported = cards.Data.Where(c => c.UserId != c.OriginalUserId).ToList().Count;

                        foreach (var card in cards.Data.Where(c => c.Favorite && c.UserId == c.OriginalUserId))
                        {
                            var cardDto = await _cardService.GetCustomCardInfoAsync(card);
                            cardsDto.Add(cardDto);
                        }
                        userInfo.FavoriteCards = cardsDto;
                    }
                }

                if (user.LeadId != null) 
                {
                    Guid leadId = (Guid)user.LeadId;
                    var leadData = await _userService.GetUserAsync(leadId);

                    if (leadData.Success)
                    {
                        userInfo.LeadFirstname = leadData.Data.FirstName;
                        userInfo.LeadLastName = leadData.Data.LastName;
                        userInfo.IsMaleLead = leadData.Data.IsMale;
                    }
                }

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

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
        private readonly IConfigurationService _configurationService;
        private readonly ICardService _cardService;
        private readonly IPetitionService _petitionService;
        private readonly IPetitionTypesService _petitionTypesService;

        public LoginController(IUserService userService, IConfiguration configuration, IConfigurationService configurationService, ICardService cardService, IPetitionService petitionService, IPetitionTypesService petitionTypesService)
        {
            _userService = userService;
            _configuration = configuration;
            _configurationService = configurationService;
            _cardService = cardService;
            _petitionService = petitionService;
            _petitionTypesService = petitionTypesService;
        }

        [HttpGet("{userId}")]
        [Authorize]
        public async Task<ActionResult<ResponseMessage<UserInfoDto>>> GetCurrentUserInfo(Guid userId)
        {
            if (Request.Headers.TryGetValue("UserId", out var currentUserId))
            {
                Guid userIdToValid = Guid.Parse(currentUserId.ToString());
                var validAccess = await _userService.ValidAccessPermissionAsync(userIdToValid, ["CSUS", "CSCN", "CSCD", "CSPT"]);
                if (!validAccess)
                {
                    return Unauthorized();
                }

                var userData = await _userService.GetUserAsync(userId);
                var user = userData.Data;

                var userInfo = new UserInfoDto
                {
                    Id = user.Id,
                    Username = user.Username,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    IsMale = user.IsMale,
                    HasLead = !string.IsNullOrEmpty(user.LeadId?.ToString()),
                    ConfigurationName = string.Empty,
                    ConfigurationId = user.ConfigurationId,
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

                var petitionsData = await _petitionService.GetPetitionsByLeadIdAsync(user.Id);
                if (petitionsData.Success && petitionsData.Data.Count > 0)
                {
                    var petitionTypes = await _petitionTypesService.GetPetitionTypesAsync();
                    userInfo.PetitionsReported = new List<PetitionInfoDto>();
                    foreach (var petition in petitionsData.Data)
                    {
                        PetitionInfoDto petitionInfoDto = new PetitionInfoDto()
                        {
                            Id = petition.Id,
                            PrayFor = petition.PrayFor,
                            Content = petition.Content,
                            CreatedDate = DateTime.Now,
                            IsPraying = petition.IsPraying,
                            PetitionTypeId = petition.PetitionTypeId,
                            UserId = petition.UserId,
                        };

                        var userPetition = await _userService.GetUserAsync(petition.UserId);
                        petitionInfoDto.OriginalUser = userPetition.Data.FirstName + " " + userPetition.Data.LastName;
                        userInfo.PetitionsReported.Add(petitionInfoDto);
                    }

                    userInfo.PetitionTypes = petitionTypes.Data;
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

                var response = new ResponseMessage<UserInfoDto>()
                {
                    Data = userInfo,
                    Message = "Get data successful",
                    Success = true
                };

                return Ok(response);
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult<ResponseMessage<LoginUserDto>>> Login([FromBody] LoginRequestDto loginRequest)
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

                var userInfo = new LoginUserDto
                {
                    Id = user.Id,
                    Token = token,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    IsMale = user.IsMale,
                    HasLead = !string.IsNullOrEmpty(user.LeadId?.ToString()),
                    ConfigurationId = user.ConfigurationId,
                    Permissions = await _userService.GetPermissionsByRoleId(user.RoleId)
                };

                var response = new ResponseMessage<LoginUserDto>()
                {
                    Data = userInfo,
                    Message = "Get data successful",
                    Success = true
                };

                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest();
                throw;
            }
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

using Daily.Planner.with.God.Application.Dtos;
using Daily.Planner.with.God.Application.Interfaces;
using Daily.Planner.with.God.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Daily.Planner.with.God.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : Controller
    {
        private readonly IUserService _userService;
        private readonly ICardService _cardService;
        private readonly IPetitionService _petitionService;
        private readonly IPetitionTypesService _petitionTypesService;
        private readonly IAgendaService _agendaService;
        private readonly IColorPalettService _colorPalettService;
        private readonly ITypeService _typeService;
        private readonly IRolService _roleService;
        private readonly IAdsService _adsService;

        public DashboardController(IUserService userService, ICardService cardService, IPetitionService petitionService, IPetitionTypesService petitionTypesService, IAgendaService agendaService, IColorPalettService colorPalettService, ITypeService typeService, IRolService roleService, IAdsService adsService)
        {
            _userService = userService;
            _cardService = cardService;
            _petitionService = petitionService;
            _petitionTypesService = petitionTypesService;
            _agendaService = agendaService;
            _colorPalettService = colorPalettService;
            _typeService = typeService;
            _roleService = roleService;
            _adsService = adsService;
        }

        [HttpGet]
        [Authorize]
        public async Task<ResponseMessage<DashboardInfoDto>> GetDataInfoDashboard()
        {
            var response = new ResponseMessage<DashboardInfoDto>();
            var usersData = await _userService.GetUsersAsync();
            var cardsData = await _cardService.GetCardsAsync();
            var petitionsData = await _petitionService.GetPetitionsAsync();
            var petitionTypesData = await _petitionTypesService.GetPetitionTypesAsync();
            var agendasData = await _agendaService.GetAgendasAsync();
            var colorsData = await _colorPalettService.GetColorPalettsAsync();
            var typesData = await _typeService.GetTypesAsync();
            var rolesData = await _roleService.GetRolesAsync();
            var adsData = await _adsService.GetAdsAsync();

            if (usersData.Success &&
                cardsData.Success &&
                petitionsData.Success &&
                petitionTypesData.Success &&
                agendasData.Success &&
                colorsData.Success &&
                typesData.Success &&
                rolesData.Success &&
                adsData.Success)
            {
                response.Success = true;
                response.Message = "All data extracted";

                var sheepId = rolesData.Data.Where(r => r.Name == "Oveja").FirstOrDefault().Id;
                var leadId = rolesData.Data.Where(r => r.Name == "Lider").FirstOrDefault().Id;
                var coordinatorNetworkId = rolesData.Data.Where(r => r.Name == "Coordinador de red").FirstOrDefault().Id;
                var networkLeadId = rolesData.Data.Where(r => r.Name == "Lider de red").FirstOrDefault().Id;
                var networkHeadId = rolesData.Data.Where(r => r.Name == "Cabeza de red").FirstOrDefault().Id;
                var pastorId = rolesData.Data.Where(r => r.Name == "Pastor").FirstOrDefault().Id;
                var adminId = rolesData.Data.Where(r => r.Name == "Admin").FirstOrDefault().Id;
                var moderatorId = rolesData.Data.Where(r => r.Name == "Moderador").FirstOrDefault().Id;

                DateTime lastMonth = DateTime.Now.AddMonths(-1);
                DateTime lastYear = DateTime.Now.AddYears(-1);
                DateTime lastLastYear = DateTime.Now.AddYears(-2);

                var topColors = cardsData.Data.Where(c => c.UserId == c.OriginalUserId).GroupBy(c => c.PrimaryColorId).Select(g => new { Id = g.Key }).ToList();
                var topPetitions = petitionsData.Data.GroupBy(p => p.PetitionTypeId).Select(g => new { Id = g.Key }).ToList();

                var primaryBackgroundId = typesData.Data.Where(r => r.Name == "Primary Background").FirstOrDefault().Id;
                var primaryLetterId = typesData.Data.Where(r => r.Name == "Primary Letter").FirstOrDefault().Id;
                var titleId = typesData.Data.Where(r => r.Name == "Title").FirstOrDefault().Id;
                var titleDateId = typesData.Data.Where(r => r.Name == "Title Date").FirstOrDefault().Id;
                var titleDateBackgroundId = typesData.Data.Where(r => r.Name == "Title Date Background").FirstOrDefault().Id;

                response.Data = new DashboardInfoDto();

                response.Data.Users = new TotalUsersDto()
                {
                    TotalUsers = usersData.Data.Count,
                    Sheeps = usersData.Data.Where(u => u.RoleId == sheepId).Count(),
                    Leaders = usersData.Data.Where(u => u.RoleId == leadId).Count(),
                    NetworkCoordinators = usersData.Data.Where(u => u.RoleId == coordinatorNetworkId).Count(),
                    NetworkHeaders = usersData.Data.Where(u => u.RoleId == networkHeadId).Count(),
                    NetworkLeaders = usersData.Data.Where(u => u.RoleId == networkLeadId).Count(),
                    Pastors = usersData.Data.Where(u => u.RoleId == pastorId).Count()
                };

                response.Data.Cards = new TotalCardsDto()
                {
                    TotalCards = cardsData.Data.Count,
                    FavoritesCards = cardsData.Data.Where(c => c.Favorite && c.UserId == c.OriginalUserId).ToList().Count,
                    ReportedCards = cardsData.Data.Where(c => c.OriginalUserId != c.UserId).ToList().Count,
                    TotalCardsLastMonth = cardsData.Data.Where(c => c.CreateDate >= lastMonth && c.UserId == c.OriginalUserId).ToList().Count,
                    TotalCardsLastYear = cardsData.Data.Where(c => c.CreateDate >= lastYear && c.UserId == c.OriginalUserId).ToList().Count,
                    TotalCardsLastLastYear = cardsData.Data.Where(c => c.CreateDate >= lastLastYear && c.UserId == c.OriginalUserId).ToList().Count,
                    TopOneColorSelected = colorsData.Data.FirstOrDefault(t => t.Id == topColors.ElementAtOrDefault(0)?.Id)?.Color ?? string.Empty,
                    TopTwoColorSelected = colorsData.Data.FirstOrDefault(t => t.Id == topColors.ElementAtOrDefault(1)?.Id)?.Color ?? string.Empty,
                    TopThreeColorSelected = colorsData.Data.FirstOrDefault(t => t.Id == topColors.ElementAtOrDefault(2)?.Id)?.Color ?? string.Empty,
                };

                response.Data.Petitions = new TotalPetitionsDto()
                {
                    TotalPetitions = petitionsData.Data.Count,
                    PetitionsInPray = petitionsData.Data.Where(p => p.IsPraying).Count(),
                    TopOnePetitionType = petitionTypesData.Data.FirstOrDefault(t => t.Id == topPetitions.ElementAtOrDefault(0)?.Id)?.Name ?? string.Empty,
                    TopTwoPetitionType = petitionTypesData.Data.FirstOrDefault(t => t.Id == topPetitions.ElementAtOrDefault(1)?.Id)?.Name ?? string.Empty,
                    TopThreePetitionType = petitionTypesData.Data.FirstOrDefault(t => t.Id == topPetitions.ElementAtOrDefault(2)?.Id)?.Name ?? string.Empty,
                };

                response.Data.TotalAgendas = agendasData.Data.Count;

                response.Data.Colors = new TotalColorsDto()
                {
                    TotalColors = colorsData.Data.Count,
                    TotalPrimaryBackground = colorsData.Data.Where(c => c.TypeId == primaryBackgroundId).Count(),
                    TotalPrimaryLetter = colorsData.Data.Where(c => c.TypeId == primaryLetterId).Count(),
                    TotalTitle = colorsData.Data.Where(c => c.TypeId == titleId).Count(),
                    TotalTitleDate = colorsData.Data.Where(c => c.TypeId == titleDateId).Count(),
                    TotalTitleDateBackground = colorsData.Data.Where(c => c.TypeId == titleDateBackgroundId).Count()
                };

                response.Data.Roles = new TotalRolesDto()
                {
                    TotalRolesExist = rolesData.Data.Count,
                    TotalAdminUsers = usersData.Data.Where(u => u.RoleId == adminId).Count(),
                    TotalModeratorUsers = usersData.Data.Where(u => u.RoleId == moderatorId).Count(),
                    RolesNames = rolesData.Data.Select(u => u.Name).ToList()
                };

                response.Data.TotalAds = adsData.Data.Count;
            }

            return response;
        }
    }
}

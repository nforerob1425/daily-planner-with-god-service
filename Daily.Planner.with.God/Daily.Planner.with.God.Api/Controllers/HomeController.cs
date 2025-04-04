using Daily.Planner.with.God.Application.Dtos;
using Daily.Planner.with.God.Application.Interfaces;
using Daily.Planner.with.God.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Daily.Planner.with.God.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IUserService _userService;

        public HomeController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<ResponseMessage<List<MenuInfoDto>>>> GetMenu()
        {
            if (Request.Headers.TryGetValue("UserId", out var currentUserId))
            {
                Guid userId = Guid.Parse(currentUserId.ToString());
                var userData = await _userService.GetUserAsync(userId);

                var response = new ResponseMessage<List<MenuInfoDto>>();
                response.Data = new List<MenuInfoDto>();

                if (userData.Success)
                {
                    if (await _userService.ValidAccessPermissionAsync(userId, ["CSHV"]))
                    {
                        response.Data.Add(new MenuInfoDto { Title = "Inicio", Icon = "mdi-home", Route = "/home" });
                    }
                    if (await _userService.ValidAccessPermissionAsync(userId, ["CSPV"]))
                    {
                        response.Data.Add(new MenuInfoDto { Title = "Mi R07", Icon = "mdi-book-variant", Route = "/planner" });
                    }
                    if (await _userService.ValidAccessPermissionAsync(userId, ["CSPTV"]) && userData.Data.LeadId != null)
                    {
                        response.Data.Add(new MenuInfoDto { Title = "Maneja tus peticiones de oración", Icon = "mdi-clipboard-text", Route = "/petitions" });
                    }
                    if (await _userService.ValidAccessPermissionAsync(userId, ["CSPRV"]))
                    {
                        response.Data.Add(new MenuInfoDto { Title = "Perfil", Icon = "mdi-account", Route = "/profile" });
                    }
                    if (await _userService.ValidAccessPermissionAsync(userId, ["CSCV"]))
                    {
                        response.Data.Add(new MenuInfoDto { Title = "Configuración", Icon = "mdi-cog", Route = "/configuration" });
                    }
                    if (await _userService.ValidAccessPermissionAsync(userId, ["CSEV"]))
                    {
                        response.Data.Add(new MenuInfoDto { Title = "Solicitudes", Icon = "mdi-gmail", Route = "/contact" });
                    }
                    if (await _userService.ValidAccessPermissionAsync(userId, ["CSUV"]))
                    {
                        response.Data.Add(new MenuInfoDto { Title = "Usuarios", Icon = "mdi-account-multiple-plus", Route = "/users" });
                    }
                    if (await _userService.ValidAccessPermissionAsync(userId, ["CSDV"]))
                    {
                        response.Data.Add(new MenuInfoDto { Title = "Dashboard", Icon = "mdi-view-dashboard", Route = "/dashboard" });
                    }
                    if (await _userService.ValidAccessPermissionAsync(userId, ["CSMAV"]))
                    {
                        response.Data.Add(new MenuInfoDto { Title = "Admin. Aplicación", Icon = "mdi-application", Route = "/application" });
                    }

                    if (response.Data.Count > 0)
                    {
                        return Ok(response);
                    }
                }
                
            }
            return Unauthorized();
        }
    }
}

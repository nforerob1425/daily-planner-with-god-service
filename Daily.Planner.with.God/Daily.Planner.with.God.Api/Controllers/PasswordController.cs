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
    public class PasswordController : Controller
    {
        private readonly IUserService _userService;
        public PasswordController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult<ResponseMessage<bool>>> UpdatePasswordAsync(NewPasswordDto newPassword)
        {
            var userData = await _userService.GetUserAsync(newPassword.UserId);
            var response = new ResponseMessage<bool>()
            {
                Success = false,
                Message = userData.Message
            };

            if (userData.Success)
            {
                var encriptedPassword = EncryptionHelper.EncryptString(newPassword.NewPassword);
                userData.Data.Password = encriptedPassword;

                var userUpdated = await _userService.UpdateUserAsync(userData.Data);
                response.Success = userUpdated.Success;
                response.Message = response.Success ? "Se actualizo correctamente tu contraseña" : response.Message;
                response.Data = response.Data;
            }

            return response;
        }
    }
}

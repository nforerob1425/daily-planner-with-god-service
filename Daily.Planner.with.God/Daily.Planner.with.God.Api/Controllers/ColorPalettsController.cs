using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Daily.Planner.with.God.Application.Interfaces;
using Daily.Planner.with.God.Domain.Entities;
using Daily.Planner.with.God.Common;
using Daily.Planner.with.God.Application.Dtos;
using Microsoft.AspNetCore.Authorization;
using Daily.Planner.with.God.Application.Services;

namespace Daily.Planner.with.God.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ColorPalettsController : ControllerBase
    {
        private readonly IColorPalettService _colorPalettService;
        private readonly ITypeService _typeService;
        private readonly IUserService _userService;

        public ColorPalettsController(IColorPalettService colorPalettService, ITypeService typeService, IUserService userService)
        {
            _colorPalettService = colorPalettService;
            _typeService = typeService;
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<ResponseMessage<List<ColorPalettInfoDto>>>> GetColorPaletts()
        {
            if (Request.Headers.TryGetValue("UserId", out var currentUserId))
            {
                Guid userIdToValid = Guid.Parse(currentUserId.ToString());
                var validAccess = await _userService.ValidAccessPermissionAsync(userIdToValid, ["CSCO", "CSTC"]);
                if (!validAccess)
                {
                    return Unauthorized();
                }

                var originColorPaletts = await _colorPalettService.GetColorPalettsAsync();
                var colorPaletts = new List<ColorPalettInfoDto>();

                if (originColorPaletts.Success)
                {
                    foreach (var item in originColorPaletts.Data)
                    {
                        var typeOrigin = await _typeService.GetTypeAsync(item.TypeId);

                        var colorPalett = new ColorPalettInfoDto
                        {
                            ColorId = item.Id,
                            Color = item.Color,
                            TypeName = typeOrigin.Data.Name,
                        };

                        colorPaletts.Add(colorPalett);
                    }

                    var response = new ResponseMessage<List<ColorPalettInfoDto>>
                    {
                        Data = colorPaletts,
                        Message = originColorPaletts.Message,
                        Success = originColorPaletts.Success
                    };

                    return Ok(response);

                }
                return NotFound(originColorPaletts);
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}

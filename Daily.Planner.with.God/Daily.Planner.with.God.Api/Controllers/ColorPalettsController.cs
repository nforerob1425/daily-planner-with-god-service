using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Daily.Planner.with.God.Application.Interfaces;
using Daily.Planner.with.God.Domain.Entities;
using Daily.Planner.with.God.Common;
using Daily.Planner.with.God.Application.Dtos;
using Microsoft.AspNetCore.Authorization;

namespace Daily.Planner.with.God.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ColorPalettsController : ControllerBase
    {
        private readonly IColorPalettService _colorPalettService;
        private readonly ITypeService _typeService;

        public ColorPalettsController(IColorPalettService colorPalettService, ITypeService typeService)
        {
            _colorPalettService = colorPalettService;
            _typeService = typeService;
        }

        [HttpGet]
        public async Task<ActionResult<ResponseMessage<List<ColorPalettInfoDto>>>> GetColorPaletts()
        {
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

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseMessage<ColorPalettInfoDto?>>> GetColorPalett(Guid id)
        {
            var response = await _colorPalettService.GetColorPalettAsync(id);
            if (response.Success)
            {
                var typeOrigin = await _typeService.GetTypeAsync(response.Data.TypeId);
                var colorPalett = new ColorPalettInfoDto
                {
                    ColorId = response.Data.Id,
                    Color = response.Data.Color,
                    TypeName = typeOrigin.Data.Name,
                };
                var responseDto = new ResponseMessage<ColorPalettInfoDto?>
                {
                    Data = colorPalett,
                    Message = response.Message,
                    Success = response.Success
                };
                return Ok(responseDto);
            }
            return NotFound(response);
        }

        [HttpPost]
        public async Task<ActionResult<ResponseMessage<ColorPalett>>> CreateColorPalett(ColorPalett colorPalett)
        {
            var response = await _colorPalettService.CreateColorPalettAsync(colorPalett);
            if (response.Success)
            {
                return CreatedAtAction(nameof(GetColorPalett), new { id = response.Data.Id }, response);
            }
            return BadRequest(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseMessage<bool>>> UpdateColorPalett(ColorPalett colorPalett)
        {
            var response = await _colorPalettService.UpdateColorPalettAsync(colorPalett);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseMessage<bool>>> DeleteColorPalett(Guid id)
        {
            var response = await _colorPalettService.DeleteColorPalettAsync(id);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
    }
}

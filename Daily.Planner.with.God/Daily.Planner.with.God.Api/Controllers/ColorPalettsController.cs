using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Daily.Planner.with.God.Application.Interfaces;
using Daily.Planner.with.God.Domain.Entities;
using Daily.Planner.with.God.Common;

namespace Daily.Planner.with.God.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorPalettsController : ControllerBase
    {
        private readonly IColorPalettService _colorPalettService;

        public ColorPalettsController(IColorPalettService colorPalettService)
        {
            _colorPalettService = colorPalettService;
        }

        [HttpGet]
        public async Task<ActionResult<ResponseMessage<List<ColorPalett>>>> GetColorPaletts()
        {
            var response = await _colorPalettService.GetColorPalettsAsync();
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseMessage<ColorPalett?>>> GetColorPalett(Guid id)
        {
            var response = await _colorPalettService.GetColorPalettAsync(id);
            if (response.Success)
            {
                return Ok(response);
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

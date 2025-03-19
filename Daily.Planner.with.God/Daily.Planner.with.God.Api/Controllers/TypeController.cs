using Microsoft.AspNetCore.Mvc;
using Daily.Planner.with.God.Application.Interfaces;
using Daily.Planner.with.God.Common;
using Type = Daily.Planner.with.God.Domain.Entities.Type;

namespace Daily.Planner.with.God.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeController : ControllerBase
    {
        private readonly ITypeService _typeService;

        public TypeController(ITypeService typeService)
        {
            _typeService = typeService;
        }

        [HttpGet]
        public async Task<ActionResult<ResponseMessage<List<Type>>>> GetTypes()
        {
            var result = await _typeService.GetTypesAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseMessage<Type?>>> GetType(Guid id)
        {
            var result = await _typeService.GetTypeAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ResponseMessage<Type>>> CreateType(Type type)
        {
            var result = await _typeService.CreateTypeAsync(type);
            return CreatedAtAction(nameof(GetType), new { id = result.Data.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseMessage<bool>>> UpdateType(Guid id, Type type)
        {
            if (id != type.Id)
            {
                return BadRequest();
            }

            var result = await _typeService.UpdateTypeAsync(type);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseMessage<bool>>> DeleteType(Guid id)
        {
            var result = await _typeService.DeleteTypeAsync(id);
            return Ok(result);
        }
    }
}

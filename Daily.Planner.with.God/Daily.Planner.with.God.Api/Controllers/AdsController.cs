using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Daily.Planner.with.God.Application.Interfaces;
using Daily.Planner.with.God.Domain.Entities;
using Daily.Planner.with.God.Common;
using Microsoft.AspNetCore.Authorization;

namespace Daily.Planner.with.God.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AdsController : ControllerBase
    {
        private readonly IAdsService _adsService;

        public AdsController(IAdsService adsService)
        {
            _adsService = adsService;
        }

        [HttpGet]
        public async Task<ActionResult<ResponseMessage<List<Ads>>>> GetAds()
        {
            var response = await _adsService.GetAdsAsync();
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseMessage<Ads?>>> GetAd(Guid id)
        {
            var response = await _adsService.GetAdAsync(id);
            if (response.Success)
            {
                return Ok(response);
            }
            return NotFound(response);
        }

        [HttpPost]
        public async Task<ActionResult<ResponseMessage<Ads>>> CreateAd(Ads ad)
        {
            var response = await _adsService.CreateAdAsync(ad);
            if (response.Success)
            {
                return CreatedAtAction(nameof(GetAd), new { id = response.Data.Id }, response);
            }
            return BadRequest(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseMessage<bool>>> UpdateAd(Ads ad)
        {
            var response = await _adsService.UpdateAdAsync(ad);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseMessage<bool>>> DeleteAd(Guid id)
        {
            var response = await _adsService.DeleteAdAsync(id);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
    }
}

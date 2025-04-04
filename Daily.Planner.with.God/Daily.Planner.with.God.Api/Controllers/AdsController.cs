using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Daily.Planner.with.God.Application.Interfaces;
using Daily.Planner.with.God.Domain.Entities;
using Daily.Planner.with.God.Common;
using Microsoft.AspNetCore.Authorization;
using Daily.Planner.with.God.Application.Dtos;

namespace Daily.Planner.with.God.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AdsController : ControllerBase
    {
        private readonly IAdsService _adsService;
        private readonly IUserService _userService;
        private readonly IRolService _roleService;

        public AdsController(IAdsService adsService, IUserService userService, IRolService roleService)
        {
            _adsService = adsService;
            _userService = userService;
            _roleService = roleService;
        }

        [HttpGet]
        public async Task<ActionResult<ResponseMessage<List<AdsInfoDto>>>> GetAds()
        {
            if (Request.Headers.TryGetValue("UserId", out var currentUserId))
            {
                Guid userId = Guid.Parse(currentUserId.ToString());
                var validAccess = await _userService.ValidAccessPermissionAsync(userId, ["CSNW"]);
                if (!validAccess)
                {
                    return Unauthorized();
                }

                var userData = await _userService.GetUserAsync(userId);

                if (userData.Success)
                {
                    var adsData = await _adsService.GetAdsAsync(userId);
                    if (adsData.Success)
                    {
                        var adsResponse = new List<AdsInfoDto>();
                        ResponseMessage<User?> userAdData = new ResponseMessage<User?>();
                        foreach (var ads in adsData.Data)
                        {
                            if (ads.UserCreatedId != null)
                            {
                                userAdData = await _userService.GetUserAsync((Guid)ads.UserCreatedId);
                            }

                            var ad = new AdsInfoDto()
                            {
                                Id = ads.Id,
                                Content = ads.Content,
                                EndDate = ads.EndDate,
                                IsGlobal = ads.IsGlobal,
                                StartDate = ads.StartDate,
                                Title = ads.Title,
                                UserCreatedId = ads.UserCreatedId,
                                UserCreatedName = ads.UserCreatedId != null ? userAdData.Data.FirstName + " " + userAdData.Data.LastName : ""
                            };

                            adsResponse.Add(ad);
                        }

                        var response = new ResponseMessage<List<AdsInfoDto>>()
                        {
                            Data = adsResponse,
                            Message = adsData.Message,
                            Success = adsData.Success,
                        };

                        return Ok(response);
                    }

                }

            }

            return Unauthorized();


        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseMessage<Ads?>>> GetAd(Guid id)
        {
            if (Request.Headers.TryGetValue("UserId", out var currentUserId))
            {
                Guid userId = Guid.Parse(currentUserId.ToString());
                var validAccess = await _userService.ValidAccessPermissionAsync(userId, ["CSNW"]);
                if (!validAccess)
                {
                    return Unauthorized();
                }
                var response = await _adsService.GetAdAsync(id);
                if (response.Success)
                {
                    return Ok(response);
                }
                return NotFound(response);
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPost]
        public async Task<ActionResult<ResponseMessage<Ads>>> CreateAd(Ads ad)
        {
            if (Request.Headers.TryGetValue("UserId", out var currentUserId))
            {
                Guid userId = Guid.Parse(currentUserId.ToString());
                var validAccess = await _userService.ValidAccessPermissionAsync(userId, ["CCNW", "CSUS"]);
                if (!validAccess)
                {
                    return Unauthorized();
                }

                var userData = await _userService.GetUserAsync(userId);

                if (userData.Success)
                {
                    var roleData = await _roleService.GetRoleAsync(userData.Data.RoleId);

                    if (roleData.Success && (roleData.Data.Name == "Admin" || roleData.Data.Name == "Moderador" || roleData.Data.Name == "Pastor"))
                    {
                        ad.IsGlobal = true;
                    }
                    else
                    {
                        ad.IsGlobal = false;
                    }


                    ad.UserCreated = userData.Data;
                    ad.UserCreatedId = userData.Data.Id;

                    var response = await _adsService.CreateAdAsync(ad);
                    if (response.Success)
                    {
                        return CreatedAtAction(nameof(GetAd), new { id = response.Data.Id }, response);
                    }
                }
            }

            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseMessage<bool>>> UpdateAd(Ads ad)
        {
            if (Request.Headers.TryGetValue("UserId", out var currentUserId))
            {
                Guid userId = Guid.Parse(currentUserId.ToString());
                var validAccess = await _userService.ValidAccessPermissionAsync(userId, ["CUNW"]);
                if (!validAccess)
                {
                    return Unauthorized();
                }

                var response = await _adsService.UpdateAdAsync(ad);
                if (response.Success)
                {
                    return Ok(response);
                }
                return BadRequest(response);
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseMessage<bool>>> DeleteAd(Guid id)
        {
            if (Request.Headers.TryGetValue("UserId", out var currentUserId))
            {
                Guid userId = Guid.Parse(currentUserId.ToString());
                var validAccess = await _userService.ValidAccessPermissionAsync(userId, ["CDNW"]);
                if (!validAccess)
                {
                    return Unauthorized();
                }

                var response = await _adsService.DeleteAdAsync(id);
                if (response.Success)
                {
                    return Ok(response);
                }
                return BadRequest(response);
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}

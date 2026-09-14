using Microsoft.AspNetCore.Mvc;
using ProfileService.DTOs;
using ProfileService.Interfaces;

namespace ProfileService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProfileController : ControllerBase
{
    private readonly IProfileService _profileService;

    public ProfileController(
        IProfileService profileService)
    {
        _profileService = profileService;
    }

    [HttpGet("{customerId}")]
    public async Task<IActionResult> GetProfile(
        int customerId)
    {
        var result =
            await _profileService.GetProfileAsync(customerId);

        if (result == null)
        {
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPut("{customerId}")]
    public async Task<IActionResult> UpdateProfile(
        int customerId,
        UpdateProfileDto dto)
    {
        var result =
            await _profileService.UpdateProfileAsync(
                customerId,
                dto);

        if (result == null)
        {
            return NotFound();
        }

        return Ok(result);
    }
}

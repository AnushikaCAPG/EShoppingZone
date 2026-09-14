using Microsoft.EntityFrameworkCore;
using ProfileService.Data;
using ProfileService.DTOs;
using ProfileService.Interfaces;
using ProfileService.Models;

namespace ProfileService.Services;

public class ProfileService : IProfileService
{
    private readonly ApplicationDbContext _context;

    public ProfileService(
        ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<CustomerProfile?> GetProfileAsync(
        int customerId)
    {
        return await _context.Profiles
            .FirstOrDefaultAsync(
                x => x.CustomerId == customerId);
    }

    public async Task<CustomerProfile?> UpdateProfileAsync(
        int customerId,
        UpdateProfileDto dto)
    {
        var profile = await _context.Profiles
            .FirstOrDefaultAsync(
                x => x.CustomerId == customerId);

        if (profile == null)
        {
            return null;
        }

        profile.Phone = dto.Phone;
        profile.Address = dto.Address;

        await _context.SaveChangesAsync();

        return profile;
    }
}

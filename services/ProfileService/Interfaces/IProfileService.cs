using ProfileService.DTOs;
using ProfileService.Models;

namespace ProfileService.Interfaces;

public interface IProfileService
{
    Task<CustomerProfile?> GetProfileAsync(int customerId);

    Task<CustomerProfile?> UpdateProfileAsync(
        int customerId,
        UpdateProfileDto dto);
}

using AuthService.DTOs;

namespace AuthService.Interfaces;

public interface IAuthService
{
    Task<LoginResponseDto?> LoginAsync(
        LoginRequestDto loginRequest);

    Task<bool> RegisterAsync(
        RegisterRequestDto registerRequest);
}
using AuthService.Data;
using AuthService.DTOs;
using AuthService.Interfaces;
using AuthService.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthService.Services;

public class AuthService : IAuthService
{
    private readonly ApplicationDbContext _context;
    private readonly IConfiguration _configuration;
    private readonly IEmailService _emailService;

    public AuthService(
        ApplicationDbContext context,
        IConfiguration configuration,
        IEmailService emailService)
    {
        _context = context;
        _configuration = configuration;
        _emailService = emailService;
    }

    public async Task<LoginResponseDto?> LoginAsync(
        LoginRequestDto loginRequest)
    {
        var customer = await _context.Customers
            .Include(c => c.Role)
            .FirstOrDefaultAsync(
                x => x.Email == loginRequest.Email);

        if (customer == null)
        {
            return null;
        }

        bool isPasswordValid =
            BCrypt.Net.BCrypt.Verify(
                loginRequest.Password,
                customer.PasswordHash);

        if (!isPasswordValid)
        {
            return null;
        }

        var claims = new[]
        {
            new Claim(
                ClaimTypes.Email,
                customer.Email),

            new Claim(
                ClaimTypes.Role,
                customer.Role?.RoleName ?? "Customer")
        };

        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(
                _configuration["Jwt:Key"]!));

        var credentials =
            new SigningCredentials(
                key,
                SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddHours(2),
            signingCredentials: credentials);

        return new LoginResponseDto
        {
            Token = new JwtSecurityTokenHandler()
                .WriteToken(token),

            Email = customer.Email,

            Role = customer.Role?.RoleName ?? "Customer"
        };
    }

    public async Task<bool> RegisterAsync(
        RegisterRequestDto registerRequest)
    {
        var existingCustomer = await _context.Customers
            .FirstOrDefaultAsync(
                x => x.Email == registerRequest.Email);

        if (existingCustomer != null)
        {
            return false;
        }

        var customer = new Customer
        {
            FirstName = registerRequest.FirstName,
            LastName = registerRequest.LastName,
            Email = registerRequest.Email,
            PasswordHash =
                BCrypt.Net.BCrypt.HashPassword(
                    registerRequest.Password),
            Phone = registerRequest.Phone,
            RoleId = 1
        };

        _context.Customers.Add(customer);

        var rowsAffected =
            await _context.SaveChangesAsync();

        if (rowsAffected > 0)
        {
            try
            {
                await _emailService.SendEmailAsync(
                    "anushikachaubey@gmail.com",
                    "New Customer Registration",
                    $"Customer {customer.FirstName} {customer.LastName} registered with email {customer.Email}");
            }
            catch
            {
            }

            return true;
        }

        return false;
    }
}

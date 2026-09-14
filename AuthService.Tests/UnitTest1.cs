using AuthService.DTOs;

namespace AuthService.Tests;

public class RegisterRequestDtoTests
{
    [Test]
    public void RegisterRequestDto_Email_Should_Be_Assigned_Correctly()
    {
        var dto = new RegisterRequestDto
        {
            Email = "anushika@test.com"
        };

        Assert.That(dto.Email, Is.EqualTo("anushika@test.com"));
    }

    [Test]
    public void RegisterRequestDto_FirstName_Should_Be_Assigned_Correctly()
    {
        var dto = new RegisterRequestDto
        {
            FirstName = "Anushika"
        };

        Assert.That(dto.FirstName, Is.EqualTo("Anushika"));
    }

    [Test]
    public void LoginRequestDto_Email_Should_Be_Assigned_Correctly()
    {
        var dto = new LoginRequestDto
        {
            Email = "login@test.com"
        };

        Assert.That(dto.Email, Is.EqualTo("login@test.com"));
    }

    [Test]
    public void LoginRequestDto_Password_Should_Be_Assigned_Correctly()
    {
        var dto = new LoginRequestDto
        {
            Password = "Password123"
        };

        Assert.That(dto.Password, Is.EqualTo("Password123"));
    }
}

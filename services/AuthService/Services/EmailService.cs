using AuthService.Interfaces;

namespace AuthService.Services;

public class EmailService : IEmailService
{
    public async Task SendEmailAsync(
        string toEmail,
        string subject,
        string body)
    {
        await Task.CompletedTask;
    }
}

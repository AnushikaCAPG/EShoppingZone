namespace AuthService.Models;

public class Merchant
{
    public int MerchantId { get; set; }

    public string MerchantName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public int RoleId { get; set; }

    public bool IsActive { get; set; } = true;

    public Role? Role { get; set; }
}
using System.ComponentModel.DataAnnotations;

namespace ProfileService.DTOs;

public class UpdateProfileDto
{
    [Required]
    public string Phone { get; set; } = string.Empty;

    [Required]
    public string Address { get; set; } = string.Empty;
}

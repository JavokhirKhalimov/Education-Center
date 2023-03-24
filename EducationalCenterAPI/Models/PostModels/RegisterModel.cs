using System.ComponentModel.DataAnnotations;

namespace EducationalCenterAPI.Models.PostModels;
public class RegisterModel
{

    [Required]
    public string FIO { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Required, MinLength(5), MaxLength(32)]
    public string Username { get; set; }
    [Required, MinLength(4)]
    public string Password { get; set; }
    

    [Required, Phone]
    public string PhoneNumber { get; set; }

}

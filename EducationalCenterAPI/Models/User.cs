using EducationalCenterAPI.Models.PostModels;

namespace EducationalCenterAPI.Models;

public class User : RegisterModel
{
    public int UserId { get; set; }

    public string? UserToken { get; set; }
}

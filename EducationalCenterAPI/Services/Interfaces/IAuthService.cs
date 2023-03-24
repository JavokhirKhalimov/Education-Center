using EducationalCenterAPI.Models;
using EducationalCenterAPI.Models.PostModels;

namespace EducationalCenterAPI.Services.Interfaces;

public interface IAuthService
{
    Task<User> RegisterAsync(RegisterModel user);
    Task<User> LoginAsync(LoginModel login);

    Task<User> GetUserByToken(string token);
}

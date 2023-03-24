using EducationalCenterAPI.Data;
using EducationalCenterAPI.Models;
using EducationalCenterAPI.Models.PostModels;
using EducationalCenterAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace EducationalCenterAPI.Services;

public class AuthService : IAuthService
{
    private readonly DataContext _db;
    public AuthService(DataContext db)
    {
        _db = db;
    }

    public async Task<User> GetUserByToken(string token)
    {
        var user = await _db.Users
            .FirstOrDefaultAsync(user => user.UserToken == token);
        if (user == null)
            throw new UnauthorizedAccessException("Foydalanuvchi tizimga kirmagan! " +
                "Yoki ayni vaqtda boshqa foydalanuvchi bu accountdan foydalamoqda!");
        return user;
    }

    public async Task<User> LoginAsync(LoginModel login)
    {
        var user = await _db.Users
            .FirstOrDefaultAsync(user => user.Username == login.Username);
        if (user == null)
            throw new UnauthorizedAccessException("Login yoki parol xato");
        if (!IsPasswordValid(user.Password, login.Password))
            throw new UnauthorizedAccessException("Login yoki parol xato");
        user.UserToken = Convert.ToBase64String(Encoding.UTF8.GetBytes(Guid.NewGuid().ToString()));
        await _db.SaveChangesAsync();
        return user;
    }

    public async Task<User> RegisterAsync(RegisterModel registerModel)
    {
        User user = new User();
        user.Email = registerModel.Email;
        user.PhoneNumber = registerModel.PhoneNumber;
        user.FIO = registerModel.FIO;
        user.Username = registerModel.Username;
        user.Password = ToPasswordHash(registerModel.Password);
        user.UserToken = Convert.ToBase64String(Encoding.UTF8.GetBytes(Guid.NewGuid().ToString()));

        await _db.Users.AddAsync(user);
        await _db.SaveChangesAsync();
        return user;
    }

    private static string ToPasswordHash(string password)
    {
        const int HASH_SIZE = 64;
        const int ITERATIONS = 1000;

        var salt = "bu mening maxfiy kalid so'zim";
        Byte[] byteValue = Encoding.UTF8.GetBytes(salt);

        var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, byteValue, ITERATIONS);
        var hashPassword = ByteArrayToString(rfc2898DeriveBytes.GetBytes(HASH_SIZE));
        return hashPassword;
    }
    private static string ByteArrayToString(byte[] ba)
    {
        StringBuilder hex = new StringBuilder(ba.Length * 2);
        foreach (byte b in ba)
            hex.AppendFormat("{0:x2}", b);
        return hex.ToString();
    }
    private static bool IsPasswordValid(string passwordHash, string password)
    {
        return passwordHash == ToPasswordHash(password);
    }
}

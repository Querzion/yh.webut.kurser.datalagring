using System.Security.Cryptography;

namespace Business.Helpers;

public static class PasswordGenerator
{
    public static (string securePassword, string securityKey) Generate(string password)
    {
        if (string.IsNullOrEmpty(password))
            throw new ArgumentException("Password cannot be null or empty.", nameof(password));

        var salt = GenerateSalt();
        
        string securePassword = HashPassword(password, salt);
        string securityKey = Convert.ToBase64String(salt);
        
        return (securePassword, securityKey);
    }

    private static byte[] GenerateSalt(int size = 16)
    {
        var salt = new byte[size];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(salt);
        }
        return salt;
    }

    private static string HashPassword(string password, byte[] salt)
    {
        using var rfc2898 = new Rfc2898DeriveBytes(password, salt, 10000, HashAlgorithmName.SHA256);
        byte[] hash = rfc2898.GetBytes(32);
        return Convert.ToBase64String(hash);
    }
}
using System.Security.Cryptography;
using System.Text;

namespace RLZZ.Timesheet.Securities;

public class PasswordHasher
{
    public static string HashPassword(string password, string salt)
    {
        // Generate a random salt
        byte[] saltArray = Encoding.UTF8.GetBytes(salt);
        
        using (var rng = new RNGCryptoServiceProvider())
        {
            rng.GetBytes(saltArray);
        }

        // Derive the hash using PBKDF2
        byte[] passwordArray = Encoding.UTF8.GetBytes(password);
        using (var pbkdf2 = new Rfc2898DeriveBytes(passwordArray, saltArray, 10000, HashAlgorithmName.SHA256))
        {
            byte[] hash = pbkdf2.GetBytes(32); // 32 bytes hash
            
            // Combine salt and hash for storage
            byte[] result = new byte[salt.Length + hash.Length];
            Array.Copy(saltArray, 0, result, 0, saltArray.Length);
            Array.Copy(hash, 0, result, saltArray.Length, hash.Length);
            
            return Convert.ToBase64String(result);
        }
    }

    public static bool VerifyPassword(string password, string salt, string storedHash)
    {
        byte[] result = Convert.FromBase64String(storedHash);
        byte[] saltArray = Encoding.UTF8.GetBytes(salt);
        Array.Copy(result, 0, saltArray, 0, 24);
        
        byte[] passwordArray = Encoding.UTF8.GetBytes(password);
        using (var pbkdf2 = new Rfc2898DeriveBytes(passwordArray, saltArray, 10000, HashAlgorithmName.SHA256))
        {
            byte[] hash = pbkdf2.GetBytes(32);
            byte[] storedHashArray = new byte[32];
            Array.Copy(result, 24, storedHashArray, 0, 32);
            
            return CryptographicOperations.FixedTimeEquals(hash, storedHashArray);
        }
    }
}
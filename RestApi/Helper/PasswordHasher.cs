using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace RestApi.Helper;

public static class PasswordHasher
{
    public static string HashPassword(string password)
    {
        var salt = _generateSalt(password);
        var hashedPass = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password, 
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 100000,
            numBytesRequested: 256 / 8));

        return hashedPass;
    }

    private static byte[] _generateSalt(string password)
    {
        var hashedPassword  = SHA256.HashData(Encoding.UTF8.GetBytes(password));
        var chunks = hashedPassword.Chunk(hashedPassword.Length/2);
        var salt = new List<byte>();
        foreach (var chunk in chunks)
        {
        
            salt.AddRange(chunk.Reverse());
        }

        return salt.ToArray();
    }
    
    public static bool CompareHashAndPassword(string hash, string password)
    {
        return hash == HashPassword(password);
    }
}
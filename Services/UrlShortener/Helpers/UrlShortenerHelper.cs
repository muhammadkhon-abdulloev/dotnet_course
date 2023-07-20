using System.Text;

namespace UrlShortener.Helpers;

public static class UrlShortenerHelper
{
    private const string Alphabet = "abcdfghjkmnpqrstvwxyzABCDFGHJKLMNPQRSTVWXYZ-_0123456789";
    private static readonly int Base = Alphabet.Length;

    public static string GenerateNewShort(int l)
    {
        var res = new List<int>();
        var sb = new StringBuilder();
        if (l < Base)
        {
            return Alphabet[l].ToString();
        }

        while (l > Base)
        {
            var c = l % Base;
            l /= Base;
            
            res.Add(c);
            res.Add(l);
        }

        for (var i = res.Count - 1; i >= 0; i--)
            sb.Append(Alphabet[i]);
        
        return sb.ToString();
    }
}
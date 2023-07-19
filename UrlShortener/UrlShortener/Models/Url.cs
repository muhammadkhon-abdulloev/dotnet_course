using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace UrlShortener.Models;

[Index("ShortUrl", IsUnique = true, Name = "ShortUrlIndex")]
public class Url
{
    public required string LongUrl { get; set; }
    [Key]
    public required string ShortUrl { get; set; }
}
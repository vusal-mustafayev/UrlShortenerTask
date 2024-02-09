namespace UrlShortener.Data.Entities;
public class UrlEntity : BaseEntity
{
    public string LongUrl { get; set; } = null!;

    public string ShortAlias { get; set; } = null!;
}
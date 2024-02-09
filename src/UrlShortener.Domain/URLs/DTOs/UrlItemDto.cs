namespace UrlShortener.Domain.URLs.DTOs;

public class UrlItemDto
{
    [DisplayName("Long URL ")]
    public string LongUrl { get; set; } = null!;

    [DisplayName("Shortened URL ")]
    public string ShortenedUrl { get; set; } = null!;

    public string ShortAlias { get; set; } = null!;

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<UrlEntity, UrlItemDto>();
        }
    }
}
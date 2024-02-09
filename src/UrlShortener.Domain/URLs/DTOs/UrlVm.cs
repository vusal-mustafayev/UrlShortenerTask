using UrlShortener.Domain.URLs.Commands.CreateUrlItem;

namespace UrlShortener.Domain.URLs.DTOs;

public class UrlVm
{
    public CreateUrlItemCommand? CreateUrlCommand { get; set; }
    public UrlItemDto? ShortenedUrlDetails { get; set; }
}

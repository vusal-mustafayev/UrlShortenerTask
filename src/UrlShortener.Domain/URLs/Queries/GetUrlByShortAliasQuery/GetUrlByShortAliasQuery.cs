namespace UrlShortener.Domain.URLs.Queries.GetUrlByShortenedUrlQuery;

public class GetUrlByShortAliasQuery : IRequest<UrlItemDto>
{
    public string ShortAlias { get; set; } = null!;

    internal class GetUrlByShortAliasQueryHandler(
        IMapper mapper,
        IUrlRepository repo)
        : IRequestHandler<GetUrlByShortAliasQuery, UrlItemDto>
    {
        public async Task<UrlItemDto> Handle(GetUrlByShortAliasQuery request, CancellationToken cancellationToken)
        {
            var entity = await repo.GetUrlByShortAliasAsync(request.ShortAlias, cancellationToken);

            Guard.Against.NotFound(request.ShortAlias, entity);

            return mapper.Map<UrlItemDto>(entity);
        }
    }
}
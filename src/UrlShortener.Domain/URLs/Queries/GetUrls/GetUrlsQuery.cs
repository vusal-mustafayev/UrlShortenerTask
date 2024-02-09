namespace UrlShortener.Domain.URLs.Queries.GetUrlsWithPagination;

public class GetUrlsQuery : IRequest<List<UrlItemDto>>
{
    internal class GetUrlsQueryHandler(IMapper mapper,
    IUrlRepository repo) : IRequestHandler<GetUrlsQuery, List<UrlItemDto>>
    {
        public async Task<List<UrlItemDto>> Handle(GetUrlsQuery request, CancellationToken cancellationToken)
        {
            var urls = await repo.GetAllAsync(cancellationToken);  

            return mapper.Map<List<UrlItemDto>>(urls);
        }
    }
}
namespace UrlShortener.Data.Repositories;

public interface IUrlRepository
{       
    Task<UrlEntity?> GetUrlByShortAliasAsync(string shortAlias, CancellationToken cancellationToken);

    Task InsertAsync(UrlEntity url, CancellationToken cancellationToken);

    Task<List<UrlEntity>> GetAllAsync(CancellationToken cancellationToken);
}
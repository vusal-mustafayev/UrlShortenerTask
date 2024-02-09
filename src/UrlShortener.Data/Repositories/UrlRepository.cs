namespace UrlShortener.Data.Repositories;

public class UrlRepository : IUrlRepository
{
    private readonly IMongoCollection<UrlEntity> _urlCollection;

    public UrlRepository(ApplicationDbContext dbContext)
    {
        _urlCollection = dbContext.Urls;
    }

    public async Task<UrlEntity?> GetUrlByShortAliasAsync(string shortAlias, CancellationToken cancellationToken)
    {
        return await _urlCollection.Find(x => x.ShortAlias == shortAlias).FirstOrDefaultAsync(cancellationToken);
    }

    public async Task InsertAsync(UrlEntity url, CancellationToken cancellationToken)
    {
        await _urlCollection.InsertOneAsync(url, null, cancellationToken);
    }

    public async Task<List<UrlEntity>> GetAllAsync(CancellationToken cancellationToken)
    {        
        return await _urlCollection.Find(_ => true).ToListAsync(cancellationToken);
    }
}

namespace UrlShortener.Data.DbContexts;

public class ApplicationDbContext
{
    public ApplicationDbContext(IOptions<MongoDbSettings> settings)
    {
        var client = new MongoClient(settings.Value.ConnectionString);
        var database = client.GetDatabase(settings.Value.DatabaseName);
        Urls = database.GetCollection<UrlEntity>(settings.Value.CollectionName);
    }

    public IMongoCollection<UrlEntity> Urls { get; }
}
namespace UrlShortener.Data;

public static class ConfigureServices
{
    public static IServiceCollection AddDataServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<MongoDbSettings>(options =>
        {
            configuration.GetSection("DatabaseSettings").Bind(options);
        });            

        services.AddScoped<IUrlRepository, UrlRepository>();
        services.AddSingleton<ApplicationDbContext>();

        return services;
    }
}
namespace UrlShortener.Domain.URLs.Commands.CreateUrlItem;

public record CreateUrlItemCommand : IRequest<string>
{
    [DisplayName("Long Url")]
    public string LongUrl { get; set; } = null!;

    internal class CreateUrlItemCommandHandler(
        IUrlRepository repo,
        IAliasGenerator tokenGenerator) : IRequestHandler<CreateUrlItemCommand, string>
    {
        public async Task<string> Handle(CreateUrlItemCommand request, CancellationToken cancellationToken)
        {
            var entity = new UrlEntity
            {
                LongUrl = request.LongUrl,
                ShortAlias = tokenGenerator.Generate()
            };

            await repo.InsertAsync(entity, cancellationToken);

            return entity.ShortAlias;
        }
    }
}
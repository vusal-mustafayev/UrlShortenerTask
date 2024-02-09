namespace UrlShortener.Domain.Tests.URLs.CommandsTests;

public class CreateUrlItemCommandHandlerTests
{
    [Fact]
    public async Task Handle_ValidRequest_ReturnsShortenedUrl()
    {
        // Arrange      
        var mockRepo = Substitute.For<IUrlRepository>();
        var aliasGenerator = Substitute.For<IAliasGenerator>();        

        var request = new CreateUrlItemCommand
        {
            LongUrl = "https://www.google.com/"
        };

        var cancellationToken = new CancellationToken();

        var generatedAlias = "abc123";        

        aliasGenerator.Generate().Returns(generatedAlias);       
                
        var entity = new UrlEntity
        {
            LongUrl = request.LongUrl,
            ShortAlias = generatedAlias
        };
        
        var handler = new CreateUrlItemCommand.CreateUrlItemCommandHandler(mockRepo, aliasGenerator);

        // Act
        var result = await handler.Handle(request, cancellationToken);

        // Assert
        result.ShouldNotBeNull();
        result.ShouldSatisfyAllConditions(           
            () => result.ShouldBe(generatedAlias)
        );

        await mockRepo.Received(1).InsertAsync(Arg.Is<UrlEntity>(x =>
            x.LongUrl == request.LongUrl &&
            x.ShortAlias == generatedAlias), cancellationToken);
    }
}
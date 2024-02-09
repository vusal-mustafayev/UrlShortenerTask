namespace UrlShortener.Domain.Tests.URLs.QueriesTests;

public class GetUrlByShortenedUrlQueryHandlerTests
{

    [Fact]
    public async Task Handle_ValidShortenedUrl_ReturnsUrlItemDto()
    {
        // Arrange
        var alias = "abc123";       
        var cancellationToken = new CancellationToken();
        var mockMapper = Substitute.For<IMapper>();
        var mockRepo = Substitute.For<IUrlRepository>();
        
        var expectedUrlItem = new UrlEntity();
        var expectedDto = new UrlItemDto();

        mockRepo.GetUrlByShortAliasAsync(alias, cancellationToken).Returns(expectedUrlItem);
        mockMapper.Map<UrlItemDto>(expectedUrlItem).Returns(expectedDto);       

        var queryHandler = new GetUrlByShortAliasQuery.GetUrlByShortAliasQueryHandler(mockMapper, mockRepo);
        var query = new GetUrlByShortAliasQuery { ShortAlias = alias };

        // Act
        var result = await queryHandler.Handle(query, cancellationToken);

        // Assert
        Assert.Equal(expectedDto, result);
    }


    [Fact]
    public async Task Handle_InvalidShortenedUrl_ThrowsNotFoundException()
    {
        var alias = "invalidUrl"; 
        var cancellationToken = new CancellationToken();
        var mapper = Substitute.For<IMapper>();
        var mockRepo = Substitute.For<IUrlRepository>();        

        mockRepo.GetUrlByShortAliasAsync(alias, cancellationToken).Returns((UrlEntity?)null);

        var queryHandler = new GetUrlByShortAliasQuery.GetUrlByShortAliasQueryHandler(mapper, mockRepo);
        var query = new GetUrlByShortAliasQuery { ShortAlias = alias };
                
        await Assert.ThrowsAsync<NotFoundException>(async () =>
        {
            await queryHandler.Handle(query, cancellationToken);
        });
    }
}
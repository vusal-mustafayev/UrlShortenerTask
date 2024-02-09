namespace UrlShortener.Domain.Tests.URLs.CommandsTests;

public class CreateUrlItemCommandValidatorTests
{
    private CreateUrlItemCommandValidator _validator;

    public CreateUrlItemCommandValidatorTests()
    {
        _validator = new CreateUrlItemCommandValidator();
    }

    [Fact]
    public void Validate_ValidLongUrl_ShouldNotHaveValidationError()
    {
        // Arrange
        var model = new CreateUrlItemCommand { LongUrl = "https://www.google.com/" };

        // Act
        var result = _validator.TestValidate(model);

        // Assert
        result.ShouldNotHaveValidationErrorFor(url => url.LongUrl);
    }

    [Fact]
    public void Validate_EmptyLongUrl_ShouldHaveValidationError()
    {
        // Arrange
        var invalidCommand = new CreateUrlItemCommand { LongUrl = string.Empty };

        // Act
        var result = _validator.TestValidate(invalidCommand);

        // Assert
        result.ShouldHaveValidationErrorFor(url => url.LongUrl)
            .WithErrorMessage("'Long Url' must not be empty.");
    }

    [Fact]
    public void Validate_InvalidLongUrl_ShouldHaveValidationError()
    {
        // Arrange
        var invalidCommand = new CreateUrlItemCommand { LongUrl = "ss" };

        // Act
        var result = _validator.TestValidate(invalidCommand);

        // Assert
        result.ShouldHaveValidationErrorFor(url => url.LongUrl)
            .WithErrorMessage("Invalid URL. Please add a valid URL");
    }
}
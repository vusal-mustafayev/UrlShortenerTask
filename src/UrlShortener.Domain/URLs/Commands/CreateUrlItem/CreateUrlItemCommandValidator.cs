namespace UrlShortener.Domain.URLs.Commands.CreateUrlItem;

public class CreateUrlItemCommandValidator : AbstractValidator<CreateUrlItemCommand>
{
    public CreateUrlItemCommandValidator()
    {
        RuleFor(url => url.LongUrl)
            .NotEmpty()
            .Must(BeValidUrl)
                .WithMessage("Invalid URL. Please add a valid URL");       
    }

    private static bool BeValidUrl(string arg)
    {
        return Uri.TryCreate(arg, UriKind.Absolute, out _);
    }
}
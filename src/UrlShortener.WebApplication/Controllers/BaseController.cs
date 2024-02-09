namespace UrlShortener.WebApplication.Controllers;
public class BaseController : Controller
{
    private ISender _mediator = null!;

    protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();
}
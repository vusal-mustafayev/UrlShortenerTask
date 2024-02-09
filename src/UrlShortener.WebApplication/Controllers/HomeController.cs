namespace UrlShortener.WebApplication.Controllers;

public class HomeController : BaseController
{    
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateUrl(CreateUrlItemCommand createUrlCommand, CancellationToken ct)
    {
        if (ModelState.IsValid)
        {
            string shortAlias = await Mediator.Send(createUrlCommand, ct);

            return RedirectToAction(nameof(GetUrl), new { shortAlias });
        }

        var vm = new UrlVm
        {
            CreateUrlCommand = createUrlCommand
        };
        return View(nameof(Index), vm);
    }

    [HttpGet]
    public async Task<IActionResult> GetUrl(string shortAlias)
    {
        var _baseUrl = $"{Request.Scheme}{Uri.SchemeDelimiter}{Request.Host}/";

        var vm = new UrlVm
        {
            ShortenedUrlDetails = await Mediator.Send(new GetUrlByShortAliasQuery { ShortAlias = shortAlias })
        };

        vm.ShortenedUrlDetails.ShortenedUrl = $"{_baseUrl}{vm.ShortenedUrlDetails.ShortAlias}";

        return View(nameof(Index), vm);
    }

    [HttpGet]
    public async Task<IActionResult> ShowAllUrls(CancellationToken ct)
    {
        var _baseUrl = $"{Request.Scheme}{Uri.SchemeDelimiter}{Request.Host}/";

        var response = await Mediator.Send(new GetUrlsQuery(), ct);

        response.ForEach(l => l.ShortenedUrl = $"{_baseUrl}{l.ShortAlias}");

        return View(response);
    }

    [HttpGet("{shortAlias}")]
    public async Task<IActionResult> RedirectToUrl(string shortAlias, CancellationToken ct)
    {      
        var url = await Mediator.Send(new GetUrlByShortAliasQuery { ShortAlias = shortAlias }, ct);

        return Redirect(url.LongUrl);
    }
}
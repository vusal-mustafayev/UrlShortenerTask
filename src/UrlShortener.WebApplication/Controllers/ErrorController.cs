namespace UrlShortener.WebApplication.Controllers;

public class ErrorController : Controller
{
    public IActionResult Error()
    {
        var error = new ErrorViewModel
        {
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
        };

        var exceptionHandlerPathFeature =
            HttpContext.Features.Get<IExceptionHandlerPathFeature>();

        if (exceptionHandlerPathFeature?.Error is NotFoundException)
        {
            error.ExceptionMessage = exceptionHandlerPathFeature.Error.Message;
        }
        else
        {
            error.ExceptionMessage = "Oops! Something went wrong on our end. We're currently experiencing technical difficulties, but our team is working hard to fix it. Please try again later.";
        }        

        return View(error);
    }
}
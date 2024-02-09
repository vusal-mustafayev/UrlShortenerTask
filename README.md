# URL Shortener

The URL Shortener is a web application that allows users to shorten long URLs into short, manageable links.

## Features

- Shorten long URLs into short, unique urls
- Redirect users to the original URL when they access the short link
- View a list of all shortened URLs with their original and short URLs

# Technologies

- [ASP.NET Core 8](https://learn.microsoft.com/en-us/aspnet/core/introduction-to-aspnet-core?view=aspnetcore-8.0) 
- [MongoDB](https://www.mongodb.com)
- [MediatR](https://github.com/jbogard/MediatR)
- [CQRS](https://docs.microsoft.com/en-us/azure/architecture/patterns/cqrs)
- [AutoMapper](https://automapper.org/)
- [FluentValidation](https://docs.fluentvalidation.net/en/latest/)
- [Serilog](https://serilog.net/) 
- [XUnit](https://xunit.net/)
- [Shouldly](https://docs.shouldly.org/documentation/getting-started/)
- [NSubstitute](https://nsubstitute.github.io/) 

## Task Description 
>Build a URL shortening service like TinyURL. This service will provide short aliases redirecting to long URLs.

## Getting Started

### Installation

1. Clone the repository
2. Open the docker destkop
3. Set Docker Compose as a startup project
4. Run the application


### Usage

1. Access the web application in your browser at `(http://localhost:65525/)`
2. Shorten a URL by entering it in the provided input field and clicking the "Make Me Shorter" button.
3. Copy the generated short URL
4. Access the short URL in the browser and get redirected to the original URL.
5. View the list of all shortened URLs and their details on the All Urls page.

# License

This project is licensed with the [MIT license](LICENSE).

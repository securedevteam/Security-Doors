# Security Doors

[![.NET](https://github.com/securedevteam/Security-Doors/actions/workflows/dotnet.yml/badge.svg)](https://github.com/securedevteam/Security-Doors/actions/workflows/dotnet.yml)

The developed set of applications is as close as possible to the IT sphere. The main idea is the transition of people or employees of a certain organization through door controllers using cards of various levels. These applications have a huge number of possibilities: from creating objects (Role, Employee and etc.) to managing all the data in the database. The main application interface is implemented as a web application (MVC) that allows you to log in and use the application in a specific role: administrator, employee and etc. Helper applications are designed as console applications and WebAPI. Registration of door actions occurs through the console application and sends request to the WebAPI, which checks the input data, performs the operation and sends response.

## Application features
1. Main web application (MVC) delimited by specific roles;
2. Web application (WebAPI) for register door actions;
3. Console application for interacting with WebAPI for sending door actions;
4. Console application for database seeding;
5. Registration with sending email letters to confirm;

## Built With
- [N-Layer architecture](https://docs.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/common-web-application-architectures);
- [LINQ](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/) (Language-Integrated Query);
- Manual and [xUnit](https://xunit.net/);
- [ASP.NET Core 5.0](https://docs.microsoft.com/en-us/aspnet/core/);
- [Console application on .NET Core](https://docs.microsoft.com/en-us/dotnet/core/about);
- [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/);
- [Serilog](https://serilog.net/);
- [Automapper](https://automapper.org/);
- [MailKit](https://github.com/myloveCc/NETCore.MailKit);
- [Microsoft Identity](https://docs.microsoft.com/en-us/aspnet/core/security/authentication/identity?view=aspnetcore-5.0&tabs=visual-studio);
- [WebAPI](https://docs.microsoft.com/en-us/aspnet/core/web-api/?view=aspnetcore-5.0) and [Swashbuckle](https://github.com/domaindrivendev/Swashbuckle.AspNetCore/blob/master/README.md);
- [Specification pattern](https://habr.com/ru/post/325280/);

## Authors
- [Mikhail M.](https://mikhailmasny.github.io/) - Architect & .NET Developer;
- [Alexandr G.](https://s207883.github.io/) - Full-stack .NET Developer;

See also the list of [contributors](https://github.com/securedevteam/Security-Doors/graphs/contributors) who participated in this project.

## License
This project is licensed under the MIT License - see the [LICENSE.md](https://github.com/securedevteam/Security-Doors/blob/master/LICENSE) file for details.

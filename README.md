# Security Doors

[![Build Status](https://dev.azure.com/30CTB/Security-Doors/_apis/build/status/securedevteam.Security-Doors?branchName=master)](https://dev.azure.com/30CTB/Security-Doors/_build/latest?definitionId=2&branchName=master)

The developed set of applications is as close as possible to the IT sphere. The main idea is the transition of people or employees of a certain organization through door controllers using cards of various levels. These applications have a huge number of possibilities: from creating objects (Door, Card, Employee, etc.) to managing all the data in the database. The main application interface is implemented as a web application that allows you to register, log in and use the application in a specific role: administrator, moderator, employee or visitor. The auxiliary interfaces developed in the form of the Console App, for the administrators of the complex, allow you to manage the database and display the doorways of employees.

## Application features
1. Web application delimited by specific roles;
2. Console application for interacting with the database for the complex administrator;
3. Console application for fixing doorways;
4. Ability to create data through a console or web application;
5. Display and editing database data through a console or web application;
6. Control of doorways through a console or web application;
7. Sending Email letters to confirm registration;

## Built With
- [N-Layer architecture](https://docs.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/common-web-application-architectures);
- [LINQ](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/) (Language-Integrated Query) - uniform query syntax in C#;
- Manual and [xUnit](https://xunit.net/) testing;
- [ASP.NET Core 2.1](https://docs.microsoft.com/en-us/aspnet/core/?view=aspnetcore-2.1) MVC web-application;
- [Console application on .NET Core](https://docs.microsoft.com/en-us/dotnet/core/about);
- [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/) - data access technology;
- [Microsoft Identity](https://docs.microsoft.com/en-us/aspnet/core/security/authentication/identity?view=aspnetcore-3.1&tabs=visual-studio) - the biggest management system for control users;
- [WebAPI](https://docs.microsoft.com/en-us/aspnet/core/web-api/?view=aspnetcore-3.1) and [Swashbuckle](https://github.com/domaindrivendev/Swashbuckle.AspNetCore/blob/master/README.md);
- [Repository pattern](https://docs.microsoft.com/en-us/aspnet/mvc/overview/older-versions/getting-started-with-ef-5-using-mvc-4/implementing-the-repository-and-unit-of-work-patterns-in-an-asp-net-mvc-application);
- [Git](https://git-scm.com/) - version control system;
- [Trello](https://trello.com/en) - a web-based Kanban-style list-making application;
- [Azure Pipelines](https://azure.microsoft.com/en-us/services/devops/) - continuous integration;

## Authors
- [Mikhail M.](https://mikhailmasny.github.io/) - Architect & .NET Developer;
- [Alexandr G.](https://s207883.github.io/) - Full-stack .NET Developer;

See also the list of [contributors](https://github.com/securedevteam/Security-Doors/graphs/contributors) who participated in this project.

## License
This project is licensed under the MIT License - see the [LICENSE.md](https://github.com/securedevteam/Security-Doors/blob/master/LICENSE) file for details.

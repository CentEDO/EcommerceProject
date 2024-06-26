# E-Commerce Product Listing Application

This is a microservice-based e-commerce application for displaying products by category asynchronously.

WebApplication1 folder is unnecessary, just ignore it :)

## Quick Start

**Prerequisites:** .NET Core 3.1+, Visual Studio 2019+, SQL Server

1. Clone the repo: `(https://github.com/CentEDO/EcommerceProject.git)`
2. Set up database connection strings in `appsettings.json` for both Web and API projects.
3. Run the solution in Visual Studio.

## Database Migration

To apply database migrations, use the Package Manager Console in Visual Studio:

1. Open the Package Manager Console.
2. Select the project containing your DbContext as the Default Project.
3. Run `Add-Migration ExampleMigration` and `Update-Database`. This applies any pending migrations to the database and creates the database if it does not exist.
   
## Features

- Asynchronous product display.
- Category filtering.
- Microservice architecture.

## Architecture

- Frontend: ASP.NET MVC.
- Backend: ASP.NET Web API.

## Contributing

Feel free to contribute! Please open an issue to discuss your ideas.

## License

MIT License. See `LICENSE` for more information.

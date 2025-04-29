using Microsoft.EntityFrameworkCore;//EntityFrameworkCore for database operations
using TodoApi; //Namespace for your application, typically contains your DbContext and models.

var builder = WebApplication.CreateBuilder(args); //Purpose: Initializes the WebApplication builder.This sets up configuration, logging, and dependency injection.



builder.Services.AddControllers(); //Purpose: Registers controller services for the API.

//This tells ASP.NET Core to use MVC-style controllers for handling HTTP requests ([ApiController]).




builder.Services.AddDbContext<DummyDataContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));  // Ensure correct connection string

// Purpose: Configures Entity Framework Core with a SQLite database.

// It injects your custom DummyDataContext into the DI (Dependency Injection) container.

// GetConnectionString("DefaultConnection") reads the connection string from appsettings.json.

var app = builder.Build();


app.UseHttpsRedirection();//Purpose: Redirects all HTTP requests to HTTPS automatically for better security.
app.UseAuthorization();//Purpose: Enables the authorization middleware, which ensures secure access to endpoints if they're protected.
app.MapControllers();//Purpose: Maps controller endpoints to the route system.

app.Run();//Purpose: Starts the web server and begins listening for incoming HTTP requests.

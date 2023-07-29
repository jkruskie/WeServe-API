using Microsoft.EntityFrameworkCore;
using WeServe.Data;

// Create the builder
var builder = WebApplication.CreateSlimBuilder(args);

// Use the WeServeContext
builder.Services.AddDbContext<WeServeContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Use Controllers
builder.Services.AddControllers();

// Build the application
var app = builder.Build();

// Enable all CORS 
app.UseCors(builder => builder
    .AllowAnyHeader()
    .AllowAnyMethod()
    .AllowAnyOrigin()
);

// Use controllers for routing
app.MapControllers();

// Migrate the database if needed
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<WeServeContext>();

    // Create the database if it doesn't exist
    context.Database.EnsureCreated();

    // Migrate the database if needed
    if (context.Database.GetPendingMigrations().Any())
    {
        // Migrate the database
        context.Database.Migrate();
    }
}

// Run the application
app.Run();


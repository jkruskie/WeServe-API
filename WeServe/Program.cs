using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WeServe.Data;
using WeServe.Models;
using WeServe.Repositories;
using WeServe.Services;

// Create the builder
var builder = WebApplication.CreateSlimBuilder(args);

// isProduction is true if the environment is Production
var isProduction = builder.Environment.IsProduction();

// Access token secret to sign JWTs
var accessTokenSecret = builder.Configuration["Jwt:AccessTokenSecret"];

// Use the WeServeContext
builder.Services.AddDbContext<WeServeContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Use Controllers
builder.Services.AddControllers();

// Enable JWT authentication
builder.Services
    // Add the authentication service
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    // Add the JWT bearer service
    .AddJwtBearer(options =>
    {
        // Define access token parameters
        options.TokenValidationParameters = new TokenValidationParameters
        {
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(accessTokenSecret ?? "secret-is-null")),
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            ValidateIssuerSigningKey = true,
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero
        };
        options.SaveToken = true;
    });

// Use Identity
builder.Services
    // Add the identity service
    .AddIdentityCore<User>(options =>
    {
        // Define user email and password requirements
        options.User.RequireUniqueEmail = true;
        options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
        options.Password.RequireDigit = isProduction;
        options.Password.RequireLowercase = isProduction;
        options.Password.RequireNonAlphanumeric = isProduction;
        options.Password.RequireUppercase = isProduction;
        options.Password.RequiredLength = 8;
        options.Password.RequiredUniqueChars = isProduction ? 3 : 0;
    })
    // Add the user store
    .AddEntityFrameworkStores<WeServeContext>();

// In-Memory Database for JWT Refresh Tokens
builder.Services.AddDbContext<TokenRepository>(
    options => options.UseInMemoryDatabase("RefreshTokens")
);

// Singleton Repositories
builder.Services.AddSingleton<TokenGenerator>();
builder.Services.AddSingleton<TokenValidator>();

// Scoped Repositories
builder.Services.AddScoped<TokenRepository>();

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
    // Get the services
    var services = scope.ServiceProvider;

    // Get the context
    var context = services.GetRequiredService<WeServeContext>();

    // Get the token context
    var tokenContext = services.GetRequiredService<TokenRepository>();

    // Create the database if it doesn't exist
    // This will automatically create the database
    // and also run any pending migrations
    await context.Database.EnsureCreatedAsync();

    // Migrate the database if needed
    //if (context.Database.GetPendingMigrations().Any())
    //{
    //    // Migrate the database
    //    await context.Database.MigrateAsync();
    //}

    // Create the database if it doesn't exist
    // This will automatically create the database
    // and also run any pending migrations
    await tokenContext.Database.EnsureCreatedAsync();

    // Migrate the database if needed
    //if (tokenContext.Database.GetPendingMigrations().Any())
    //{
    //    // Migrate the database
    //    await tokenContext.Database.MigrateAsync();
    //}
}

// Run the application
app.Run();


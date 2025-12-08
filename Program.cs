using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add Ocelot configuration
builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);
builder.Services.AddOcelot(builder.Configuration);

var allowedOrigins = builder.Configuration
    .GetSection("Cors:AllowedOrigins")
    .Get<string[]>();


if (allowedOrigins == null || allowedOrigins.Length == 0)
{
    throw new Exception("No allowed origins configured for CORS.");
}

builder.Services.AddCors(options =>
{
    options.AddPolicy("OnlyAllowed", policy =>
    {
        policy.WithOrigins(allowedOrigins)
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});



var app = builder.Build();


app.UseCors("OnlyAllowed");
app.UseOcelot().Wait();

app.Run();

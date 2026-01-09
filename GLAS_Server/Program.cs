using GLAS_Server.Data;
using GLAS_Server.Services;
using GLAS_Server.Services.Interfaces;
var builder = WebApplication.CreateBuilder(new WebApplicationOptions
{
    Args = args,
    WebRootPath = "wwwroot",
    ContentRootPath = Directory.GetCurrentDirectory(),
    ApplicationName = "FitnessTrackerBack"
});

builder.WebHost.UseUrls("http://0.0.0.0:5024");

builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.ListenAnyIP(5024);
});


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddScoped<IUserService, UserService>();




var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? "Host=localhost;Port=5432;Database=glas_db;Username=postgres;Password=12345";
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));



var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();

    app.UseSwaggerUI(options =>
    {

        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = "swagger";
    });
}

app.MapControllers();

app.Run();

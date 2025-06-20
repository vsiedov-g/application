using System.Text.Json.Serialization;
using application.Data;
using application.Repositories;
using application.Repositories.IRepositories;
using application.Services;
using application.Services.IService;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(config.GetConnectionString("DefaultConnection")));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddHttpClient("groqAi", (ServiceProvider, httpClient) => 
{
    httpClient.DefaultRequestHeaders.Add("Authorization", config["Groq:API_key"]);
    httpClient.BaseAddress = new Uri("https://api.groq.com");
});
builder.Services.AddControllers().AddJsonOptions(options => {
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
    });
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IBookingService, BookingService>();
builder.Services.AddScoped<IAIHelperService, AIHelperService>();
builder.Services.AddControllersWithViews();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Configuration.AddEnvironmentVariables();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();

using Extrato.Domain.Configurations;
using Extrato.Services.Services;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// Configuration
builder.Services.Configure<ApiConfig>(builder.Configuration.GetSection("ApiConfig"));
// Services
builder.Services.AddScoped<RequestsHandlerService>();

// Configuration 
builder.Configuration.AddJsonFile("appsettings.json");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

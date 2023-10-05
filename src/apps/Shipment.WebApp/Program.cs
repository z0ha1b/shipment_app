using System.Reflection;
using Shipment.Infrastructure.Data;
using Shipment.WebApp.Extensions;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddControllersWithViews();
builder.Services.AddProjectsServices(configuration);
builder.Services.AddHealthChecks().Services.AddDbContext<OrderContext>();
builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

app.MigrateDatabase<OrderContext>((context, services) =>
{
    var logger = services.GetService<ILogger<OrderContextSeed>>();
    if (logger is not null)
    {
        OrderContextSeed.SeedAsync(context, logger).Wait();
    }
});

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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
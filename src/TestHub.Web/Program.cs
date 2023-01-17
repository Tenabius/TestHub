using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TestHub.ApplicationCore.Entities;
using TestHub.ApplicationCore.Interfaces;
using TestHub.Infrastructure;
using TestHub.Infrastructure.Data;
using TestHub.Web.Configuration;
using TestHub.Web.Interfaces;
using TestHub.Web.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMvc();

builder.Services.AddDbContext<TestHubContext>(options => 
    options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=TestHub"));

builder.Services.AddScoped<IRepository<Test>, TestRepository>();
builder.Services.AddSingleton<IPartialViewResolver, PartialViewResolver>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var scopedProvider = scope.ServiceProvider;
    try
    {
        var context = scopedProvider.GetRequiredService<TestHubContext>();
        await TestHubContextSeed.SeedAsync(context);
    }
    catch (Exception ex)
    {
        app.Logger.LogError(ex, "An error occurred seeding the DB.");
    }
}

app.ConfigurePartialViewResolver();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.MapDefaultControllerRoute();

app.MapRazorPages();

app.Run();

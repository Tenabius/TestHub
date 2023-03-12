using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using TestHub.Core.Entities;
using TestHub.Core.Interfaces;
using TestHub.Infrastructure;
using TestHub.Infrastructure.Data;
using TestHub.Infrastructure.Data.Identity;
using TestHub.Web.Configuration;
using TestHub.Web.Interfaces;
using TestHub.Web.ModelBinders;
using TestHub.Web.Services;

var builder = WebApplication.CreateBuilder(args);

builder.ConfigureApplication();

var connectionString = builder.Configuration.GetConnectionString("TestHubIdentityContextConnection") ?? throw new InvalidOperationException("Connection string 'TestHubIdentityContextConnection' not found.");

// Add services to the container.
builder.Services.AddMvc();

builder.Services.AddDbContext<TestHubContext>(options =>
    options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=TestHub"));

builder.Services.AddDbContext<TestHubIdentityContext>(options =>
    options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=TestHub.Identity"));

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = IdentityConstants.ApplicationScheme;
    options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
})
    .AddCookie(options =>
    {
        options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
        options.SlidingExpiration = true;
        options.LoginPath = "/Identity/Account/Login";
    })
    .AddIdentityCookies(options => { });

//builder.Services.AddAuthentication(options =>
//{
//    options.DefaultScheme = IdentityConstants.ApplicationScheme;
//    options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
//})
//    .AddCookie(options =>
//    {
//        options.LoginPath = "/Index";
//    })
//    .AddIdentityCookies(options => { });

var configuration = builder.Configuration;
builder.Services.AddAuthentication().AddGoogle(googleOptions =>
{
    googleOptions.ClientId = configuration["Authentication:Google:ClientId"]!;
    googleOptions.ClientSecret = configuration["Authentication:Google:ClientSecret"]!;
});

builder.Services.AddIdentityCore<IdentityUser>(options =>
{
    options.Stores.MaxLengthForKeys = 128;
    options.SignIn.RequireConfirmedAccount = true;
})
    .AddDefaultTokenProviders()
    .AddSignInManager()
    .AddEntityFrameworkStores<TestHubIdentityContext>();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddScoped<IRepository<Test>, TestRepository>();
builder.Services.AddSingleton<IPartialViewResolver, PartialViewResolver>();

builder.Services.AddControllers(options =>
    options.ModelBinderProviders.Insert(0, new QuestionFormModelBinderProvider()));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var scopedProvider = scope.ServiceProvider;
    try
    {
        var context = scopedProvider.GetRequiredService<TestHubIdentityContext>();
        context.Database.EnsureDeleted();
        context.Database.Migrate();
        //await TestHubContextSeed.SeedAsync(context);
    }
    catch (Exception ex)
    {
        app.Logger.LogError(ex, "An error occurred seeding the DB.");
    }
}

app.ConfigurePartialViewResolver();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseStatusCodePagesWithRedirects("~/Error");

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapRazorPages();
app.MapDefaultControllerRoute();

app.UseCookiePolicy(new CookiePolicyOptions()
{
    MinimumSameSitePolicy = SameSiteMode.Lax
});

app.Run();

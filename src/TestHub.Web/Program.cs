using Microsoft.EntityFrameworkCore;
using TestHub.Core.Entities;
using TestHub.Core.Interfaces;
using TestHub.Infrastructure;
using TestHub.Infrastructure.Data;
using TestHub.Web.Configuration;
using TestHub.Web.Interfaces;
using TestHub.Web.ModelBinders;
using TestHub.Web.Services;

var builder = WebApplication.CreateBuilder(args);

builder.ConfigureApplication();

builder.Services.AddMvc();

builder.Services.AddSingleton<IPartialViewResolver, PartialViewResolver>();

builder.Services.AddControllers(options =>
options.ModelBinderProviders.Insert(0, new QuestionViewModelBinderProvider())
);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var scopedProvider = scope.ServiceProvider;
    try
    {
        var context = scopedProvider.GetRequiredService<TestHubContext>();
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();
        await TestHubContextSeed.SeedAsync(context);
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
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseStatusCodePagesWithRedirects("~/Error");
    app.UseHsts();
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.UseSession();

app.MapRazorPages();

app.MapControllerRoute(
    name: "Areas",
    pattern: "{area}/{controller}/{action}/{id?}");

app.MapDefaultControllerRoute();

app.UseCookiePolicy(new CookiePolicyOptions()
{
    MinimumSameSitePolicy = SameSiteMode.Lax
});

app.Run();

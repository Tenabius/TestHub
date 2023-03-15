﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TestHub.Infrastructure.Data.Identity;
using TestHub.Web.Interfaces;

namespace TestHub.Web.Configuration
{
    public class AuthenthicationWithIdentityConfiguration : IApplicationConfigurator
    {
        public void ConfigureApplication(WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<TestHubIdentityContext>(options =>
            options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=TestHub.Identity"));

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultScheme = IdentityConstants.ApplicationScheme;
                options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
            })
                .AddIdentityCookies();

            builder.Services.AddAuthentication().AddGoogle(googleOptions =>
            {
                googleOptions.ClientId = builder.Configuration["GoogleOAuth:ClientId"]!;
                googleOptions.ClientSecret = builder.Configuration["GoogleOAuth:ClientSecret"]!;
            });

            builder.Services.AddIdentityCore<IdentityUser>(options =>
            {
                options.Stores.MaxLengthForKeys = 128;
                options.SignIn.RequireConfirmedAccount = true;
            })
                .AddDefaultTokenProviders()
                .AddSignInManager()
                .AddEntityFrameworkStores<TestHubIdentityContext>();

            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Identity/Account/Login";
            });
        }
    }
}

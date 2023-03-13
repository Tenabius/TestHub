﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TestHub.Infrastructure.Data.Identity;
using TestHub.Web.Interfaces;

namespace TestHub.Web.Configuration
{
    public class AuthenthicationWithIdentityConfiguration : IApplicationConfigurator
    {
        public void ApplyConfiguration(WebApplicationBuilder builder)
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
                googleOptions.ClientId = builder.Configuration["Authentication:Google:ClientId"]!;
                googleOptions.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"]!;
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
﻿using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Silky.Identity.EntityFrameworkCore.DbContexts;

namespace Silky.IdentityHost
{
    public class ConfigureService : IConfigureService
    {
        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSilkyCaching()
                .AddSilkySkyApm()
                .AddMessagePackCodec();

            services.AddHeroIdentity(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.Lockout.AllowedForNewUsers = true;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
            });

            services.AddDatabaseAccessor(
                options => { options.AddDbPool<DefaultContext>(); },
                "Silky.Identity.Database.Migrations");
        }
    }
}
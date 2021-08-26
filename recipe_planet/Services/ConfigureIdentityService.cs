using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using recipe_planet.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace recipe_planet.Services
{
    public static class ConfigureIdentityService
    {
        public static void ConfigureIdentity(this IServiceCollection services)
        {

            var builder = services.AddIdentityCore<User>(q => q.User.RequireUniqueEmail = true);

            builder = new IdentityBuilder(builder.UserType, typeof(IdentityRole), services);

            builder.AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

        }
    }
}

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace recipe_planet.Data
{
    public class AppDbContext : IdentityDbContext<User>
    {

        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

       

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            foreach (var foreignKey in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
              foreignKey.DeleteBehavior = DeleteBehavior.Cascade;
            }

        }

        public DbSet<MyRecipe> MyRecipes { get; set; }

        public DbSet<Ingredient> Ingredients { get; set; }

        public DbSet<Favorite> Favorites { get; set; }

    }
}

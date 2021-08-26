using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace recipe_planet.Data
{
    public class User : IdentityUser
    {
        public string first_name { get; set; }
        public string last_name { get; set; }

        //Navigation Properties

        public List<MyRecipe> MyRecipes { get; set; }

        public List<Favorite> Favorites { get; set; }

    }
}

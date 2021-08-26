using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace recipe_planet.Data
{
    public class MyRecipe
    {
        public int Id { get; set; }
        public string recipe_key { get; set; }
        public string publisher { get; set; }
        public string title { get; set; }
        public string image_url { get; set; }
        public string source_url { get; set; }
        public int cooking_time { get; set; }
        public int num_servings { get; set; }
        public bool my_recipe { get; set; }


        //Navigation Properties
        public string  UserId { get; set; }
        public User User { get; set; }

        public List<Ingredient> Ingredients { get; set; }
    }
}

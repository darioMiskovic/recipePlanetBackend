using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace recipe_planet.Data
{
    public class Ingredient
    {
        public int Id { get; set; }

        public string quantity { get; set; }

        public string unit { get; set; }

        public string description { get; set; }

        //Navigation Properties
        public int MyRecipeId { get; set; }
        public MyRecipe MyRecipe { get; set; }
    }

    
}

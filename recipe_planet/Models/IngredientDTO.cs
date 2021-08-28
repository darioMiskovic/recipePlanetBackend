using recipe_planet.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace recipe_planet.Models
{
    public class CreateIngredientDTO
    {
        [Required]
        public int quantity { get; set; }
        [Required]
        public string unit { get; set; }
        [Required]
        public string description { get; set; }
        
        public int MyRecipeId { get; set; }

    }

    public class IngredientDTO : CreateIngredientDTO
    {
        public int Id { get; set; }

        public MyRecipeDTO MyRecipe { get; set; }
    }
}

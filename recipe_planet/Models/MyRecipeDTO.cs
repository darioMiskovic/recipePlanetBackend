using recipe_planet.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace recipe_planet.Models
{
    public class CreateMyRecipeDTO
    {
        [Required]
        public string recipe_key { get; set; }

        [Required]
        public string publisher { get; set; }

        [Required]
        public string title { get; set; }

        [Required]
        public string image_url { get; set; }

        [Required]
        public string source_url { get; set; }

        [Required]
        public int cooking_time { get; set; }

        [Required]
        public int num_servings { get; set; }

        [Required]
        public bool my_recipe { get; set; }

        [Required]
        public List<IngredientDTO> Ingredients { get; set; }

        [Required]
        public string UserId { get; set; }

    }

    public class MyRecipeDTO : CreateMyRecipeDTO
    {
        public int Id { get; set; }

        public UserDTO User { get; set; }

    }
}

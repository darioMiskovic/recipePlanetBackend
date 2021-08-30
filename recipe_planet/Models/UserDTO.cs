using recipe_planet.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace recipe_planet.Models
{

    public class LoginUserDTO
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }


    public class UserDTO : LoginUserDTO
    {
        [Required]
        public string first_name { get; set; }
        [Required]
        public string last_name { get; set; }

        //Navigation Properties

        //public List<MyRecipeDTO> MyRecipes { get; set; }

        //public List<FavoriteDTO> Favorites { get; set; }

    }
}

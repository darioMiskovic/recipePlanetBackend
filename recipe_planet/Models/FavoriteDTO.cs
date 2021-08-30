using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace recipe_planet.Models
{
    public class CreateFavoriteDTO
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
        public string UserId { get; set; }
    }

    public class FavoriteDTO : CreateFavoriteDTO
    {
        public int Id { get; set; }

        //public UserDTO User { get; set; }
    }
}

using AutoMapper;
using recipe_planet.Data;
using recipe_planet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace recipe_planet.Configuration
{
    public class MapperInitializer : Profile
    {
        public MapperInitializer()
        {
            CreateMap<User, LoginUserDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();

            CreateMap<MyRecipe, MyRecipeDTO>().ReverseMap();
            CreateMap<MyRecipe, CreateMyRecipeDTO>().ReverseMap();

            CreateMap<Ingredient, CreateIngredientDTO>().ReverseMap();
            CreateMap<Ingredient, IngredientDTO>().ReverseMap();

            CreateMap<Favorite, CreateFavoriteDTO>().ReverseMap();
            CreateMap<Favorite, FavoriteDTO>().ReverseMap();
          
        }
    }
}

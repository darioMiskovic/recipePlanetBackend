using AutoMapper;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using recipe_planet.Data;
using recipe_planet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace recipe_planet.Services
{
    public class MyRecipeService
    {
        private  AppDbContext _context;
        private readonly IMapper _mapper;
        public MyRecipeService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public MyRecipe AddMyRecipe(CreateMyRecipeDTO myRecipe)
        {
            try
            {
                var _myRecipe = _mapper.Map<MyRecipe>(myRecipe);
                //_context.MyRecipes.Add(_myRecipe);
                //_context.SaveChanges();
                return _myRecipe;

            }
            catch (Exception ex)
            {
                throw new Exception($"Please enter valid inputs!{ex}");
            }
        }
    }
}

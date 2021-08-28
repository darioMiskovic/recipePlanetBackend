using AutoMapper;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
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
        private AppDbContext _context;
        private readonly IMapper _mapper;
        public MyRecipeService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<MyRecipe> AddMyRecipe(CreateMyRecipeDTO myRecipe)
        {
            var _myRecipe = _mapper.Map<MyRecipe>(myRecipe);
            await _context.MyRecipes.AddAsync(_myRecipe);
            await _context.SaveChangesAsync();
            return _myRecipe;
        }


        public async Task<List<MyRecipeDTO>> GetMyRecipesById(string id)
        {
            var myRecipes = await _context.MyRecipes.Where(n => n.UserId == id).ToListAsync();
            return _mapper.Map<List<MyRecipeDTO>>(myRecipes);
        }

        public async Task<MyRecipeDTO> MyRecipeInfo(int id)
        {
            var myRecipe = await _context.MyRecipes.Include(n => n.Ingredients).Where(recipe => recipe.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<MyRecipeDTO>(myRecipe);
            
        }
    }
}

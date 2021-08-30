using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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

        //Add My Recipe 
        public async Task<MyRecipeDTO> AddMyRecipe(CreateMyRecipeDTO myRecipe)
        {
            var _myRecipe = _mapper.Map<MyRecipe>(myRecipe);
            await _context.MyRecipes.AddAsync(_myRecipe);
            await _context.SaveChangesAsync();
            return _mapper.Map<MyRecipeDTO>(_myRecipe);
        }

       
        //GET My Recipe Info
        public async Task<MyRecipeDTO> MyRecipeInfo(int id)
        {
            var myRecipe = await _context.MyRecipes.Include(n => n.Ingredients).Where(recipe => recipe.Id == id).FirstOrDefaultAsync();

            if (myRecipe == null)  throw new Exception($"My Recipe with id: {id} does not exist");

            return _mapper.Map<MyRecipeDTO>(myRecipe);
            
        }


        //Update My Recipe 
        public async Task<MyRecipeDTO> MyRecipeUpdate(int recipeId ,CreateMyRecipeDTO myRecipe)
        {
           
            var _fetchMyRecipe = await _context.MyRecipes.FindAsync(recipeId);

            if (_fetchMyRecipe == null)
            {
                throw new Exception($"My Recipe with id: {recipeId} does not exist");
            }

            _mapper.Map(myRecipe, _fetchMyRecipe);
             _context.MyRecipes.Update(_fetchMyRecipe);
            await _context.SaveChangesAsync();

            return _mapper.Map<MyRecipeDTO>(_fetchMyRecipe);

        }

        //Delete My Recipe 
        public async Task<bool> DeleteMyRecipeById(int id)
        {
            var myRecipe = await _context.MyRecipes.FindAsync(id);
            if (myRecipe == null)
            {
                throw new Exception($"My Recipe with id: {id} does not exist");
            }

             _context.MyRecipes.Remove(myRecipe);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}

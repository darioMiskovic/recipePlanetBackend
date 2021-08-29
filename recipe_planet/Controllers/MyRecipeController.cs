using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using recipe_planet.Models;
using recipe_planet.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace recipe_planet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyRecipeController : ControllerBase
    {

        private  MyRecipeService _myRecipeService;

        public MyRecipeController(MyRecipeService myRecipeService)
        {
            _myRecipeService = myRecipeService;
        }

        //Add My Rcipe
        [HttpPost("add-my-recipe" , Name ="AddMyRecipe")]
        public async Task<IActionResult> AddMyRecipe([FromBody] CreateMyRecipeDTO myRecipe)
        {
            if (!ModelState.IsValid) BadRequest(ModelState);

            try
            {
                var _myRecipe = await _myRecipeService.AddMyRecipe(myRecipe);

                return CreatedAtRoute("AddMyRecipe", new { id = _myRecipe.Id}, _myRecipe);
            }
            catch (Exception )
            {
                return StatusCode(500, "Internal Server Error. Please Try Again Later.");
            }
        }

        //Get My Recipes List
        [HttpGet("my-recipes/{userId}")]
        public async Task<IActionResult> GetMyRecipesById(string userId)
        {
            var recipes = await _myRecipeService.GetMyRecipesById(userId);
            return Ok(recipes);
        }

        //Get My Recipe Info
        [HttpGet("my-recipe-info/{recipeId}")]
        public async Task<IActionResult> MyRecipeInfo(int recipeId)
        {
            var recipes = await _myRecipeService.MyRecipeInfo(recipeId);
            return Ok(recipes);
        }

        //Update My Recipe
        [HttpPut("my-recipe-update/{recipeId}")]
        public async Task<IActionResult> MyRecipeUpdate(int recipeId, [FromBody] CreateMyRecipeDTO myRecipe)
        {
            if (!ModelState.IsValid) BadRequest(ModelState);

            var recipes = await _myRecipeService.MyRecipeUpdate(recipeId, myRecipe);
            return Ok(recipes);
        }


        //Delete My Recipe 
        [HttpDelete("my-recipe-delete/{recipeId}")]
        public async Task<IActionResult> MyRecipeDeleteById(int recipeId)
        {
            var isDeleted = await _myRecipeService.DeleteMyRecipeById(recipeId);
            return Ok(isDeleted);
        }

    }
}

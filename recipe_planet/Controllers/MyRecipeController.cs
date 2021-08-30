using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<MyRecipeController> _logger;

        public MyRecipeController(MyRecipeService myRecipeService, ILogger<MyRecipeController> logger)
        {
            _myRecipeService = myRecipeService;
            _logger = logger;
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
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                return StatusCode(500, "Internal Server Error. Please Try Again Later.");
            }
        }

       

        //Get My Recipe Info
        [HttpGet("my-recipe-info/{recipeId}")]
        public async Task<IActionResult> MyRecipeInfo(int recipeId)
        {
            try
            {
                var recipes = await _myRecipeService.MyRecipeInfo(recipeId);
                return Ok(recipes);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        //Update My Recipe
        [HttpPut("my-recipe-update/{recipeId}")]
        public async Task<IActionResult> MyRecipeUpdate(int recipeId, [FromBody] CreateMyRecipeDTO myRecipe)
        {
            if (!ModelState.IsValid) BadRequest(ModelState);

            try
            {
                var recipes = await _myRecipeService.MyRecipeUpdate(recipeId, myRecipe);
                
                return Ok(recipes);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


        //Delete My Recipe 
        [HttpDelete("my-recipe-delete/{recipeId}")]
        public async Task<IActionResult> MyRecipeDeleteById(int recipeId)
        {
            try
            {
                var isDeleted = await _myRecipeService.DeleteMyRecipeById(recipeId);
                return Ok(isDeleted);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

    }
}

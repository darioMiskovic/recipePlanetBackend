using Microsoft.AspNetCore.Authorization;
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

        //Add My Recipe
        [Authorize]
        [HttpPost("add-my-recipe" , Name ="AddMyRecipe")]
        public async Task<IActionResult> AddMyRecipe([FromBody] CreateMyRecipeDTO myRecipe)
        {
            if (!ModelState.IsValid) {
                _logger.LogError($"Invalid POST attempt in {nameof(AddMyRecipe)}");
                return BadRequest(ModelState);
            }

            try
            {
                var _myRecipe = await _myRecipeService.AddMyRecipe(myRecipe);

                return CreatedAtRoute("AddMyRecipe", new { id = _myRecipe.Id}, _myRecipe);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(AddMyRecipe)}");
                return StatusCode(500, "Internal Server Error. Please Try Again Later.");
            }
        }



        //Get My Recipe Info
        [Authorize]
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
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(MyRecipeInfo)}");
                return BadRequest(ex.Message);
            }
        }

        //Update My Recipe
        [Authorize]
        [HttpPut("my-recipe-update/{recipeId}")]
        public async Task<IActionResult> MyRecipeUpdate(int recipeId, [FromBody] CreateMyRecipeDTO myRecipe)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid PUT attempt in {nameof(MyRecipeUpdate)}");
                return BadRequest(ModelState);
            }

            try
            {
                var recipes = await _myRecipeService.MyRecipeUpdate(recipeId, myRecipe);
                
                return Ok(recipes);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(MyRecipeUpdate)}");
                return StatusCode(500, "Internal Server Error. Please Try Again Later.");
            }
        }


        //Delete My Recipe 
        [Authorize]
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
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(MyRecipeDeleteById)}");
                return BadRequest(ex.Message);
            }
        }

    }
}

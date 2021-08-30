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
    public class FavoriteController : ControllerBase
    {
        private FavoriteService _favoriteService;

        public FavoriteController(FavoriteService favoriteService)
        {
            _favoriteService = favoriteService;
        }

       

        //Add My Rcipe
        [HttpPost("add-favorite-recipe", Name = "AddFavoriteRecipe")]
        public async Task<IActionResult> AddFavoriteRecipe([FromBody] CreateFavoriteDTO favorite)
        {
            if (!ModelState.IsValid) BadRequest(ModelState);

            try
            {
                var _favorite = await _favoriteService.AddFavoriteRecipe(favorite);

                
                return Created(nameof(AddFavoriteRecipe), _favorite);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error. Please Try Again Later.");
            }
        }


        //Get My Favorites List
        [HttpGet("favorites/{userId}")]

        public async Task<IActionResult> GetFavorites(string userId)
        {
            var recipes = await _favoriteService.GetFavorites(userId);
            return Ok(recipes);
        }


       //Delete 
        [HttpDelete("favorite-delete/{favoriteId}")]
        public async Task<IActionResult> DeleteFavoriteRecipe(int favoriteId)
        {
            try
            {
                var isDeleted = await _favoriteService.DeleteFavoriteRecipe(favoriteId);
                return Ok(isDeleted);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}

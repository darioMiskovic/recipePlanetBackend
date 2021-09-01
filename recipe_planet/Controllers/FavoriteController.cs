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
    public class FavoriteController : ControllerBase
    {
        private FavoriteService _favoriteService;
        private readonly ILogger<FavoriteController> _logger;

        public FavoriteController(FavoriteService favoriteService, ILogger<FavoriteController> logger)
        {
            _favoriteService = favoriteService;
            _logger = logger;
        }



        //Add My Favorite Recipe
        [Authorize]
        [HttpPost("add-favorite-recipe", Name = "AddFavoriteRecipe")]
        public async Task<IActionResult> AddFavoriteRecipe([FromBody] CreateFavoriteDTO favorite)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid POST attempt in {nameof(AddFavoriteRecipe)}");
                return BadRequest(ModelState);
            }

            try
            {
                var _favorite = await _favoriteService.AddFavoriteRecipe(favorite);  
                return Created(nameof(AddFavoriteRecipe), _favorite);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(AddFavoriteRecipe)}");
                return StatusCode(500, "Internal Server Error. Please Try Again Later.");
            }
        }


        //Delete Favorite Recipe By Id 
        [Authorize]
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
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(DeleteFavoriteRecipe)}");
                return BadRequest(ex.Message);
            }
        }
    }
}

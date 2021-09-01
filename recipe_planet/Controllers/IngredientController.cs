using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using recipe_planet.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace recipe_planet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientController : ControllerBase
    {
        private IngredientService _ingredientService;
        private readonly ILogger<IngredientController> _logger;

        public IngredientController(IngredientService ingredientService, ILogger<IngredientController> logger)
        {
            _ingredientService = ingredientService;
            _logger = logger;
        }

        //Delete Ingredient By Id
        [Authorize]
        [HttpDelete("delete-ingredient/{ingredientId}")]
        public async Task<IActionResult> DeleteIngredientById(int ingredientId)
        {
            try
            {
                var isDeleted = await _ingredientService.DeleteIngredientById(ingredientId);
                return Ok(isDeleted);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(DeleteIngredientById)}");
                return BadRequest(ex.Message);
            }
        }
    }
}

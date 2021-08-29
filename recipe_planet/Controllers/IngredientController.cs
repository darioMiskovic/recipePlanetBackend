using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        public IngredientController(IngredientService ingredientService)
        {
            _ingredientService = ingredientService;
        }

        [HttpDelete("delete-ingredient/{id}")]
        public async Task<IActionResult> MyRecipeDeleteById(int id)
        {
            var isDeleted = await _ingredientService.DeleteIngredientById(id);
            return Ok(isDeleted);
        }
    }
}

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

        [HttpPost("add-my-recipe")]
        public IActionResult AddMyRecipe([FromBody] CreateMyRecipeDTO myRecipe)
        {
            if (!ModelState.IsValid) BadRequest(ModelState);

            try
            {
                var recipe = _myRecipeService.AddMyRecipe(myRecipe);

                return Ok(recipe);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       
    }
}

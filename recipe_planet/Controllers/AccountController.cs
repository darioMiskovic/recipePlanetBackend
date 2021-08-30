using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using recipe_planet.Data;
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
    public class AccountController : ControllerBase
    {

        private AccountService _accountService;

        public AccountController(AccountService accountService)
        {
            _accountService = accountService;
        }


        //Register
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] UserDTO userDTO)
        {
            if (!ModelState.IsValid) BadRequest(ModelState);
            
            try
            {
               var result = await _accountService.RegisterAccount(userDTO);
                
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);
                    }
                    return BadRequest(ModelState);
                }
                return Accepted(result.Succeeded);
            }
            catch (Exception)
            {
                return Problem($"Something Went Wrong in the {nameof(Register)}", statusCode: 500);
            }
        }


        //Get My Recipes List
        [HttpGet("my-recipes/{id}")]
        public async Task<IActionResult> GetMyRecipes(string id)
        {
            try
            {
                var recipes = await _accountService.GetMyRecipesById(id);
                return Ok(recipes);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


        //Get My Favorites List
        [HttpGet("my-favorites/{id}")]
        public async Task<IActionResult> GetMyFavorites(string id)
        {
            try
            {
                var recipes = await _accountService.GetMyFavorites(id);
                return Ok(recipes);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


        //Delete My Recipe 
        [HttpDelete("user-delete/{userId}")]
        public async Task<IActionResult> DeleteUserById(string userId)
        {
            try
            {
                var result = await _accountService.DeleteUserById(userId);
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);
                    }
                    return BadRequest(ModelState);
                }
                return Accepted(result.Succeeded);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
                //return Problem($"Something Went Wrong in the {nameof(Register)}", statusCode: 500);
            }
        }
    }
}

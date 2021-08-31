using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<AccountController> _logger;

        public AccountController(AccountService accountService, ILogger<AccountController> logger)
        {
            _accountService = accountService;
            _logger = logger;
        }


        //Register
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserDTO userDTO)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid Register attempt in {nameof(Register)}");
                return BadRequest(ModelState);
            }

            try
            {
               var result = await _accountService.RegisterAccount(userDTO);
                
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);
                    }
                    _logger.LogError($"Invalid POST attempt in {nameof(Register)}");
                    return BadRequest(ModelState);
                }

                return Accepted(result.Succeeded);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(Register)}");
                return Problem($"Something Went Wrong in the {nameof(Register)}", statusCode: 500);
            }
        }


        /*[HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserDTO userDTO)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid Login attempt in {nameof(Login)}");
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _accountService.LoginAccount(userDTO);

                if (!result.Succeeded)
                {
                    _logger.LogError($"Unauthorized user attemtp to login {nameof(Register)}");
                    return Unauthorized(userDTO);
                }
                return Accepted(result.Succeeded);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(Register)}");
                return Problem($"Something Went Wrong in the {nameof(Register)}", statusCode: 500);
            }
        }*/

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
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(GetMyRecipes)}");
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
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(GetMyFavorites)}");
                return BadRequest(ex.Message);
            }
        }


        //Delete User
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

                    _logger.LogError($"Invalid DELETE attempt in {nameof(DeleteUserById)}");
                    return BadRequest(ModelState);
                }
                return Accepted(result.Succeeded);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(DeleteUserById)}");
                return BadRequest(ex.Message);
            }
        }
    }
}

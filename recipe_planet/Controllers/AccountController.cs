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
                    return new BadRequestObjectResult(ModelState);
                    
                }

                return Accepted();

            }
            catch (Exception)
            {
                return Problem($"Something Went Wrong in the {nameof(Register)}", statusCode: 500);
            }
        }

    }
}

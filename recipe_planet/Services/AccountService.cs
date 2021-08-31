using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using recipe_planet.Data;
using recipe_planet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace recipe_planet.Services
{
    public class AccountService
    {


        private readonly UserManager<User> _userManager;
        private AppDbContext _context;
        private readonly IMapper _mapper;
        

        public AccountService(UserManager<User> userManager, IMapper mapper, AppDbContext context)
        {
            _userManager = userManager;
            _mapper = mapper;
            _context = context;
        }

        //Registration
        public async Task<IdentityResult> RegisterAccount(UserDTO userDTO)
        {
            var user = _mapper.Map<User>(userDTO);
            user.UserName = userDTO.Email;
            var result = await _userManager.CreateAsync(user, userDTO.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "User");
            }

            return result;

        }


        //Get My Recipes List
        public async Task<List<MyRecipeDTO>> GetMyRecipesById(string id)
        {
            var user = await _context.Users.Include(n => n.MyRecipes).Where(n => n.Id == id).FirstOrDefaultAsync();

            if (user == null) throw new Exception($"User with id: {id} does'nt exist!");

            return _mapper.Map<List<MyRecipeDTO>>(user.MyRecipes);
        }


        //Get My Favorites List
        public async Task<List<FavoriteDTO>> GetMyFavorites(string id)
        {
            var user = await _context.Users.Include(n => n.Favorites).Where(n => n.Id == id).FirstOrDefaultAsync();

            if (user == null) throw new Exception($"User with id: {id} does'nt exist!");

            return _mapper.Map<List<FavoriteDTO>>(user.Favorites);
        }

        //Delete User By Id 
        public async Task<IdentityResult> DeleteUserById(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                throw new Exception($"User with id: {id} does not exist");
            }

            return await _userManager.DeleteAsync(user);
            
        }
    }
}

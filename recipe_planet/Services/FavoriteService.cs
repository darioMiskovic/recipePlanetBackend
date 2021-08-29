using AutoMapper;
using Microsoft.EntityFrameworkCore;
using recipe_planet.Data;
using recipe_planet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace recipe_planet.Services
{
    public class FavoriteService
    {
        private AppDbContext _context;
        private readonly IMapper _mapper;
        public FavoriteService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //Add Favorite Recipe
        public async Task<Favorite> AddFavoriteRecipe(CreateFavoriteDTO favorite)
        {
            var _favorite = _mapper.Map<Favorite>(favorite);
            await _context.Favorites.AddAsync(_favorite);
            await _context.SaveChangesAsync();
            return _favorite;
        }


        //Get Favorites List
        public async Task<List<FavoriteDTO>> GetFavorites(string id)
        {
            var favorites = await _context.Favorites.Where(n => n.UserId == id).ToListAsync();
            return _mapper.Map<List<FavoriteDTO>>(favorites);
        }

        //Delete Favorite Recipe
        public async Task<bool> DeleteFavoriteRecipe(int id)
        {
            var favorite = await _context.Favorites.FindAsync(id);
            if (favorite == null)
            {
                throw new Exception("Submited data is invalid");
            }

            _context.Favorites.Remove(favorite);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

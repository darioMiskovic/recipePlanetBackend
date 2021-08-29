using AutoMapper;
using recipe_planet.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace recipe_planet.Services
{
    public class IngredientService
    {
        private AppDbContext _context;
        private readonly IMapper _mapper;
        public IngredientService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //DELETE
        public async Task<bool> DeleteIngredientById(int id)
        {
            var ingredient = await _context.Ingredients.FindAsync(id);
            if (ingredient == null)
            {
                throw new Exception("Submited data is invalid");
            }

            _context.Ingredients.Remove(ingredient);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}

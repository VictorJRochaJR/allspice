using System.Collections.Generic;
using allspice.Data;
using allspice.Models;

namespace allspice.Services
{
    public class RecipesService
    {
        private readonly RecipesRepository _recipeRepo;
        
        public RecipesService(RecipesRepository recipeRepo)
        {
            _recipeRepo = recipeRepo;
        }
        public List<Recipe> GetAll()
        {
            return _recipeRepo.GetAll();
        }
        public Recipe CreateRecipe(Recipe recipeData)
        {
            return _recipeRepo.Create(recipeData);
        
        }

    }
}
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
        public Recipe getOne(int id)
        {
            return _recipeRepo.getOne(id);
        }
        public Recipe CreateRecipe(Recipe recipeData)
        {
            return _recipeRepo.Create(recipeData);
        
        }

        internal Recipe update(int id, Recipe recipe)
        {
            recipe.id  = id;
            Recipe original = getOne(id);
            recipe.Title = recipe.Title != null ? recipe.Title : original.Title;
            recipe.Description = recipe.Description != null ? recipe.Description : original.Description;
            recipe.imgUrl = recipe.imgUrl  != null ? recipe.imgUrl : original.imgUrl;
            recipe.Steps = recipe.Steps != null ? recipe.Steps : original.Steps;
            recipe.Ingredients = recipe.Ingredients != null ? recipe.Ingredients : original.Ingredients;
            int updated = _recipeRepo.update(recipe);
            return recipe;
        }

    }
}
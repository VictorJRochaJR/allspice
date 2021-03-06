using System.Collections.Generic;
using allspice.Models;
using allspice.Services;
using Microsoft.AspNetCore.Mvc;

namespace allspice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class RecipesController: ControllerBase
    {
        private readonly RecipesService _rs;

        public RecipesController(RecipesService rs)
        {
            _rs = rs;
        }
        [HttpGet]
        public ActionResult<List<Recipe>> GetRecipes()
        {
            try
            {
                var recipes = _rs.GetAll();
                return Ok(recipes);
            }
            catch (System.Exception e)
            {
                
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Recipe>> getOneRecipe(int id)
        {
            try
            {
                return Ok(_rs.getOne(id));
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
                            }
        }

        [HttpPost]
        public ActionResult<Recipe> CreateRecipe([FromBody] Recipe recipeData)
        {
            try
            {
                var recipe = _rs.CreateRecipe(recipeData);
                return Created("api/recipes/" + recipe.id, recipe);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut("{id}")]
        public ActionResult<Recipe> update(int id, [FromBody] Recipe recipe)
{
    try
    {
        return Ok(_rs.update(id, recipe));
    }
    catch (System.Exception e)
    {
        
        return BadRequest(e.Message);
    }
}

        
    }
    
}
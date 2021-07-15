using System.Collections.Generic;
using System.Data;
using System.Linq;
using allspice.Models;
using Dapper;

namespace allspice.Data{
    public class RecipesRepository{
        private readonly IDbConnection _db;
        
        public RecipesRepository(IDbConnection db)
        {
            _db = db;
        }

        public List<Recipe> GetAll()
        {
            var sql = "SELECT * FROM Recipes";
            return _db.Query<Recipe>(sql).ToList();
        }

    public Recipe Create(Recipe recipeData)
    {
        var sql = @"
        INSERT INTO Recipes(creatorId, Title, Description, imgUrl, Steps, Ingredients )
        VALUES(@CreatorId, @Title, @Description, @ImgUrl, @Steps, @Ingredients);
        SELECT LAST_INSERT_ID();
        ";

        int id = _db.ExecuteScalar<int>(sql, recipeData);
        recipeData.id = id;
        return recipeData;
    }
    internal int update(Recipe  recipeData)
    {
    string sql =@"
    Update Recipes
    SET 
    title = @Title,
    description = @Description,
    imgUrl = @ImgUrl,
    steps = @Steps,
    ingredients = @Ingredients
    where id = @id;
    ";
    return _db.Execute(sql, recipeData);

        
    }
    internal Recipe getOne(int id)
    {
        string sql = "SELECT * FROM Recipes  WHERE id = @id";
        return _db.QueryFirstOrDefault<Recipe>(sql, new {id});

    }
    }
}
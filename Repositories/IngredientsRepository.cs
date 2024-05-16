


namespace recipe.Repositories;

public class IngredientsRepository
{
  private readonly IDbConnection _db;

  public IngredientsRepository(IDbConnection db)
  {
    _db = db;
  }



  internal Ingredient CreateIngredient(Ingredient ingredientData)
  {
    string sql = @"
        INSERT INTO
        ingredients(name, quantity, recipeId)
        VALUES(@Name, @Quantity, @RecipeId);
        
        SELECT
        ingredients.*
        FROM ingredients
        WHERE ingredients.Id = LAST_INSERT_ID();";

    Ingredient ingredient = _db.Query<Ingredient>(sql, ingredientData).FirstOrDefault();

    return ingredient;

  }

  internal void EraseIngredient(int ingredientId)
  {
    string sql = "DELETE FROM ingredients WHERE id = @ingredientId LIMIT 1";

    int rowsAffected = _db.Execute(sql, new { ingredientId });
  }

  internal Ingredient GetIngredientById(int ingredientId)
  {
    string sql = "SELECT * FROM ingredients WHERE id = @ingredientId;";

    Ingredient ingredient = _db.Query<Ingredient>(sql, new { ingredientId }).FirstOrDefault();

    return ingredient;
  }

  internal List<Ingredient> GetIngredients(int recipeId)
  {
    string sql = @"
     SELECT
     *
     FROM ingredients
     WHERE ingredients.RecipeId = @recipeId
     ;";

    List<Ingredient> ingredients = _db.Query<Ingredient>(sql, new { recipeId }).ToList();

    return ingredients;
  }

}
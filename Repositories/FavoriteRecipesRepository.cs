
using Microsoft.Extensions.Configuration.UserSecrets;
using recipe.models;

namespace recipe.Repositories;

public class FavoritesRecipesRepository
{
  private readonly IDbConnection _db;

  public FavoritesRecipesRepository(IDbConnection db)
  {
    _db = db;
  }

  internal FavoriteRecipe CreateFavoriteRecipe(int recipeId, string accountId)
  {
    string sql = @"
        INSERT INTO
        favorites(recipeId, accountId)
        VALUES(@RecipeId, @AccountId);

        SELECT
        favorites.*,
        recipes.*,
        accounts.*
        FROM favorites
        JOIN recipes on favorites.recipeId = recipes.id
        JOIN accounts on accounts.id = favorites.accountId
        WHERE favorites.id = LAST_INSERT_ID();";

    var favoriteRecipes = _db.Query(sql, (Favorites favorite, FavoriteRecipe recipe, Profile profile) =>
    {
      recipe.FavoriteId = favorite.Id;
      recipe.AccountId = profile.Id;
      recipe.RecipeId = recipe.Id;
      recipe.Creator = profile;
      return recipe;

    }, new { recipeId, accountId }
    ).FirstOrDefault();

    return favoriteRecipes;
  }

  internal void EraseFavorite(int favoriteId)
  {
    string sql = "DELETE FROM favorites WHERE id = @favoriteId LIMIT 1";

    int rowsAffected = _db.Execute(sql, new { favoriteId });
  }

  internal List<FavoriteRecipe> GetAccountFavoriteRecipes(string userId, int recipeId)
  {
    string sql = @"
        SELECT
        favorites.*,
        recipes.*,
        accounts.*
        FROM favorites
        JOIN recipes on favorites.recipeId = recipes.id
        JOIN accounts on accounts.id = favorites.accountId
        WHERE favorites.accountId = @userId;";

    var favoriteRecipes = _db.Query(sql, (Favorites favorite, FavoriteRecipe recipe, Profile profile) =>
{
  recipe.FavoriteId = favorite.Id;
  recipe.AccountId = profile.Id;
  recipe.RecipeId = recipe.Id;
  recipe.Creator = profile;
  return recipe;

}, new { userId, recipeId }
).ToList();

    return favoriteRecipes;
  }

  internal FavoriteRecipe GetFavoriteRecipeById(int recipeId)
  {
    string sql = "SELECT * FROM favorites WHERE id = @recipeId;";

    FavoriteRecipe favoriteRecipe = _db.Query<FavoriteRecipe>(sql, new { recipeId }).FirstOrDefault();

    return favoriteRecipe;
  }
}
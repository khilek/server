
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
}
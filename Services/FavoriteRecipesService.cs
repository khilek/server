
using recipe.models;

namespace recipe.Services;

public class FavoriteRecipesService
{
  private readonly FavoritesRecipesRepository _repository;

  public FavoriteRecipesService(FavoritesRecipesRepository repository)
  {
    _repository = repository;
  }

  internal FavoriteRecipe CreateFavoriteRecipe(int recipeId, Profile profile)
  {

    FavoriteRecipe favorites = _repository.CreateFavoriteRecipe(recipeId, profile.Id);
    return favorites;
  }

  internal string EraseFavorite(int favoriteId, string userId)
  {
    FavoriteRecipe eraseFavorite = GetFavoriteRecipeById(favoriteId);

    if (eraseFavorite.AccountId != userId)
    {
      throw new Exception("NOT your FAVORITE to DELETE");
    }
    _repository.EraseFavorite(favoriteId);

    return "NO LONGER A FAVORITE RECIPE";
  }

  internal FavoriteRecipe GetFavoriteRecipeById(int recipeId)
  {
    FavoriteRecipe favoriteRecipe = _repository.GetFavoriteRecipeById(recipeId);

    if (favoriteRecipe == null)
    {
      throw new Exception($"Invalid id: {recipeId}");
    }

    return favoriteRecipe;
  }

  internal List<FavoriteRecipe> GetAccountFavoriteRecipes(string userId, int recipeId)
  {
    List<FavoriteRecipe> favoriteRecipes = _repository.GetAccountFavoriteRecipes(userId, recipeId);
    return favoriteRecipes;
  }





}
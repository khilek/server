
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
}
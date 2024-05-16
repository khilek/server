


namespace recipe.Services;

public class RecipesService
{
  private readonly RecipesRepository _repository;

  public RecipesService(RecipesRepository repository)
  {
    _repository = repository;
  }

  internal string BurnRecipe(int recipeId, string userId)
  {
    Recipe RecipeToBurn = GetRecipeById(recipeId);

    if (RecipeToBurn.CreatorId != userId)
    {
      throw new Exception("NOT YOUR RECIPE TO BURN");
    }
    _repository.BurnRecipe(recipeId);

    return "RECIPE has been BURNED";
  }

  internal Recipe CreateRecipe(Recipe recipeData)
  {
    Recipe recipe = _repository.CreateRecipe(recipeData);
    return recipe;
  }

  internal List<Recipe> GetAllRecipes()
  {
    List<Recipe> recipes = _repository.GetAllRecipes();
    return recipes;
  }

  internal Recipe GetRecipeById(int recipeId)
  {
    Recipe recipe = _repository.GetRecipeById(recipeId);
    if (recipe == null)
    {
      throw new Exception($"Invalid id: {recipeId}");
    }
    return recipe;
  }

  internal Recipe UpdateRecipe(int recipeId, string userId, Recipe recipeData)
  {
    Recipe RecipeToUpdate = GetRecipeById(recipeId);

    if (RecipeToUpdate.CreatorId != userId)
    {
      throw new Exception("You are not the creator of this Recipe");
    }

    RecipeToUpdate.Category = recipeData.Category ?? RecipeToUpdate.Category;
    RecipeToUpdate.Instructions = recipeData.Instructions ?? RecipeToUpdate.Instructions;
    RecipeToUpdate.Title = recipeData.Title ?? RecipeToUpdate.Title;
    RecipeToUpdate.Img = recipeData.Img ?? RecipeToUpdate.Img;

    Recipe updatedRecipe = _repository.UpdateRecipe(RecipeToUpdate);

    return RecipeToUpdate;
  }
}
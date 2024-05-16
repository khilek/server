

namespace recipe.Services;

public class IngredientsService
{
  private readonly IngredientsRepository _repository;
  private readonly RecipesService _recipesService;

  public IngredientsService(IngredientsRepository repository, RecipesService recipesService)
  {
    _repository = repository;
    _recipesService = recipesService;
  }

  internal Ingredient CreateIngredient(Ingredient ingredientData)
  {
    Recipe recipe = _recipesService.GetRecipeById(ingredientData.RecipeId);

    if (recipe == null)
    {
      throw new Exception("Recipe does not exist, Cannot create ingredient for a recipe that doesn't exist");
    }

    Ingredient ingredient = _repository.CreateIngredient(ingredientData);

    return ingredient;
  }

  internal List<Ingredient> GetIngredients(int recipeId)
  {
    List<Ingredient> ingredients = _repository.GetIngredients(recipeId);
    return ingredients;
  }

  internal Ingredient GetIngredientById(int ingredientId)
  {
    Ingredient ingredient = _repository.GetIngredientById(ingredientId);

    if (ingredient == null)
    {
      throw new Exception($"Invalid id: {ingredientId}");
    }

    return ingredient;
  }

  internal string EraseIngredient(int ingredientId, string userId)
  {
    Ingredient ingredient = GetIngredientById(ingredientId);

    // if (ingredient. != userId)
    // {
    //   throw new Exception("You cannot erase a ingredient you did not post.");
    // }

    _repository.EraseIngredient(ingredientId);

    return "Ingredient was deleted";
  }
}
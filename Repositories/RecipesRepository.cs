namespace recipe.Repositories;

public class RecipesRepository
{
  private readonly IDbConnection _db;


  public RecipesRepository(IDbConnection db)
  {
    _db = db;
  }

  private Recipe PopulateCreator(Recipe recipe, Account account)
  {
    recipe.Creator = account;
    return recipe;
  }


















}
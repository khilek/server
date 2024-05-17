namespace recipe.models;

public class Favorites : RepoItem<int>
{
  public string AccountId { get; set; }
  public int RecipeId { get; set; }
}
using recipe.models;

namespace recipe.Controllers;

[ApiController]
[Route("api/favorites")]
public class FavoriteRecipesController : ControllerBase
{
  private readonly FavoriteRecipesService _favoriteRecipesService;
  private readonly Auth0Provider _auth0provider;

  public FavoriteRecipesController(FavoriteRecipesService favoriteRecipesService, Auth0Provider auth0Provider)
  {
    _favoriteRecipesService = favoriteRecipesService;
    _auth0provider = auth0Provider;
  }



  [Authorize]
  [HttpPost]

  public async Task<ActionResult<FavoriteRecipe>> CreateFavoriteRecipe([FromBody] FavoriteRecipe favoriteRecipeData)
  {
    try
    {
      Account userInfo = await _auth0provider.GetUserInfoAsync<Account>(HttpContext);
      favoriteRecipeData.AccountId = userInfo.Id;
      var profile = _favoriteRecipesService.CreateFavoriteRecipe(favoriteRecipeData.RecipeId, userInfo);
      return Ok(profile);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }



















}
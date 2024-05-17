namespace recipe.Controllers;

[ApiController]
[Route("[controller]")]
public class AccountController : ControllerBase
{
  private readonly AccountService _accountService;
  private readonly Auth0Provider _auth0Provider;
  private readonly FavoriteRecipesService _favoriteRecipesService;

  public AccountController(AccountService accountService, Auth0Provider auth0Provider, FavoriteRecipesService favoriteRecipesService)
  {
    _accountService = accountService;
    _auth0Provider = auth0Provider;
    _favoriteRecipesService = favoriteRecipesService;
  }

  [HttpGet]
  [Authorize]
  public async Task<ActionResult<Account>> Get()
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      return Ok(_accountService.GetOrCreateProfile(userInfo));
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }



  [Authorize]
  [HttpGet("{favorites}")]
  public async Task<ActionResult<List<FavoriteRecipe>>> GetAccountFavoriteRecipes(int recipeId)
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      List<FavoriteRecipe> favoriteRecipes = _favoriteRecipesService.GetAccountFavoriteRecipes(userInfo.Id, recipeId);
      return Ok(favoriteRecipes);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);

    }
  }
}

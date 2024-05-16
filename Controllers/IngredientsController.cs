namespace recipe.Controllers;

[ApiController]
[Route("api/[controller]")]
public class IngredientsController : ControllerBase
{
    private readonly IngredientsService _ingredientsService;
    private readonly Auth0Provider _auth0Provider;

    public IngredientsController(IngredientsService ingredientsService, Auth0Provider auth0Provider)
    {
        _ingredientsService = ingredientsService;
        _auth0Provider = auth0Provider;
    }

    [Authorize]
    [HttpPost]
    public ActionResult<Ingredient> CreateIngredient([FromBody] Ingredient ingredientData)
    {
        try
        {
            Ingredient ingredient = _ingredientsService.CreateIngredient(ingredientData);
            return Ok(ingredient);
        }
        catch (Exception exception)
        {

            return BadRequest(exception.Message);
        }
    }


    [Authorize]
    [HttpDelete("{ingredientId}")]
    public async Task<ActionResult<string>> EraseIngredient(int ingredientId)
    {
        try
        {
            Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
            string message = _ingredientsService.EraseIngredient(ingredientId, userInfo.Id);
            return Ok(message);
        }
        catch (Exception exception)
        {
            return BadRequest(exception.Message);
        }
    }


}
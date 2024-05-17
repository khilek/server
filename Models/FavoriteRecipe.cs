namespace recipe.Models;

public class FavoriteRecipe : Recipe
{
  // public int Id { get; set; }
  // public DateTime CreatedAt { get; set; }
  // public DateTime UpdatedAt { get; set; }
  public int RecipeId { get; set; }
  public string AccountId { get; set; }
  public int FavoriteId { get; set;}

}

/*
 {
    "favoriteId": 9, // ID of many-to-many
    "title": "Big Jerms' famous Shakshuka",
    "instructions": "Take your tomatoes and cook them, then add the eggs. Boom, Shakshuka.",
    "img": "https://images.unsplash.com/photo-1614570218825-c2a3be79b0fd?w=600&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NHx8c2hha3NodWthfGVufDB8fDB8fHww",
    "category": "breakfast",
    "creatorId": "65f87bc1e02f1ee243874743",
    "creator": {
        "name": "jerms@jerms.jerms",
        "picture": "https://s.gravatar.com/avatar/c2161d4c4a6d8087b112d5e9d41c3c88?s=480&r=pg&d=https://cdn.auth0.com/avatars/je.png",
        "id": "65f87bc1e02f1ee243874743",
        "createdAt": "2024-05-14T15:37:25",
        "updatedAt": "2024-05-14T15:37:25"
    },
    "id": 24, // ID of recipe
    "createdAt": "2024-05-15T04:44:24",
    "updatedAt": "2024-05-15T04:44:24"
}*/
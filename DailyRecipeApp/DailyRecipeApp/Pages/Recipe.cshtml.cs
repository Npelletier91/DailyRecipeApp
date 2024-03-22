using DailyRecipeApp.Data;
using DailyRecipeApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DailyRecipeApp.Pages
{
    public class RecipeModel : PageModel
    {
        private readonly SpoonacularServices _spoonacularService;

        public string RecipesJson { get; private set; }
        public RecipeData Recipe { get; set; } // Use your RecipeModel class here


        public RecipeModel(SpoonacularServices spoonacularService)
        {
            _spoonacularService = spoonacularService;
        }


        public async Task<JsonResult> OnGetRecipeAsync()
        {
            var recipeData = await _spoonacularService.GetRecipeAsync();
            return new JsonResult(recipeData);
        }
    }

}


using Newtonsoft.Json; // Make sure this is installed and used
using DailyRecipeApp.Data;


namespace DailyRecipeApp.Services
{
    public class SpoonacularServices
    {
        private readonly HttpClient _httpClient;
        private string apiKey = "77bf324b50b74c939272fd51c505992c";

        public SpoonacularServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<RecipeData> GetRecipeAsync()
        {

            string requestUri = $"https://api.spoonacular.com/recipes/random?apiKey={apiKey}&number=1";

            HttpResponseMessage responce = await _httpClient.GetAsync(requestUri);

            if (responce.IsSuccessStatusCode)
            {
                string jsonResponse = await responce.Content.ReadAsStringAsync();
                var recipeData = JsonConvert.DeserializeObject<dynamic>(jsonResponse);

                if (recipeData.recipes.Count > 0)
                {
                    return new RecipeData
                    {
                        Title = recipeData.recipes[0].title,
                        Image = recipeData.recipes[0].image,
                        SourceUrl = recipeData.recipes[0].sourceUrl,
                        ReadyInMinutes = recipeData.recipes[0].readyInMinutes
                    };
                }
            }

            return null;
        }
    }
}

using Cocktails.Domain.Models;
using Cocktails.WebApi.Resources;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiClientConsoleApp
{
    public interface ICocktailProcess
    {
        Task<RawCocktailIdsListModel> LoadCocktailsIds(string url);
        Task<RawCocktailFullModel> LoadCocktail(int strDrink);
        List<Ingredient> getCocktailIngredients(RawCocktailFullModelItem rawCocktail, List<Ingredient> AllIngredients);
        SaveCocktailResource ProcessCocktailData(RawCocktailFullModelItem rawCocktail, int catId);
        void SaveCocktail(SaveCocktailResource resource, List<Ingredient> ingredients);
        int GetCategoryId(string categoryName, List<Category> allCategories);
    }
}
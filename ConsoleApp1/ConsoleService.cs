using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cocktails.Domain.Models;
using Cocktails.WebApi.Resources;
using ConsoleApp;
namespace ApiClientConsoleApp
{
    public class ConsoleService : IConsoleService
    {
        private ICategoriesProcess _categoriesProcess;
        private IIngredientsProcess _ingredientsProcess;
        private ICocktailProcess _cocktailProcess;

        public ConsoleService(ICategoriesProcess categoriesProcess,IIngredientsProcess ingredientsProcess, ICocktailProcess cocktailsProcess)
        {
            _categoriesProcess = categoriesProcess;
            _ingredientsProcess = ingredientsProcess;
            _cocktailProcess = cocktailsProcess;
        }

        public async void Categories()
        {
            RawCategoriesList RawCategs = await _categoriesProcess.LoadCategories();
            List<SaveCategoryResource> categories = _categoriesProcess.ProcessCategoryData(RawCategs);
            _categoriesProcess.SaveCategories(categories);
        }
        public async void Ingredients()
        {
            RawIngredientsList RawIngs = await _ingredientsProcess.LoadIngredients();
            List<SaveIngredientResource> ingredients = _ingredientsProcess.ProcessIngredientData(RawIngs);
            _ingredientsProcess.SaveIngredients(ingredients);
        }
        public async void Cocktails()
        {
            List<string> allUrls = new List<string>()
            {
                "https://www.thecocktaildb.com/api/json/v1/1/filter.php?c=Ordinary_Drink",
                "https://www.thecocktaildb.com/api/json/v1/1/filter.php?c=Milk_/_Float_/_Shake",
                //"https://www.thecocktaildb.com/api/json/v1/1/filter.php?c=Other_/_Unknown",
                "https://www.thecocktaildb.com/api/json/v1/1/filter.php?c=Coffee_/_Tea",
                "https://www.thecocktaildb.com/api/json/v1/1/filter.php?c=Punch_/_Party_Drinks",
                "https://www.thecocktaildb.com/api/json/v1/1/filter.php?c=Homemade_Liqueur",
                "https://www.thecocktaildb.com/api/json/v1/1/filter.php?c=Soft_Drink_/_Soda",
                "https://www.thecocktaildb.com/api/json/v1/1/filter.php?c=Cocktail",
                "https://www.thecocktaildb.com/api/json/v1/1/filter.php?c=Cocoa",
                "https://www.thecocktaildb.com/api/json/v1/1/filter.php?c=Beer",
                "https://www.thecocktaildb.com/api/json/v1/1/filter.php?c=Shot",
            };
            List<Category> allCategories = (await _categoriesProcess.GetAllCategories()).ToList();
            List<Ingredient> allIngredients = (await _ingredientsProcess.GetAllIngredients()).ToList();
            int catId;
            foreach (string url in allUrls)
            { 
            RawCocktailIdsListModel RawCocktailIds = await _cocktailProcess.LoadCocktailsIds(url);
            Console.WriteLine("Ids: "+ RawCocktailIds.Drinks);
            foreach (RawCocktailSimpleModel cocktailId in RawCocktailIds.Drinks)
            {
                Console.WriteLine("Call Id:" + cocktailId.idDrink);
                RawCocktailFullModel RawCocktail = await _cocktailProcess.LoadCocktail(cocktailId.idDrink);
                catId = _cocktailProcess.GetCategoryId(RawCocktail.Drinks[0].StrCategory, allCategories);
                SaveCocktailResource cocktail = _cocktailProcess.ProcessCocktailData(RawCocktail.Drinks[0], catId);
                List<Ingredient> ingredients = _cocktailProcess.getCocktailIngredients(RawCocktail.Drinks[0], allIngredients);
                _cocktailProcess.SaveCocktail(cocktail, ingredients);

                Console.WriteLine(RawCocktail.Drinks[0].StrDrink);
            }
}
            


        }
    }
}

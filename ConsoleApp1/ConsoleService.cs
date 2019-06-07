using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cocktails.Domain.Models;
using Cocktails.Domain.Repositories;
using Cocktails.WebApi.Resources;
using ConsoleApp;

namespace ApiClientConsoleApp
{
    public class ConsoleService : IConsoleService
    {
        private ICategoriesProcess _categoriesProcess;
        private IIngredientsProcess _ingredientsProcess;
        private ICocktailProcess _cocktailProcess;
        private IUnitOfWork _unitOfWork;

        public ConsoleService(ICategoriesProcess categoriesProcess,IIngredientsProcess ingredientsProcess, ICocktailProcess cocktailsProcess, IUnitOfWork unitOfWork)
        {
            _categoriesProcess = categoriesProcess;
            _ingredientsProcess = ingredientsProcess;
            _cocktailProcess = cocktailsProcess;
            _unitOfWork = unitOfWork;
        }

        public async Task Categories()
        {
            RawCategoriesList RawCategs = await _categoriesProcess.LoadCategories();
            List<SaveCategoryResource> categories = _categoriesProcess.ProcessCategoryData(RawCategs);
            _categoriesProcess.SaveCategories(categories);
        }
        public async Task Ingredients()
        {
            RawIngredientsList RawIngs = await _ingredientsProcess.LoadIngredients();
            List<SaveIngredientResource> ingredients = _ingredientsProcess.ProcessIngredientData(RawIngs);
            _ingredientsProcess.SaveIngredients(ingredients);
        }
        public async Task Cocktails()
        {
            int cocktailsCounter = 0;
            List<string> allUrls = new List<string>()
            {
                "https://www.thecocktaildb.com/api/json/v1/1/filter.php?c=Beer",
                "https://www.thecocktaildb.com/api/json/v1/1/filter.php?c=Cocoa",
                "https://www.thecocktaildb.com/api/json/v1/1/filter.php?c=Milk_/_Float_/_Shake",
                //"https://www.thecocktaildb.com/api/json/v1/1/filter.php?c=Other_/_Unknown", // bad url
                "https://www.thecocktaildb.com/api/json/v1/1/filter.php?c=Coffee_/_Tea",
                //"https://www.thecocktaildb.com/api/json/v1/1/filter.php?c=Punch_/_Party_Drinks", //bad url
                "https://www.thecocktaildb.com/api/json/v1/1/filter.php?c=Homemade_Liqueur",
                "https://www.thecocktaildb.com/api/json/v1/1/filter.php?c=Soft_Drink_/_Soda",
                "https://www.thecocktaildb.com/api/json/v1/1/filter.php?c=Cocktail",
                "https://www.thecocktaildb.com/api/json/v1/1/filter.php?c=Shot",
                "https://www.thecocktaildb.com/api/json/v1/1/filter.php?c=Ordinary_Drink"
            };
            List<Category> allCategories = (await _categoriesProcess.GetAllCategories()).ToList();
            List<Ingredient> allIngredients = (await _ingredientsProcess.GetAllIngredients()).ToList();
            int catId;
            foreach (string url in allUrls)
            {
                Console.WriteLine("Call: " + url);
                RawCocktailIdsListModel RawCocktailIds = await _cocktailProcess.LoadCocktailsIds(url);
                if (RawCocktailIds.Drinks != null)
                {
                    foreach (RawCocktailSimpleModel cocktailId in RawCocktailIds.Drinks)
                    {
                        RawCocktailFullModel RawCocktail = await _cocktailProcess.LoadCocktail(cocktailId.idDrink);
                        catId = _cocktailProcess.GetCategoryId(RawCocktail.Drinks[0].StrCategory, allCategories);
                        SaveCocktailResource cocktail = _cocktailProcess.ProcessCocktailData(RawCocktail.Drinks[0], catId);
                        List<Ingredient> ingredients = _cocktailProcess.getCocktailIngredients(RawCocktail.Drinks[0], allIngredients);
                        await _cocktailProcess.SaveCocktail(cocktail, ingredients);
                        cocktailsCounter++;
                        Console.WriteLine("Added: " + RawCocktail.Drinks[0].StrDrink);
                        Console.WriteLine("Total: " + cocktailsCounter);
                    }
                }
            }
        }
    }
}

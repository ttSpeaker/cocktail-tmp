using System;
using System.Collections.Generic;
using System.Text;
using Cocktails.WebApi.Resources;
using ConsoleApp;
namespace ApiClientConsoleApp
{
    public class ConsoleService : IConsoleService
    {
        private ICategoriesProcess _categoriesProcess;
        private IIngredientsProcess _ingredientsProcess;
        //private ICocktailProcess _cocktailProcess;

        public ConsoleService(ICategoriesProcess categoriesProcess,IIngredientsProcess ingredientsProcess/*, ICocktailProcess cocktailProcess*/ )
        {
            _categoriesProcess = categoriesProcess;
            _ingredientsProcess = ingredientsProcess;
            //_cocktailProcess = CocktailsProcess;
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
    }
}

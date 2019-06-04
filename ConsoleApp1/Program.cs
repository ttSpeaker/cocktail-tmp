using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cocktails.WebApi.Resources;
using Newtonsoft.Json.Linq;
using Cocktails.WebApi.Persistence.Repositories;
using Cocktails.WebApi.Domain.Repositories;
using Cocktails.WebApi.Controllers;
using Newtonsoft.Json;
using ApiClientConsoleApp;
using Microsoft.Extensions.DependencyInjection;
using Cocktails.WebApi.Domain.Services;
using Cocktails.WebApi.Services;

// GET DATA DE LA API
// PARSEAR LA DATA A OBJETO
// TRANSFORMARLA EN "SaveCategoryResource"
// USAR EL CategoryRepository p/ GUARDAR EN BD



namespace ConsoleApp1
{
    class Program
    {
        
        static void Main(string[] args)
        {
            ApiHelper.InitializeClient();
            Categories();
            Ingredients();
            Console.ReadKey();
        }
        public static async void Categories()
        {
            RawCategoriesList RawCategs = await CategoriesProcess.LoadCategories();
            List<SaveCategoryResource> categories = CategoriesProcess.ProcessCategoryData(RawCategs);
            CategoriesProcess.SaveCategories(categories);
        }
        public static async void Ingredients()
        {
            RawIngredientsList RawIngs = await IngredientsProcess.LoadIngredients();
            List<SaveIngredientResource> ingredients = IngredientsProcess.ProcessIngredientData(RawIngs);
            IngredientsProcess.SaveIngredients(ingredients);
        }


    }
}

//List<SaveCategoryResource> Categories = new List<SaveCategoryResource>()
//{
//    new SaveCategoryResource() {Name="Ordinary Drink"},
//    new SaveCategoryResource() {Name="Cocktail"},
//    new SaveCategoryResource() {Name="Milk Float Shake"},
//    new SaveCategoryResource() {Name="OtherUnknown"},
//    new SaveCategoryResource() {Name="Cocoa"},
//    new SaveCategoryResource() {Name="Shot"},
//    new SaveCategoryResource() {Name="Coffee Tea"},
//    new SaveCategoryResource() {Name="Homemade Liqueur"},
//    new SaveCategoryResource() {Name="Punch Party Drink"},
//    new SaveCategoryResource() {Name="Beer"},
//    new SaveCategoryResource() {Name="Soft Drink Soda"}
//}; 
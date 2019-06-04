using System;
using System.Collections.Generic;
using ApiClientConsoleApp;
using Cocktails.WebApi.Resources;


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
using Cocktails.WebApi.Resources;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class CategoriesProcess
    {
        public static async Task<RawCategoriesList> LoadCategories()
        {
            string url = "https://www.thecocktaildb.com/api/json/v1/1/list.php?c=list";
            using (HttpResponseMessage response = await ApiHelper.HttpClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    RawCategoriesList RawCategories = await response.Content.ReadAsAsync<RawCategoriesList>();
                    return RawCategories;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
        public static List<SaveCategoryResource> ProcessCategoryData (RawCategoriesList rawCategoriesList)
        {
            List<SaveCategoryResource> categories = new List<SaveCategoryResource>();
            foreach (RawCategoryModel rawCat in rawCategoriesList.Drinks)
            {
                categories.Add(new SaveCategoryResource() { Name = rawCat.StrCategory });
            }
            return categories;
        }
        public static void SaveCategories(List<SaveCategoryResource> categories)
        {
            //SAVE EACH CATEGORY
        }
        
    }
}
//class rawCategory
//{
//    public string strCategory { get; set; }
//}
//class rawCategoryList
//{
//    public List<rawCategory> Drinks { get; set; }
//}
using System.Collections.Generic;
using System.Threading.Tasks;
using Cocktails.WebApi.Resources;

namespace ConsoleApp
{
    public interface ICategoriesProcess
    {
        Task<RawCategoriesList> LoadCategories();
        List<SaveCategoryResource> ProcessCategoryData(RawCategoriesList rawCategoriesList);
        void SaveCategories(List<SaveCategoryResource> categories);
    }
}
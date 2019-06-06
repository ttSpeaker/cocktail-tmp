using System.Collections.Generic;
using System.Threading.Tasks;
using Cocktails.Domain.Models;
using Cocktails.WebApi.Resources;

namespace ConsoleApp
{
    public interface ICategoriesProcess
    {
        Task<RawCategoriesList> LoadCategories();
        List<SaveCategoryResource> ProcessCategoryData(RawCategoriesList rawCategoriesList);
        void SaveCategories(List<SaveCategoryResource> categories);
        Task<IEnumerable<Category>> GetAllCategories();

    }
}
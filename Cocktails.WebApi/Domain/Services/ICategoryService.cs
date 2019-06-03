using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cocktails.WebApi.Domain.Models;
using Cocktails.WebApi.Domain.Services.Communication;

namespace Cocktails.WebApi.Domain.Services
{
    public interface ICategoryService
    { 
        Task<IEnumerable<Category>> ListAsync();
        Task<CategoryResponse> SaveAsync(Category category);
        Task<CategoryResponse> UpdateAsync(int id,Category category);
        Task<CategoryResponse> DeleteAsync(int id);
    }
}

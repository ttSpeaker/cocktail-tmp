using AutoMapper;
using Cocktails.Domain.Models;
using Cocktails.WebApi.Resources;

namespace Cocktails.WebApi.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveCategoryResource, Category>();
            CreateMap<SaveCocktailResource, Cocktail>();
            CreateMap<SaveIngredientResource, Ingredient>();
        }
    }
}

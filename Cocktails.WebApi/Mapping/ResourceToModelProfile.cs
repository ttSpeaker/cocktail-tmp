using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Cocktails.WebApi.Domain.Models;
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

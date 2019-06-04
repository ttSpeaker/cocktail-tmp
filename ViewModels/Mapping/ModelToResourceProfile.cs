using System;
using AutoMapper;
using Cocktails.Domain.Models;
using Cocktails.Persistence.Contexts;
using Cocktails.WebApi.Resources;

namespace Cocktails.WebApi.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Category, CategoryResource>();
            CreateMap<Cocktail, CocktailResource>();
            CreateMap<Ingredient, IngredientResource>();
            var ciMap = CreateMap<CocktailIngredient, IngredientResource>();
            ciMap.ForMember(dest=>dest.Id, opt=> opt.MapFrom(src => src.Ingredient.Id));
            ciMap.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Ingredient.Name));

        }
    }
}

using Autofac;
using AutoMapper;
using Cocktails.Domain.Models;
using Cocktails.Domain.Repositories;
using Cocktails.Domain.Services;
using Cocktails.Persistence.Contexts;
using Cocktails.Persistence.Repositories;
using Cocktails.WebApi.Mapping;
using Cocktails.WebApi.Resources;
using Cocktails.WebApi.Services;
using ConsoleApp;
using Microsoft.EntityFrameworkCore;

namespace ApiClientConsoleApp
{
    public static class ContainerConfig
    {

        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Application>().As<IApplication>();
            builder.RegisterType<ConsoleService>().As<IConsoleService>();
            builder.RegisterType<CategoriesProcess>().As<ICategoriesProcess>();
            builder.RegisterType<IngredientsProcess>().As<IIngredientsProcess>();
            builder.RegisterType <CocktailsProcess>().As<ICocktailProcess>();

            builder.RegisterType<CategoryService>().As<ICategoryService>();
            builder.RegisterType<IngredientService>().As<IIngredientService>();
            builder.RegisterType<CocktailService>().As<ICocktailService>();

            builder.RegisterType<CategoryRepository>().As<ICategoryRepository>();
            builder.RegisterType<CocktailRepository>().As<ICocktailRepository>();
            builder.RegisterType<IngredientsRepository>().As<IIngredientRepository>();

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();

            var dbContextOptionsBuilder = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Cocktail;Trusted_Connection=True;MultipleActiveResultSets=true");

            builder.RegisterType<AppDbContext>()
                .WithParameter("options", dbContextOptionsBuilder.Options)
                .SingleInstance();

            builder.RegisterType<ResourceToModelProfile>();

            builder.RegisterAssemblyTypes().AssignableTo(typeof(Profile));

            builder.Register(c => new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<SaveCategoryResource, Category>();
                cfg.CreateMap<SaveCocktailResource, Cocktails.Domain.Models.Cocktail>();
                cfg.CreateMap<SaveIngredientResource, Ingredient>();
            })).AsSelf().SingleInstance();

            builder.Register(c => c.Resolve<MapperConfiguration>()
            .CreateMapper(c.Resolve)).As<IMapper>().InstancePerLifetimeScope();

            return builder.Build();
        }
    }
}

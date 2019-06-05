using Autofac;
using AutoMapper;
using Cocktails.Domain.Repositories;
using Cocktails.Persistence.Contexts;
using Cocktails.Persistence.Repositories;
using Cocktails.WebApi.Mapping;
using ConsoleApp;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

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
            //builder.RegisterType<CockTailsProcess>().As<ICocktailsProcess>();

            builder.RegisterType<CategoryRepository>().As<ICategoryRepository>();
            builder.RegisterType<CocktailRepository>().As<ICocktailRepository>();
            builder.RegisterType<IngredientsRepository>().As<IIngredientRepository>();

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();

            var dbContextOptionsBuilder = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlServer("DefaultConnectionString");

            builder.RegisterType<AppDbContext>()
                .WithParameter("options", dbContextOptionsBuilder.Options)
                .InstancePerLifetimeScope();

            builder.RegisterType<ResourceToModelProfile>();

            builder.RegisterAssemblyTypes().AssignableTo(typeof(Profile));

            builder.Register(c => new MapperConfiguration(cfg =>
            {
                foreach (var profile in c.Resolve<IEnumerable<Profile>>())
                {
                    cfg.AddProfile(profile);
                }
            })).AsSelf().SingleInstance();

            builder.Register(c => c.Resolve<MapperConfiguration>()
            .CreateMapper(c.Resolve)).As<IMapper>().InstancePerLifetimeScope();

            return builder.Build();
        }
    }
}

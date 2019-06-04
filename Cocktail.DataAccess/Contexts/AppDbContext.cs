using Cocktails.Domain.Models;
using Microsoft.EntityFrameworkCore;


namespace Cocktails.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Domain.Models.Cocktail> Cocktails { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Category>().ToTable("Categories");
            builder.Entity<Category>().HasKey(p => p.Id);
            builder.Entity<Category>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Category>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.Entity<Category>().HasMany(p => p.Cocktails).WithOne(p => p.Category).HasForeignKey(p => p.CategoryId);

            builder.Entity<Domain.Models.Cocktail>().ToTable("Cocktails");
            builder.Entity<Domain.Models.Cocktail>().HasKey(c => c.Id);
            builder.Entity<Domain.Models.Cocktail>().Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Domain.Models.Cocktail>().Property(c => c.Name).IsRequired().HasMaxLength(50);
            builder.Entity<Domain.Models.Cocktail>().Property(c => c.Thumb).IsRequired();
            builder.Entity<Domain.Models.Cocktail>().Property(c => c.Instructions).IsRequired();
            builder.Entity<Domain.Models.Cocktail>().Property(c => c.Glass);
            builder.Entity<Domain.Models.Cocktail>().Property(c => c.Alcoholic);
            builder.Entity<Domain.Models.Cocktail>().Property(c => c.Tags);

            builder.Entity<Ingredient>().ToTable("Ingredients");
            builder.Entity<Ingredient>().HasKey(i => i.Id);
            builder.Entity<Ingredient>().Property(i => i.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Ingredient>().Property(i => i.Name).IsRequired().HasMaxLength(30);

            builder.Entity<CocktailIngredient>().HasKey(ci => new { ci.CocktailId, ci.IngredientId });
            //builder.Entity<CocktailIngredient>().HasOne(c => c.Cocktail).WithMany(ci => ci.CocktailIngredients).HasForeignKey(c => c.CocktailId);
            //builder.Entity<CocktailIngredient>().HasOne(i => i.Ingredient).WithMany(ci => ci.CocktailIngredients).HasForeignKey(c => c.IngredientId);

            builder.Entity<CocktailIngredient>()
                .HasOne(e => e.Cocktail)
                .WithMany(e => e.IngredientsTo)
                .HasForeignKey(e => e.CocktailId);

            builder.Entity<CocktailIngredient>()
                .HasOne(e => e.Ingredient)
                .WithMany(e => e.CocktailWith)
                .HasForeignKey(e => e.IngredientId);

            //builder.Entity<Category>().HasData
            //   (
            //       new Category { Id = 100, Name = "Cocktail" }, // Id set manually due to in-memory provider
            //       new Category { Id = 101, Name = "Beer" }
            //   );
            //builder.Entity<Cocktail>().HasData
            //  (
            //      new Cocktail { Id = 100, Name = "Cocktail Name 1", Thumb = "Image/URL", Instructions = "How To Make it", CategoryId = 100 },
            //      new Cocktail { Id = 101, Name = "Cocktail Name 2", Thumb = "Image/URL", Instructions = "How To Make it", CategoryId = 100 },
            //      new Cocktail { Id = 102, Name = "Cocktail Name 3", Thumb = "Image/URL", Instructions = "How To Make it", CategoryId = 100 }
            //  );
            //builder.Entity<Ingredient>().HasData
            //    (
            //        new Ingredient { Id = 100, Name = "Ingrediente 1" },
            //        new Ingredient { Id = 101, Name = "Ingrediente 2" }
            //    );
            //builder.Entity<CocktailIngredient>().HasData
            //    (
            //        new CocktailIngredient { CocktailId = 100, IngredientId = 100 },
            //        new CocktailIngredient { CocktailId = 100, IngredientId = 101 }
            //    );
        }

    }
}

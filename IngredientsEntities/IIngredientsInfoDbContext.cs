using IngredientsEntities.Entities;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace IngredientsEntities
{
    public interface IIngredientsInfoDbContext
    {
        //DbSet<T> Set<T>() where T : class;
        //DbEntityEntry<T> Entry<T>(T entity) where T : class;
        DbSet<Allergen> Allergens { get; set; }
        DbSet<Ingredient> Ingredients { get; set; }
        DbSet<Dish> Dishes { get; set; }
        int SaveChanges();
        void Dispose();
    }
}
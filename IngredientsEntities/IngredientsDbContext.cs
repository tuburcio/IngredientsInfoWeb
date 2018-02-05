using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IngredientsEntities.Entities;

namespace IngredientsEntities
{
    public class IngredientsInfoDbContext : DbContext, IIngredientsInfoDbContext
    {
        public IngredientsInfoDbContext() : base("IngredientsInfoConnectionString")
        {
        }

        public DbSet<Allergen> Allergens { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Dish> Dishes { get; set; }
    }
}

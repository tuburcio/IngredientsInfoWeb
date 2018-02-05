namespace IngredientsEntities.Migrations
{
    using IngredientsEntities.Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<IngredientsEntities.IngredientsInfoDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(IngredientsEntities.IngredientsInfoDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            Dish d1 = new Dish
            {
                Id = 1,
                Name = "Leche Frita"
            };
            context.Dishes.AddOrUpdate(d1);
            
            Dish d2 = new Dish
            {
                Id = 2,
                Name = "Patatas con salsa rosa"
            };
            context.Dishes.AddOrUpdate(d2);

            context.SaveChanges();

            Ingredient i1 = new Ingredient
            {

                Id = 1,
                Name = "Leche"
            };
            i1.Dishes = new List<Dish>();
            i1.Dishes.Add(d1);

            Ingredient i2 = new Ingredient
            {

                Id = 2,
                Name = "Mayonesa"
            };
            i2.Dishes = new List<Dish>();
            i2.Dishes.Add(d2);

            context.Ingredients.AddOrUpdate(i1);
            context.Ingredients.AddOrUpdate(i2);

            Allergen a1 = new Allergen
            {
                Id = 1,
                Name = "Lactosa"
            };
            i1.Allergens = new List<Allergen>();
            i1.Allergens.Add(a1);
            context.Allergens.AddOrUpdate(a1);

            Allergen a2 = new Allergen
            {
                Id = 2,
                Name = "Huevo"
            };
            i2.Allergens = new List<Allergen>();
            i2.Allergens.Add(a2);
            context.Allergens.AddOrUpdate(a2);

            context.SaveChanges();
        }
    }
}

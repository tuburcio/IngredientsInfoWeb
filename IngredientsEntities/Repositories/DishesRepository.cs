using IngredientsEntities.Entities;
using IngredientsEntities.DTO;
using IngredientsEntities.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace IngredientsEntities.Repositories
{
    public class DishesRepository : IDishesRepository
    {
        private readonly IIngredientsInfoDbContext dbContext;
        public DishesRepository(IIngredientsInfoDbContext newDbContext)
        {
            this.dbContext = newDbContext;
        }
        public void AddDish(DishDTO newDish)
        {
            this.dbContext.Ingredients.AddRange(AutoMapper.Mapper.Map<IEnumerable<Ingredient>>(newDish.Ingredients));
            this.dbContext.Dishes.Add(AutoMapper.Mapper.Map<Dish>(newDish));

            this.dbContext.SaveChanges();
        }

        public void AddIngredient(int dishId, IngredientDTO newIngredient)
        {
            var dish = this.dbContext.Dishes.SingleOrDefault(x => x.Id == dishId);
            if (dish != null)
            {
                dish.Ingredients.Add(AutoMapper.Mapper.Map<Ingredient>(newIngredient));
                this.dbContext.SaveChanges();
            }
        }

        public void AddIngredientToDish(int dishId, IngredientDTO newIngredient)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AllergenDTO> GetAllergensFromDish(int id)
        {
            var result = this.dbContext.Dishes
                .Include("Ingredients.Allergens")
                .Where(x => x.Id == id)
                .SelectMany(x => x.Ingredients.SelectMany(y => y.Allergens).Select(y => new AllergenDTO { Id = y.Id, Name = y.Name }))
                .ToList();

            return this.dbContext.Dishes
                .Include("Ingredients.Allergens")
                .Where(x => x.Id == id)
                .SelectMany(x => x.Ingredients.SelectMany(y => y.Allergens).Select(y => new AllergenDTO { Id = y.Id, Name = y.Name }))
                .ToList();
        }

        public DishDTO GetDish(int id)
        {
            return this.dbContext.Dishes
                .Include("Ingredients")
                .Where(x => x.Id == id)
                .Select(x => new DishDTO
                {
                    Id = x.Id,
                    Ingredients = x.Ingredients.Select(y => new IngredientDTO { Id = y.Id, Name = y.Name }),
                    Name = x.Name
                })
                .SingleOrDefault();
        }

        public IEnumerable<DishDTO> GetDishes()
        {
            return this.dbContext.Dishes
                .Include("Ingredients")
                .Select(x => new DishDTO
                {
                    Id = x.Id,
                    Ingredients = x.Ingredients.Select(y => new IngredientDTO { Id = y.Id, Name = y.Name }),
                    Name = x.Name
                })
                .ToList();
            //return this.dbContext.Set<Dish>().Select(x => new DishDTO { Id = x.Id, Name = x.Name });
        }

        public IEnumerable<DishDTO> GetDishesForAllergen(AllergenDTO allergen)
        {
            var result = this.dbContext.Allergens
                .Include("Ingredients.Dishes")
                .Where(x => x.Id == allergen.Id)
                .SelectMany(x => x.Ingredients.SelectMany(y => y.Dishes));
            return null;
        }

        public void RemoveDish(int id)
        {
            var dish = this.dbContext.Dishes.SingleOrDefault(x => x.Id == id);
            if (dish != null)
            {
                this.dbContext.Dishes.Remove(dish);
                this.dbContext.SaveChanges();
            }
        }

        public void RemoveIngredientFromDish(int dishId, int ingredientId)
        {
            var dish = this.dbContext.Dishes
                .Include("Ingredients")
                .SingleOrDefault(x => x.Id == dishId);
            var ingredient = dish.Ingredients.SingleOrDefault(x => x.Id == ingredientId);
            if (ingredient != null)
            {
                dish.Ingredients.Remove(ingredient);
                this.dbContext.SaveChanges();
            }
        }

        public void UpdateDish(DishDTO modifiedDish)
        {
            var entry = AutoMapper.Mapper.Map<Dish>(modifiedDish);
            var attachedentry = this.dbContext.Dishes.Find(entry.Id);
            if (attachedentry != null)
            {
                ((DbContext)this.dbContext).Entry(attachedentry).CurrentValues.SetValues(entry);
                this.dbContext.SaveChanges();
            }
        }
    }
}

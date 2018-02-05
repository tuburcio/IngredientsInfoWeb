using IngredientsEntities.DTO;
using IngredientsEntities.Entities;
using IngredientsEntities.IRepositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace IngredientsEntities.Repositories
{
    public class IngredientsRepository : IIngredientsRepository
    {
        #region Fields
        private readonly IIngredientsInfoDbContext dbContext;
        #endregion

        #region Constructor
        public IngredientsRepository(IIngredientsInfoDbContext newDbContext)
        {
            this.dbContext = newDbContext;
        } 
        #endregion

        public void AddAllergen(int ingredientId, AllergenDTO allergen)
        {
            var newallergen = AutoMapper.Mapper.Map<Allergen>(allergen);
            var ingredient = this.dbContext.Ingredients.SingleOrDefault(x => x.Id == ingredientId);
            if (ingredient != null)
            {
                ingredient.Allergens.Add(newallergen);
                this.dbContext.SaveChanges();
            }
        }

        public void AddIngredient(IngredientDTO newIngredient)
        {
            var ingredient = AutoMapper.Mapper.Map<Ingredient>(newIngredient);
            if (ingredient != null && ingredient.Id <= 0)
            {
                this.dbContext.Ingredients.Add(ingredient);
                this.dbContext.SaveChanges();
            }
        }

        public IEnumerable<AllergenDTO> GetAllergens(int ingredientId)
        {
            return AutoMapper.Mapper.Map<IEnumerable<AllergenDTO>>(
                this.dbContext.Ingredients
                        .Include("Allergens")
                        .Where(x => x.Id == ingredientId)
                        .Select(x => x.Allergens));
        }

        public IngredientDTO GetIngredientById(int id)
        {
            var ingredient = this.dbContext.Ingredients.SingleOrDefault(x => x.Id == id);
            if (ingredient != null)
            {
                return AutoMapper.Mapper.Map<IngredientDTO>(ingredient);
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<IngredientDTO> GetIngredients()
        {
            return AutoMapper.Mapper.Map<IEnumerable<IngredientDTO>>(
                    this.dbContext.Ingredients.ToList());
        }

        public void RemoveAllergen(int ingredientId, AllergenDTO allergen)
        {
            throw new NotImplementedException();
        }

        public void RemoveIngredient(int id)
        {
            var ingredient = this.dbContext.Ingredients.SingleOrDefault(x => x.Id == id);
            if (ingredient != null)
            {
                this.dbContext.Ingredients.Remove(ingredient);
                this.dbContext.SaveChanges();
            }
        }

        public void UpdateIngredient(IngredientDTO modifiedIngredient)
        {
            var entry = AutoMapper.Mapper.Map<Ingredient>(modifiedIngredient);
            var attachedentry = this.dbContext.Ingredients.Find(entry.Id);
            if (attachedentry != null)
            {
                ((DbContext)this.dbContext).Entry(attachedentry).CurrentValues.SetValues(entry);
                this.dbContext.SaveChanges();
            }
        }
    }
}

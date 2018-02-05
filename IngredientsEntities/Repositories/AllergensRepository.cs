using IngredientsEntities.DTO;
using IngredientsEntities.Entities;
using IngredientsEntities.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngredientsEntities.Repositories
{
    public class AllergensRepository : IAllergensRepository
    {
        private readonly IIngredientsInfoDbContext dbContext;
        public AllergensRepository(IIngredientsInfoDbContext newDbContext)
        {
            this.dbContext = newDbContext;
        }

        public void AddAllergen(AllergenDTO newAllergen)
        {
            var allergen = AutoMapper.Mapper.Map<Allergen>(newAllergen);
            this.dbContext.Allergens.Add(allergen);
            this.dbContext.SaveChanges();
        }

        public AllergenDTO GetAllergen(int id)
        {
            var result = this.dbContext.Allergens
                .SingleOrDefault(x => x.Id == id);
            return AutoMapper.Mapper.Map<AllergenDTO>(result);
        }

        public AllergenDTO GetAllergenByName(string name)
        {
            var allergen = this.dbContext.Allergens.FirstOrDefault(x => x.Name == name);
            if(allergen != null)
            {
                return AutoMapper.Mapper.Map<AllergenDTO>(allergen);
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<AllergenDTO> GetAllergens()
        {
            var result = this.dbContext.Allergens.ToList();
            return AutoMapper.Mapper.Map<IEnumerable<AllergenDTO>>(result);
        }

        public IEnumerable<DishDTO> GetDishesForAllergen(int allergenId)
        {
            var result = this.dbContext.Allergens
                .Include("Ingredients.Dishes")
                .Where(x => x.Id == allergenId)
                .SelectMany(x => x.Ingredients.SelectMany(y => y.Dishes))
                .ToList();
            return AutoMapper.Mapper.Map<IEnumerable<DishDTO>>(result);
        }

        public void ModifyAllergen(AllergenDTO updatedAllergen)
        {
            throw new NotImplementedException();
        }
    }
}

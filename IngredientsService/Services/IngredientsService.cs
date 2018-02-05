using IngredientsEntities.DTO;
using IngredientsEntities.IRepositories;
using IngredientsService.IServices;
using IngredientsService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngredientsService.Services
{
    public class IngredientsService : IIngredientsService
    {
        private readonly IIngredientsRepository ingredientsRepository;
        public IngredientsService(IIngredientsRepository newIngredientsRepository)
        {
            this.ingredientsRepository = newIngredientsRepository;
        }

        public void AddAllergen(int ingredientId, AllergenViewModel newAllergen)
        {
            var allergen = AutoMapper.Mapper.Map<AllergenDTO>(newAllergen);
            if (allergen != null)
            {
                this.ingredientsRepository.AddAllergen(ingredientId, allergen);
            }
        }

        public void AddIngredient(IngredientsViewModel ingredient)
        {
            var newIngredient = AutoMapper.Mapper.Map<IngredientDTO>(ingredient);
            this.ingredientsRepository.AddIngredient(newIngredient);
        }

        public IEnumerable<AllergenViewModel> GetAllergensForIngredient(int id)
        {
            throw new NotImplementedException();
        }

        public IngredientsViewModel GetIngredient(int id)
        {
            var ingredient = this.ingredientsRepository.GetIngredientById(id);
            return AutoMapper.Mapper.Map<IngredientsViewModel>(ingredient);
        }

        public IEnumerable<IngredientsViewModel> GetIngredients()
        {
            var ingredients = this.ingredientsRepository.GetIngredients();
            return AutoMapper.Mapper.Map<IEnumerable<IngredientsViewModel>>(ingredients);
        }

        public void RemoveAllergen(int ingredientId, AllergenViewModel allergen)
        {
            var ingredient = this.ingredientsRepository.GetIngredientById(ingredientId);

        }
    }
}

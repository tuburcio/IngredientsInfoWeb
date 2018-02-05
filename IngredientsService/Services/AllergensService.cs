using System.Collections.Generic;
using IngredientsEntities.DTO;
using IngredientsEntities.IRepositories;
using IngredientsService.IServices;
using IngredientsService.ViewModels;

namespace IngredientsService.Services
{
    public class AllergensService : IAllergensService
    {
        private readonly IAllergensRepository allergensRepository;
        public AllergensService(IAllergensRepository newAllergensRepository)
        {
            this.allergensRepository = newAllergensRepository;
        }
        public void AddAllergen(AllergenViewModel newAllergen)
        {
            if (string.IsNullOrWhiteSpace(this.allergensRepository.GetAllergenByName(newAllergen.Name)?.Name))
            {
                this.allergensRepository.AddAllergen(AutoMapper.Mapper.Map<AllergenDTO>(newAllergen));
            }
        }

        public AllergenViewModel GetAllergen(int id)
        {
            var result = this.allergensRepository.GetAllergen(id);
            return AutoMapper.Mapper.Map<AllergenViewModel>(result);
        }

        public IEnumerable<AllergenViewModel> GetAllergens()
        {
            var result = this.allergensRepository.GetAllergens();
            return AutoMapper.Mapper.Map<IEnumerable<AllergenViewModel>>(result);
        }

        public IEnumerable<DishViewModel> GetDishesWithAllergen(int allergenId)
        {
            var result = this.allergensRepository.GetDishesForAllergen(allergenId);

            return AutoMapper.Mapper.Map<IEnumerable<DishViewModel>>(result);
        }
    }
}
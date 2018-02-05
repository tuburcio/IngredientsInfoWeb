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
    public class DishesService :IDishesService
    {
        private readonly IDishesRepository dishesRepository;
        public DishesService(IDishesRepository newDishesRepository)
        {
            this.dishesRepository = newDishesRepository;
        }

        public void AddDish(DishViewModel newDish)
        {
            throw new NotImplementedException();
        }


        public IEnumerable<AllergenViewModel> GerAllergenForDishById(int id)
        {
            return AutoMapper.Mapper.Map<IEnumerable<AllergenViewModel>>(this.dishesRepository.GetAllergensFromDish(id));
        }

        public void AddIngredient(int dishId, IngredientsViewModel newIngredient)
        {
            
        }

        public void AddIngredientForDish(int dishId, IngredientsViewModel newIngredient)
        {
            throw new NotImplementedException();
        }

        public DishViewModel GetDish(int id)
        {
            return AutoMapper.Mapper.Map<DishViewModel>(this.dishesRepository.GetDish(id));
        }

        public IEnumerable<DishViewModel> GetDishes()
        {
            return AutoMapper.Mapper.Map<IEnumerable<DishViewModel>>(this.dishesRepository.GetDishes().ToList());
        }

        public IEnumerable<IngredientsViewModel> GetIngredientsForDish(int id)
        {
            throw new NotImplementedException();
        }

        public void RemoveIngredientFromDish(int dishId, int ingredientId)
        {
            this.dishesRepository.RemoveIngredientFromDish(dishId, ingredientId);
        }
    }
}

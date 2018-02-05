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
    public class DishesService : IDishesService
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


        public IEnumerable<AllergenViewModel> GerAllergenFromDishById(int id)
        {
            return AutoMapper.Mapper.Map<IEnumerable<AllergenViewModel>>(this.dishesRepository.GetAllergensFromDish(id));
        }

        public void AddIngredientToDish(int dishId, IngredientViewModel newIngredient)
        {
            this.dishesRepository.AddIngredientToDish(dishId, AutoMapper.Mapper.Map<IngredientDTO>(newIngredient));
        }

        public DishViewModel GetDish(int id)
        {
            return AutoMapper.Mapper.Map<DishViewModel>(this.dishesRepository.GetDish(id));
        }

        public IEnumerable<DishViewModel> GetDishes()
        {
            return AutoMapper.Mapper.Map<IEnumerable<DishViewModel>>(this.dishesRepository.GetDishes().ToList());
        }

        public IEnumerable<IngredientViewModel> GetIngredientsFromDish(int id)
        {
            var ingredients = this.dishesRepository.GetDish(id);
            if (ingredients != null)
            {
                return AutoMapper.Mapper.Map<IEnumerable<IngredientViewModel>>(ingredients.Ingredients);
            }
            return null;
        }

        public void RemoveIngredientFromDish(int dishId, int ingredientId)
        {
            this.dishesRepository.RemoveIngredientFromDish(dishId, ingredientId);
        }

        public void DeleteDish(int id)
        {
            this.dishesRepository.RemoveDish(id);
        }

        public void RenameDish(int id, string newName)
        {
            var dish = this.dishesRepository.GetDish(id);
            if (dish != null)
            {
                dish.Name = newName;
                this.dishesRepository.UpdateDish(
                    AutoMapper.Mapper.Map<DishDTO>(dish));
            }
        }
    }
}

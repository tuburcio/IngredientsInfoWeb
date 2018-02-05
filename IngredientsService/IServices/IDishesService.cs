using IngredientsService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IngredientsService.IServices
{
    public interface IDishesService
    {
        IEnumerable<DishViewModel> GetDishes();

        DishViewModel GetDish(int id);

        IEnumerable<IngredientsViewModel> GetIngredientsForDish(int id);

        IEnumerable<AllergenViewModel> GerAllergenForDishById(int id);

        void AddDish(DishViewModel newDish);

        void RemoveIngredientFromDish(int dishId, int ingredientId);

        void AddIngredientForDish(int dishId, IngredientsViewModel newIngredient);
    }
}
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

        IEnumerable<IngredientViewModel> GetIngredientsFromDish(int id);

        IEnumerable<AllergenViewModel> GerAllergenFromDishById(int id);

        void AddDish(DishViewModel newDish);

        void RemoveIngredientFromDish(int dishId, int ingredientId);

        void AddIngredientToDish(int dishId, IngredientViewModel newIngredient);
        void RenameDish(int id, string newName);
        void DeleteDish(int id);
    }
}
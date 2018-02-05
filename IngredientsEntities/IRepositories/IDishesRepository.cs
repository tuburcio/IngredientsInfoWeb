using IngredientsEntities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngredientsEntities.IRepositories
{
    public interface IDishesRepository
    {
        IEnumerable<DishDTO> GetDishes();
        DishDTO GetDish(int id);
        void AddDish(DishDTO newDish);
        void AddIngredientToDish(int dishId, IngredientDTO newIngredient);
        void RemoveIngredientFromDish(int dishId, int ingredientId);
        void RemoveDish(int dishId);
        IEnumerable<AllergenDTO> GetAllergensFromDish(int id);
    }
}

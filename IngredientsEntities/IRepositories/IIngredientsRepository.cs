using IngredientsEntities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngredientsEntities.IRepositories
{
    public interface IIngredientsRepository
    {
        IEnumerable<IngredientDTO> GetIngredients();
        IngredientDTO GetIngredientById(int id);
        void AddIngredient(IngredientDTO newIngredient);
        IEnumerable<AllergenDTO> GetAllergens(int ingredientId);
        void RemoveAllergen(int ingredientId, AllergenDTO allergen);
        void AddAllergen(int ingredientId, AllergenDTO allergen);
        void RemoveIngredient(int id);
        void UpdateIngredient(IngredientDTO modifiedIngredient);
    }
}

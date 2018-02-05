using IngredientsService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngredientsService.IServices
{
    public interface IIngredientsService
    {
        IngredientViewModel GetIngredient(int id);
        IEnumerable<IngredientViewModel> GetIngredients();
        void AddIngredient(IngredientViewModel ingredient);
        void AddAllergen(int ingredientId, AllergenViewModel newAllergen);
        void RemoveAllergen(int ingredientId, AllergenViewModel allergen);
        IEnumerable<AllergenViewModel> GetAllergensForIngredient(int id);
        void RenameIngredient(int id, string newName);
        void DeleteIngredient(int id);
    }
}

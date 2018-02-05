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
        IngredientsViewModel GetIngredient(int id);
        IEnumerable<IngredientsViewModel> GetIngredients();
        void AddIngredient(IngredientsViewModel ingredient);
        void AddAllergen(int ingredientId, AllergenViewModel newAllergen);
        void RemoveAllergen(int ingredientId, AllergenViewModel allergen);
        IEnumerable<AllergenViewModel> GetAllergensForIngredient(int id);
    }
}

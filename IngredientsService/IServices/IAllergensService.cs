using IngredientsService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngredientsService.IServices
{
    public interface IAllergensService
    {
        void AddAllergen(AllergenViewModel newAllergen);
        IEnumerable<DishViewModel> GetDishesWithAllergen(int allergenId);
        IEnumerable<AllergenViewModel> GetAllergens();
        AllergenViewModel GetAllergen(int id);
        void RenameAllergen(int id, AllergenViewModel allergen);
        void DeleteAllergen(int id);
    }
}

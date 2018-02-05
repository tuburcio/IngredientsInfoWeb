using IngredientsEntities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngredientsEntities.IRepositories
{
    public interface IAllergensRepository
    {
        AllergenDTO GetAllergenByName(string name);
        AllergenDTO GetAllergen(int id);
        IEnumerable<AllergenDTO> GetAllergens();
        void AddAllergen(AllergenDTO newAllergen);
        void ModifyAllergen(AllergenDTO updatedAllergen);
        IEnumerable<DishDTO> GetDishesForAllergen(int allergenId);
    }
}

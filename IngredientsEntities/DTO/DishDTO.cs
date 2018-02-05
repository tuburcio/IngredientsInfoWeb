using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngredientsEntities.DTO
{
    public class DishDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<IngredientDTO> Ingredients { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngredientsEntities.Entities
{
    public class Ingredient
    {
        [Key]
        public int Id { get; set; }
        
        public string Name { get; set; }

        public virtual ICollection<Allergen> Allergens { get; set; }

        public virtual ICollection<Dish> Dishes { get; set; }
    }
}

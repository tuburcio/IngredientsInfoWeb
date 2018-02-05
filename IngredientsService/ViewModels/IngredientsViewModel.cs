using System.Collections.Generic;

namespace IngredientsService.ViewModels
{
    public class IngredientsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<AllergenViewModel> Allergens { get; set; }
    }
}
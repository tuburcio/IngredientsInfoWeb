using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IngredientsService.ViewModels
{
    public class DishViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<IngredientsViewModel> Ingredients {get;set;}
    }
}
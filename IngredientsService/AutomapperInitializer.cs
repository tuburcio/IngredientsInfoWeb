using IngredientsEntities.DTO;
using IngredientsEntities.Entities;
using IngredientsService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngredientsService
{
    public static class AutomapperInitializer
    {
        public static void ConfigureMappings()
        {
            AutoMapper.Mapper.Initialize(config =>
            {
                config.CreateMap<DishViewModel, DishDTO>();

                config.CreateMap<AllergenDTO, Allergen>();
                config.CreateMap<Allergen, AllergenDTO>();
                config.CreateMap<IngredientDTO, Ingredient>();
                config.CreateMap<Ingredient, IngredientDTO>();
                config.CreateMap<DishDTO, Dish>();
                config.CreateMap<Dish, DishDTO>();
            });
        }
    }
}

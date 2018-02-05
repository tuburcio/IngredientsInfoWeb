using IngredientsService.IServices;
using IngredientsService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IngredientsInfoWeb.Controllers
{
    [RoutePrefix("api/dishes")]
    public class DishesController : ApiController
    {
        private readonly IDishesService dishesService;

        public DishesController(IDishesService newDishesService)
        {
            dishesService = newDishesService;
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetDishes()
        {
            return Ok(dishesService.GetDishes());
        }

        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult GetDishById(int id)
        {
            return Ok(dishesService.GetDish(id));
        }

        [HttpGet]
        [Route("{id:int}/allergens")]
        public IHttpActionResult GetAllergensForDishById(int id)
        {
            return Ok(dishesService.GerAllergenForDishById(id));
        }

        [HttpPost]
        public IHttpActionResult AddDish([FromBody] DishViewModel newDishViewModel)
        {
            this.dishesService.AddDish(newDishViewModel);
            return Ok();
        }

        [HttpDelete]
        [Route("{id:int}/ingredients/{ingredientid:int}")]
        public IHttpActionResult RemoveIngredient(int id, int ingredientid)
        { 
            this.dishesService.RemoveIngredientFromDish(id, ingredientid);
            return Ok();
        }
    }
}

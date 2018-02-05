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
    [RoutePrefix("api/ingredients")]
    public class IngredientsController : ApiController
    {
        private readonly IIngredientsService ingredientsService;
        public IngredientsController(IIngredientsService newIngredientsService)
        {
            this.ingredientsService = newIngredientsService;
        }
        [HttpGet]
        [Route("")]
        public IHttpActionResult Get()
        {
            var ingredients = this.ingredientsService.GetIngredients();
            return Ok(ingredients);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult Get(int id)
        {
            var ingredient = this.ingredientsService.GetIngredient(id);
            return Ok(ingredient);
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult Post([FromBody]IngredientsViewModel value)
        {
            if (value == null)
            {
                return BadRequest();
            }
            else
            {
                this.ingredientsService.AddIngredient(value);
                return Ok();
            }
        }

        [HttpPost]
        [Route("{id:int}/allergens")]
        public IHttpActionResult Post(int id, [FromBody]AllergenViewModel newAllergen)
        {
            if (newAllergen == null)
            {
                return BadRequest();
            }
            else
            {
                this.ingredientsService.AddAllergen(id, newAllergen);
            }
            return Ok();
        }

        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody]string value)
        {
            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            return Ok();
        }
    }
}

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
    [RoutePrefix("api/allergens")]
    public class AllergensController : ApiController
    {
        private readonly IAllergensService allergensService;

        public AllergensController(IAllergensService newAllergensService)
        {
            this.allergensService = newAllergensService;
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult Get()
        {
            var result = this.allergensService.GetAllergens();
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult Get(int id)
        {
            var result = this.allergensService.GetAllergen(id);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("{id:int}/dishes")]
        public IHttpActionResult GetDishesForAllergen(int id)
        {
            var result = this.allergensService.GetDishesWithAllergen(id);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult Post([FromBody] AllergenViewModel value)
        {
            if (value != null)
            {
                this.allergensService.AddAllergen(value);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }


        [HttpPut]
        [Route("{id:int}")]
        public IHttpActionResult ModifyAllergen(int id, [FromBody] AllergenViewModel allergen) 
        {
            if (allergen == null)
            {
                return BadRequest();
            }
            else
            {
                this.allergensService.RenameAllergen(id, allergen);
            }
            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            this.allergensService.DeleteAllergen(id);
            return Ok();
        }
    }
}

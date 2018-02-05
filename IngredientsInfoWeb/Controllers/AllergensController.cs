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
        public IHttpActionResult Put(int id, [FromBody]string value)
        {
            return Ok();
        }

        // DELETE: api/Allergens/5
        public void Delete(int id)
        {
        }
    }
}

using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using winter20_burgershack.Models;
using winter20_burgershack.Services;

namespace winter20_burgershack.Controllers
{
          [ApiController]
    [Route("api/[controller]")]
    public class DrinksController: ControllerBase
    {
        private readonly DrinkService _ds;
        public DrinksController(DrinkService ds)
        {
            _ds = ds;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Drink>> Get()
        {
            try
            {
                return Ok(_ds.Get());
            }
            catch (System.Exception err)
            {
                
                return BadRequest(err.Message);
            }
        }

        [HttpGet("{drinkId}")]
        public ActionResult<Drink> GetDrinkById(int drinkId)
        {
            try
            {
                return Ok(_ds.GetDrinkById(drinkId));
            }
            catch (System.Exception err)
            {
                
                return BadRequest(err.Message);
            }
        }

        [HttpPost]
        public ActionResult<Drink> CreateDrink([FromBody] Drink newDrink)
        {
            try
            {
                return Ok(_ds.CreateDrink(newDrink));
            }
            catch (System.Exception err)
            {
                
                return BadRequest(err.Message);
            }
        }

        [HttpPut("{drinkId}")]
        public ActionResult<Drink> EditDrink([FromBody] Drink updatedDrink, int drinkId)
        {
            try
            {
                updatedDrink.Id = drinkId;
                return Ok(_ds.EditDrink(updatedDrink));
            }
            catch (System.Exception err)
            {
                
                return BadRequest(err.Message);
            }
        }

        [HttpDelete("{drinkId}")]
        public ActionResult<string> DeleteDrink(int drinkId)
        {
            try
            {
                _ds.Delete(drinkId);
                return Ok("Deleted the drink");
            }
            catch (System.Exception err)
            {
                
                return BadRequest(err.Message);
            }
        }






    }
}
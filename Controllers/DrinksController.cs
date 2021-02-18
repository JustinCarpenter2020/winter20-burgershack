using Microsoft.AspNetCore.Mvc;
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
    }
}
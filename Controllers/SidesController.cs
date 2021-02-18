using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using winter20_burgershack.Models;
using winter20_burgershack.Services;

namespace winter20_burgershack.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SidesController: ControllerBase
    {
        private readonly SideService _ss;
        public SidesController(SideService ss)
        {
            _ss = ss;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Side>> Get()
        {
            try
            {
                return Ok(_ss.Get());
            }
            catch (System.Exception err)
            {
                
                return BadRequest(err.Message);
            }
        }

        [HttpGet("{sideId}")]
        public ActionResult<Side> GetSideById(int sideId)
        {
            try
            {
                return Ok(_ss.GetSideById(sideId));
            }
            catch (System.Exception err)
            {
                
                return BadRequest(err.Message);
            }
        }

        [HttpPost]
        public ActionResult<Side> CreateSide([FromBody] Side newSide)
        {
            try
            {
                return Ok(_ss.CreateSide(newSide));
            }
            catch (System.Exception err)
            {
                
                return BadRequest(err.Message);
            }
        }

        [HttpPut("{sideId}")]
        public ActionResult<Side> EditSide(int sideId)
        {
            try
            {
                return Ok(_ss.EditSide(sideId));
            }
            catch (System.Exception err)
            {
                
                return BadRequest(err.Message);
            }
        }

        [HttpDelete("{sideId}")]
        public ActionResult<string> DeleteSide(int sideId)
        {
            try
            {
                return Ok(_ss.DeleteSide(sideId));
            }
            catch (System.Exception err)
            {
                
                return BadRequest(err.Message);
            }
        }


    }
}
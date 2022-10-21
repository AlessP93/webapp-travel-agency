using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using webapp_travel_agency.Models;

namespace webapp_travel_agency.Controllers.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SmartBoxController : ControllerBase
    {
        SmartBoxContext sbc;
        public SmartBoxController()
        {
            sbc = new SmartBoxContext();
        }

        [HttpGet]
        public IActionResult Get(string? name)
        {
            IQueryable<SmartBox> smartBoxes;

            if (name != null)
            {
                smartBoxes = sbc.smartBoxes.Where(smartbox => smartbox.Name.ToLower().Contains(name.ToLower()));
            }
            else
            {
                smartBoxes = sbc.smartBoxes;
            }
            return Ok(smartBoxes.ToList<SmartBox>());
           
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var box = sbc.smartBoxes.FirstOrDefault(obj => obj.Id == id);

            if (box == null)
            {
                return NotFound();
            }

            return Ok(box);
        }
    }
}


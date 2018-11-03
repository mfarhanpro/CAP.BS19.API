using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CAP.BS19.API.Data;
using Microsoft.AspNetCore.Mvc;

namespace CAP.BS19.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        public DataContext Context { get; }

        public CitiesController(DataContext context)
        {
            Context = context;
        }
        // GET api/Cities
        [HttpGet]
        public IActionResult Get()
        {
            var Cities = Context.Cities.ToList();
            return Ok(Cities);
        }

        // GET api/Cities/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var city = Context.Cities.FirstOrDefault(x => x.CityId == id);
            return Ok(city);
        }

        // POST api/Cities
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/Cities/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/Cities/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

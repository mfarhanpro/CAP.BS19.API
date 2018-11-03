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
    public class RegionsController : ControllerBase
    {
        public DataContext Context { get; }

        public RegionsController(DataContext context)
        {
            Context = context;
        }
        // GET api/Regions
        [HttpGet]
        public IActionResult Get()
        {
            var regions = Context.Regions.ToList();
            return Ok(regions);
        }

        // GET api/Regions/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var region = Context.Regions.FirstOrDefault(x => x.RegionId == id);
            return Ok(region);
        }

        // POST api/Regions
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/Regions/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/Regions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

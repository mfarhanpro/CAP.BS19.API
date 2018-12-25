using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CAP.BS19.API.Data;
using CAP.BS19.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CAP.BS19.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RetailersController : ControllerBase
    {
        public DataContext Context { get; }

        public RetailersController(DataContext context)
        {
            Context = context;
        }
        // GET api/Retailers
        [HttpGet]
        public IActionResult Get()
        {
            var Retailers = Context.Retailers.ToList();
            return Ok(Retailers);
        }

        // GET api/Retailers/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var retailer = Context.Retailers.FirstOrDefault(x => x.RetailerId == id);
            if(retailer == null)
                return NotFound();

            return Ok(retailer);
        }

        // POST api/Retailers
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Retailer model)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(model);
            }

            await Context.Retailers.AddAsync(model);
            await Context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = model.RetailerId }, model);
        }

        // PUT api/Retailers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Retailer model)
        {
            if(!ModelState.IsValid)
                return BadRequest(model);
            
            var retailer = Context.Retailers.FirstOrDefault(x => x.RetailerId == id);
            if(retailer == null)
            {
                return NotFound();
            }
            else
            {
                retailer.Name = model.Name;
                retailer.ShortName = model.ShortName;
                retailer.Email = model.Email;
                retailer.Phone = model.Phone;
                retailer.RegionId = model.RegionId;
                retailer.CityId = model.CityId;
                retailer.OfficeId = model.OfficeId;
                await Context.SaveChangesAsync();
                return CreatedAtAction(nameof(Get), new { id = model.RetailerId }, model);
            }
        }

        // DELETE api/Retailers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var retailer = Context.Retailers.FirstOrDefault(x => x.RetailerId == id);
            if(retailer == null)
                return NotFound();

            Context.Retailers.Remove(retailer);
            await Context.SaveChangesAsync();
            return Ok(retailer);
        }
    }
}

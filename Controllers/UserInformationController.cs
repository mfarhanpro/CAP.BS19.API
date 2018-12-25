using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CAP.BS19.API.Data;
using CAP.BS19.API.DTOs;
using CAP.BS19.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CAP.BS19.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserInformationController : ControllerBase
    {
        public DataContext Context { get; }

        public UserInformationController(DataContext context)
        {
            Context = context;
        }
        // GET api/UserInformation
        [HttpGet]
        public IActionResult Get()
        {
            var user = Context.UserInformation.ToList();
            return Ok(user);
        }

        // GET api/UserInformation/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var user = Context.UserInformation.FirstOrDefault(x => x.Id == id);
            if(user == null)
                return NotFound();

            return Ok(user);
        }
        // [HttpGet]
        // [Route("Login")]
        // public IActionResult Login(LoginDto model)
        // {
        //     var user = Context.UserInformation.FirstOrDefault(x => x.LoginUserName == model.Username && x.Password == model.Password);
        //     if(user == null)
        //         return NotFound();

        //     return Ok(user);
        // }

        // // POST api/UserInformation
        // [HttpPost]
        // public async Task<IActionResult> Post([FromBody] UserForRegisterDto model)
        // {
        //     if(!ModelState.IsValid)
        //     {
        //         return BadRequest(model);
        //     }
        //     model.EntryTime = DateTime.Now;
        //     await Context.UserInformation.AddAsync(model);
        //     await Context.SaveChangesAsync();
        //     return CreatedAtAction(nameof(Get), new { id = model.Id }, model);
        // }

        // // PUT api/UserInformation/5
        // [HttpPut("{id}")]
        // public async Task<IActionResult> Put(int id, [FromBody] UserInformation model)
        // {
        //     if(!ModelState.IsValid)
        //         return BadRequest(model);
            
        //     var user = Context.UserInformation.FirstOrDefault(x => x.Id == id);
        //     if(user == null)
        //     {
        //         return NotFound();
        //     }
        //     else
        //     {
        //         user.Name = model.Name;
        //         user.Email = model.Email;
        //         user.Phone = model.Phone;
        //         user.UserRoleId = model.UserRoleId;
        //         user.CompanyId = model.CompanyId;
        //         user.OfficeId = model.OfficeId;
        //         if(!string.IsNullOrWhiteSpace(model.Password))
        //             user.Password = model.Password;
        //         await Context.SaveChangesAsync();
        //         return CreatedAtAction(nameof(Get), new { id = model.Id }, model);
        //     }
        // }

        // DELETE api/UserInformation/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var user = Context.UserInformation.FirstOrDefault(x => x.Id == id);
            if(user == null)
                return NotFound();

            Context.UserInformation.Remove(user);
            await Context.SaveChangesAsync();
            return Ok(user);
        }
    }
}

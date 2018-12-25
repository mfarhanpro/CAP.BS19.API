using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CAP.BS19.API.Data;
using CAP.BS19.API.DTOs;
using CAP.BS19.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace CAP.BS19.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository repo;
        private readonly IConfiguration config;
        public AuthController(IAuthRepository repo, IConfiguration config)
        {
            this.config = config;
            this.repo = repo;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
        {
            //validate request.

            userForRegisterDto.LoginUserName = userForRegisterDto.LoginUserName.ToLower();
            if (await repo.UserExists(userForRegisterDto.LoginUserName))
                return BadRequest("Username already exist.");

            var userToCreate = new UserInformation()
            {
                Name = userForRegisterDto.Name,
                LoginUserName = userForRegisterDto.LoginUserName,
                Email = userForRegisterDto.Email,
                Phone = userForRegisterDto.Phone,
                EntryTime = DateTime.Now,
                IsActive = userForRegisterDto.IsActive,
                CompanyId = userForRegisterDto.CompanyId,
                OfficeId = userForRegisterDto.OfficeId,
                UserRoleId = userForRegisterDto.UserRoleId
            };

            var createdUser = await repo.Register(userToCreate, userForRegisterDto.Password);

            return Ok(new {Message = "User Successfully Created"});
        }

        [HttpPost("updateuser")]
        public async Task<IActionResult> UpdateUser(int id, UserForUpdateDto userForupdateDto)
        {
            var result = await repo.UpdateUser(id, userForupdateDto);
            if(result != null)
                return Ok(new { Message = "User Successfully Updated." });

            return NotFound();
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        {
            var userFromRepo = await repo.Login(userForLoginDto.Username.ToLower(), userForLoginDto.Password);

            if (userFromRepo == null)
                return Unauthorized();

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userFromRepo.Id.ToString()),
                new Claim(ClaimTypes.Name, userFromRepo.Name),
                new Claim(ClaimTypes.Role, userFromRepo.UserRoleId.ToString())
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            var authDto = new AuthDto()
            {
                Token = tokenHandler.WriteToken(token),
                Username  = userFromRepo.Name,
                UserId = userFromRepo.Id,
                UserRoleId = userFromRepo.UserRoleId,
                CompanyId = userFromRepo.CompanyId,
                OfficeId = userFromRepo.OfficeId
            };

            return Ok(authDto); 

        }

    }
}
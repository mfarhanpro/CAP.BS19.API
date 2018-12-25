using System;
using System.Threading.Tasks;
using CAP.BS19.API.DTOs;
using CAP.BS19.API.Models;
using Microsoft.EntityFrameworkCore;

namespace CAP.BS19.API.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext context;
        public AuthRepository(DataContext context)
        {
            this.context = context;

        }
        public async Task<UserInformation> Login(string username, string password)
        {
            var user = await context.UserInformation.FirstOrDefaultAsync(x => x.LoginUserName.ToLower() == username.ToLower());

            if (user == null)
                return null;

            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            return user;
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                        return false;
                }
            }
            return true;
        }

        public async Task<UserInformation> Register(UserInformation user, string password)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            await context.UserInformation.AddAsync(user);
            await context.SaveChangesAsync();

            return user;
        }

        public async Task<UserInformation> UpdateUser(int id, UserForUpdateDto userForUpdateDto)
        {
            var user = await context.UserInformation.FirstOrDefaultAsync(x => x.Id == id);

            if (user != null)
            {
                user.Name = userForUpdateDto.Name;
                user.Email = userForUpdateDto.Email;
                user.Phone = userForUpdateDto.Phone;
                user.UserRoleId = userForUpdateDto.UserRoleId;
                user.CompanyId = userForUpdateDto.CompanyId;
                user.OfficeId = userForUpdateDto.OfficeId;
                if (!string.IsNullOrWhiteSpace(userForUpdateDto.Password))
                {
                    byte[] passwordHash, passwordSalt;
                    CreatePasswordHash(userForUpdateDto.Password, out passwordHash, out passwordSalt);
                    user.PasswordHash = passwordHash;
                    user.PasswordSalt = passwordSalt;
                }
                
                await context.SaveChangesAsync();
            }
            return user;

        }

        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public async Task<bool> UserExists(string username)
        {
            if (await context.UserInformation.AnyAsync(x => x.LoginUserName == username && x.IsDeleted == false))
                return true;

            return false;
        }
    }
}
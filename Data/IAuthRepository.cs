using System.Threading.Tasks;
using CAP.BS19.API.DTOs;
using CAP.BS19.API.Models;

namespace CAP.BS19.API.Data
{
    public interface IAuthRepository
    {
         Task<UserInformation> Register(UserInformation user, string password);
         Task<UserInformation> UpdateUser(int id, UserForUpdateDto user);
         Task<UserInformation> Login(string username, string password);
         Task<bool> UserExists(string username);
    }
}
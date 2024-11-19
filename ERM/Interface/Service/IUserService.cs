using ERM.Dtos;
using ERM.Models;
using Microsoft.Identity.Client;

namespace ERM.Interface.Service
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsers();

        Task<User> AddUser(UserDto dto);
            
        Task<User> UpdateUser(int id, UserDto dto);

        Task<bool> DeleteUser(int id);
    }
}

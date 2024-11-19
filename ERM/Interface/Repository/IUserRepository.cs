using ERM.Models;

namespace ERM.Interface.Repository
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task Delete(User entity);
    }
}

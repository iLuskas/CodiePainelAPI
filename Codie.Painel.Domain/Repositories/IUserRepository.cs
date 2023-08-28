using Codie.Painel.Domain.Entities;

namespace Codie.Painel.Domain.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetUserByloginAndPasswordAsync(string login, string password);
    }
}

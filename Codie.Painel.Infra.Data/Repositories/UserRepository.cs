using Codie.Painel.Domain.Entities;
using Codie.Painel.Domain.Repositories;
using Codie.Painel.Infra.Data.Context;

namespace Codie.Painel.Infra.Data.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<User> GetUserByloginAndPasswordAsync(string? login, string? password)
        {
            return await FirstOrDefaultAsync(f => f.Login.Equals(login) && f.Password.Equals(password));
        }
    }
}

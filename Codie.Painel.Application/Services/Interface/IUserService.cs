using Codie.Painel.Application.Dtos;
using Codie.Painel.Domain.Entities;

namespace Codie.Painel.Application.Services
{
    public interface IUserService
    {
        Task<ResultService<TokenDto>> GetAuthAsync(LoginDTO loginDTO);
    }
}

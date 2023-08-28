using AutoMapper;
using Codie.Painel.Application.Dtos;
using Codie.Painel.Domain.Entities;
using System.Reflection;

namespace Codie.Painel.Application.Mappins
{
    public class DomainMapEntities : Profile
    {
        public DomainMapEntities()
        {
            #region 'Personalizados'
            CreateMap<User, UserDTO>().ReverseMap();
            #endregion
        }

    }
}

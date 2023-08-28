using Codie.Painel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codie.Painel.Domain.Authentication
{
    public interface ITokenGenerator
    {
        string Generator(User user);
    }
}

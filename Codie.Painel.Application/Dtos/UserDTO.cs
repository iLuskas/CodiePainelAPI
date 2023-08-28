using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codie.Painel.Application.Dtos
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string? Nome { get; private set; }
        public string? Login { get; private set; }
        public string? Email { get; private set; }
        public string? RoleGate { get; private set; }
        public string? AvatarUrl { get; private set; }
    }
}

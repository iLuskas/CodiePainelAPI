using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codie.Painel.Application.Dtos
{
    public class TokenDto
    {
        public UserDTO User { get; set; } = null!;
        public string Token { get; set; } = null!;
        public DateTime Expires { get; set; }
    }
}

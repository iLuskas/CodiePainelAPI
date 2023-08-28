using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codie.Painel.Domain.Constants
{
    public static class TokenSettings
    {
        private static string key = "40ceff0fb8965706f4a0667c12156771";

        public static string SecretKey { get => key;}
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagementControlAPI.Models
{
    public class LoginRequest
    {
        public string Login { get; set; } = string.Empty;
/*         public string email { get; set; } = string.Empty; */ //TODO: MAKE LOGIN OR EMAIL 
        public string Password { get; set; } = string.Empty;
    }
}
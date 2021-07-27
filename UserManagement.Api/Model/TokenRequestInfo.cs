using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagement.Api.Model
{
    public class TokenRequestInfo
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}

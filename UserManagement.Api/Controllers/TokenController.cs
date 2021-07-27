
using AuthManager;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UserManagement.Api.Model;

namespace UserManagement.Api.Controllers
{
    [Route("api/token")]
    public class TokenController : ControllerBase
    {
        [HttpPost]
        [AllowAnonymous]
        [Route("post")]
        public IActionResult Post([FromBody] TokenRequestInfo reqInfo)
        {
            var tkn = JwtManager.GenerateToken(reqInfo.UserName);
            return Ok(new { token = tkn});
        }

    }
}

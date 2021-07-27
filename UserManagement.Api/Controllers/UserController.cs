using AuthManager;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Api.Services;

namespace UserManagement.Api.Controllers
{
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        UserService _userService;
        ILogger<UserController> _logger;
        public UserController(ILogger<UserController> logger, UserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpGet]
        [Route("get")]
        [ServiceFilter(typeof(Authorize))]
        public IActionResult Get()
        {
            var users = this._userService.GetAll();
            return Ok(users);
        }

        [HttpGet]
        [Route("get/{id}")]
        [ServiceFilter(typeof(Authorize))]
        public IActionResult Get(int id)
        {
            var user = this._userService.GetById(id);
            return Ok(user);
        }

        [HttpPost]
        [Route("post")]
        [ServiceFilter(typeof(Authorize))]
        public IActionResult Post([FromBody] User user)
        {
             var res = this._userService.Create(user);
            return Ok(res);
        }
         
        [HttpPut]
        [Route("put")]
        [ServiceFilter(typeof(Authorize))]
        public IActionResult Put([FromBody] User user)
        {
            var res = this._userService.Update(user);
            return Ok(res);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        [ServiceFilter(typeof(Authorize))]
        public IActionResult Delete(int id)
        {
            var res = this._userService.Delete(id);
            return Ok(res);
        }

    }
}

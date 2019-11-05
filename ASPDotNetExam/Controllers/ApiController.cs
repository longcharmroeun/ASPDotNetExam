using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ASPDotNetExam.DataBase;
using ASPDotNetExam.Model;
using System.Security.Claims;

namespace ASPDotNetExam.Controllers
{
    [Authorize]
    [ApiController]
    public class ApiController : ControllerBase
    {
        private IUserService _userService;

        public ApiController(IUserService userService)
        {
            _userService = userService;
        }

        [Route("api/login")]
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]AuthenticateModel model)
        {
            var user = _userService.AuthenticateAsync(model.Name, model.Password);

            if (user == null) return BadRequest(new { message = "Username or password is incorrect" });
            
            return Ok(user);
        }

        protected int UserID()
        {
            return int.Parse(this.User.Claims.First().Value);
        }

        [HttpGet]
        [Route("UserInfo")]
        public IActionResult GetUserinfo()
        {
            var users = _userService.GetUserInfor(UserID());
            return Ok(users);
        }

        [HttpGet]
        [Route("Item")]
        public IActionResult GetItem()
        {
            return Ok(_userService.GetItems(UserID()));
        }

        [HttpPost]
        [Route("Item/Insert")]
        public async Task<IActionResult> InserItemAsync([FromBody]Item item)
        {
            return Ok(await _userService.AddItemAsync(UserID(), item));
        }
    }
}
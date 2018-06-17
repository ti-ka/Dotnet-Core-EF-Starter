using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Models.Context;
using Models.Enitites;
using Services;

namespace Api
{
    [Route("user")]
    public class UserController: Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        
        [HttpGet("by-email")]
        public User ByEmail([FromBody] User model)
        {
            return _userService.GetUserByEmail(model.Email);
        }
        
        [HttpPost("update-password")]
        public void UpdatPassword([FromBody] User model)
        {
            _userService.UpdatePasswordByUserId(model.Id, model.Password);
        }
        
    }
}
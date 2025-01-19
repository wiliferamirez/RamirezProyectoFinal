using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RamirezforaneoApp.Models;

namespace RamirezforaneoAppAPI.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserManagementController : ControllerBase
    {

        private readonly UserManager<User> _userManager;
        private readonly ILogger<User> _logger;

        public UserManagementController(UserManager<User> userManager, ILogger<User> logger)
        {
            _userManager = userManager;
            _logger = logger;
        }

        // GET: api/Users
        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = _userManager.Users.ToList();
            return Ok(users);
        }
    }
 }

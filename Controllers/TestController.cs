using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RegisterMember.API.Models;
using RegisterMember.API.Repositories;

namespace RegisterMember.API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public TestController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        public async Task<IActionResult> SaveUser(User user)
        {
            return Ok(await _userRepository.AddUser(user));

        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            return Ok(await _userRepository.GetAllUsers());
            
        }
    }
}

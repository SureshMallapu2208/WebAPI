using API.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUser _userService;

        public UsersController(IUser userService)
        {

            _userService = userService;

        }
        // GET: api/<UsersController>
        [HttpGet]
        [Route("GetUsers")]
        public IActionResult GetUsers()
        {
            try
            {
                var users = _userService.GetUsers();

                if (users != null)
                    return Ok(users);
            }
            catch (Exception)
            {

                return BadRequest();
            }
            return NoContent();
        }


        [HttpGet]
        [Route("GetUser/{userId}")]
        public IActionResult GetUserById(int userId)
        {
            try
            {
                var users = _userService.GetUsers().Where(a => a.Id == userId);

                if (users != null)
                    return Ok(users);
            }
            catch (Exception)
            {

                return BadRequest();
            }
            return NoContent();
        }


    }
}

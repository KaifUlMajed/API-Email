using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace API_Email.Controllers
{
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using Repositories;

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IRepository<User> _usersRepository;

        public UsersController(IRepository<User> usersRepository)
        {
            _usersRepository = usersRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var users = await _usersRepository.GetAll();
            if (users == null)
            {
                return Ok(Enumerable.Empty<User>());
            }

            return Ok(users);
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<User>> GetUser(int userId)
        {

            var user = await _usersRepository.GetById(userId);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<User>> CreateUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var createdUser = await _usersRepository.Create(user);

            if (createdUser == null)
            {
                return StatusCode(403, "The email address already exists");
            }

            return Created(nameof(GetUser), createdUser);
        }

        [HttpDelete("{userId}")]
        public async Task<ActionResult> DeleteUser(int userId)
        {
            var result = await _usersRepository.Delete(userId);
            if (result)
            {
                return NoContent();
            }

            return NotFound();
        }

        [HttpPut("{userId}")]
        public async Task<ActionResult> UpdateUser([FromRoute] int userId, [FromBody] User user)
        {
            if (userId != user.Id)
            {
                return BadRequest("User id in route and body do not match");
            }

            var result = await _usersRepository.Update(user);
            if (result)
            {
                return NoContent();
            }

            return NotFound();
        }
    }
}
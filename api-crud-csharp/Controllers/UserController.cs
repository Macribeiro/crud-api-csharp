using api_crud_csharp.Data;
using api_crud_csharp.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api_crud_csharp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public UserController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            var users = await _dataContext.Users.ToListAsync();

            return Ok(users);
        }

        [HttpGet("/{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _dataContext.Users.FindAsync(id);

            if (user is null) return BadRequest("User not found. ID might be wrong");

            else return Ok(user);
        }

        [HttpPost("/User")]
        public async Task<ActionResult<List<User>>> AddUser([FromBody] User user)
        {
            _dataContext.Users.Add(user);
            await _dataContext.SaveChangesAsync();

            return Ok(await _dataContext.Users.ToListAsync());
        }

        [HttpPut("/User/{id}")]
        public async Task<ActionResult<User>> UpdateUser(int id, [FromBody] User updatedUser)
        {
            var dbUser = await _dataContext.Users.FindAsync(id);

            if (dbUser is null) return BadRequest("User not found. ID might be wrong");

            else
            {
                dbUser.Name = updatedUser.Name;
                dbUser.Age = updatedUser.Age;
                dbUser.Departament = updatedUser.Departament;
                dbUser.Address = updatedUser.Address;

                await _dataContext.SaveChangesAsync();

                return Ok(await _dataContext.Users.ToListAsync());
            }
        }

        [HttpDelete("/User/{id}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            var dbUser = await _dataContext.Users.FindAsync(id);

            if (dbUser is null)
                return BadRequest("User not found. ID might be wrong");

            _dataContext.Users.Remove(dbUser);
            await _dataContext.SaveChangesAsync();

            return Ok(await _dataContext.Users.ToListAsync());

        }
    }
}
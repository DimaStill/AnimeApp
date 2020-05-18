using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnimeAPI.Models;
using AnimeAPI.Models.DTO;
using AnimeAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AnimeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService userService;
        public UserController(UserService userService)
        {
            this.userService = userService;
        }
        // GET: api/User
        [HttpGet]
        public async Task<IEnumerable<User>> Get()
        {
            return await userService.GetAllUsers();
        }

        // GET: api/User/5
        [HttpGet("{id}", Name = "GetUsers")]
        public async Task<User> Get(int id)
        {
            return await userService.GetUser(id);
        }

        // POST: api/User
        [HttpPost]
        public async Task<User> Post([FromBody] UserDTO value)
        {
            return await userService.AddUser(value);
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public async Task<User> Put(int id, [FromBody] UserDTO value)
        {
            return await userService.UpdateUser(id, value);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<User> Delete(int id)
        {
            return await userService.DeleteUser(id);
        }
    }
}

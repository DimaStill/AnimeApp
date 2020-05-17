using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnimeAPI.Models;
using AnimeAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AnimeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudioController : ControllerBase
    {
        private readonly StudioService studioService;
        public StudioController(StudioService studioService)
        {
            this.studioService = studioService;
        }

        // GET: api/Studio
        [HttpGet]
        public async Task<IEnumerable<Studio>> Get()
        {
            return await studioService.GetAllStudios();
        }

        // GET: api/Studio/5
        [HttpGet("{id}", Name = "GetStudios")]
        public async Task<Studio> Get(int id)
        {
            return await studioService.GetStudio(id);
        }

        // POST: api/Studio
        [HttpPost]
        public async Task<Studio> Post([FromBody] Studio value)
        {
            return await studioService.AddStudio(value);
        }

        // PUT: api/Studio/5
        [HttpPut("{id}")]
        public async Task<Studio> Put(int id, [FromBody] Studio value)
        {
            return await studioService.UpdateStudio(id, value);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<Studio> Delete(int id)
        {
            return await studioService.DeleteStudio(id);
        }
    }
}

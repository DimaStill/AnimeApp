using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnimeAPI.Models;
using AnimeAPI.Models.Interfaces;
using AnimeAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AnimeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimeController : ControllerBase
    {
        private readonly AnimeService animeService;
        public AnimeController(AnimeService animeService)
        {
            this.animeService = animeService;
        }

        // GET: api/Anime
        [HttpGet]
        public async Task<IEnumerable<IAnime>> Get()
        {
            return await animeService.GetAllAnimes();
        }

        // GET: api/Anime/5
        [HttpGet("{id}", Name = "GetAnime")]
        public async Task<IAnime> Get(int id)
        {
            return await animeService.GetAnimeById(id);
        }

        // POST: api/Anime
        [HttpPost]
        public async Task<IAnime> Post([FromBody] IAnime value)
        {
            return await animeService.AddAnime(value);
        }

        // PUT: api/Anime/5
        [HttpPut("{id}")]
        public async Task<IAnime> Put(int id, [FromBody] IAnime value)
        {
            return await animeService.UpdateAnime(id, value);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IAnime> Delete(int id)
        {
            return await animeService.DeleteAnime(id);
        }
    }
}

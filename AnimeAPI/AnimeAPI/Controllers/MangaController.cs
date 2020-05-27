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
    public class MangaController : ControllerBase
    {
        private readonly MangaService animeService;
        public MangaController(MangaService animeService)
        {
            this.animeService = animeService;
        }

        // GET: api/Manga
        [HttpGet]
        public async Task<IEnumerable<Manga>> Get()
        {
            return await animeService.GetAllMangas();
        }

        // GET: api/Manga/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<Manga> Get(int id)
        {
            return await animeService.GetMangaById(id);
        }

        // POST: api/Manga
        [HttpPost]
        public async Task<Manga> Post([FromBody] MangaDTO value)
        {
            return await animeService.AddManga(value);
        }

        // PUT: api/Manga/5
        [HttpPut("{id}")]
        public async Task<Manga> Put(int id, [FromBody] MangaDTO value)
        {
            return await animeService.UpdateManga(id, value);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<Manga> Delete(int id)
        {
            return await animeService.DeleteManga(id);
        }
    }
}

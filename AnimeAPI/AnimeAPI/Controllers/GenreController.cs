using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnimeAPI.Models;
using AnimeAPI.Models.DTO;
using AnimeAPI.Models.Interfaces;
using AnimeAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AnimeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly GenreService genreService;
        public GenreController(GenreService genreService)
        {
            this.genreService = genreService;
        }

        // GET: api/Genre
        [HttpGet]
        public async Task<List<GenreDTO>> Get()
        {
            return await genreService.GetAllGenres();
        }

        // GET: api/Genre/5
        [HttpGet("{id}", Name = "GetGenre")]
        public async Task<GenreDTO> Get(int id)
        {
            return await genreService.GetGenreById(id);
        }

        // POST: api/Genre
        [HttpPost]
        public async Task<GenreDTO> Post([FromBody] GenreDTO value)
        {
            return await genreService.AddGenre(value);
        }

        // PUT: api/Genre/5
        [HttpPut("{id}")]
        public async Task<GenreDTO> Put(int id, [FromBody] GenreDTO value)
        {
            return await genreService.UpdateGenre(id, value);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<GenreDTO> Delete(int id)
        {
            return await genreService.DeleteGenre(id);
        }
    }
}

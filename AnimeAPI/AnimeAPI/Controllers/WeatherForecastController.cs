using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnimeAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AnimeAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private AnimeContext db;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, AnimeContext animeContext)
        {
            _logger = logger;
            db = animeContext;

            var anime = new Anime()
            {
                Name = "Test",
                ReleaseDate = DateTime.Now,
                Season = 1,
                Source = "TestSource",
                Status = "Finish",
                Studio = "TestStudio",
                Type = "TestType",
                CountEpisodes = 21
            };
            var genre = new Genre() { Id = 0, Name = "XXX" };
            anime.Genres.Add(genre);
            var testStudio = new Studio() { Id = 0, Name = "Google", Link = "google.com" };
            anime.Voices.Add(testStudio);

            var manga = new Manga() { 
                Author = "TestAuthor", 
                Name = "TestManga", 
                ReleaseContinues = true, 
                Translater = "Google Translate", 
                Volume = 1 
            };
            manga.Genres.Add(genre);

            var user = new User() { Login = "admin", Password = "admin" };
            user.FavoritesAnime.Add(anime);
            user.FavoritesManga.Add(manga);

            db.Animes.Add(anime);
            db.Mangas.Add(manga);
            db.Users.Add(user);

            db.SaveChanges();
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}

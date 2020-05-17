using AnimeAPI.Models;
using AnimeAPI.Models.DTO;
using AnimeAPI.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimeAPI.Services
{
    public class GenreService
    {
        private AnimeContext db;
        public GenreService(AnimeContext animeContext)
        {
            db = animeContext;

            /*var anime = new Anime()
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

            var manga = new Manga()
            {
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

            db.SaveChanges();*/
        }

        public async Task<List<Genre>> GetAllGenres()
        {
            return await db.Genres.ToListAsync();
        }

        public async Task<Genre> GetGenreById(int genreId)
        {
            return await db.Genres.FirstOrDefaultAsync(genre => genre.Id == genreId);
        }

        public async Task<Genre> AddGenre(GenreDTO newGenreDTO)
        {
            Genre newGenre = new Genre(newGenreDTO);
            var result = await db.Genres.AddAsync(newGenre);
            await db.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<Genre> UpdateGenre(int id, IGenre updateGenre)
        {
            Genre genre = db.Genres.SingleOrDefault(genre => genre.Id == id);

            if (genre != null)
            {
                genre.Name = updateGenre.Name;

                await db.SaveChangesAsync();
            }

            return genre;
        }

        public async Task<Genre> DeleteGenre(int id)
        {
            Genre genre = await db.Genres.FirstOrDefaultAsync(genre => genre.Id == id);
            var deletedGenre = db.Genres.Remove(genre);

            await db.SaveChangesAsync();

            return deletedGenre.Entity;
        }
    }
}

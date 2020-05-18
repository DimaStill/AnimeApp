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
    public class AnimeService
    {
        private AnimeContext db;
        public AnimeService(AnimeContext animeContext) {
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
            var genre = new Genre() { Name = "XXX" };
            anime.Genres.Add(genre);
            var testStudio = new Studio() { Name = "Google", Link = "google.com" };
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

        public async Task<List<Anime>> GetAllAnimes()
        {
            return await db.Animes.ToListAsync();
        }

        public async Task<Anime> GetAnimeById(int animeId)
        {
            return await db.Animes.FirstOrDefaultAsync(anime => anime.Id == animeId);
        }

        public async Task<Anime> AddAnime(AnimeDTO newAnimeDTO)
        {
            List<Genre> selectedGenre = new List<Genre>();
            foreach(var genreId in newAnimeDTO.GenreIds) {
                selectedGenre.Add(await db.Genres.FirstOrDefaultAsync(genre => genre.Id == genreId));
            }

            List<Studio> selectedVoices = new List<Studio>();
            foreach (var voiceId in newAnimeDTO.VoiceIds)
            {
                selectedVoices.Add(await db.Studios.FirstOrDefaultAsync(voice => voice.Id == voiceId));
            }

            Anime newAnime = new Anime(newAnimeDTO, selectedGenre, selectedVoices);
            var result = await db.Animes.AddAsync(newAnime as Anime);
            await db.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<Anime> UpdateAnime(int id, AnimeDTO updateAnime)
        {
            List<Genre> selectedGenre = new List<Genre>();
            foreach (var genreId in updateAnime.GenreIds)
            {
                selectedGenre.Add(await db.Genres.FirstOrDefaultAsync(genre => genre.Id == genreId));
            }

            List<Studio> selectedVoices = new List<Studio>();
            foreach (var voiceId in updateAnime.VoiceIds)
            {
                selectedVoices.Add(await db.Studios.FirstOrDefaultAsync(voice => voice.Id == voiceId));
            }

            Anime anime = db.Animes.SingleOrDefault(anime => anime.Id == id);

            if (anime != null)
            {
                anime.Name = updateAnime.Name;
                anime.ReleaseDate = updateAnime.ReleaseDate;
                anime.Season = updateAnime.Season;
                anime.Source = updateAnime.Source;
                anime.Status = updateAnime.Status;
                anime.Studio = updateAnime.Studio;
                anime.Type = updateAnime.Type;
                anime.Voices = selectedVoices;
                anime.Genres = selectedGenre;

                await db.SaveChangesAsync();
            }

            return anime;
        }

        public async Task<Anime> DeleteAnime(int id)
        {
            Anime anime = await db.Animes.FirstOrDefaultAsync(anime => anime.Id == id);
            var deletedAnime = db.Animes.Remove(anime);

            return deletedAnime.Entity;
        }
    }
}

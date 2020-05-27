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
            db.Genres.Load();
            db.Studios.Load();
        }

        public async Task<List<Anime>> GetAllAnimes()
        {
            await db.Animes.LoadAsync();
            return await db.Animes.ToListAsync();
        }

        public async Task<Anime> GetAnimeById(int animeId)
        {
            await db.Animes.LoadAsync();
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
                anime.PhotoBase64 = updateAnime.PhotoBase64;

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

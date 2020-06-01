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

        public async Task<List<AnimeDTO>> GetAllAnimes()
        {
            await db.Animes.LoadAsync();
            return AnimeDTO.getListAnimeDTOsFromAnime(await db.Animes.ToListAsync());
        }

        public async Task<AnimeDTO> GetAnimeById(int animeId)
        {
            await db.Animes.LoadAsync();
            return new AnimeDTO(await db.Animes.FirstOrDefaultAsync(anime => anime.Id == animeId));
        }

        public async Task<AnimeDTO> AddAnime(AnimeDTO newAnimeDTO)
        {
            List<Genre> selectedGenre = new List<Genre>();
            foreach(var genreId in newAnimeDTO.GenreIds) {
                Genre genre = await db.Genres.FirstOrDefaultAsync(genre => genre.Id == genreId);
                if (genre != null)
                {
                    selectedGenre.Add(genre);
                }
            }

            List<Studio> selectedVoices = new List<Studio>();
            foreach (var voiceId in newAnimeDTO.VoiceIds)
            {
                Studio voice = await db.Studios.FirstOrDefaultAsync(voice => voice.Id == voiceId);
                if (voice != null)
                {
                    selectedVoices.Add(voice);
                }
            }

            Anime newAnime = new Anime(newAnimeDTO, selectedGenre, selectedVoices);
            var result = await db.Animes.AddAsync(newAnime as Anime);
            await db.SaveChangesAsync();

            return new AnimeDTO(result.Entity);
        }

        public async Task<AnimeDTO> UpdateAnime(int id, AnimeDTO updateAnime)
        {
            List<Genre> selectedGenre = new List<Genre>();
            foreach (var genreId in updateAnime.GenreIds)
            {
                Genre genre = await db.Genres.FirstOrDefaultAsync(genre => genre.Id == genreId);
                if (genre != null)
                {
                    selectedGenre.Add(genre);
                }
            }

            List<Studio> selectedVoices = new List<Studio>();
            foreach (var voiceId in updateAnime.VoiceIds)
            {
                Studio voice = await db.Studios.FirstOrDefaultAsync(voice => voice.Id == voiceId);
                if (voice != null)
                {
                    selectedVoices.Add(voice);
                }
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

            return new AnimeDTO(anime);
        }

        public async Task<AnimeDTO> DeleteAnime(int id)
        {
            Anime anime = await db.Animes.FirstOrDefaultAsync(anime => anime.Id == id);
            var deletedAnime = db.Animes.Remove(anime);

            return new AnimeDTO(deletedAnime.Entity);
        }
    }
}

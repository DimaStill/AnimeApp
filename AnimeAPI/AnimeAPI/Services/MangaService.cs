using AnimeAPI.Models;
using AnimeAPI.Models.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimeAPI.Services
{
    public class MangaService
    {
        private AnimeContext db;
        public MangaService(AnimeContext animeContext)
        {
            db = animeContext;
            db.Genres.Load();
        }

        public async Task<List<Manga>> GetAllMangas()
        {
            return await db.Mangas.ToListAsync();
        }

        public async Task<Manga> GetMangaById(int mangaId)
        {
            await db.Genres.LoadAsync();
            return await db.Mangas.FirstOrDefaultAsync(manga => manga.Id == mangaId);
        }

        public async Task<Manga> AddManga(MangaDTO newMangaDTO)
        {
            List<Genre> selectedGenre = new List<Genre>();
            foreach (var genreId in newMangaDTO.GenreIds)
            {
                selectedGenre.Add(await db.Genres.FirstOrDefaultAsync(genre => genre.Id == genreId));
            }

            Manga newManga = new Manga(newMangaDTO, selectedGenre);
            var result = await db.Mangas.AddAsync(newManga as Manga);
            await db.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<Manga> UpdateManga(int id, MangaDTO updateManga)
        {
            List<Genre> selectedGenre = new List<Genre>();
            foreach (var genreId in updateManga.GenreIds)
            {
                selectedGenre.Add(await db.Genres.FirstOrDefaultAsync(genre => genre.Id == genreId));
            }

            Manga manga = db.Mangas.SingleOrDefault(manga => manga.Id == id);

            if (manga != null)
            {
                manga.Name = updateManga.Name;
                manga.ReleaseDate = updateManga.ReleaseDate;
                manga.Volume = updateManga.Volume;
                manga.ReleaseContinues = updateManga.ReleaseContinues;
                manga.Translater = updateManga.Translater;
                manga.Genre = selectedGenre;
                manga.Author = updateManga.Author;
                manga.PhotoBase64 = updateManga.PhotoBase64;

                await db.SaveChangesAsync();
            }

            return manga;
        }

        public async Task<Manga> DeleteManga(int id)
        {
            Manga manga = await db.Mangas.FirstOrDefaultAsync(manga => manga.Id == id);
            var deletedManga = db.Mangas.Remove(manga);

            return deletedManga.Entity;
        }
    }
}

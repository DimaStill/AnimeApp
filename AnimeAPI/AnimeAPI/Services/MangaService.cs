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

        public async Task<List<MangaDTO>> GetAllMangas()
        {
            return MangaDTO.getListMangaDTOsFromManga(await db.Mangas.ToListAsync());
        }

        public async Task<MangaDTO> GetMangaById(int mangaId)
        {
            await db.Genres.LoadAsync();
            return new MangaDTO(await db.Mangas.FirstOrDefaultAsync(manga => manga.Id == mangaId));
        }

        public async Task<MangaDTO> AddManga(MangaDTO newMangaDTO)
        {
            List<Genre> selectedGenre = new List<Genre>();
            foreach (var genreId in newMangaDTO.GenreIds)
            {
                Genre genre = await db.Genres.FirstOrDefaultAsync(genre => genre.Id == genreId);
                if (genre != null)
                {
                    selectedGenre.Add(genre);
                }
            }

            Manga newManga = new Manga(newMangaDTO, selectedGenre);
            var result = await db.Mangas.AddAsync(newManga as Manga);
            await db.SaveChangesAsync();

            return new MangaDTO(result.Entity);
        }

        public async Task<MangaDTO> UpdateManga(int id, MangaDTO updateManga)
        {
            List<Genre> selectedGenre = new List<Genre>();
            foreach (var genreId in updateManga.GenreIds)
            {
                Genre genre = await db.Genres.FirstOrDefaultAsync(genre => genre.Id == genreId);
                if (genre != null)
                {
                    selectedGenre.Add(genre);
                }
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

            return new MangaDTO(manga);
        }

        public async Task<MangaDTO> DeleteManga(int id)
        {
            Manga manga = await db.Mangas.FirstOrDefaultAsync(manga => manga.Id == id);
            var deletedManga = db.Mangas.Remove(manga);

            return new MangaDTO(deletedManga.Entity);
        }

        public async Task<MangaPagesDTO> GetMangaPages(int mangaId)
        {
            return new MangaPagesDTO(await db.MangaPages.FirstOrDefaultAsync(mangaPages => mangaPages.Manga.Id == mangaId));
        } 
    }
}

using AnimeAPI.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimeAPI.Models.DTO
{
    public class MangaDTO: IManga
    {
        public MangaDTO()
        { }

        public MangaDTO(Manga manga)
        {
            Id = manga.Id;
            Name = manga.Name;
            ReleaseDate = manga.ReleaseDate;
            Volume = manga.Volume;
            ReleaseContinues = manga.ReleaseContinues;
            Author = manga.Author;
            PhotoBase64 = manga.PhotoBase64;

            foreach (Studio studio in manga.Translater)
            {
                TranslaterIds.Add(studio.Id);
            }

            foreach (Genre genre in manga.Genre)
            {
                GenreIds.Add(genre.Id);
            }
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int Volume { get; set; }
        public bool ReleaseContinues { get; set; }
        public ICollection<int> TranslaterIds { get; set; }
        public ICollection<int> GenreIds { get; set; } = new List<int>();
        public string Author { get; set; }
        public string PhotoBase64 { get; set; }

        public static List<MangaDTO> getListMangaDTOsFromManga(List<Manga> mangas)
        {
            List<MangaDTO> mangaDTOs = new List<MangaDTO>();
            foreach (var manga in mangas)
            {
                mangaDTOs.Add(new MangaDTO(manga));
            }

            return mangaDTOs;
        }
    }
}

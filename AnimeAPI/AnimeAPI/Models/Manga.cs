using AnimeAPI.Models.DTO;
using AnimeAPI.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimeAPI.Models
{
    public class Manga: MangaDTO
    {
        public Manga() : base()
        { }

        public Manga(MangaDTO mangaDTO)
        {
            Name = mangaDTO.Name;
            ReleaseDate = mangaDTO.ReleaseDate;
            Volume = mangaDTO.Volume;
            ReleaseContinues = mangaDTO.ReleaseContinues;
            Translater = mangaDTO.Translater;
            Genres = mangaDTO.Genres;
            Author = mangaDTO.Author;
        }

        public int Id { get; set; }
    }
}

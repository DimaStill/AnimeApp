﻿using AnimeAPI.Models.DTO;
using AnimeAPI.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimeAPI.Models
{
    public class Manga
    {
        public Manga()
        { }

        public Manga(MangaDTO mangaDTO, List<Genre> selectedGenres, List<Studio> selectedStudio)
        {
            Name = mangaDTO.Name;
            ReleaseDate = mangaDTO.ReleaseDate;
            Volume = mangaDTO.Volume;
            ReleaseContinues = mangaDTO.ReleaseContinues;
            Translater = selectedStudio;
            Genre = selectedGenres;
            Author = mangaDTO.Author;
            PhotoBase64 = mangaDTO.PhotoBase64;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string ReleaseDate { get; set; }
        public int Volume { get; set; }
        public bool ReleaseContinues { get; set; }
        public List<Studio> Translater { get; set; }
        public List<Genre> Genre { get; set; } = new List<Genre>();
        public string Author { get; set; }
        public string PhotoBase64 { get; set; }
    }
}

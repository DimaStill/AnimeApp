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

        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int Volume { get; set; }
        public bool ReleaseContinues { get; set; }
        public string Translater { get; set; }
        public ICollection<Genre> Genres { get; set; } = new List<Genre>();
        public string Author { get; set; }
    }
}

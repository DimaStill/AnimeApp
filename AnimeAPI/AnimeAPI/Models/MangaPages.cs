using AnimeAPI.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimeAPI.Models
{
    public class MangaPages
    {
        public int Id { get; set; }
        public Manga Manga { get; set; }
        public List<Page> Pages { get; set; } = new List<Page>();

        public MangaPages() { }
        public MangaPages(AddMangaPagesDTO addMangaPagesDTO, Manga manga)
        {
            Manga = manga;
            Pages = addMangaPagesDTO.Pages;
        }
    }
}

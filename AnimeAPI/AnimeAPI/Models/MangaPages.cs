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
    }
}

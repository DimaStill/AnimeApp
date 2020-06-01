using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimeAPI.Models.DTO
{
    public class AddMangaPagesDTO
    {
        public int Id { get; set; }
        public int MangaId { get; set; }
        public List<Page> Pages { get; set; } = new List<Page>();
    }
}

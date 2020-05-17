using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimeAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public ICollection<Manga> FavoritesManga { get; set; } = new List<Manga>();
        public ICollection<Anime> FavoritesAnime { get; set; } = new List<Anime>();
    }
}

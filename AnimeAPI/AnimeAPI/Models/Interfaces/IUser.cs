using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimeAPI.Models.Interfaces
{
    public interface IUser
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public ICollection<Manga> FavoritesManga { get; set; }
        public ICollection<Anime> FavoritesAnime { get; set; }
    }
}

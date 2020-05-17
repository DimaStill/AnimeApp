using AnimeAPI.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimeAPI.Models.DTO
{
    public class UserDTO: IUser
    {
        public UserDTO()
        { }

        public string Login { get; set; }
        public string Password { get; set; }
        public ICollection<Manga> FavoritesManga { get; set; } = new List<Manga>();
        public ICollection<Anime> FavoritesAnime { get; set; } = new List<Anime>();
    }
}

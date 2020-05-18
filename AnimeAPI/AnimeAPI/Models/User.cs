using AnimeAPI.Models.DTO;
using AnimeAPI.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimeAPI.Models
{
    public class User
    {
        public User() : base()
        { }

        public User(UserDTO userDTO)
        {
            Login = userDTO.Login;
            Password = userDTO.Password;
            FavoritesMangas = null;
            FavoritesAnimes = null;
        }

        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public ICollection<Manga> FavoritesMangas { get; set; } = new List<Manga>();
        public ICollection<Anime> FavoritesAnimes { get; set; } = new List<Anime>();
    }
}

using AnimeAPI.Models.DTO;
using AnimeAPI.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimeAPI.Models
{
    public class User: UserDTO
    {
        public User() : base()
        { }

        public User(UserDTO userDTO)
        {
            Login = userDTO.Login;
            Password = userDTO.Password;
            FavoritesManga = userDTO.FavoritesManga;
            FavoritesAnime = userDTO.FavoritesAnime;
        }

        public int Id { get; set; }
    }
}

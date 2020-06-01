using AnimeAPI.Models.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimeAPI.Models.DTO
{
    public class UserDTO: IUser
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public ICollection<int> FavoritesMangaIds { get; set; } = new List<int>();
        public ICollection<int> FavoritesAnimeIds { get; set; } = new List<int>();

        public UserDTO() { }
        public UserDTO(User user)
        {
            Id = user.Id;
            Login = user.Login;
            Password = user.Password;
            IsAdmin = user.IsAdmin;
            if (user.FavoritesAnimes != null)
            {
                foreach (var anime in user.FavoritesAnimes)
                {
                    FavoritesAnimeIds.Add(anime.Id);
                }
            }

            if (user.FavoritesMangas != null)
            {
                foreach (var manga in user.FavoritesMangas)
                {
                    FavoritesMangaIds.Add(manga.Id);
                }
            }
        }

        public static List<UserDTO> getListUserDTOsFromUser(List<User> users)
        {
            List<UserDTO> userDTOs = new List<UserDTO>();
            foreach (var user in users)
            {
                userDTOs.Add(new UserDTO(user));
            }

            return userDTOs;
        }
    }
}

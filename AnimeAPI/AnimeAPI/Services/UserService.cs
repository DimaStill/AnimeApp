using AnimeAPI.Models;
using AnimeAPI.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimeAPI.Services
{
    public class UserService
    {

        private AnimeContext db;
        public UserService(AnimeContext animeContext)
        {
            db = animeContext;
            db.Genres.Load();
            db.Studios.Load();
            db.Mangas.Load();
            db.Animes.Load();
        }

        public async Task<List<UserDTO>> GetAllUsers()
        {
            await db.Users.LoadAsync();
            return UserDTO.getListUserDTOsFromUser(await db.Users.ToListAsync());
        }

        public async Task<UserDTO> GetUser(int id)
        {
            await db.Users.LoadAsync();
            return new UserDTO(await db.Users.FirstOrDefaultAsync(user => user.Id == id));
        }

        public async Task<UserDTO> AddUser(UserDTO newUserDTO)
        {
            User newUser = new User(newUserDTO);
            var result = await db.Users.AddAsync(newUser);
            await db.SaveChangesAsync();

            return new UserDTO(result.Entity);
        }

        public async Task<UserDTO> UpdateUser(int id, UserDTO updateUser)
        {
            List<Manga> favoriteMangas = new List<Manga>();
            foreach (int mangaId in updateUser.FavoritesMangaIds)
            {
                Manga favoriteManga = await db.Mangas.FirstOrDefaultAsync(manga => manga.Id == mangaId);
                if (favoriteManga != null)
                {
                    favoriteMangas.Add(favoriteManga);
                }
            }


            List<Anime> favoriteAnimes = new List<Anime>();
            foreach (int animeId in updateUser.FavoritesAnimeIds)
            {
                Anime favoriteAnime = await db.Animes.FirstOrDefaultAsync(anime => anime.Id == animeId);
                if (favoriteAnime != null)
                {
                    favoriteAnimes.Add(favoriteAnime);
                }
            }

            User user = db.Users.SingleOrDefault(user => user.Id == id);

            if (user != null)
            {
                user.Login = updateUser.Login;
                user.Password = updateUser.Password;
                user.IsAdmin = updateUser.IsAdmin;
                user.FavoritesAnimes = favoriteAnimes;
                user.FavoritesMangas = favoriteMangas;

                await db.SaveChangesAsync();
            }

            return new UserDTO(user);

        }

        public async Task<UserDTO> DeleteUser(int id)
        {
            User user = await db.Users.FirstOrDefaultAsync(user => user.Id == id);
            var deletedUser = db.Users.Remove(user);

            await db.SaveChangesAsync();

            return new UserDTO(deletedUser.Entity);
        }

        public async Task<UserDTO> Login(LoginUserDTO loginUserDTO)
        {
            User user = await db.Users.FirstOrDefaultAsync(user => user.Login == loginUserDTO.Login &&
                user.Password == loginUserDTO.Password);

            return new UserDTO(user);
        }
    }
}

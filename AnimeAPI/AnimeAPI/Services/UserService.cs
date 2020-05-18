using AnimeAPI.Models;
using AnimeAPI.Models.DTO;
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

        public async Task<List<User>> GetAllUsers()
        {
            await db.Users.LoadAsync();
            return await db.Users.ToListAsync();
        }

        public async Task<User> GetUser(int id)
        {
            await db.Users.LoadAsync();
            return await db.Users.FirstOrDefaultAsync(user => user.Id == id);
        }

        public async Task<User> AddUser(UserDTO newUserDTO)
        {
            User newUser = new User(newUserDTO);
            var result = await db.Users.AddAsync(newUser);
            await db.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<User> UpdateUser(int id, UserDTO updateUser)
        {
            List<Manga> favoriteMangas = new List<Manga>();
            foreach (int mangaId in updateUser.FavoritesMangaIds)
            {
                favoriteMangas.Add(await db.Mangas.FirstOrDefaultAsync(manga => manga.Id == mangaId));
            }


            List<Anime> favoriteAnimes = new List<Anime>();
            foreach (int animeId in updateUser.FavoritesAnimeIds)
            {
                favoriteAnimes.Add(await db.Animes.FirstOrDefaultAsync(anime => anime.Id == animeId));
            }

            User user = db.Users.SingleOrDefault(user => user.Id == id);

            if (user != null)
            {
                user.Login = updateUser.Login;
                user.Password = updateUser.Password;
                user.FavoritesAnimes = favoriteAnimes;
                user.FavoritesMangas = favoriteMangas;

                await db.SaveChangesAsync();
            }

            return user;

        }

        public async Task<User> DeleteUser(int id)
        {
            User user = await db.Users.FirstOrDefaultAsync(user => user.Id == id);
            var deletedUser = db.Users.Remove(user);

            await db.SaveChangesAsync();

            return deletedUser.Entity;
        }
    }
}

using AnimeAPI.Models;
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
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await db.Users.ToListAsync();
        }

        public async Task<User> GetUser(int id)
        {
            return await db.Users.FirstOrDefaultAsync(user => user.Id == id);
        }

        public async Task<User> AddUser(User newUserDTO)
        {
            User newUser = new User(newUserDTO);
            var result = await db.Users.AddAsync(newUser);
            await db.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<User> UpdateUser(int id, User updateUser)
        {
            User user = db.Users.SingleOrDefault(user => user.Id == id);

            if (user != null)
            {
                user.Login = updateUser.Login;
                user.Password = updateUser.Password;
                user.FavoritesAnime = updateUser.FavoritesAnime;
                user.FavoritesManga = updateUser.FavoritesManga;

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

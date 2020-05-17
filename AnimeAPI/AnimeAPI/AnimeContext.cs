using AnimeAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimeAPI
{
    public class AnimeContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Anime> Animes { get; set; }
        public DbSet<Manga> Mangas { get; set; }

        public AnimeContext(DbContextOptions<AnimeContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}

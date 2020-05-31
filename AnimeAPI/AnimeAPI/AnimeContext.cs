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
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Studio> Studios { get; set; }
        public DbSet<MangaPages> MangaPages { get; set; }
        public DbSet<Page> Pages { get; set; }

        public AnimeContext(DbContextOptions<AnimeContext> options)
            : base(options)
        {
            /*Database.EnsureDeleted();*/
            Database.EnsureCreated();
        }
    }
}

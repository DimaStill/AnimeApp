using AnimeAPI.Models.DTO;
using AnimeAPI.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimeAPI.Models
{
    public class Genre: GenreDTO
    {
        public Genre(): base()
        { }
        public Genre(GenreDTO genreDTO)
        {
            Name = genreDTO.Name;
        }

        public int Id { get; set; }
    }
}

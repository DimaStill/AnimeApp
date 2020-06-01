using AnimeAPI.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimeAPI.Models.DTO
{
    public class GenreDTO: IGenre
    {
        public GenreDTO() 
        { }
    
        public GenreDTO(Genre genre)
        {
            Id = genre.Id;
            Name = genre.Name;
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public static List<GenreDTO> GetGenreDTOsFromGenre(List<Genre> genres)
        {
            List<GenreDTO> genreDTOs = new List<GenreDTO>();
            foreach (Genre genre in genres)
            {
                genreDTOs.Add(new GenreDTO(genre));
            }

            return genreDTOs;
        }
    }
}

using AnimeAPI.Models.DTO;
using AnimeAPI.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimeAPI.Models
{
    public class Anime: AnimeDTO
    {
        public Anime() : base()
        { }

        public Anime(AnimeDTO animeDTO)
        {
            Name = animeDTO.Name;
            ReleaseDate = animeDTO.ReleaseDate;
            Studio = animeDTO.Studio;
            Type = animeDTO.Type;
            CountEpisodes = animeDTO.CountEpisodes;
            Status = animeDTO.Status;
            Genres = animeDTO.Genres;
            Source = animeDTO.Source;
            Season = animeDTO.Season;
            Voices = animeDTO.Voices;
        }

        public int Id { get; set; }
    }
}

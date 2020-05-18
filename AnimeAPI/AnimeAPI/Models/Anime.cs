using AnimeAPI.Models.DTO;
using AnimeAPI.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimeAPI.Models
{
    public class Anime
    {
        public Anime() : base()
        { }

        public Anime(AnimeDTO animeDTO, List<Genre> selectedGenres, List<Studio> selectedStudio)
        {
            Name = animeDTO.Name;
            ReleaseDate = animeDTO.ReleaseDate;
            Studio = animeDTO.Studio;
            Type = animeDTO.Type;
            CountEpisodes = animeDTO.CountEpisodes;
            Status = animeDTO.Status;
            Genres = selectedGenres;
            Source = animeDTO.Source;
            Season = animeDTO.Season;
            Voices = selectedStudio;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Studio { get; set; }
        public string Type { get; set; }
        public int CountEpisodes { get; set; }
        public string Status { get; set; }
        public ICollection<Genre> Genres { get; set; } = new List<Genre>();
        public string Source { get; set; }
        public int Season { get; set; }
        public ICollection<Studio> Voices { get; set; } = new List<Studio>();
    }
}

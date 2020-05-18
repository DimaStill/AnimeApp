using AnimeAPI.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimeAPI.Models.DTO
{
    public class AnimeDTO: IAnime
    {
        public AnimeDTO()
        { }

        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Studio { get; set; }
        public string Type { get; set; }
        public int CountEpisodes { get; set; }
        public string Status { get; set; }
        public ICollection<int> GenreIds { get; set; } = new List<int>();
        public string Source { get; set; }
        public int Season { get; set; }
        public ICollection<int> VoiceIds { get; set; } = new List<int>();
    }
}

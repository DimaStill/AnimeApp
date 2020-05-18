using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimeAPI.Models.Interfaces
{
    public interface IAnime
    {
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Studio { get; set; }
        public string Type { get; set; }
        public int CountEpisodes { get; set; }
        public string Status { get; set; }
        public ICollection<int> GenreIds { get; set; }
        public string Source { get; set; }
        public int Season { get; set; }
        public ICollection<int> VoiceIds { get; set; }
    }
}

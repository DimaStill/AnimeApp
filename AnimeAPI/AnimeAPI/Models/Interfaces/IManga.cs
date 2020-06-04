using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimeAPI.Models.Interfaces
{
    public interface IManga
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int Volume { get; set; }
        public bool ReleaseContinues { get; set; }
        public ICollection<int> TranslaterIds { get; set; }
        public ICollection<int> GenreIds { get; set; }
        public string Author { get; set; }
        public string PhotoBase64 { get; set; }
    }
}

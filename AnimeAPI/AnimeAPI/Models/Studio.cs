using AnimeAPI.Models.DTO;
using AnimeAPI.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimeAPI.Models
{
    public class Studio: StudioDTO
    {
        public Studio() : base()
        { }
        public Studio(StudioDTO studioDTO)
        {
            Name = studioDTO.Name;
            Link = studioDTO.Link;
        }
        public int Id { get; set; }
    }
}

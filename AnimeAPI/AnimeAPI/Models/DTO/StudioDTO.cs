using AnimeAPI.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimeAPI.Models.DTO
{
    public class StudioDTO: IStudio
    {
        public string Name { get; set; }
        public string Link { get; set; }
    }
}

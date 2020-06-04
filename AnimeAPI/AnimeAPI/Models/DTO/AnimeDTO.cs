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

        public AnimeDTO(Anime anime)
        {
            Id = anime.Id;
            Name = anime.Name;
            ReleaseDate = anime.ReleaseDate;
            Studio = anime.Studio;
            Type = anime.Type;
            CountEpisodes = anime.CountEpisodes;
            Status = anime.Status;
            Source = anime.Source;
            Season = anime.Season;
            PhotoBase64 = anime.PhotoBase64;

            foreach (Genre genre in anime.Genres)
            {
                GenreIds.Add(genre.Id);
            }

            foreach (Studio voice in anime.Voices)
            {
                VoiceIds.Add(voice.Id);
            }
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string ReleaseDate { get; set; }
        public string Studio { get; set; }
        public string Type { get; set; }
        public int CountEpisodes { get; set; }
        public string Status { get; set; }
        public ICollection<int> GenreIds { get; set; } = new List<int>();
        public string Source { get; set; }
        public int Season { get; set; }
        public ICollection<int> VoiceIds { get; set; } = new List<int>();
        public string PhotoBase64 { get; set; }

        public static List<AnimeDTO> getListAnimeDTOsFromAnime(List<Anime> animes)
        {
            List<AnimeDTO> animeDTOs = new List<AnimeDTO>();
            foreach (var anime in animes)
            {
                animeDTOs.Add(new AnimeDTO(anime));
            }

            return animeDTOs;
        }
    }
}

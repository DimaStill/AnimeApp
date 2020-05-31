using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimeAPI.Models.DTO
{
    public class MangaPagesDTO
    {
        public int Id { get; set; }
        public int MangaId { get; set; }
        public List<int> PagesId { get; set; } = new List<int>();

        public MangaPagesDTO() { }

        public MangaPagesDTO(MangaPages mangaPages)
        {
            Id = mangaPages.Id;
            MangaId = mangaPages.Manga.Id;
            foreach(Page page in mangaPages.Pages)
            {
                PagesId.Add(page.Id);
            }
        }

        public static List<MangaPagesDTO> GetMangaPagesDTOFromMangaPages(List<MangaPages> mangaPages)
        {
            List<MangaPagesDTO> mangaPagesDTOs = new List<MangaPagesDTO>();
            foreach(MangaPages mangaPage in mangaPages)
            {
                mangaPagesDTOs.Add(new MangaPagesDTO(mangaPage));
            }

            return mangaPagesDTOs;
        }
    }
}

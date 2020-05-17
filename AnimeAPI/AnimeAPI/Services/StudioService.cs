using AnimeAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimeAPI.Services
{
    public class StudioService
    {

        private AnimeContext db;
        public StudioService(AnimeContext animeContext)
        {
            db = animeContext;
        }

        public async Task<List<Studio>> GetAllStudios()
        {
            return await db.Studios.ToListAsync();
        }

        public async Task<Studio> GetStudio(int id)
        {
            return await db.Studios.FirstOrDefaultAsync(studio => studio.Id == id);
        }

        public async Task<Studio> AddStudio(Studio newStudioDTO)
        {
            Studio newStudio = new Studio(newStudioDTO);
            var result = await db.Studios.AddAsync(newStudio);
            await db.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<Studio> UpdateStudio(int id, Studio updateStudio)
        {
            Studio studio = db.Studios.SingleOrDefault(studio => studio.Id == id);

            if (studio != null)
            {
                studio.Name = updateStudio.Name;
                studio.Link = updateStudio.Link;

                await db.SaveChangesAsync();
            }

            return studio;

        }

        public async Task<Studio> DeleteStudio(int id)
        {
            Studio studio = await db.Studios.FirstOrDefaultAsync(studio => studio.Id == id);
            var deletedStudio = db.Studios.Remove(studio);

            await db.SaveChangesAsync();

            return deletedStudio.Entity;
        }
    }
}

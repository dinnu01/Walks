using Microsoft.EntityFrameworkCore;
using Walks.API.Data;
using Walks.API.Models.Domains;

namespace Walks.API.Repositories
{
    public class RegionRepository : IRegionRepository
    {
        private readonly WalksDbContext _walksDbContext;
        public RegionRepository(WalksDbContext walksDbContext)
        {
            _walksDbContext = walksDbContext;
        }

        public async Task<Region> AddAsync(Region region)
        {
           await _walksDbContext.Regions.AddAsync(region);
           await _walksDbContext.SaveChangesAsync();
           return region;
        }

        public async Task<Region> DeleteAsync(Guid id)
        {
           Region region = await _walksDbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if (region==null) { return null; }
             _walksDbContext.Regions.Remove(region);
             await _walksDbContext.SaveChangesAsync();
            return region;
        }

        public async Task<IEnumerable<Region>> GetAllAsync()
        {
            return await _walksDbContext.Regions.ToListAsync();
        }

        public async Task<Region> GetAsync(Guid id)
        {
            return await _walksDbContext.Regions.FirstOrDefaultAsync(x=>x.Id==id);
        }

        public async Task<Region> UpdateAsync(Guid id, Region region)
        {
            Region existingResion =await _walksDbContext.Regions.FirstOrDefaultAsync(x=> x.Id==id);
            if (existingResion == null) { return null; }
            existingResion.Area = region.Area;
            existingResion.Name = region.Name;
            existingResion.Code = region.Code;
            existingResion.Population = region.Population;
            existingResion.Lat = region.Lat;
            existingResion.Long = region.Long;
            await _walksDbContext.SaveChangesAsync();
            return existingResion;
        }
    }
}

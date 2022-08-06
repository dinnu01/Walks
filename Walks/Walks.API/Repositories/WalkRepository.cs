
using Microsoft.EntityFrameworkCore;
using Walks.API.Data;
using Walks.API.Models.Domains;

namespace Walks.API.Repositories
{
    public class WalkRepository : IWalkRepository
    {
        private readonly WalksDbContext _walksDbContext;
        
        public WalkRepository(WalksDbContext walksDbContext)
        {
            _walksDbContext = walksDbContext;
           
        }

        public async Task<Walk> AddAsync(Walk walk)
        {
            await _walksDbContext.AddAsync(walk);
            await _walksDbContext.SaveChangesAsync();
            return walk;
        }

        public async Task<Walk> DelteAsync(Guid id)
        {
            Walk walk = await _walksDbContext.Walks.FirstOrDefaultAsync(x => x.Id == id);
            if (walk == null)
            { return null; }
            _walksDbContext.Walks.Remove(walk);
            await _walksDbContext.SaveChangesAsync();
            return walk;
        }

        public async Task<IEnumerable<Walk>> GetAllAsync()
        {
            return await _walksDbContext.Walks.Include(x=>x.Region).Include(x=>x.WalkDifficulty).ToListAsync();
        }

        public async Task<Walk> GetAsync(Guid id)
        {
            return await _walksDbContext.Walks.Include(x=>x.Region).Include(x=>x.WalkDifficulty).FirstOrDefaultAsync(x => x.Id == id);
           
        }

        public async Task<Walk> UpdateAsync(Guid id, Walk walk)
        {
            Walk existing =await _walksDbContext.Walks.FirstOrDefaultAsync();
            if (existing == null) { return null; }
            existing.Length = walk.Length;
            existing.Name = walk.Name;
            await _walksDbContext.SaveChangesAsync();
            return existing;

        }
    }
}

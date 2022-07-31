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
        public async Task<IEnumerable<Region>> GetAllAsync()
        {
            return await _walksDbContext.Regions.ToListAsync();
        }
    }
}

using Walks.API.Models.Domains;

namespace Walks.API.Repositories
{
    public interface IRegionRepository
    {
       Task<IEnumerable<Region>> GetAllAsync();
        Task<Region> GetAsync(Guid Id);
        Task<Region> AddAsync(Region region);
        Task<Region> DeleteAsync(Guid id);
        Task<Region> UpdateAsync(Guid id, Region region);
    }
}

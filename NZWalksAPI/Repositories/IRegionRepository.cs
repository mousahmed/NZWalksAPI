using NZWalksAPI.Models.Domain;

namespace NZWalksAPI.Repositories
{
    public interface IRegionRepository
    {
        Task<List<Region>> GetAllAsync();
        Task<Region?> GetByIdAsync(Guid regionId);
        Task<Region> CreateAsync(Region region);
        Task<Region?> UpdateAsync(Guid id, Region region);
        Task<Boolean> RemoveAsync(Guid id);
    }
}

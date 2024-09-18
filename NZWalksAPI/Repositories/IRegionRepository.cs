using NZWalksAPI.Models.Domain;

namespace NZWalksAPI.Repositories
{
    public interface IRegionRepository
    {
        Task<List<Region>> GetAllAsync();
        Task<Region> Get(Guid regionId);
        Task<Region> Create(Region region);
        Task<Region> Update(Region region);
        Task Delete(Region region);
    }
}

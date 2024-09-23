using NZWalksAPI.Models.Domain;

namespace NZWalksAPI.Repositories
{
    public interface IWalkRepository
    {
        Task<List<Walk>> GetAllAsync(string? filterOn = null,
            string? filterQuery = null,
            string? sortBy = null,
            bool? isAscending = false,
            int? pageNumber = 1,
            int? pageSize = 1000);
        Task<Walk?> GetByIdAsync(Guid walkId);
        Task<Walk> CreateAsync(Walk walk);
        Task<Walk?> UpdateAsync(Guid id, Walk walk);
        Task<Boolean> RemoveAsync(Guid id);
    }
}

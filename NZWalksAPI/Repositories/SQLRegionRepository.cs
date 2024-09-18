using Microsoft.EntityFrameworkCore;
using NZWalksAPI.Data;
using NZWalksAPI.Models.Domain;

namespace NZWalksAPI.Repositories
{
    public class SqlRegionRepository : IRegionRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public SqlRegionRepository(ApplicationDbContext context)
        {
            _dbContext = context;
        }
        public async Task<Region> Create(Region region)
        {
            await _dbContext.Regions.AddAsync(region);
            await _dbContext.SaveChangesAsync();
            return region;
        }

        public async Task Delete(Region region)
        {
            _dbContext.Regions.Remove(region);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Region> Get(Guid regionId)
        {
            Region region = await _dbContext.Regions.FirstOrDefaultAsync(u => u.Id == regionId);
            return region;
        }

        public async Task<List<Region>> GetAllAsync()
        {
            List<Region> regions = await _dbContext.Regions.ToListAsync();
            return regions;
        }

        public async Task<Region> Update(Region region)
        {
            await _dbContext.SaveChangesAsync();
            return region;
        }
    }
}

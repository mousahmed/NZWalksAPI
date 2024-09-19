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
        public async Task<Region> CreateAsync(Region region)
        {
            await _dbContext.Regions.AddAsync(region);
            await _dbContext.SaveChangesAsync();
            return region;
        }

        public async Task<Boolean> RemoveAsync(Guid id)
        {
            Region? region = await _dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if (region == null)
            {
                return false;
            }
            _dbContext.Regions.Remove(region);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<Region?> GetByIdAsync(Guid regionId)
        {
            return await _dbContext.Regions.FirstOrDefaultAsync(x => x.Id == regionId);
        }

        public async Task<List<Region>> GetAllAsync()
        {
            List<Region> regions = await _dbContext.Regions.ToListAsync();
            return regions;
        }

        public async Task<Region?> UpdateAsync(Guid id, Region region)
        {
            Region? existingRegion = await _dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if (existingRegion == null)
            {
                return null;
            }
            existingRegion.Name = region.Name;
            existingRegion.Code = region.Code;
            existingRegion.RegionImageUrl = region.RegionImageUrl;
            await _dbContext.SaveChangesAsync();
            return existingRegion;
        }
    }
}

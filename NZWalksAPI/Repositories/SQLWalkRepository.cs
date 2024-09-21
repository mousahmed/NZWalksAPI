using Microsoft.EntityFrameworkCore;
using NZWalksAPI.Data;
using NZWalksAPI.Models.Domain;

namespace NZWalksAPI.Repositories
{
    public class SQLWalkRepository : IWalkRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public SQLWalkRepository(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }

        public async Task<Walk> CreateAsync(Walk walk)
        {
            await _dbContext.Walks.AddAsync(walk);
            await _dbContext.SaveChangesAsync();
            return walk;
        }

        public async Task<Boolean> RemoveAsync(Guid id)
        {
            Walk? walk = await _dbContext.Walks.FirstOrDefaultAsync(x => x.Id == id);
            if (walk == null)
            {
                return false;
            }
            _dbContext.Walks.Remove(walk);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<Walk?> GetByIdAsync(Guid walkId)
        {
            return await _dbContext.Walks
                .Include("Difficulty")
                .Include("Region")
                .FirstOrDefaultAsync(x => x.Id == walkId);
        }

        public async Task<List<Walk>> GetAllAsync()
        {
            List<Walk> walks = await _dbContext.Walks
                .Include("Difficulty")
                .Include("Region")
                .ToListAsync();
            return walks;
        }

        public async Task<Walk?> UpdateAsync(Guid id, Walk walk)
        {
            Walk? existingWalk = await _dbContext.Walks.FirstOrDefaultAsync(x => x.Id == id);
            if (existingWalk == null)
            {
                return null;
            }
            existingWalk.Name = walk.Name;
            existingWalk.Description = walk.Description;
            existingWalk.LenghtInKm = walk.LenghtInKm;
            existingWalk.RegionId = walk.RegionId;
            existingWalk.DifficultyId = walk.DifficultyId;
            existingWalk.WalkImageUrl = walk.WalkImageUrl;
            await _dbContext.SaveChangesAsync();
            return existingWalk;
        }
    }
}

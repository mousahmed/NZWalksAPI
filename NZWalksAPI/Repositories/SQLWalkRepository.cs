using Microsoft.EntityFrameworkCore;
using NZWalksAPI.Data;
using NZWalksAPI.Models.Domain;
using System.Globalization;

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

        public async Task<List<Walk>> GetAllAsync(string? filterOn = null,
            string? filterQuery = null,
            string? sortBy = null,
            bool? isAscending = false,
            int? pageNumber = 1,
            int? pageSize = 1000)
        {
            var allowedFilterColumns = new List<string> { "Name", "Description" };
            var allowdSortColumns = new List<string> { "Name", "LenghtInKm" };
            var walks = _dbContext.Walks
                 .Include("Difficulty")
                 .Include("Region")
                 .AsQueryable();
            if (!string.IsNullOrWhiteSpace(filterOn) &&
                !string.IsNullOrWhiteSpace(filterQuery)
                )
            {
                if (allowedFilterColumns.Contains(filterOn))
                {
                    walks = walks.Where(x => EF.Property<string>(x, filterOn).Contains(filterQuery));
                }


            }
         
            if (!string.IsNullOrWhiteSpace(sortBy) && !string.IsNullOrWhiteSpace(isAscending.ToString()))
            {
                if (allowdSortColumns.Contains(sortBy))
                {
                    if (isAscending == true)
                    {
                        walks = walks.OrderBy(x => EF.Property<string>(x, sortBy));
                    }
                    else
                    {
                        walks = walks.OrderByDescending(x => EF.Property<string>(x, sortBy));
                    }
                }
            }

            if (pageNumber.HasValue && pageSize.HasValue)
            {
                walks = walks.Skip((pageNumber.Value - 1) * pageSize.Value).Take(pageSize.Value);
            }


            return await walks.ToListAsync();
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

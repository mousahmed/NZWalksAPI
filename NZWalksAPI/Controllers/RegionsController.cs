using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalksAPI.Data;
using NZWalksAPI.Models.Domain;
using NZWalksAPI.Models.DTO;

namespace NZWalksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public RegionsController(ApplicationDbContext context)
        {
            _dbContext = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<Region> regions = await _dbContext.Regions.ToListAsync();
            List<RegionDto> regionDtos = new List<RegionDto>();
            foreach (Region region in regions)
            {
                regionDtos.Add(new RegionDto
                {
                    Id = region.Id,
                    Code = region.Code,
                    Name = region.Name,
                    RegionImageUrl = region.RegionImageUrl
                });
            }
            return Ok(regionDtos);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRegion(Guid id)
        {
            Region region = await _dbContext.Regions.FindAsync(id);
            if (region == null)
            {
                return NotFound();
            }
            RegionDto regionDto = new RegionDto
            {
                Id = region.Id,
                Code = region.Code,
                Name = region.Name,
                RegionImageUrl = region.RegionImageUrl
            };
            return Ok(regionDto);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddRegionRequestDto addRegionRequestDto)
        {
            Region region = new Region
            {
                Code = addRegionRequestDto.Code,
                Name = addRegionRequestDto.Name,
                RegionImageUrl = addRegionRequestDto.RegionImageUrl
            };
            await _dbContext.Regions.AddAsync(region);
            await _dbContext.SaveChangesAsync();

            RegionDto regionDto = new RegionDto
            {
                Id = region.Id,
                Code = region.Code,
                Name = region.Name,
                RegionImageUrl = region.RegionImageUrl
            };
            return CreatedAtAction(nameof(GetRegion), new { id = regionDto.Id }, regionDto);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
        {
            Region region = await _dbContext.Regions.FindAsync(id);
            if (region == null)
            {
                return NotFound();
            }
            region.Code = updateRegionRequestDto.Code;
            region.Name = updateRegionRequestDto.Name;
            region.RegionImageUrl = updateRegionRequestDto.RegionImageUrl;
            await _dbContext.SaveChangesAsync();

            RegionDto regionDto = new RegionDto
            {
                Id = region.Id,
                Code = region.Code,
                Name = region.Name,
                RegionImageUrl = region.RegionImageUrl
            };
            return Ok(regionDto);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(Guid id)
        {
            Region region = await _dbContext.Regions.FindAsync(id);
            if (region == null)
            {
                return NotFound();
            }
            _dbContext.Regions.Remove(region);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }
    }

}

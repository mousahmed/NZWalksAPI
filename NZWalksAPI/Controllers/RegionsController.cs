using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult GetAll()
        {
            List<Region> regions = _dbContext.Regions.ToList();
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
        public IActionResult GetRegion(Guid id)
        {
            Region region = _dbContext.Regions.Find(id);
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
        public IActionResult Create([FromBody] AddRegionRequestDto addRegionRequestDto)
        {
            Region region = new Region
            {
                Code = addRegionRequestDto.Code,
                Name = addRegionRequestDto.Name,
                RegionImageUrl = addRegionRequestDto.RegionImageUrl
            };
            _dbContext.Regions.Add(region);
            _dbContext.SaveChanges();

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
        public IActionResult Update(Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
        {
            Region region = _dbContext.Regions.Find(id);
            if (region == null)
            {
                return NotFound();
            }
            region.Code = updateRegionRequestDto.Code;
            region.Name = updateRegionRequestDto.Name;
            region.RegionImageUrl = updateRegionRequestDto.RegionImageUrl;
            _dbContext.SaveChanges();

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
        public IActionResult Remove(Guid id)
        {
            Region region = _dbContext.Regions.Find(id);
            if (region == null)
            {
                return NotFound();
            }
            _dbContext.Regions.Remove(region);
            _dbContext.SaveChanges();
            return Ok();
        }
    }
 
}

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
    }
 
}

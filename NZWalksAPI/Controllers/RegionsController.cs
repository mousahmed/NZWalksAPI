using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalksAPI.CustomActionsFilters;
using NZWalksAPI.Data;
using NZWalksAPI.Models.Domain;
using NZWalksAPI.Models.DTO;
using NZWalksAPI.Repositories;

namespace NZWalksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Reader")]
    public class RegionsController : ControllerBase
    {
        private readonly IRegionRepository _regionRepository;
        private readonly IMapper _mapper;
        public RegionsController(IRegionRepository regionRepository, IMapper mapper)
        {
            _regionRepository = regionRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<Region> regions = await _regionRepository.GetAllAsync();

            List<RegionDto> regionDtos = _mapper.Map<List<RegionDto>>(regions);
           
            return Ok(regionDtos);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRegion(Guid id)
        {
            Region? region = await _regionRepository.GetByIdAsync(id);
            if (region == null)
            {
                return NotFound();
            }
            RegionDto regionDto = _mapper.Map<RegionDto>(region);
            return Ok(regionDto);
        }
        [HttpPost]
        [ValidateModelAttributes]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Create([FromBody] AddRegionRequestDto addRegionRequestDto)
        {
            Region region = _mapper.Map<Region>(addRegionRequestDto);
            await _regionRepository.CreateAsync(region);

            RegionDto regionDto = _mapper.Map<RegionDto>(region);
            return CreatedAtAction(nameof(GetRegion), new { id = regionDto.Id }, regionDto);
        }
        [HttpPut("{id}")]
        [ValidateModelAttributes]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
        {

            Region? region = _mapper.Map<Region>(updateRegionRequestDto);

            region = await _regionRepository.UpdateAsync(id, region);

            if (region == null)
            {
                return NotFound();
            }

            RegionDto regionDto = _mapper.Map<RegionDto>(region);
            return Ok(regionDto);
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Remove(Guid id)
        {
            Boolean isDeleted = await _regionRepository.RemoveAsync(id);
            if (!isDeleted)
            {
                return NotFound();
            }

            return Ok();
        }
    }

}

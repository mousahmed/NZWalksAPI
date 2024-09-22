using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalksAPI.CustomActionsFilters;
using NZWalksAPI.Models.Domain;
using NZWalksAPI.Models.DTO;
using NZWalksAPI.Repositories;

namespace NZWalksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IWalkRepository _walkRepository;
        private readonly IMapper _mapper;

        public WalksController(IWalkRepository walkRepository, IMapper mapper)
        {
            _walkRepository = walkRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<Walk> walks = await _walkRepository.GetAllAsync();

            List<WalkDto> walkDtos = _mapper.Map<List<WalkDto>>(walks);

            return Ok(walkDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetWalk(Guid id)
        {
            Walk? walk = await _walkRepository.GetByIdAsync(id);
            if (walk == null)
            {
                return NotFound();
            }
            WalkDto walkDto = _mapper.Map<WalkDto>(walk);
            return Ok(walkDto);
        }

        [HttpPost]
        [ValidateModelAttributes]
        public async Task<IActionResult> Create([FromBody] AddWalkRequestDto addWalkRequestDto)
        {
            
            Walk walk = _mapper.Map<Walk>(addWalkRequestDto);
            await _walkRepository.CreateAsync(walk);

            WalkDto walkDto = _mapper.Map<WalkDto>(walk);
            return CreatedAtAction(nameof(GetWalk), new { id = walkDto.Id }, walkDto);
        }

        [HttpPut("{id}")]
        [ValidateModelAttributes]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateWalkRequestDto updateWalkRequestDto)
        {
            
            Walk? walk = _mapper.Map<Walk>(updateWalkRequestDto);

            walk = await _walkRepository.UpdateAsync(id, walk);

            if (walk == null)
            {
                return NotFound();
            }

            WalkDto walkDto = _mapper.Map<WalkDto>(walk);
            return Ok(walkDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(Guid id)
        {
            Boolean isDeleted = await _walkRepository.RemoveAsync(id);
            if (!isDeleted)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}

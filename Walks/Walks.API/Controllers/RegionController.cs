using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Walks.API.Models.Domains;
using Walks.API.Models.DTOs;
using Walks.API.Repositories;

namespace Walks.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    
    public class RegionController : Controller
    {
        private readonly IRegionRepository _regionRepository;
        private readonly IMapper _mapper;
        public RegionController(IRegionRepository regionRepository, IMapper mapper)
        {
            _regionRepository = regionRepository;
            _mapper = mapper;
        }
        
        
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllRegionsAsync()
        {
            return Ok(_mapper.Map<List<RegionDto>>(await _regionRepository.GetAllAsync()));
        }

        [HttpGet("{id:guid}")]
        [ActionName("GetRegionAsync")]
        public async Task<IActionResult> GetRegionAsync(Guid id)
        {
            Region region = await _regionRepository.GetAsync(id);
            if (region == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<RegionDto>(region));
        }

        [HttpPost]
        public async Task<IActionResult> AddRegionAsync(AddRegionRequest region) {

            Region addedRegion = await _regionRepository.AddAsync(_mapper.Map<Region>(region));
            RegionDto result = _mapper.Map<RegionDto>(addedRegion);
            return CreatedAtAction(nameof(GetRegionAsync), new { id = result.Id }, result);
        }
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteAsync(Guid id) {
           Region result = await _regionRepository.DeleteAsync(id);
            if (result==null) { return NotFound(); }
            return Ok(_mapper.Map<RegionDto>(result));
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateRegionAsync(Guid id, [FromBody] UpdateRegionRequest updateRegionRequest)
        {
           Region updateRegion= await _regionRepository.UpdateAsync(id, _mapper.Map<Region>(updateRegionRequest));
            if (updateRegion==null) { return NotFound(); }
            RegionDto result = _mapper.Map<RegionDto>(updateRegion);
            return Ok(result);
        }
    }
}

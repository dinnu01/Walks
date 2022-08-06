using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Walks.API.Models.Domains;
using Walks.API.Models.DTOs;
using Walks.API.Repositories;

namespace Walks.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WalkController : Controller
    {
        private readonly IWalkRepository _walkRepository;
        private readonly IMapper _mapper;
        public WalkController(IWalkRepository walkRepository, IMapper mapper)
        {
            _walkRepository = walkRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetallAsync() {
          IEnumerable<Walk> walk = await _walkRepository.GetAllAsync();
           return Ok(_mapper.Map<List<WalksDto>>(walk));
        }
        [ActionName("GetAsync")]
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetAsync(Guid id) {
            Walk walk = await _walkRepository.GetAsync(id);
            return Ok(_mapper.Map<WalksDto>(walk));
        }
        [HttpPost]
        public async Task<IActionResult> AddAsync(AddWalkRequest walk) {
           Walk walkResult= await _walkRepository.AddAsync(_mapper.Map<Walk>(walk));
            return CreatedAtAction("GetAsync", new { id = walkResult.Id }, walkResult);
        }
        [HttpPut("{id:guid}")]
        public  async Task<IActionResult> UpdateAsync(Guid id, [FromBody]UpdateWalkRequest updateWalkRequest) {
           Walk result= await _walkRepository.UpdateAsync(id, _mapper.Map<Walk>(updateWalkRequest));
            return Ok(result);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteAsync(Guid id) {
            Walk result = await _walkRepository.DelteAsync(id);
            return Ok(result);
        }
    }
}

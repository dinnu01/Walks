using AutoMapper;
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
        public RegionController(IRegionRepository regionRepository,IMapper mapper)
        {
            _regionRepository = regionRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllRegions()
        {
            return Ok(_mapper.Map<List<RegionDto>>(await _regionRepository.GetAllAsync()));
        }
    }
}

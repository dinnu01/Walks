using AutoMapper;
using Walks.API.Models.Domains;
using Walks.API.Models.DTOs;

namespace Walks.API.Profiles
{
    public class RegionProfile:Profile
    {
        public RegionProfile()
        {
            CreateMap<Region, RegionDto>().ReverseMap();
        }
    }
}

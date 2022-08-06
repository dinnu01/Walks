using AutoMapper;
using Walks.API.Models.Domains;
using Walks.API.Models.DTOs;

namespace Walks.API.Profiles
{
    public class WalksProfileL:Profile
    {
        public WalksProfileL()
        {
            CreateMap<Walk, WalksDto>().ReverseMap();
            CreateMap<WalkDifficulty, WalkDifficultyDto>().ReverseMap();
            CreateMap<Walk, AddWalkRequest>().ReverseMap();
            CreateMap<Walk, UpdateWalkRequest>().ReverseMap();
        }
    }
}

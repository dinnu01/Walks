namespace Walks.API.Models.DTOs
{
    public class WalksDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Length { get; set; }
        public Guid RegionId { get; set; }
        public Guid WalkDifficultyId { get; set; }

        //navigation properties
        public RegionDto Region { get; set; }
        public WalkDifficultyDto WalkDifficulty { get; set; }

    }
}

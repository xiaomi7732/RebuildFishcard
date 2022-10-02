namespace Fishcard.Models
{
    public class FishItem
    {
        public string Name { get; set; } = default!;
        public Recommendation Recommendation { get; set; }
    }
}
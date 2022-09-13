namespace Fishcard.Contracts;

public class FishItem
{
    public string Name { get; set; } = default!;

    public Recommendation Recommendation { get; set; } = Recommendation.Avoid;
}
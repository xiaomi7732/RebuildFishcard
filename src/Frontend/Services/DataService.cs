using Fishcard.Contracts;

namespace Fishcard.Frontend;

public class DataService
{
    public Task<IEnumerable<FishItem>> GetFishItemsAsync(CancellationToken cancellationToken)
    {
        return Task.FromResult(new List<FishItem>{
            new FishItem{
                Name = "Salmon",
                Recommendation = Recommendation.Best,
            },
            new FishItem{
                Name = "Halibut",
                Recommendation = Recommendation.Good,
            },
        }.AsEnumerable());
    }
}
using Fishcard.Frontend.Services;
using Fishcard.Models;
using Microsoft.AspNetCore.Components;

namespace Fishcard.Frontend.Pages;

public partial class FishcardHome
{
    private FishItem[] _allFish;

    [Inject]
    public FishDataService FishDataService { get; private set; }

    protected override async Task OnInitializedAsync()
    {
        _allFish = (await FishDataService.GetFishItemsAsync(default)).ToArray();
        Console.WriteLine("Get fish item count: " + _allFish.Length);
    }

    public void Search()
    {
        Console.WriteLine("Search for fish: " + Keyword);
        if(string.IsNullOrEmpty(Keyword))
        {
            Result = null;
            return;
        }

        Result = _allFish
            .Where(f => f.Name.Contains(Keyword, StringComparison.OrdinalIgnoreCase))
            .OrderBy(f => f.Name)
            .ToArray();
        Keyword = null;
    }

    public FishItem[]? Result { get; private set; }

    public string? Keyword { get; set; }
}

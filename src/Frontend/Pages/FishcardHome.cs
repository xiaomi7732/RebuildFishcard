using Fishcard.Contracts;

namespace Fishcard.Frontend.Pages;

public partial class FishcardHome
{
    private List<FishItem>? _allFishItemCache;
    protected async override Task OnInitializedAsync()
    {
        _allFishItemCache = (await _dataService.GetFishItemsAsync(default)).OrderBy(fish => fish.Name).ToList();
    }

    private string? _keyword;
    public string? Keyword
    {
        get { return _keyword; }
        set
        {
            if (!string.Equals(_keyword, value, StringComparison.Ordinal))
            {
                _keyword = value;
                Search();
            }
        }
    }

    public FishItem[]? Result { get; set; }

    private void Search()
    {
        if (_allFishItemCache is null)
        {
            Result = null;
            return;
        }
        if (string.IsNullOrEmpty(Keyword))
        {
            Result = null;
            return;
        }

        Result = _allFishItemCache.Where(fish => fish.Name.Contains(Keyword, StringComparison.OrdinalIgnoreCase)).ToArray();
    }

    private void Clear()
    {
        Keyword = null;
    }
}

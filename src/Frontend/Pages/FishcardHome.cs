using Microsoft.AspNetCore.Components;

namespace Fishcard.Frontend.Pages;

public partial class FishcardHome
{
    protected override Task OnInitializedAsync()
    {
        return base.OnInitializedAsync();
    }

    [Parameter]
    public string? FishName { get; set; }

    [Parameter]
    [SupplyParameterFromQuery(Name = "w")]
    public double? Weight { get; set; }
}
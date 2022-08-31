using Microsoft.AspNetCore.Components;

namespace Fishcard.Frontend.Pages;

public partial class Counter
{
    [Parameter]
    public int? InitialCount { get; set; } = 100;

    private int currentCount = 0;

    private void IncrementCount()
    {
        currentCount++;
        currentCount++;
        Console.WriteLine($"Current count: {currentCount}");
    }
}
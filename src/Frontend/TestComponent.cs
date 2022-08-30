using Microsoft.AspNetCore.Components;

namespace Fishcard.Frontend;

public class TestComponent : IComponent
{
    RenderHandle _renderHandle = default!;
    public void Attach(RenderHandle renderHandle)
    {
        _renderHandle = renderHandle;
    }

    public Task SetParametersAsync(ParameterView parameters)
    {
        RenderFragment fragment = (treeBuilder) =>{
            treeBuilder.AddContent(1, "Hello Component!");
        };
        _renderHandle.Render(fragment);

        return Task.CompletedTask;
    }
}
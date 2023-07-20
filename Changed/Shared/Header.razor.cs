using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Changed.Shared
{
    public partial class Header
    {
        [Inject]
        public IJSRuntime? JSRuntime { get; set; }

        private IJSObjectReference _jsModule;
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                _jsModule = await JSRuntime.InvokeAsync<IJSObjectReference>("import", "./assets/js/main.js");

            }
        }
        public async Task ToggleMenu() =>
            await _jsModule.InvokeVoidAsync("Changed");


    }
}

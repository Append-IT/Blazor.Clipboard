using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace Append.Blazor.Clipboard
{
    internal class ClipboardService : IAsyncDisposable, IClipboardService
    {
        private readonly Lazy<Task<IJSObjectReference>> _moduleTask;

        public ClipboardService(IJSRuntime jsRuntime)
        {
            _moduleTask = new(() => jsRuntime.InvokeAsync<IJSObjectReference>("import", "./_content/Append.Blazor.Clipboard/scripts.js").AsTask());
        }

        /// <inheritdoc/>
        public async ValueTask CopyTextToClipboardAsync(string text)
        {
            var module = await _moduleTask.Value;
            await module.InvokeVoidAsync("copyText", text);
        }

        public async ValueTask DisposeAsync()
        {
            if (_moduleTask.IsValueCreated)
            {
                var module = await _moduleTask.Value;
                await module.DisposeAsync();
            }
        }
    }
}

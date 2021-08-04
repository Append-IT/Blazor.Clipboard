using Microsoft.Extensions.DependencyInjection;

namespace Append.Blazor.Clipboard
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddClipboard(this IServiceCollection services)
        {
            return services.AddScoped<IClipboardService, ClipboardService>();
        }
    }
}

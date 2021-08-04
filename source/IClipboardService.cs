using System.Threading.Tasks;

namespace Append.Blazor.Clipboard
{
    public interface IClipboardService
    {
        /// <summary>
        /// Copies the given text to the clipboard if it's supported.
        /// </summary>
        /// <param name="text">The text to be copied to the clipboard.</param>
        /// <returns></returns>
        ValueTask CopyTextToClipboardAsync(string text);
    }
}
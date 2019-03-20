using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace Blazor.Extensions.Storage.Test.Interop
{
    /// <summary>
    /// Interop calls to JavaScript Local and Session storage via Blazor's <see cref="JSRuntime"/>.
    /// </summary>
    public class InteropStorage
    {
        private IJSRuntime jsRuntime;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="js">Reference to the js runtime.</param>
        public InteropStorage(IJSRuntime js)
        {
            this.jsRuntime = js;
        }

        /// <summary>
        /// Returns a session storage value.
        /// </summary>
        /// <param name="key">Key associated with stroed value.</param>
        /// <returns>Task that returns the stored value as a string.</returns>
        public async Task<string> GetSessionStorage(string key)
        {
            return await this.jsRuntime.InvokeAsync<string>(
                "getSessionStorage",
                key
            );
        }

        /// <summary>
        /// Returns a local storage value.
        /// </summary>
        /// <param name="key">Key associated with stroed value.</param>
        /// <returns>Task that returns the stored value as a string.</returns>
        public async Task<string> GetLocalStorage(string key)
        {
            return await this.jsRuntime.InvokeAsync<string>(
                "getLocalStorage",
                key
            );
        }
    }
}

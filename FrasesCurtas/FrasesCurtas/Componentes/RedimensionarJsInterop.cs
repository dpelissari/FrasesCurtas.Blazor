using FrasesCurtas.Models.Interop;
using Microsoft.JSInterop;

namespace FrasesCurtas.Componentes {
    public class RedimensionarJsInterop : IAsyncDisposable {
        private readonly Lazy<Task<IJSObjectReference>> moduleTask;

        public event EventHandler<Dimensao>? AoRedimensionar;

        public RedimensionarJsInterop(IJSRuntime jsRuntime) {
            moduleTask = new(() => jsRuntime.InvokeAsync<IJSObjectReference>(
                "import", "./js/redimensionar.js").AsTask());
        }

        public async ValueTask<Dimensao> Escutar() {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<Dimensao>(nameof(Escutar), DotNetObjectReference.Create(this));
        }

        [JSInvokable]
        public void SetBrowserDimensions(Dimensao dimensao) =>
            AoRedimensionar?.Invoke(this, dimensao);

        public async ValueTask DisposeAsync() {
            if (moduleTask.IsValueCreated)
            {
                var module = await moduleTask.Value;
                await module.DisposeAsync();
            }
        }
    }
}

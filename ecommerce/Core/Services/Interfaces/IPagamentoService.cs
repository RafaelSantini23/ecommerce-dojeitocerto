namespace ecommerce.Core.Services.Interfaces
{
    public interface IPagamentoService
    {
        Task<bool> ProcessarPagamento(int pedidoId, bool pagamentoComPix, bool pagamentoParcelado);
        Task<decimal> CancelarPagamento(int pedidoId);
    }
}

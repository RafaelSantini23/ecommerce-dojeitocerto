using ecommerce.Application.DTO;
using ecommerce.Core.Domain.Model.Pedido;

namespace ecommerce.Core.Services.Interfaces
{
    public interface IPedidoService
    {
        Task<Pedido> ObterPedido();
        Task<bool> CriarPedido(PedidoDto pedidoDto);
        Task<bool> CancelarPedido(int pedidoId);
    }
}

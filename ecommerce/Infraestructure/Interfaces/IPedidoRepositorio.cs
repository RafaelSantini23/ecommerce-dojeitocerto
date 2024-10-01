using ecommerce.Core.Domain.Enums;
using ecommerce.Core.Domain.Model.Pedido;

namespace ecommerce.Core.Services.Interfaces
{
    public interface IPedidoRepositorio
    {
        Task<Pedido> ObterPedidos();
        Task<Pedido> ObterPedidoPorId(int id);
        Task<IEnumerable<Item>> ObterItens(int id);
        Task<int> CriarPedido(Pedido pedido);
        Task<bool> CriarItem(int pedidoId, Item item);
        Task<bool> AtualizarStatusPedido(int id, EnumStatus status);
    }
}
